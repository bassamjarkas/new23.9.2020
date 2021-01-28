using System;
using ZwajApp.API.Model;

namespace ZwajApp.API.Dtos
{
    public class PhotoForDetailsDto
    {
        public int Id { get; set; }
        public string url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
       
       

    }
}