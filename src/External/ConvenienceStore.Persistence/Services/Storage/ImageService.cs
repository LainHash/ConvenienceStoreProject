using AutoMapper;
using ConvenienceStore.Application.Features.Storage.Images.Commands.Upload;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Storage;
using ConvenienceStore.Contract.DTOs.Storage.Images;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Domain.Repositories.Catalog;
using ConvenienceStore.Domain.Repositories.Storage;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Storage
{
    internal class ImageService : IImageService
    {
        private const int MaxImagesPerProduct = 5;

        private readonly IImageRepository _imageRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ImageService> _logger;

        public ImageService(
            IImageRepository imageRepository,
            IProductRepository productRepository,
            IProductImageRepository productImageRepository,
            ICloudinaryService cloudinaryService,
            IUnitOfWork unitOfWork,
            ILogger<ImageService> logger,
            IMapper mapper)
        {
            _imageRepository = imageRepository;
            _productRepository = productRepository;
            _cloudinaryService = cloudinaryService;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<Result<UploadImageResponse>> UploadProductImageAsync(
            UploadProductImageSpecification specification,
            CancellationToken cancellationToken)
        {
            // 1. Kiểm tra product tồn tại
            var product = await _productRepository.FindAsync(specification.ProductId, cancellationToken);
            if (product is null)
            {
                return Result<UploadImageResponse>
                    .Fail(Error<Product>.NotFound, HttpStatusCode.NotFound);
            }

            // 2. Kiểm tra giới hạn số ảnh
            var currentCount = await _productImageRepository.CountByProductIdAsync(product.Id, cancellationToken);
            if (currentCount >= MaxImagesPerProduct)
            {
                return Result<UploadImageResponse>
                    .Fail($"Product đã đạt giới hạn tối đa {MaxImagesPerProduct} ảnh.", HttpStatusCode.UnprocessableEntity);
            }

            await using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // 3. Upload lên Cloudinary
                var uploadResult = await _cloudinaryService.UploadAsync(
                    specification.FileStream,
                    specification.FileName,
                    folder: "products",
                    cancellationToken);

                if (!uploadResult.IsSuccess)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return Result<UploadImageResponse>
                        .Fail(uploadResult.ErrorMessage ?? "Upload ảnh thất bại.", HttpStatusCode.BadGateway);
                }

                // 4. Nếu ảnh mới là primary → unset ảnh primary cũ
                if (specification.Metadata.IsPrimary)
                {
                    await _productImageRepository.UnsetPrimaryAsync(product.Id, cancellationToken);
                }

                // 5. Tạo Image entity và lưu để lấy Id từ EF
                var image = Image.Create(
                    altText: specification.Metadata.AltText ?? specification.FileName,
                    url: uploadResult.Url,
                    storagePath: uploadResult.StoragePath,
                    fileSize: uploadResult.FileSize,
                    contentType: uploadResult.ContentType);

                _imageRepository.Add(image);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                // 6. Tạo ProductImage join entity
                var productImage = ProductImage.Create(
                    productId: product.Id,
                    imageId: image.Id,
                    isPrimary: specification.Metadata.IsPrimary,
                    displayOrder: currentCount + 1);

                _productImageRepository.Add(productImage);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                // 7. Commit transaction
                await transaction.CommitAsync(cancellationToken);

                // 8. Trả về response
                return Result<UploadImageResponse>.Succeed(new UploadImageResponse
                {
                    ImageId = image.PublicId,
                    Url = image.Url,
                    PublicId = uploadResult.PublicId,
                    AltText = image.AltText,
                    IsPrimary = productImage.IsPrimary,
                    DisplayOrder = productImage.DisplayOrder,
                    FileSize = image.FileSize,
                    ContentType = image.ContentType
                }, "Upload ảnh thành công.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                _logger.LogError(ex, "Lỗi khi upload ảnh cho product {ProductId}.", specification.ProductId);
                return Result<UploadImageResponse>
                    .Fail("Lỗi khi upload ảnh.", HttpStatusCode.InternalServerError);
            }
        }
    }
}
