using Finanzas.Dto;
using Finanzas.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finanzas.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class UserBonoController : Controller
    {
        private readonly IUserBonoService _service;

        public UserBonoController(IUserBonoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<UserBonoDto>> Post([FromBody] UserBonoDto userGroupDto)
        {
            try
            {
                await _service.Create(userGroupDto);
            }
            catch (FinanzasException e)
            {
                return BadRequest(e.Message + " " + e.value);
            }

            return CreatedAtAction(nameof(GetItemById), new { userId = userGroupDto.UserId, bonoId = userGroupDto.BonoId }, userGroupDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBonoDto>>> GetItemById([FromQuery] int groupId)
        {

            return Accepted(await _service.GetItemsByUserId(groupId));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsingUser([FromQuery] int userId, int bonoId)
        {
            try
            {
                await _service.DeleteUsingUser(userId, bonoId);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

            return NoContent();
        }
    }
}
