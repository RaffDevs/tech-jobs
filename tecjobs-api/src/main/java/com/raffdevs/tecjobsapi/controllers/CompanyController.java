package com.raffdevs.tecjobsapi.controllers;

import com.raffdevs.tecjobsapi.dtos.CreateCompanyDTO;
import com.raffdevs.tecjobsapi.dtos.UpdateCompanyDTO;
import com.raffdevs.tecjobsapi.models.CompanyModel;
import com.raffdevs.tecjobsapi.services.CompanyService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping(value = "company")
public class CompanyController {
    @Autowired
    private CompanyService service;

    @GetMapping(produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<List<CompanyModel>> findAll() {
        List<CompanyModel> companies = this.service.findAll();
        return ResponseEntity.ok().body(companies);
    }

    @GetMapping(
            value = "/{id}",
            produces = MediaType.APPLICATION_JSON_VALUE
    )
    public ResponseEntity<CompanyModel> findById(@PathVariable Long id) {
        CompanyModel company = this.service.findById(id);
        return ResponseEntity.ok().body(company);
    }

    @PostMapping(
            produces = MediaType.APPLICATION_JSON_VALUE,
            consumes = MediaType.APPLICATION_JSON_VALUE
    )
    public ResponseEntity<CompanyModel> create(@RequestBody CreateCompanyDTO data) {
        CompanyModel company = this.service.create(data);
        return ResponseEntity.ok(company);
    }

    @PutMapping(
            produces = MediaType.APPLICATION_JSON_VALUE,
            consumes = MediaType.APPLICATION_JSON_VALUE
    )
    public ResponseEntity<CompanyModel> update(
            @RequestBody UpdateCompanyDTO data
    ) {
        CompanyModel company = this.service.update(data);
        return ResponseEntity.ok(company);
    }

    @DeleteMapping(value = "/{id}")
    public ResponseEntity<?> delete(@PathVariable Long id) {
        this.service.delete(id);
        return ResponseEntity.noContent().build();
    }


}
