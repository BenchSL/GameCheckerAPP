using System.Threading.Tasks;

namespace GameCheckerAPI.AutenticationServices
{
    public interface IAutenticationService
    {
        Task<bool> Login(string userName, string password);
        Task<bool> Register(string userName, string password, string email, string confirmPassword);
    }
}
