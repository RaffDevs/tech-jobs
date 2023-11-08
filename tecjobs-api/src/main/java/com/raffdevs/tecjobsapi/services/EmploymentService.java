package com.raffdevs.tecjobsapi.services;

import com.raffdevs.tecjobsapi.dtos.CreateEmploymentDTO;
import com.raffdevs.tecjobsapi.dtos.UpdateEmploymentDTO;
import com.raffdevs.tecjobsapi.entities.Employment;
import com.raffdevs.tecjobsapi.exceptions.ResourceNotFoundException;
import com.raffdevs.tecjobsapi.repositories.EmploymentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.Instant;
import java.util.List;
import java.util.logging.Logger;

@Service
public class EmploymentService {
    private final Logger logger = Logger.getLogger(EmploymentService.class.getName());

    @Autowired
    EmploymentRepository repository;

    @Autowired
    CompanyService service;

    public List<Employment> findAll() {
        logger.info("Finding all employments!");
        return repository.findAll();
    }

    public Employment findById(Long id) {
        logger.info("Finding one employment!");

        return repository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("No records found for this ID!"));
    }

    public Employment create(CreateEmploymentDTO data) {
        logger.info("Creating one employment!");
        var company = service.findById(data.getcompanyId());
        Employment employment = new Employment();
        employment.setTitle(data.getTitle());
        employment.setDescription(data.getDescription());
        employment.setRequirements(data.getRequirements());
        employment.setQtPositions(data.getQtPositions());
        employment.setPublishedAt(Instant.now());
        employment.setCompany(company);

        return repository.save(employment);
    }

    public Employment update(UpdateEmploymentDTO data) {
        var employment = repository.findById(data.getId())
                .orElseThrow(() -> new ResourceNotFoundException("No records found for this ID"));
        var company = service.findById(data.getCompanyId());
        employment.setTitle(data.getTitle());
        employment.setDescription(data.getDescription());
        employment.setRequirements(data.getRequirements());
        employment.setQtPositions(data.getQtPositions());
        employment.setCompany(company);

        return repository.save(employment);
    }

    public void delete(Long id) {
        logger.info("Deleting one employment");
        var employment = repository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("No records found for this ID"));

        repository.delete(employment);
    }
}
