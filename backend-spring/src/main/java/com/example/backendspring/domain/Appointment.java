package com.example.backendspring.domain;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;
import java.util.UUID;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
@Table(name = "AgendaItems")
@Entity
public class Appointment {
    @Id
    @Column(name = "Id")
    private UUID id;
    @Column(name = "Date")
    private LocalDateTime date;

    @Column(name = "StartTime")
    private LocalDateTime startTime;

    @Column(name = "EndTime")
    private LocalDateTime endTime;


    @Column(name = "ClientId")
    private UUID clientId;

    @Column(name = "PractitionerId")
    private UUID practitionerId;
}
