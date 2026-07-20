using AutoMapper;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.DataRecords.Catalog;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Seeders.Catalog
{
    internal class CategorySeeder : IDataSeeder
    {
        private readonly IDataImporter _importer;
        private readonly IMapper _mapper;

        public CategorySeeder(
            IDataImporter importer,
            IMapper mapper)
        {
            _importer = importer;
            _mapper = mapper;
        }

        public async Task SeedAsync(ConvenienceStoreDbContext context)
        {
            if (await context.Categories.AnyAsync())
                return;

            var records =
                _importer.Read<CategoryRecord>("Categories");

            var entities =
                _mapper.Map<List<Category>>(records);

            context.Categories.AddRange(entities);

            await context.SaveChangesAsync();
        }
    }
}
