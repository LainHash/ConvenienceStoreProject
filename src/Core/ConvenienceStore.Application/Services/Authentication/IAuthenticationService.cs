using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Authentication;

namespace ConvenienceStore.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<Result<object>> RegisterAsync(
            RegisterRequest request,
            CancellationToken cancellationToken = default);

        Task<Result<AuthenticationResponse>> LoginAsync(
            LoginRequest request,
            CancellationToken cancellationToken = default);

        Task<Result<object>> VerifyEmailAsync(
            VerifyEmailRequest request,
            CancellationToken cancellationToken = default);

        Task<Result<object>> CompleteProfileAsync(
            CompleteProfileRequest request,
            CancellationToken cancellationToken = default);

        Task<Result<object>> ResendVerificationAsync(
            ResendVerificationRequest request,
            CancellationToken cancellationToken = default);
    }
}
