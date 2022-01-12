namespace ServerGrpc.AuthCode
{
    public interface IJwtAuthenticationManager
    {
        Task<string> Authenticate(string login, string password);
    }
}
