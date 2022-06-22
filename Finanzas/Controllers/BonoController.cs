using Finanzas.Dto;
using Finanzas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finanzas.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BonoController : Controller
    {
        private readonly IBonoService _service;

        public BonoController(IBonoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<BonoDto>> GetItemById([FromQuery] int id)
        {
            BonoDto bonoDto;
            try
            {
                bonoDto = await _service.GetItem(id);
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
            catch (FinanzasException e)
            {
                return BadRequest(e.Message + " " + e.value);
            }
            return Ok(bonoDto);
        }
        [HttpPost]
        public async Task<ActionResult<BonoDto>> Post([FromBody] BonoDto bonoDto)
        {
            try
            {
                await _service.Create(bonoDto);
            }
            catch (FinanzasException e)
            {
                return BadRequest(e.Message + " " + e.value);
            }

            return CreatedAtAction(nameof(GetItemById), new { id = bonoDto.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BonoDto bonoDto)
        {
            try
            {
                await _service.Update(bonoDto);
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
        public async Task<ActionResult<IEnumerable<BonoDto>>> GetAllByFilter([FromQuery] string filter)
        {
            return Accepted(await _service.GetCollection(filter));
        }
    }
}
