package com.example.backendspring.controllers;

import com.example.backendspring.domain.Client;
import com.example.backendspring.services.IClientService;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@Slf4j
@RequiredArgsConstructor
@RequestMapping("/api/clients")
public class ClientController {
    private final IClientService clientService;

    @GetMapping
    public ResponseEntity<List<Client>> getAllClients(){
        return  new ResponseEntity<>(clientService.findAllClients(), HttpStatus.OK);
    }
}
