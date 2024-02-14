using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using TestTaskService.Abstractions;
using TestTaskService.Models;

namespace TestTaskService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly ILogger<EntityController> _logger;
        private readonly IEntityService _entityService;

        public EntityController(ILogger<EntityController> logger, IEntityService entityService)
        {
            _logger = logger;
            _entityService = entityService;
        }

        [HttpPost()]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Guid>> Create(string entity)
        {
            var model = JsonSerializer.Deserialize<EntityModel>(entity, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            if (model == null)
                return BadRequest();

            return Ok(await _entityService.Add(model));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntityModel>> GetById(Guid id)
        {
            var result = await _entityService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
    }
}