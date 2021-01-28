using System.Linq;
using AutoMapper;
using ZwajApp.API.Dtos;
using ZwajApp.API.Model;

namespace ZwajApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                        .ForMember(x => x.PhotoUrl, opt =>
               {
                   opt.MapFrom(x => x.photos.FirstOrDefault(xe => xe.IsMain).url
               );
               }).ForMember(x=>x.Age,op=>{op.ResolveUsing(c=>c.DateofBirth.Calculateage());});

            CreateMap<User, UserForDetailsDto>()
            .ForMember(x => x.PhotoUrl, opt =>
               {
                   opt.MapFrom(x => x.photos.FirstOrDefault(xe => xe.IsMain).url
               );
               }).ForMember(x=>x.Age,op=>{op.ResolveUsing(c=>c.DateofBirth.Calculateage());});
            CreateMap<Photo, PhotoForDetailsDto>();
        }

    }
}