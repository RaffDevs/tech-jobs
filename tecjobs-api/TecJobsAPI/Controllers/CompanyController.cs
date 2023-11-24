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

namespace TecJobsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _service;

        public CompanyController(CompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                var companies = await _service.GetAllCompanies();
                return Ok(companies);
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
        public async Task<IActionResult> GetCompanyById(int id)
        {
            try
            {
                var company = await _service.GetCompanyById(id);

                if (company == null)
                {
                    return NotFound(new
                    {
                        Message = "No records found for this ID!",
                        ErrorCode = 404
                    });
                }

                var jsonOptions = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };

                var jsonResult = JsonSerializer.Serialize(company, jsonOptions);

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
        public async Task<IActionResult> CreateCompany(CreateCompanyDTO data)
        {
            try
            {
                var result = await _service.CreateCompany(data);

                if (result == null)
                {
                    return StatusCode(500, new
                    {
                        Message = "Can't create comapany"
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
        public async Task<IActionResult> UpdateCompany(int id, UpdateCompanyDTO data)
        {
            try
            {
                var result = await _service.UpdateCompany(id, data);

                if (result == null)
                {
                    return NotFound(new
                    {
                        Message = "No records found for this ID!",
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
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var result = await _service.DeleteCompany(id);

                if (result)
                {
                    return NoContent();
                }

                return NotFound(new
                {
                    Message = "No records found for this ID!",
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
