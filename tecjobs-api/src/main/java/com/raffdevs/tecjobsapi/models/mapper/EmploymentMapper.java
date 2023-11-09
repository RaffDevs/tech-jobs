package com.raffdevs.tecjobsapi.models.mapper;

import com.raffdevs.tecjobsapi.entities.Employment;
import com.raffdevs.tecjobsapi.models.EmploymentModel;

public class EmploymentMapper {
    public static EmploymentModel parseToModel(Employment entity) {
        return new EmploymentModel(
                entity.getId(),
                entity.getTitle(),
                entity.getDescription(),
                entity.getRequirements(),
                entity.getQt_positions(),
                entity.getPublishedAt(),
                entity.getCompany()
        );
    }
}
