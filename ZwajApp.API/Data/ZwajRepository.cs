using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZwajApp.API.Model;

namespace ZwajApp.API.Data
{
    public class ZwajRepository : IZwajrepositpry
      {   private readonly dbcontext _context;
      public ZwajRepository(dbcontext context)
           
    {

         _context = context; 
    }
    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
       _context.Remove(entity);
    }

    public async Task<User> GetUser(int Id)
    {
        var user=await _context.Users.Include(u=>u.photos).FirstOrDefaultAsync(u=>u.Id==Id);
        return user;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      var users=await _context.Users.Include(u=>u.photos).ToListAsync();
      return users;
    }

    public async Task<bool> SaveAll()
    {
        return await _context.SaveChangesAsync()>0;
    }
}
}