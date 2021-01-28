using System.Threading.Tasks;
using ZwajApp.API.Model;

namespace ZwajApp.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Regsiter(User user,string password);
         Task<User> login (string user,string password);

         Task<bool> UserExistes(string username);
    }
}