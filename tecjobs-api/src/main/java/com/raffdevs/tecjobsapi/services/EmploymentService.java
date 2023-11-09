package com.raffdevs.tecjobsapi.services;

import com.raffdevs.tecjobsapi.dtos.CreateEmploymentDTO;
import com.raffdevs.tecjobsapi.dtos.UpdateEmploymentDTO;
import com.raffdevs.tecjobsapi.entities.Employment;
import com.raffdevs.tecjobsapi.exceptions.ResourceNotFoundException;
import com.raffdevs.tecjobsapi.models.EmploymentModel;
import com.raffdevs.tecjobsapi.models.mapper.CompanyMapper;
import com.raffdevs.tecjobsapi.models.mapper.EmploymentMapper;
import com.raffdevs.tecjobsapi.repositories.EmploymentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.Instant;
import java.util.List;
import java.util.logging.Logger;
import java.util.stream.Collectors;

@Service
public class EmploymentService {
    private final Logger logger = Logger.getLogger(EmploymentService.class.getName());

    @Autowired
    EmploymentRepository repository;

    @Autowired
    CompanyService service;

    public List<EmploymentModel> findAll() {
        logger.info("Finding all employments!");
        return repository.findAll()
                .stream()
                .map(EmploymentMapper::parseToModel)
                .collect(Collectors.toList());
    }

    public EmploymentModel findById(Long id) {
        logger.info("Finding one employment!");

        var entity = repository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("No records found for this ID!"));

        return EmploymentMapper.parseToModel(entity);
    }

    public EmploymentModel create(CreateEmploymentDTO data) {
        logger.info("Creating one employment!");
        var company = service.findById(data.getcompanyId());
        Employment employment = new Employment();
        employment.setTitle(data.getTitle());
        employment.setDescription(data.getDescription());
        employment.setRequirements(data.getRequirements());
        employment.setQtPositions(data.getQtPositions());
        employment.setPublishedAt(Instant.now());
        employment.setCompany(CompanyMapper.parseToEntity(company));

        return EmploymentMapper.parseToModel(repository.save(employment));
    }

    public EmploymentModel update(UpdateEmploymentDTO data) {
        var employment = repository.findById(data.getId())
                .orElseThrow(() -> new ResourceNotFoundException("No records found for this ID"));
        var company = service.findById(data.getCompanyId());
        employment.setTitle(data.getTitle());
        employment.setDescription(data.getDescription());
        employment.setRequirements(data.getRequirements());
        employment.setQtPositions(data.getQtPositions());
        employment.setCompany(CompanyMapper.parseToEntity(company));

        return EmploymentMapper.parseToModel(repository.save(employment));
    }

    public void delete(Long id) {
        logger.info("Deleting one employment");
        var employment = repository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("No records found for this ID"));

        repository.delete(employment);
    }
}
