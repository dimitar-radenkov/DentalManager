namespace DentalManager.Services.Contracts
{
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Tokens;

    public interface ILoginService
    {
        Task<string> LoginAsync(string username, string password);
    }
}
