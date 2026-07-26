using AutoMapper;
using ConvenienceStore.Application.Features.Authentication.Roles.Commands.Update;
using ConvenienceStore.Application.Features.Authentication.Roles.Queries.GetAll;
using ConvenienceStore.Application.Features.Authentication.Roles.Queries.GetById;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Roles;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Identity;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Identity
{
    internal class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(
            IRoleRepository roleRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PageResult<IEnumerable<RoleResponse>>> GetAllAsync(
            GetAllRolesSpecification specification,
            CancellationToken cancellationToken)
        {
            var totalItems = await _roleRepository.CountAsync(specification, cancellationToken);

            var roles = await _roleRepository.ToListAsync(specification, cancellationToken);
            if (!roles.Any())
            {
                return PageResult<IEnumerable<RoleResponse>>
                    .Fail(Error<Role>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<RoleResponse>>(roles);
            return PageResult<IEnumerable<RoleResponse>>
                .Succeed(response, Success<Role>.Retrieved, totalItems, specification.Skip, specification.Take);
        }

        public async Task<Result<RoleResponse>> GetByIdAsync(
            GetRoleByIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var role = await _roleRepository.FindAsync(specification, cancellationToken);
            if (role is null)
            {
                return Result<RoleResponse>
                    .Fail(Error<Role>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<RoleResponse>(role);
            return Result<RoleResponse>
                .Succeed(response, Success<Role>.Retrieved);
        }

        public async Task<Result<RoleResponse>> CreateAsync(
            CreateRoleRequest request,
            CancellationToken cancellationToken)
        {
            var existingRole = await _roleRepository.FindByNameAsync(request.Name, cancellationToken);
            if (existingRole is not null)
            {
                return Result<RoleResponse>
                    .Fail(Error<Role>.ExistedName, HttpStatusCode.Conflict);
            }

            var role = new Role();
            _mapper.Map(request, role);
            _roleRepository.Add(role);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<RoleResponse>(role);
            return Result<RoleResponse>
                .Succeed(response, Success<Role>.Created, HttpStatusCode.Created);
        }

        public async Task<Result<RoleResponse>> UpdateAsync(
            UpdateRoleSpecification specification,
            CancellationToken cancellationToken)
        {
            var role = await _roleRepository.FindAsync(specification, cancellationToken);
            if (role is null)
            {
                return Result<RoleResponse>
                    .Fail(Error<Role>.NotFound, HttpStatusCode.NotFound);
            }

            _mapper.Map(specification.Body, role);
            _roleRepository.Update(role);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<RoleResponse>(role);
            return Result<RoleResponse>
                .Succeed(response, Success<Role>.Updated, HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.FindAsync(id, cancellationToken);
            if (role is null)
            {
                return Result<object>
                    .Fail(Error<Role>.NotFound, HttpStatusCode.NotFound);
            }

            if (role.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Role>.AlreadyDeleted, HttpStatusCode.Conflict);
            }

            role.SoftDelete();
            _roleRepository.Update(role);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Role>.Deleted, HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> RestoreAsync(string id, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.FindAsync(id, cancellationToken);
            if (role is null)
            {
                return Result<object>
                    .Fail(Error<Role>.NotFound, HttpStatusCode.NotFound);
            }

            if (!role.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Role>.NotYetDeleted, HttpStatusCode.Conflict);
            }

            role.Restore();
            _roleRepository.Update(role);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Role>.Restored, HttpStatusCode.Accepted);
        }
    }
}
