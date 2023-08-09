package com.example.backendspring.models;

import jakarta.persistence.Column;
import jakarta.persistence.Id;
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
public class AppointmentDTO {

    private String id;
    private LocalDateTime startTime;

    private LocalDateTime endTime;

    private String name;

    private String discipline;
}

