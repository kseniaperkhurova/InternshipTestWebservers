package com.example.backendspring.services.impl;

import com.example.backendspring.domain.Appointment;
import com.example.backendspring.domain.Client;
import com.example.backendspring.domain.Practitioner;
import com.example.backendspring.models.AppointmentDTO;
import com.example.backendspring.repository.AppointmentsRepository;
import com.example.backendspring.repository.ClientRepository;
import com.example.backendspring.repository.PractitionerRepository;
import com.example.backendspring.services.IAppointmentsService;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

@Service
@Slf4j
@RequiredArgsConstructor
public class AppointmentsService implements IAppointmentsService {
    private final ClientRepository clientRepository;
    private final PractitionerRepository practitionerRepository;
    private  final AppointmentsRepository appointmentsRepository;

    @Override
    public List<AppointmentDTO> getAllClientsAppointmentsForTimeRange(String clientId, String startDate, String endDate) {
       try{
          UUID id = isValidId(clientId);
          LocalDateTime sd = isDateValid(startDate);
          LocalDateTime ed = isDateValid(endDate);
          Client client = getClient(id);
           return appointmentsRepository.findAll().stream()
                   .filter(a-> a.getClientId().equals(client.getId()) && a.getDate().isAfter(sd) && a.getDate().isBefore(ed))
                   .map(a-> {
                       try {
                           return createAppointmentDTOForClient(a, a.getPractitionerId());
                       } catch (Exception e) {
                           throw new RuntimeException(e);
                       }
                   }).toList();
       }catch (Exception ex){
           log.info(ex.getMessage());
           return new ArrayList<>();
       }

    }

    @Override
    public List<AppointmentDTO> getAllPractitionersAppointmentsForTimeRange(String practitionerId, String startDate, String endDate) {
        try{
            UUID id = isValidId(practitionerId);
            LocalDateTime sd = isDateValid(startDate);
            LocalDateTime ed = isDateValid(endDate);
            Practitioner practitioner = getPractitioner(id);
            return appointmentsRepository.findAll().stream()
                    .filter(a-> a.getPractitionerId().equals(id) && a.getDate().isAfter(sd) && a.getDate().isBefore(ed))
                    .map(a-> {
                        try {
                            return createAppointmentDTOForPractitioner(a, a.getClientId(), practitioner);
                        } catch (Exception e) {
                            throw new RuntimeException(e);
                        }
                    }).toList();
        }catch (Exception ex){
            log.info(ex.getMessage());
            return new ArrayList<>();
        }
    }
    private UUID isValidId(String id) throws Exception {
        if(id == null || id.isEmpty()){
            throw  new Exception("Id can not be empty or null");
        }
        return UUID.fromString(id);
    }
    private LocalDateTime isDateValid(String date) throws Exception {
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd");
        if(date == null || date.isEmpty()){
            throw  new Exception("date can not be empty or null");
        }
        LocalDate date1 = LocalDate.parse(date, formatter);
        return LocalDateTime.of(date1.getYear(), date1.getMonth(), date1.getDayOfMonth(), 0, 0, 0);
    }
    private AppointmentDTO createAppointmentDTOForClient(Appointment appointment, UUID practitionerId) throws Exception {
        Practitioner practitioner = getPractitioner(practitionerId);
        return AppointmentDTO.builder()
                .id(appointment.getId().toString())
                .startTime( createNewDate(appointment.getDate(), appointment.getStartTime()))
                .endTime(createNewDate(appointment.getDate(), appointment.getEndTime()))
                .name(practitioner.getDisplayName())
                .discipline(practitioner.getDiscipline())
                .build();
    }
    private AppointmentDTO createAppointmentDTOForPractitioner(Appointment appointment, UUID clientId, Practitioner practitioner) throws Exception {
        Client client = getClient(clientId);
        return AppointmentDTO.builder()
                .id(appointment.getId().toString())
                .startTime( createNewDate(appointment.getDate(), appointment.getStartTime()))
                .endTime(createNewDate(appointment.getDate(), appointment.getEndTime()))
                .name(client.getDisplayName())
                .discipline(practitioner.getDiscipline())
                .build();
    }
    private LocalDateTime createNewDate(LocalDateTime date, LocalDateTime time){
        return LocalDateTime.of(date.getYear(), date.getMonth(), date.getDayOfMonth(), time.getHour(), time.getMinute(), time.getSecond());
    }
    private Client getClient(UUID id) throws Exception {
        log.info("id of client is " + id.toString());
        Optional<Client> client = clientRepository.findClientById(id);
        if(client.isEmpty()){
            log.info("client is not here");
            throw  new Exception("Client is not exist");
        }
        return  client.get();
    }
    private Practitioner getPractitioner(UUID id) throws Exception {
        Optional<Practitioner> practitioner = practitionerRepository.findById(id);
        if(practitioner.isEmpty()){
            throw  new Exception("Practitioner is not exist");
        }
        return practitioner.get();
    }
}
