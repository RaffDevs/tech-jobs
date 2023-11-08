package com.raffdevs.tecjobsapi.repositories;

import com.raffdevs.tecjobsapi.entities.Employment;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface EmploymentRepository extends JpaRepository<Employment, Long> { }
