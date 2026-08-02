using AutoMapper;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Domain.Entities.Territory;
using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.DataRecords.Territory;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Seeders.Territory
{
    internal class BranchSeeder(
        IDataImporter importer,
        IMapper mapper) : IDataSeeder
    {
        private readonly IDataImporter _importer = importer;
        private readonly IMapper _mapper = mapper;

        public async Task SeedAsync(ConvenienceStoreDbContext context)
        {
            if (await context.Branches.AnyAsync())
                return;

            var records =
                _importer.Read<BranchRecord>("Branchs");

            var entities =
                _mapper.Map<List<Branch>>(records);

            context.Branches.AddRange(entities);

            await context.SaveChangesAsync();
        }
    }
}
