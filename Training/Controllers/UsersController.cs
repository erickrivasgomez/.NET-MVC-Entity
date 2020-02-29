using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Training.API.Operations.Users;
using Training.Data.Models;
using Training.DTO;

namespace Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IServiceProvider _IoC;

        public UsersController(IServiceProvider services)
        {
            _IoC = services;
        }

        [HttpGet]
        [Authorize(Roles="admin")]
        public async Task<List<DTO.User>> GetUsers()
        {
            return await _IoC.GetService<GetAll>().Execute();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<List<Order>> GetOrders()
        {
            return await _IoC.GetService<GetAllOrders>().Execute();
        }

        [HttpGet]
        [Route("/{id}")]
        public DTO.User GetUserById([FromRoute] string id)
        {

            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            //TODO implement GetUserById Operation
            //return Execute(userId);
            return new User() { Email = "xxx", Id = "xxx", FullName = "xxx", Gender = "" };
        }

        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<DTO.User> SignUp(UserCredentials user)
        {
            return await _IoC.GetService<SignUp>().Execute(user);
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        // [Authorize(Roles="admin")]
        public async Task<DTO.UserAuthorization> SignIn(UserCredentials user)
        {
            return await _IoC.GetService<SignIn>().Execute(user);
        }
    }
}