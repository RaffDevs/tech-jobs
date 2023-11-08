package com.raffdevs.tecjobsapi.services;

import com.raffdevs.tecjobsapi.dtos.CreateCompanyDTO;
import com.raffdevs.tecjobsapi.dtos.UpdateCompanyDTO;
import com.raffdevs.tecjobsapi.entities.Company;
import com.raffdevs.tecjobsapi.exceptions.ResourceNotFoundException;
import com.raffdevs.tecjobsapi.repositories.CompanyRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.logging.Logger;

@Service
public class CompanyService {
    private final Logger logger = Logger.getLogger(CompanyService.class.getName());

    @Autowired
    private CompanyRepository repository;

    public List<Company> findAll() {
        logger.info("Finding all companies!");
        return repository.findAll();
    }

    public Company findById(Long id) {
        logger.info("Finding one company!");
        return repository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("No records for this ID!"));
    }

    public Company create(CreateCompanyDTO data) {
        logger.info("Creating company!");
        Company company = new Company();
        company.setName(data.getName());
        company.setAboutUs(data.getAboutUs());

        return repository.save(company);
    }

    public Company update(UpdateCompanyDTO data) {
        logger.info("Updating company!");

        var company = repository.findById(data.getId())
                .orElseThrow(() -> new ResourceNotFoundException("No records for this ID!"));

        company.setName(data.getName());
        company.setAboutUs(data.getAboutUs());

        return repository.save(company);

    }

    public void delete(Long id) {
        logger.info("Deleting one company!");

        var company = repository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("No records for this ID!"));

        repository.delete(company);
    }

}
