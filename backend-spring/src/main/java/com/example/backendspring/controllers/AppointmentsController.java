package com.example.backendspring.controllers;


import com.example.backendspring.domain.Client;
import com.example.backendspring.models.AppointmentDTO;
import com.example.backendspring.services.IAppointmentsService;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.data.repository.query.Param;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@Slf4j
@RequiredArgsConstructor
@RequestMapping("/api/appointments")
public class AppointmentsController {

    private final IAppointmentsService appointmentsService;


    @GetMapping
    public ResponseEntity<String> test(){
        return  new ResponseEntity<>("Hello", HttpStatus.OK);
    }
    @GetMapping("/client/")
    public ResponseEntity<List<AppointmentDTO>>
        getAllClientsAppointmentsForTimeRange(@RequestParam("id") String id, @RequestParam("startDate") String startDate, @RequestParam("endDate") String endDate){
        log.info(id +  " " + startDate + " " + endDate);
        return  new ResponseEntity<>(appointmentsService.getAllClientsAppointmentsForTimeRange(id, startDate, endDate), HttpStatus.OK);
    }
    @GetMapping("/practitioner/")
    public ResponseEntity<List<AppointmentDTO>> getAllPractitionersAppointmentsForTimeRange(@RequestParam("id") String id, @RequestParam("startDate") String startDate, @RequestParam("endDate") String endDate){
        log.info(id +  " " + startDate + " " + endDate);
        return  new ResponseEntity<>(appointmentsService.getAllPractitionersAppointmentsForTimeRange(id, startDate, endDate), HttpStatus.OK);
    }
}
