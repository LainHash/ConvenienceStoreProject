using AutoMapper;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.DataRecords.Catalog;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Seeders.Catalog
{
    internal class ProductSeeder(
        IDataImporter importer,
        IMapper mapper) : IDataSeeder
    {
        private readonly IDataImporter _importer = importer;
        private readonly IMapper _mapper = mapper;

        public async Task SeedAsync(ConvenienceStoreDbContext context)
        {
            if (await context.Products.AnyAsync())
                return;

            var records =
                _importer.Read<ProductRecord>("Products");

            var entities =
                _mapper.Map<List<Product>>(records);

            context.Products.AddRange(entities);

            await context.SaveChangesAsync();
        }
    }
}
