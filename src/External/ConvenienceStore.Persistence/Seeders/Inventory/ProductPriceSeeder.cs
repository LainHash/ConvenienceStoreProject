using AutoMapper;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Domain.Entities.Inventory;
using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.DataRecords.Inventory;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Seeders.Inventory
{
    internal class ProductPriceSeeder(
        IDataImporter importer,
        IMapper mapper) : IDataSeeder
    {
        private readonly IDataImporter _importer = importer;
        private readonly IMapper _mapper = mapper;

        public async Task SeedAsync(ConvenienceStoreDbContext context)
        {
            if (await context.ProductPrices.AnyAsync())
                return;

            var records =
                _importer.Read<ProductPriceRecord>("ProductPrices");

            var entities =
                _mapper.Map<List<ProductPrice>>(records);

            context.ProductPrices.AddRange(entities);

            await context.SaveChangesAsync();
        }
    }
}
