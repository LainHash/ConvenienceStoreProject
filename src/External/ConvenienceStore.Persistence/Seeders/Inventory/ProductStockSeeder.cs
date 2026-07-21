using AutoMapper;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Domain.Entities.Inventory;
using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.DataRecords.Inventory;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Seeders.Inventory
{
    internal class ProductStockSeeder(
        IDataImporter importer,
        IMapper mapper) : IDataSeeder
    {
        private readonly IDataImporter _importer = importer;
        private readonly IMapper _mapper = mapper;

        public async Task SeedAsync(ConvenienceStoreDbContext context)
        {
            if (await context.ProductStocks.AnyAsync())
                return;

            var records =
                _importer.Read<ProductStockRecord>("ProductStocks");

            var entities =
                _mapper.Map<List<ProductStock>>(records);

            context.ProductStocks.AddRange(entities);

            await context.SaveChangesAsync();
        }
    }
}
