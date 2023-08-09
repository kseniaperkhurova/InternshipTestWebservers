package com.example.backendspring.services;

import com.example.backendspring.models.AppointmentDTO;

import java.util.List;

public interface IAppointmentsService {

    List<AppointmentDTO> getAllClientsAppointmentsForTimeRange(String clientId, String startDate, String endDate);
    List<AppointmentDTO> getAllPractitionersAppointmentsForTimeRange(String practitionerId, String startDate, String endDate);

}
