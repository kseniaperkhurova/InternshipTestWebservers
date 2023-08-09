package com.example.backendspring.services;

import com.example.backendspring.domain.Client;

import java.util.List;

public interface IClientService {

    List<Client> findAllClients();
}
