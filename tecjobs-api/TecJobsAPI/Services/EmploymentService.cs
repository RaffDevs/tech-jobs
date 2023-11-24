using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecJobsAPI.DTO;
using TecJobsAPI.Entities;
using TecJobsAPI.Exceptions;
using TecJobsAPI.Repositories;

namespace TecJobsAPI.Services
{
    public class EmploymentService
    {
        private readonly EmploymentRepository _repository;

        public EmploymentService(EmploymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Employment>> GetAllEmployments()
        {
            try
            {
                var employments = await _repository.GetAll();
                return employments;
            }
            catch (Exception ex)
            {
                throw new ExceptionReponse("A internal error ocurred!", true);
            }
        }

        public async Task<Employment> GetEmploymentById(int id)
        {
            try
            {
                var employment = await _repository.GetById(id);

                if (employment == null)
                {
                    throw new ExceptionReponse("No records found for this ID!", false);
                }
                return employment;
            }
            catch (Exception ex)
            {

                throw new ExceptionReponse("A internal error ocurred!", true);
            }
        }

        public async Task<List<Employment>> GetEmploymentsByCompanyId(int companyId)
        {
            try
            {
                var employment = await _repository.GetAllByCompany(companyId);

                if (employment == null)
                {
                    throw new ExceptionReponse("No records found for this ID!", false);
                }
                return employment;
            }
            catch (Exception ex)
            {

                throw new ExceptionReponse("A internal error ocurred!", true);
            }
        }

        public async Task<Employment> CreateEmployment(CreateEmploymentDTO data)
        {
            try
            {
                var result = await _repository.Create(data);

                if (result == null)
                {
                    throw new ExceptionReponse("Error on save employment!", false);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new ExceptionReponse("A internal error ocurred!", true);

            }
        }

        public async Task<Employment> UpdateEmployment(int id, UpdateEmploymentDTO data)
        {
            try
            {
                var result = await _repository.Update(id, data);

                if (result == null)
                {
                    throw new ExceptionReponse("No records found for this ID!", false);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new ExceptionReponse("A internal error ocurred!", true);

            }
        }

        public async Task<Boolean> DeleteEmployment(int id)
        {
            try
            {
                var result = await _repository.Delete(id);

                if (!result)
                {
                    throw new ExceptionReponse("No records found for this ID", false);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new ExceptionReponse("A internal error ocurred!", true);

            }
        }
    }
}