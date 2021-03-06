using System;
using System.Collections.Generic;
using ZwajApp.API.Model;

namespace ZwajApp.API.Dtos
{
    public class UserForDetailsDto
    {

        public int Id { get; set; }
        public string Username { get; set; }
       public string gender { get; set; }

        public int Age{ get; set; }

        public string Knowas { get; set; } 

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Introduction { get; set; }

        public string LookingFor { get; set; }

        public string Intersstes { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PhotoUrl { get; set; }

        public ICollection<PhotoForDetailsDto> Photos{ get; set; }



    }
}