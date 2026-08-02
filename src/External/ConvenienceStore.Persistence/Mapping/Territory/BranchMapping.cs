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
            CreateMap<BranchRecord, Branch>()
                .ForMember(dest => dest.OpenTime, opt => opt.MapFrom(src => TimeOnly.FromTimeSpan(src.OpenTime)))
                .ForMember(dest => dest.CloseTime, opt => opt.MapFrom(src => TimeOnly.FromTimeSpan(src.CloseTime)));

            CreateMap<Branch, BranchResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId));
            CreateMap<CreateBranchRequest, Branch>();
            CreateMap<UpdateBranchRequest, Branch>();
        }
    }
}
