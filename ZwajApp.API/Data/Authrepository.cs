using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZwajApp.API.Model;

namespace ZwajApp.API.Data
{
    public class Authrepository : IAuthRepository
    {
        private readonly dbcontext _context;
        public Authrepository(dbcontext context)
        {
            _context = context;

        }
        public  async Task<User> login(string user, string password)
        {    
            var use=await _context.Users.FirstOrDefaultAsync(x=>x.Username==user);
            if(use==null)return null;
            if(!verfypasswordhash(password,use.passwordsalt,use.Passwordhash))
            return null;
            return use;
        }

        private bool verfypasswordhash(string password, byte[] passwordsalt, byte[] passwordhash)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512(passwordsalt)){
             var computedhash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
             for (int i = 0; i <computedhash.Length; i++)
             {
                if(computedhash[i]!=passwordhash[i]){return false;} 
             }
            }
            return true;
        }

        public async Task<User> Regsiter(User user, string password)
        {
            byte [] passwordHash,passwordSalt;
            CreatpasswordHash(password,out passwordHash,out passwordSalt);
            user.Passwordhash=passwordHash;
            user.passwordsalt=passwordSalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatpasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512()){
                passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }   

        }

        public async Task<bool> UserExistes(string username)
        {
            if(await _context.Users.AnyAsync(x=>x.Username==username))
            { return true;}
            return false;
        }
    }
}