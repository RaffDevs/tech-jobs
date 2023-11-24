using System;
using System.Collections.Generic;
using System.Linq;
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
                if (ex.IsInternalError)
                {
                    return StatusCode(500, new
                    {
                        ex.Message
                    });
                }

                return StatusCode(500, new
                {
                    Message = "Can't get companies!"
                });

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            try
            {
                var result = await _service.GetCompanyById(id);
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
        public async Task<IActionResult> CreateCompany(CreateCompanyDTO data)
        {
            try
            {
                var result = await _service.CreateCompany(data);
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
                    Message = "Can't create comapany"
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, UpdateCompanyDTO data)
        {
            try
            {
                var result = await _service.UpdateCompany(id, data);
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
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var result = await _service.DeleteCompany(id);
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
