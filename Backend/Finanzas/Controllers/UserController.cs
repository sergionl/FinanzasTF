using Finanzas.Dto;
using Finanzas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Finanzas.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetItemById([FromQuery] int id)
        {
            UserDto userDto;
            try
            {
                userDto = await _service.GetItem(id);
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
            catch (FinanzasException e)
            {
                return BadRequest(e.Message + " " + e.value);
            }
            return Ok(userDto);
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto userDto)
        {
            try
            {
                await _service.Create(userDto);
            }
            catch (FinanzasException e)
            {
                return BadRequest(e.Message + " " + e.value);
            }

            return CreatedAtAction(nameof(GetItemById), new { id = userDto.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDto userDto)
        {
            try
            {
                await _service.Update(userDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Accepted();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await _service.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Accepted();
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetItemByEmail([FromQuery] string email, [FromQuery] string password)
        {
            UserDto userDto;
            try
            {
                userDto = await _service.GetItemByEmail(email,password);
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
            catch (FinanzasException e)
            {
                return BadRequest(e.Message + " " + e.value);
            }
            return Ok(userDto);
        }


    }
}
