using AutoMapper;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.DataRecords.Catalog;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Seeders.Catalog
{
    internal class BrandSeeder : IDataSeeder
    {
        private readonly IDataImporter _importer;
        private readonly IMapper _mapper;

        public BrandSeeder(
            IDataImporter importer,
            IMapper mapper)
        {
            _importer = importer;
            _mapper = mapper;
        }

        public async Task SeedAsync(ConvenienceStoreDbContext context)
        {
            if (await context.Brands.AnyAsync())
                return;

            var records =
                _importer.Read<BrandRecord>("Brands");

            var entities =
                _mapper.Map<List<Brand>>(records);

            context.Brands.AddRange(entities);

            await context.SaveChangesAsync();
        }
    }
}
