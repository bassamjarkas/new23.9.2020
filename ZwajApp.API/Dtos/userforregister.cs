using System.ComponentModel.DataAnnotations;

namespace ZwajApp.API.Dtos
{
    public class userforregister
    {    
        
        
        
        [Required]
        
        public string username { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string password { get; set; }
        
      
    }
}