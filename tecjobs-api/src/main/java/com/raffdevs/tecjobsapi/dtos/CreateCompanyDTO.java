package com.raffdevs.tecjobsapi.dtos;

import java.io.Serializable;

public class CreateCompanyDTO implements Serializable {
    final private String name;
    final private String aboutUs;

    public CreateCompanyDTO(String name, String aboutUs) {
        this.name = name;
        this.aboutUs = aboutUs;
    }

    public String getName() {
        return name;
    }

    public String getAboutUs() {
        return aboutUs;
    }
}
