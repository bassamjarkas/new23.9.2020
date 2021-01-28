using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZwajApp.API.Model;

namespace ZwajApp.API.Data
{
    public interface IZwajrepositpry
    {
         void Add<T>(T entity) where T:class;

         void Delete<T>(T entity) where T:class;

         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         
         Task<User> GetUser(int Id); 
    }

}