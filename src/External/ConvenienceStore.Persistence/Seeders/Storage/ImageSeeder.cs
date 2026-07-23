using AutoMapper;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.DataRecords.Catalog;
using ConvenienceStore.Persistence.DataRecords.Storage;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Seeders.Storage
{
    internal class ImageSeeder : IDataSeeder
    {
        private readonly IDataImporter _importer;
        private readonly IMapper _mapper;

        public ImageSeeder(
            IDataImporter importer,
            IMapper mapper)
        {
            _importer = importer;
            _mapper = mapper;
        }

        public async Task SeedAsync(ConvenienceStoreDbContext context)
        {
            if (await context.Images.AnyAsync())
                return;

            var records =
                _importer.Read<ImageRecord>("Images");

            var entities =
                _mapper.Map<List<Image>>(records);

            context.Images.AddRange(entities);

            await context.SaveChangesAsync();
        }
    }
}
