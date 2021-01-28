using System;
using Microsoft.AspNetCore.Http;
namespace ZwajApp.API.Helpers
{
    public static class Exctensions
    {
        public static void ExtenionError(this HttpResponse response,string message){
           
           
            response.Headers.Add("Application-Error",message);
            response.Headers.Add("Access-Control-Expose-Headers","Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin","*");

        }

        public static int Calculateage(this DateTime DateofBirth){
         var age=DateTime.Today.Year-DateofBirth.Year;
         if (DateofBirth.AddYears(age)>DateTime.Today) age --;

         return age;
     
        }
    }
}