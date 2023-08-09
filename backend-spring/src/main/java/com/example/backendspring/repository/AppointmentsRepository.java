package com.example.backendspring.repository;

import com.example.backendspring.domain.Appointment;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.UUID;

@Repository
public interface AppointmentsRepository extends JpaRepository<Appointment, UUID> {
}
