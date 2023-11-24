using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecJobsAPI.DTO;
using TecJobsAPI.Exceptions;
using TecJobsAPI.Services;

// [TODO]Ver o pq em caso de buscar id inexistente estar retornando 500 ao inves de 404
// [TODO] Documentar o swagger
namespace TecJobsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmploymentController : ControllerBase
    {
        private readonly EmploymentService _service;

        public EmploymentController(EmploymentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployments()
        {
            try
            {
                var employments = await _service.GetAllEmployments();
                var jsonOptions = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };
                var jsonResult = JsonSerializer.Serialize(employments, jsonOptions);
                return Ok(jsonResult);
            }
            catch (ExceptionReponse ex)
            {
                return StatusCode(500, new
                {
                    ex.Message
                });

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmploymentById(int id)
        {
            try
            {
                var employment = await _service.GetEmploymentById(id);

                if (employment == null)
                {
                    return NotFound(new
                    {
                        Message = "Can't found records for this ID!",
                        ErrorCode = 404
                    });
                }
                var jsonOptions = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };
                var jsonResult = JsonSerializer.Serialize(employment, jsonOptions);
                return Ok(jsonResult);
            }
            catch (ExceptionReponse ex)
            {
                return StatusCode(500, new
                {
                    ex.Message
                });
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployment(CreateEmploymentDTO data)
        {
            try
            {
                var result = await _service.CreateEmployment(data);

                if (result == null)
                {
                    return StatusCode(500, new
                    {
                        Message = "Can't create employment"
                    });
                }
                return Ok(result);
            }
            catch (ExceptionReponse ex)
            {
                return StatusCode(500, new
                {
                    ex.Message
                });

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployment(int id, UpdateEmploymentDTO data)
        {
            try
            {
                var result = await _service.UpdateEmployment(id, data);

                if (result == null)
                {
                    return NotFound(new
                    {
                        Message = "Can't found records for this ID!",
                        ErrorCode = 404
                    });
                }
                return Ok(result);
            }
            catch (ExceptionReponse ex)
            {
                return StatusCode(500, new
                {
                    ex.Message
                });

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployment(int id)
        {
            try
            {
                var result = await _service.DeleteEmployment(id);

                if (result)
                {
                    return NoContent();
                }

                return NotFound(new
                {
                    Message = "Can't found records for this ID!",
                    ErrorCode = 404
                });
            }
            catch (ExceptionReponse ex)
            {
                return StatusCode(500, new
                {
                    ex.Message
                });

            }
        }
    }
}