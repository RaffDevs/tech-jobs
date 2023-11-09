package com.raffdevs.tecjobsapi.repositories;

import com.raffdevs.tecjobsapi.entities.Company;
import org.springframework.data.jpa.repository.JpaRepository;

public interface CompanyRepository extends JpaRepository<Company, Long> { }
