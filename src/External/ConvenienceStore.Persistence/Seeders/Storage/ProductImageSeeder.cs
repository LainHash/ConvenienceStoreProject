using AutoMapper;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.DataRecords.Storage;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Seeders.Storage
{
    internal class ProductImageSeeder : IDataSeeder
    {
        private readonly IDataImporter _importer;
        private readonly IMapper _mapper;

        public ProductImageSeeder(
            IDataImporter importer,
            IMapper mapper)
        {
            _importer = importer;
            _mapper = mapper;
        }

        public async Task SeedAsync(ConvenienceStoreDbContext context)
        {
            if (await context.ProductImages.AnyAsync())
                return;

            var records =
                _importer.Read<ProductImageRecord>("ProductImages");

            var entities =
                _mapper.Map<List<ProductImage>>(records);

            context.ProductImages.AddRange(entities);

            await context.SaveChangesAsync();
        }
    }
}
