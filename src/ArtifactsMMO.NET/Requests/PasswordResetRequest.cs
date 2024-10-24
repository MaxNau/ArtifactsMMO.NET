namespace ArtifactsMMO.NET.Requests
{
    internal class PasswordResetRequest : IRequest
    {
        internal PasswordResetRequest(string password)
        {
            Password = password;
        }

        internal string Password { get; }
    }
}
