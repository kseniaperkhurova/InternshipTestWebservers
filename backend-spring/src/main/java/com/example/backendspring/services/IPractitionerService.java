package com.example.backendspring.services;

import com.example.backendspring.domain.Client;
import com.example.backendspring.domain.Practitioner;
import com.example.backendspring.models.PractitionerRequest;

import java.util.List;

public interface IPractitionerService {
    List<Practitioner> findAllPractitioners();
    String addPractitioner(PractitionerRequest practitionerRequest);
    void deletePractitioner(String id);
    void updatePractitioner(String id, PractitionerRequest practitionerRequest);
}
