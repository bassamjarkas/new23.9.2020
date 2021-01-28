using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Data;
using ZwajApp.API.Dtos;

namespace ZwajApp.API.Controllers
{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IZwajrepositpry _Repo;
        private readonly IMapper _mapper;

        public UserController(IZwajrepositpry Repo, IMapper mapper)
        {
            _mapper = mapper;
            _Repo = Repo;


        }

        [HttpGet]
        public async Task<IActionResult> getUsers()
        {   
            var Users = await _Repo.GetUsers();
            var usersToReturn=_mapper.Map<IEnumerable<UserForListDto>>(Users);
            return Ok(usersToReturn);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getUser(int id)
        {
            var User = await _Repo.GetUser(id);
            var UserToReturn=_mapper.Map<UserForDetailsDto>(User);
            return Ok(UserToReturn);

        }
    }
}