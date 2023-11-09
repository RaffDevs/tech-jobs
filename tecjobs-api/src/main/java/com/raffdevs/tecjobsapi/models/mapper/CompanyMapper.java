package com.raffdevs.tecjobsapi.models.mapper;

import com.raffdevs.tecjobsapi.entities.Company;
import com.raffdevs.tecjobsapi.models.CompanyModel;

public class CompanyMapper {
    public static CompanyModel parseToModel(Company entity) {
        return new CompanyModel(
                entity.getId(),
                entity.getName(),
                entity.getAbout_us(),
                entity.getEmployments()
        );
    }

    public static Company parseToEntity(CompanyModel model) {
        var company = new Company();
        company.setId(model.getId());
        company.setName(model.getName());
        company.setAboutUs(model.getAbout_us());
        company.setEmployments(model.getEmployments());

        return company;
    }
}
