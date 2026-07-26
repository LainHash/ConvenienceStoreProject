namespace ConvenienceStore.Application.Services.Authentication
{
    public interface IJwtProvider
    {
        string GenerateToken(string userId, string userName, string email, string role);
    }
}
