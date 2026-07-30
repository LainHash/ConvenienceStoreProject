using AutoMapper;
using ConvenienceStore.Application.Features.Identity.Profiles.Commands.Update;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Profiles;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Identity;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Identity
{
    internal class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(
            IProfileRepository profileRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ProfileResponse>> UpdateAsync(
            UpdateProfileSpecification specification,
            CancellationToken cancellationToken)
        {
            var profile = await _profileRepository.FindAsync(specification, cancellationToken);
            if(profile is null)
            {
                return Result<ProfileResponse>
                    .Fail(Error<Domain.Entities.Identity.Profile>.NotFound, HttpStatusCode.NotFound);
            }

            _mapper.Map(specification.Body, profile);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<ProfileResponse>(profile);
            return Result<ProfileResponse>
                .Succeed(response, Success<Domain.Entities.Identity.Profile>.Updated, HttpStatusCode.Accepted);
        }
    }
}
