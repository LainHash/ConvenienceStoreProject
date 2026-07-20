namespace ConvenienceStore.Application.Models.Messages
{
    public class EmailMessage
    {
        public string Subject { get; private set; } = string.Empty;
        public string Body { get; private set; } = string.Empty;

        public EmailMessage(string userName, string verificationCode)
        {
            Subject = "Restaurant - Email Verification Code";
            Body = $"Hello {userName},<br/><br/>Your verification code is: <b>{verificationCode}</b><br/>This code will expire in 15 minutes.";
        }
    }
}
