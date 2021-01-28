using System.Collections.Generic;
using Newtonsoft.Json;
using ZwajApp.API.Model;

namespace ZwajApp.API.Data
{
    public class trailData
    {
        private readonly dbcontext _context;
        public trailData(dbcontext context)
        {
            _context = context;

        }

        public void trial()
        {
            var UserData = System.IO.File.ReadAllText("Data/UsersTrialData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(UserData);
            foreach (var user in users)
            {
                byte[] passwordHash, Passwordsalt;
                CreatpasswordHash("password",out passwordHash,out Passwordsalt);
                user.passwordsalt=Passwordsalt;
                user.Passwordhash=passwordHash;
                user.Username=user.Username.ToLower();
                _context.Add(user);

            }
            _context.SaveChanges();
        }

        private void CreatpasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
          using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
        
        }  

    }
    
    


    