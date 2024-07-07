using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Users
{
    [ApiController]
    [Route("api/users")]
    public class UserDeleteController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserDeleteController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
         var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok();
        } 
    }
}