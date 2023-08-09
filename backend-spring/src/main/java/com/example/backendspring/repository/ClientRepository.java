package com.example.backendspring.repository;

import com.example.backendspring.domain.Client;
import org.springframework.data.jpa.repository.JpaRepository;

import org.springframework.stereotype.Repository;


import java.util.Optional;
import java.util.UUID;

@Repository
public interface ClientRepository extends JpaRepository<Client, UUID> {
    Optional<Client> findClientById(UUID id);



}
