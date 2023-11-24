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

// [TODO]Fazer rota que busca employment por id retornar a company
// [TODO]Ver o pq em caso de buscar id inexistente estar retornando 500 ao inves de 404
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
                if (ex.IsInternalError)
                {
                    return StatusCode(500, new
                    {
                        ex.Message
                    });
                }

                return StatusCode(500, new
                {
                    Message = "Can't get employments!"
                });

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmploymentById(int id)
        {
            try
            {
                var result = await _service.GetEmploymentById(id);
                return Ok(result);
            }
            catch (ExceptionReponse ex)
            {
                if (ex.IsInternalError)
                {
                    return StatusCode(500, new
                    {
                        ex.Message
                    });
                }

                return NotFound(new
                {
                    ex.Message,
                    ErrorCode = 404
                });
            }

        }

        [HttpGet("/company/{id}")]
        public async Task<IActionResult> GetEmploymentByCompanyId(int companyId)
        {
            try
            {
                var result = await _service.GetEmploymentsByCompanyId(companyId);
                return Ok(result);
            }
            catch (ExceptionReponse ex)
            {
                if (ex.IsInternalError)
                {
                    return StatusCode(500, new
                    {
                        ex.Message
                    });
                }

                return NotFound(new
                {
                    ex.Message,
                    ErrorCode = 404
                });
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployment(CreateEmploymentDTO data)
        {
            try
            {
                var result = await _service.CreateEmployment(data);
                return Ok(result);
            }
            catch (ExceptionReponse ex)
            {
                if (ex.IsInternalError)
                {
                    return StatusCode(500, new
                    {
                        ex.Message
                    });
                }

                return StatusCode(500, new
                {
                    Message = "Can't create employment"
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployment(int id, UpdateEmploymentDTO data)
        {
            try
            {
                var result = await _service.UpdateEmployment(id, data);
                return Ok(result);
            }
            catch (ExceptionReponse ex)
            {
                if (ex.IsInternalError)
                {
                    return StatusCode(500, new
                    {
                        ex.Message
                    });
                }

                return NotFound(new
                {
                    ex.Message,
                    ErrorCode = 404
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployment(int id)
        {
            try
            {
                var result = await _service.DeleteEmployment(id);
                return NoContent();
            }
            catch (ExceptionReponse ex)
            {
                if (ex.IsInternalError)
                {
                    return StatusCode(500, new
                    {
                        ex.Message
                    });
                }

                return NotFound(new
                {
                    ex.Message,
                    ErrorCode = 404
                });
            }
        }
    }
}