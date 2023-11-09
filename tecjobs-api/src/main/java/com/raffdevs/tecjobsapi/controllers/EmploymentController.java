package com.raffdevs.tecjobsapi.controllers;

import com.raffdevs.tecjobsapi.dtos.CreateEmploymentDTO;
import com.raffdevs.tecjobsapi.dtos.UpdateEmploymentDTO;
import com.raffdevs.tecjobsapi.models.EmploymentModel;
import com.raffdevs.tecjobsapi.services.EmploymentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping(value = "employments")
public class EmploymentController {

    @Autowired
    private EmploymentService service;
    @GetMapping(
            produces = MediaType.APPLICATION_JSON_VALUE
    )
    public ResponseEntity<List<EmploymentModel>> findAll() {
        List<EmploymentModel> employments = this.service.findAll();
        return ResponseEntity.ok(employments);
    }

    @GetMapping(value = "/{id}")
    public ResponseEntity<EmploymentModel> findById(@PathVariable Long id) {
        EmploymentModel employment = this.service.findById(id);
        return ResponseEntity.ok(employment);
    }

    @PostMapping(
            produces = MediaType.APPLICATION_JSON_VALUE,
            consumes = MediaType.APPLICATION_JSON_VALUE
    )
    public ResponseEntity<EmploymentModel> create(@RequestBody CreateEmploymentDTO data) {
        EmploymentModel employment = service.create(data);
        return ResponseEntity.ok(employment);
    }

    @PutMapping(
            produces = MediaType.APPLICATION_JSON_VALUE,
            consumes = MediaType.APPLICATION_JSON_VALUE
    )
    public ResponseEntity<EmploymentModel> update(@RequestBody UpdateEmploymentDTO data) {
        EmploymentModel employment = this.service.update(data);
        return ResponseEntity.ok(employment);
    }

    @DeleteMapping(value = "/{id}")
    public ResponseEntity<?> delete(@PathVariable Long id) {
        this.service.delete(id);
        return ResponseEntity.noContent().build();
    }
}
