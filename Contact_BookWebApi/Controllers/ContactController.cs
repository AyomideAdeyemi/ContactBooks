using ContactBooks_Application.Services;
using ContactBooks_Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contact_BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactImplementation _contactImplementation;

        public ContactController(IContactImplementation contactImplementation)
        {
            _contactImplementation = contactImplementation;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetContact([FromQuery]string name, bool trackChanges)
        {
          var result = await _contactImplementation.GetContactBySearch(name, trackChanges);
            return Ok(result);
        }

        
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromForm] ContactRequestDto requestDto)
        {
            var result = await _contactImplementation.CreateContact(requestDto);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(string id, [FromBody] ContactRequestDto requestDto)
        {
            var result = await _contactImplementation.UpdateBrand(id, requestDto);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            var result = await _contactImplementation.DeleteContact(id);
            return Ok(result);
        }
    }
}
