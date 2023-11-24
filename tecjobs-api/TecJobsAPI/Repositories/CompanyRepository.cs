using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TecJobsAPI.Context;
using TecJobsAPI.DTO;
using TecJobsAPI.Entities;
using TecJobsAPI.Exceptions;

namespace TecJobsAPI.Repositories
{
    public class CompanyRepository
    {
        private readonly DatabaseContext _db;

        public CompanyRepository(DatabaseContext database)
        {
            _db = database;
        }


        public async Task<List<Company>> GetAll()
        {
            return await _db.Company.ToListAsync();
        }

        public async Task<Company> GetById(int id)
        {
            return await _db.Company.FindAsync(id);
        }

        public async Task<Company> Create(CreateCompanyDTO data)
        {
            Company company = new Company
            {
                Name = data.Name,
                AboutUs = data.AboutUs
            };

            var result = await _db.Company.AddAsync(company);
            await _db.SaveChangesAsync();

            return result.Entity;

        }

        public async Task<Company> Update(int id, UpdateCompanyDTO data)
        {
            var company = await _db.Company.FindAsync(id);

            if (company != null)
            {
                company.Name = data.Name;
                company.AboutUs = data.AboutUs;
                _db.Company.Update(company);
                await _db.SaveChangesAsync();
            }

            return company;
        }

        public async Task<Boolean> Delete(int id)
        {
            var company = await _db.Company.FindAsync(id);

            if (company != null)
            {
                _db.Company.Remove(company);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}