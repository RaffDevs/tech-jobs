package com.raffdevs.tecjobsapi.entities;

import javax.persistence.*;
import java.io.Serializable;
import java.time.Instant;

@Entity
@Table(name = "employment")
public class Employment implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Column(nullable = false)
    private String title;
    @Column(nullable = false)
    private String description;
    @Column(nullable = false)

    private String requirements;
    @Column(name = "qt_positions", nullable = false)
    private Integer qtPositions;
    private Instant publishedAt;
    @ManyToOne()
    @JoinColumn(name = "company_id")
    private Company company;

    public Employment() {}

    public Long getId() {
        return id;
    }


    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }


    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }


    public String getRequirements() {
        return requirements;
    }

    public void setRequirements(String requirements) {
        this.requirements = requirements;
    }


    public Integer getQt_positions() {
        return qtPositions;
    }

    public void setQtPositions(Integer qtPositions) {
        this.qtPositions = qtPositions;
    }

    public Instant getPublishedAt() {
        return publishedAt;
    }

    public void setPublishedAt(Instant publishedAt) {
        this.publishedAt = publishedAt;
    }

    public Company getCompany() {
        return company;
    }


    public void setCompany(Company company) {
        this.company = company;
    }
}
