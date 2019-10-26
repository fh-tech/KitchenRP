namespace KitchenRP.Domain.Services
{
    public interface IAuthenticationService
    {
        bool AuthenticateUser(string username, string password);
    }
}