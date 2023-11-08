package com.raffdevs.tecjobsapi.controllers;

import com.raffdevs.tecjobsapi.dtos.CreateEmploymentDTO;
import com.raffdevs.tecjobsapi.dtos.UpdateEmploymentDTO;
import com.raffdevs.tecjobsapi.entities.Employment;
import com.raffdevs.tecjobsapi.services.EmploymentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.print.attribute.standard.Media;
import java.util.List;

@RestController
@RequestMapping(value = "employments")
public class EmploymentController {

    @Autowired
    private EmploymentService service;
    @GetMapping(
            produces = MediaType.APPLICATION_JSON_VALUE
    )
    public ResponseEntity<List<Employment>> findAll() {
        List<Employment> employments = this.service.findAll();
        return ResponseEntity.ok(employments);
    }

    @GetMapping(value = "/{id}")
    public ResponseEntity<Employment> findById(@PathVariable Long id) {
        Employment employment = this.service.findById(id);
        return ResponseEntity.ok(employment);
    }

    @PostMapping(
            produces = MediaType.APPLICATION_JSON_VALUE,
            consumes = MediaType.APPLICATION_JSON_VALUE
    )
    public ResponseEntity<Employment> create(@RequestBody CreateEmploymentDTO data) {
        Employment employment = service.create(data);
        return ResponseEntity.ok(employment);
    }

    @PutMapping(
            produces = MediaType.APPLICATION_JSON_VALUE,
            consumes = MediaType.APPLICATION_JSON_VALUE
    )
    public ResponseEntity<Employment> update(@RequestBody UpdateEmploymentDTO data) {
        Employment employment = this.service.update(data);
        return ResponseEntity.ok(employment);
    }

    @DeleteMapping(value = "/{id}")
    public ResponseEntity<?> delete(@PathVariable Long id) {
        this.service.delete(id);
        return ResponseEntity.noContent().build();
    }
}
