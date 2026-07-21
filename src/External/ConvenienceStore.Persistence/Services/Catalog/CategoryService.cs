using AutoMapper;
using ConvenienceStore.Application.Features.Catalog.Categories.Commands.Update;
using ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetById;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog.Categories;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Repositories.Catalog;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Catalog
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<CategoryResponse>>> GetAllAsync(
            GetAllCategoriesSpecification specification,
            CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.ToListAsync(specification, cancellationToken);
            if (!categories.Any())
            {
                return Result<IEnumerable<CategoryResponse>>
                    .Fail(Error<Category>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return Result<IEnumerable<CategoryResponse>>
                .Succeed(response, Success<Category>.Retrieved);
        }

        public async Task<Result<CategoryResponse>> GetByIdAsync(GetCategoryByIdSpecification specification, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(specification, cancellationToken);
            if (category is null)
            {
                return Result<CategoryResponse>
                    .Fail(Error<Category>.NotFound, HttpStatusCode.InternalServerError);
            }

            var response = _mapper.Map<CategoryResponse>(category);
            return Result<CategoryResponse>
                .Succeed(response, Success<Category>.Retrieved);
        }

        public async Task<Result<CategoryResponse>> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryRepository.FindNameAsync(request.Name, cancellationToken);
            if(existingCategory is not null)
            {
                return Result<CategoryResponse>
                    .Fail(Error<Category>.ExistedName, HttpStatusCode.Conflict);
            }

            var category = new Category();
            _mapper.Map(request, category);
            _categoryRepository.Add(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<CategoryResponse>(category);
            return Result<CategoryResponse>
                .Succeed(response, Success<Category>.Created, HttpStatusCode.Created);
        }

        public async Task<Result<CategoryResponse>> UpdateAsync(UpdateCategorySpecification specification, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(specification, cancellationToken);
            if (category is null)
            {
                return Result<CategoryResponse>
                    .Fail(Error<Category>.NotFound, HttpStatusCode.InternalServerError);
            }

            _mapper.Map(specification.Body, category);
            _categoryRepository.Update(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<CategoryResponse>(category);
            return Result<CategoryResponse>
                .Succeed(response, Success<Category>.Updated, HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(id, cancellationToken);
            if (category is null)
            {
                return Result<object>
                    .Fail(Error<Category>.NotFound, HttpStatusCode.InternalServerError);
            }

            if (category.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Category>.AlreadyDeleted, HttpStatusCode.Conflict);
            }

            category.SoftDelete();
            _categoryRepository.Update(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Category>.Deleted, HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> RestoreAsync(string id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(id, cancellationToken);
            if (category is null)
            {
                return Result<object>
                    .Fail(Error<Category>.NotFound, HttpStatusCode.InternalServerError);
            }

            if (!category.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Category>.NotYetDeleted, HttpStatusCode.Conflict);
            }

            category.Restore();
            _categoryRepository.Update(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Category>.Deleted, HttpStatusCode.Accepted);
        }
    }
}
