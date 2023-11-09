package com.raffdevs.tecjobsapi.dtos;

import java.io.Serializable;

public class UpdateCompanyDTO implements Serializable {

    final private Long id;
    final private String name;
    final private String aboutUs;

    public UpdateCompanyDTO(Long id, String name, String aboutUs) {
        this.id = id;
        this.name = name;
        this.aboutUs = aboutUs;
    }

    public Long getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getAboutUs() {
        return aboutUs;
    }
}
