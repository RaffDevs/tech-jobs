package com.raffdevs.tecjobsapi.models;

import com.raffdevs.tecjobsapi.entities.Company;

import java.time.Instant;

public class EmploymentModel {
    private final Long id;
    private final String title;
    private final String description;

    private final String requirements;
    private final Integer qtPositions;
    private final Instant publishedAt;
    private final Company company;

    public EmploymentModel(Long id, String title, String description, String requirements, Integer qtPositions, Instant publishedAt, Company company) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.requirements = requirements;
        this.qtPositions = qtPositions;
        this.publishedAt = publishedAt;
        this.company = company;
    }

    public Long getId() {
        return id;
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

    public Instant getPublishedAt() {
        return publishedAt;
    }

    public Company getCompany() {
        return company;
    }
}
