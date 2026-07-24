using AutoMapper;
using ConvenienceStore.Contract.DTOs.Storage.Images;
using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Persistence.DataRecords.Storage;

namespace ConvenienceStore.Persistence.Mapping.Storage
{
    internal class ImageMapping : Profile
    {
        public ImageMapping()
        {
            CreateMap<ImageRecord, Image>().ReverseMap();

        }
    }
}
