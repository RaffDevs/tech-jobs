package com.raffdevs.tecjobsapi.services;

import com.raffdevs.tecjobsapi.dtos.CreateCompanyDTO;
import com.raffdevs.tecjobsapi.dtos.UpdateCompanyDTO;
import com.raffdevs.tecjobsapi.entities.Company;
import com.raffdevs.tecjobsapi.exceptions.ResourceNotFoundException;
import com.raffdevs.tecjobsapi.models.CompanyModel;
import com.raffdevs.tecjobsapi.models.mapper.CompanyMapper;
import com.raffdevs.tecjobsapi.repositories.CompanyRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.logging.Logger;
import java.util.stream.Collectors;

@Service
public class CompanyService {
    private final Logger logger = Logger.getLogger(CompanyService.class.getName());

    @Autowired
    private CompanyRepository repository;

    public List<CompanyModel> findAll() {
        logger.info("Finding all companies!");
        return repository.findAll()
                .stream()
                .map(CompanyMapper::parseToModel)
                .collect(Collectors.toList());
    }

    public CompanyModel findById(Long id) {
        logger.info("Finding one company!");
        var entity =  repository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("No records for this ID!"));

        return CompanyMapper.parseToModel(entity);
    }

    public CompanyModel create(CreateCompanyDTO data) {
        logger.info("Creating company!");
        Company company = new Company();
        company.setName(data.getName());
        company.setAboutUs(data.getAboutUs());

        return CompanyMapper.parseToModel(repository.save(company));
    }

    public CompanyModel update(UpdateCompanyDTO data) {
        logger.info("Updating company!");

        var company = repository.findById(data.getId())
                .orElseThrow(() -> new ResourceNotFoundException("No records for this ID!"));

        company.setName(data.getName());
        company.setAboutUs(data.getAboutUs());

        return CompanyMapper.parseToModel(repository.save(company));

    }

    public void delete(Long id) {
        logger.info("Deleting one company!");

        var company = repository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("No records for this ID!"));

        repository.delete(company);
    }

}
