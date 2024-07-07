using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Users;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Users
{
    [ApiController]
    [Route("api/users")]
    public class UserUpdateController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserUpdateController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            var userFound = await _userRepository.CheckExistence(id);
            if (userFound == false)
            {
                return NotFound();
            }
            else
            {
                user.Id = id;
                await _userRepository.Update(user);
                return Ok(new { message = "user updated successfully" });
            }
        }
    }
}
