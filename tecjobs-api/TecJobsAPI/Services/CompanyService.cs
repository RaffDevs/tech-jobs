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
    public class CompanyService
    {
        private readonly CompanyRepository _repository;

        public CompanyService(CompanyRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<Company>> GetAllCompanies()
        {
            try
            {
                var companies = await _repository.GetAll();
                return companies;
            }
            catch (Exception ex)
            {
                throw new ExceptionReponse("A internal error ocurred!", true);
            }
        }

        public async Task<Company> GetCompanyById(int id)
        {
            try
            {
                var company = await _repository.GetById(id);

                return company;
            }
            catch (Exception ex)
            {
                throw new ExceptionReponse("A internal error ocurred!", true);
            }
        }

        public async Task<Company> CreateCompany(CreateCompanyDTO data)
        {
            try
            {
                var result = await _repository.Create(data);

                return result;
            }
            catch (Exception ex)
            {
                throw new ExceptionReponse("A internal error ocurred!", true);

            }
        }

        public async Task<Company> UpdateCompany(int id, UpdateCompanyDTO data)
        {
            try
            {
                var result = await _repository.Update(id, data);

                return result;
            }
            catch (Exception ex)
            {
                throw new ExceptionReponse("A internal error ocurred!", true);

            }
        }

        public async Task<Boolean> DeleteCompany(int id)
        {
            try
            {
                var result = await _repository.Delete(id);

                return result;
            }
            catch (Exception ex)
            {
                throw new ExceptionReponse("A internal error ocurred!", true);

            }
        }
    }
}