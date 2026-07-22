using AutoMapper;
using ConvenienceStore.Application.Features.Territory.Branches.Commands.Update;
using ConvenienceStore.Application.Features.Territory.Branches.Queries.GetAll;
using ConvenienceStore.Application.Features.Territory.Branches.Queries.GetById;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Territory;
using ConvenienceStore.Contract.DTOs.Territory.Branches;
using ConvenienceStore.Domain.Entities.Territory;
using ConvenienceStore.Domain.Repositories.Territory;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Territory
{
    internal class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchService(
            IBranchRepository branchRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<BranchResponse>>> GetAllAsync(
            GetAllBranchesSpecification specification,
            CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.ToListAsync(specification, cancellationToken);
            if (!branches.Any())
            {
                return Result<IEnumerable<BranchResponse>>
                    .Fail(Error<Branch>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<BranchResponse>>(branches);
            return Result<IEnumerable<BranchResponse>>
                .Succeed(response, Success<Branch>.Retrieved);
        }

        public async Task<Result<BranchResponse>> GetByIdAsync(GetBranchByIdSpecification specification, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.FindAsync(specification, cancellationToken);
            if (branch is null)
            {
                return Result<BranchResponse>
                    .Fail(Error<Branch>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<BranchResponse>(branch);
            return Result<BranchResponse>
                .Succeed(response, Success<Branch>.Retrieved);
        }

        public async Task<Result<BranchResponse>> CreateAsync(CreateBranchRequest request, CancellationToken cancellationToken)
        {
            var branch = new Branch();
            _mapper.Map(request, branch);
            _branchRepository.Add(branch);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<BranchResponse>(branch);
            return Result<BranchResponse>
                .Succeed(response, Success<Branch>.Created, HttpStatusCode.Created);
        }

        public async Task<Result<BranchResponse>> UpdateAsync(UpdateBranchSpecification specification, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.FindAsync(specification, cancellationToken);
            if (branch is null)
            {
                return Result<BranchResponse>
                    .Fail(Error<Branch>.NotFound, HttpStatusCode.NotFound);
            }

            _mapper.Map(specification.Body, branch);
            _branchRepository.Update(branch);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<BranchResponse>(branch);
            return Result<BranchResponse>
                .Succeed(response, Success<Branch>.Updated, HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.FindAsync(id, cancellationToken);
            if (branch is null)
            {
                return Result<object>
                    .Fail(Error<Branch>.NotFound, HttpStatusCode.NotFound);
            }

            if (branch.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Branch>.AlreadyDeleted, HttpStatusCode.Conflict);
            }

            branch.SoftDelete();
            _branchRepository.Update(branch);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Branch>.Deleted, HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> RestoreAsync(string id, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.FindAsync(id, cancellationToken);
            if (branch is null)
            {
                return Result<object>
                    .Fail(Error<Branch>.NotFound, HttpStatusCode.NotFound);
            }

            if (!branch.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Branch>.NotYetDeleted, HttpStatusCode.Conflict);
            }

            branch.Restore();
            _branchRepository.Update(branch);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Branch>.Restored, HttpStatusCode.Accepted);
        }
    }
}
