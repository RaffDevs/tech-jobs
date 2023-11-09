package com.raffdevs.tecjobsapi.models;

import com.raffdevs.tecjobsapi.entities.Employment;

import java.util.List;

public class CompanyModel {
    final private Long id;
    final private String name;
    final private String aboutUs;
    final private List<Employment> employments;

    public CompanyModel(Long id, String name, String aboutUs, List<Employment> employments) {
        this.id = id;
        this.name = name;
        this.aboutUs = aboutUs;
        this.employments = employments;
    }

    public Long getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getAbout_us() {
        return aboutUs;
    }

    public List<Employment> getEmployments() {
        return employments;
    }

}
