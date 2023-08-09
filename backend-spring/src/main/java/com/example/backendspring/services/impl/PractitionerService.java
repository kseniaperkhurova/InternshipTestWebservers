package com.example.backendspring.services.impl;

import com.example.backendspring.domain.Practitioner;
import com.example.backendspring.models.PractitionerRequest;
import com.example.backendspring.repository.PractitionerRepository;
import com.example.backendspring.services.IPractitionerService;
import jakarta.transaction.Transactional;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.UUID;

@Service
@RequiredArgsConstructor
@Slf4j
public class PractitionerService implements IPractitionerService {

    private final PractitionerRepository practitionerRepository;


    @Override
    public List<Practitioner> findAllPractitioners() {
        return practitionerRepository.findAll().stream().toList();
    }

    @Transactional
    @Override
    public String addPractitioner(PractitionerRequest practitionerRequest) {
        try{
            isRequestValid(practitionerRequest);
            Practitioner newPractitioner = Practitioner.builder().displayName(practitionerRequest.getDisplayName()).discipline(practitionerRequest.getDiscipline()).build();
            Practitioner savedPractitioner = practitionerRepository.save(newPractitioner);
            String id = savedPractitioner.getId().toString();
            if(id == null){
                throw new Exception("Practitioner is not created");
            }
            return id;

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void deletePractitioner(String id) {
        try{
            isStringParameterValid(id);
            Practitioner practitionerToBeDelete = isPractitionerExist(id);
            practitionerRepository.delete(practitionerToBeDelete);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }

    }
    @Transactional
    @Override
    public void updatePractitioner(String id, PractitionerRequest practitionerRequest) {
        try{
            isStringParameterValid(id);
            isRequestValid(practitionerRequest);
            Practitioner practitionerToBeUpdate = isPractitionerExist(id);
            practitionerToBeUpdate.setDiscipline(practitionerRequest.getDiscipline());
            practitionerToBeUpdate.setDisplayName(practitionerRequest.getDisplayName());
            practitionerRepository.save(practitionerToBeUpdate);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }

    }

    private void isRequestValid(PractitionerRequest practitionerRequest) throws Exception {
        isStringParameterValid(practitionerRequest.getDisplayName());
        isStringParameterValid(practitionerRequest.getDiscipline());

    }

    private void isStringParameterValid(String value) throws Exception {
        if(value == null || value.isEmpty()){
            throw new Exception("Value can not be null or empty");
        }
    }
    private  Practitioner isPractitionerExist(String id) throws Exception {
        Optional<Practitioner> practitioner = practitionerRepository.findById(UUID.fromString(id));
        if(practitioner.isEmpty()){
            throw new Exception("Practitioner is not exist");
        }else{
            return  practitioner.get();
        }
    }
}
