using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TecJobsAPI.Context;
using TecJobsAPI.DTO;
using TecJobsAPI.Entities;

namespace TecJobsAPI.Repositories
{
    public class EmploymentRepository
    {
        private readonly DatabaseContext _db;

        public EmploymentRepository(DatabaseContext database)
        {
            _db = database;
        }

        public async Task<List<Employment>> GetAll()
        {
            return await _db.Employment.Include(e => e.Company).ToListAsync();
        }

        public async Task<List<Employment>> GetAllByCompany(int companyId)
        {
            return await _db.Employment
                .Where(e => e.CompanyId == companyId)
                .ToListAsync();
        }

        public async Task<Employment> GetById(int id)
        {
            return await _db.Employment.FindAsync(id);
        }

        public async Task<Employment> Create(CreateEmploymentDTO data)
        {
            Employment employment = new Employment
            {
                Title = data.Title,
                Description = data.Description,
                QtdPositions = data.QtdPositions,
                Requirements = data.Requirements,
                PublishedAt = data.PublishedAt,
                CompanyId = data.CompanyId
            };

            var result = await _db.Employment.AddAsync(employment);
            await _db.SaveChangesAsync();

            return result.Entity;

        }

        public async Task<Employment> Update(int id, UpdateEmploymentDTO data)
        {
            var employment = await _db.Employment.FindAsync(id);

            if (employment != null)
            {
                employment.Title = data.Title;
                employment.Description = data.Description;
                employment.QtdPositions = data.QtdPositions;
                employment.Requirements = data.Requirements;
                employment.PublishedAt = data.PublishedAt;
                employment.CompanyId = data.CompanyId;

                _db.Employment.Update(employment);
                await _db.SaveChangesAsync();
            }

            return employment;
        }

        public async Task<Boolean> Delete(int id)
        {
            var employment = await _db.Employment.FindAsync(id);

            if (employment != null)
            {
                _db.Employment.Remove(employment);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}