package com.example.backendspring.controllers;

import com.example.backendspring.domain.Client;
import com.example.backendspring.domain.Practitioner;
import com.example.backendspring.models.PractitionerRequest;
import com.example.backendspring.services.IClientService;
import com.example.backendspring.services.IPractitionerService;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@Slf4j
@RequiredArgsConstructor
@RequestMapping("/api/practitioners")
public class PractitionerController {
    private final IPractitionerService practitionerService;

    @GetMapping
    public ResponseEntity<List<Practitioner>> getAllPractitioners(){
        return  new ResponseEntity<>(practitionerService.findAllPractitioners(), HttpStatus.OK);
    }
    @PostMapping
    public ResponseEntity<String> addPractitioner(@RequestBody PractitionerRequest practitionerRequest){
        return  new ResponseEntity<>(practitionerService.addPractitioner(practitionerRequest), HttpStatus.CREATED);
    }
    @DeleteMapping
    public ResponseEntity<Void> deletePractitioner(@RequestParam String id){
        practitionerService.deletePractitioner(id);
        return  new ResponseEntity<>( HttpStatus.OK);
    }
    @PutMapping
    public ResponseEntity<Void> updatePractitioner(@RequestParam String id, @RequestBody PractitionerRequest practitionerRequest){
        practitionerService.updatePractitioner(id, practitionerRequest);
        return  new ResponseEntity<>( HttpStatus.ACCEPTED);
    }
}
