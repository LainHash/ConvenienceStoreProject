using AutoMapper;
using ConvenienceStore.Contract.DTOs.Territory.Branches;
using ConvenienceStore.Domain.Entities.Territory;
using ConvenienceStore.Persistence.DataRecords.Territory;

namespace ConvenienceStore.Persistence.Mapping.Territory
{
    internal class BranchMapping : Profile
    {
        public BranchMapping()
        {
            CreateMap<BranchRecord, Branch>().ReverseMap();
            CreateMap<Branch, BranchResponse>();
            CreateMap<CreateBranchRequest, Branch>();
            CreateMap<UpdateBranchRequest, Branch>();
        }
    }
}
