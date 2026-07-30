using ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmCurrentEmailChange;
using ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmEmailChange;
using ConvenienceStore.Application.Features.Identity.Users.Commands.RequestEmailChange;
using ConvenienceStore.Application.Models.Results;

namespace ConvenienceStore.Application.Services.Identity
{
    public interface IEmailChangeService
    {
        /// <summary>
        /// Bước 1: Tạo EmailChangeRequest, sinh OTP và gửi email xác nhận đến địa chỉ mới.
        /// </summary>
        Task<Result<object>> RequestEmailChangeAsync(
            RequestEmailChangeSpecification specification,
            CancellationToken cancellationToken);

        /// <summary>
        /// Xác nhận OTP cho email hiện tại.
        /// </summary>
        Task<Result<object>> ConfirmCurrentEmailChangeAsync(
            ConfirmCurrentEmailChangeSpecification specification,
            CancellationToken cancellationToken);

        /// <summary>
        /// Bước 2: Xác nhận OTP → cập nhật Email trên User, xóa EmailChangeRequest.
        /// </summary>
        Task<Result<object>> ConfirmEmailChangeAsync(
            ConfirmEmailChangeSpecification specification,
            CancellationToken cancellationToken);
    }
}
