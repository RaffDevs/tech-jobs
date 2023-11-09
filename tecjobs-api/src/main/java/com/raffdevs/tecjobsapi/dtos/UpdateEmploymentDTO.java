package com.raffdevs.tecjobsapi.dtos;

public class UpdateEmploymentDTO {
    final private Long id;
    final private String title;
    final private String description;
    final private String requirements;
    final private Integer qtPositions;
    final private Long companyId;

    public UpdateEmploymentDTO(Long id, String title, String description, String requirements, Integer qtPositions, Long companyId) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.requirements = requirements;
        this.qtPositions = qtPositions;
        this.companyId = companyId;
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

    public Long getCompanyId() {
        return companyId;
    }
}
