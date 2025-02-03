using Guider.API.Pages.Data;
using Guider.API.Pages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Guider.API.Pages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly GenericRepository _repository;

        public GenericController(GenericRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenericDocument>>> GetAll()
        {
            var documents = await _repository.GetAllAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenericDocument>> GetById(string id)
        {
            var document = await _repository.GetByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BsonDocument data)
        {
            var document = new GenericDocument { Data = data };
            await _repository.CreateAsync(document);
            return CreatedAtAction(nameof(GetById), new { id = document.Id }, document);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] BsonDocument newData)
        {
            var existingDocument = await _repository.GetByIdAsync(id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(id, newData);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existingDocument = await _repository.GetByIdAsync(id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
