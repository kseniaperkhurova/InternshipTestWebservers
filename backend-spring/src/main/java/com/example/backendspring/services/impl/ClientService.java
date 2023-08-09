package com.example.backendspring.services.impl;

import com.example.backendspring.domain.Client;
import com.example.backendspring.repository.ClientRepository;
import com.example.backendspring.services.IClientService;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@RequiredArgsConstructor
public class ClientService implements IClientService {
    private final ClientRepository clientRepository;
    @Override
    public List<Client> findAllClients() {
        return clientRepository.findAll().stream().toList();
    }
}
