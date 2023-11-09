package com.raffdevs.tecjobsapi.dtos;

import com.raffdevs.tecjobsapi.entities.Company;

import javax.persistence.Column;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import java.io.Serializable;
import java.time.Instant;

public class CreateEmploymentDTO implements Serializable {
    final private String title;
    final private String description;
    final private String requirements;
    final private Integer qtPositions;
    final private Long companyId;

    public CreateEmploymentDTO(String title, String description, String requirements, Integer qtPositions, Long companyId) {
        this.title = title;
        this.description = description;
        this.requirements = requirements;
        this.qtPositions = qtPositions;
        this.companyId = companyId;
    }

    public String getTitle() {
        return title;
    }

    public String getDescription() {
        return description;
    }

    public String getRequirements() {
        return requirements;
    }

    public Integer getQtPositions() {
        return qtPositions;
    }

    public Long getcompanyId() {
        return companyId;
    }
}
