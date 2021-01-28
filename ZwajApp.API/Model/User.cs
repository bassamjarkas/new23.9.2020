using System;
using System.Collections.Generic;

namespace ZwajApp.API.Model
{
    public class User
    {
        public int Id{ get; set; }
        public string Username { get; set; }
        public byte[] Passwordhash { get; set; }

        public byte[] passwordsalt { get; set; }

        public string gender { get; set; }

        public DateTime DateofBirth { get; set; }

        public string Knowas { get; set; }

      public DateTime Created { get; set; }

      public DateTime LastActive { get; set; }

      public string  Introduction { get; set; }

      public string LookingFor { get; set; }

      public string Intersstes { get; set; }

      public string City { get; set; }

      public string  Country { get; set; }

      public ICollection<Photo> photos{ get; set; }


    }
}