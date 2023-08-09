package com.example.backendspring.domain;


import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
@Table(name = "Practitioners")
@Entity
public class Practitioner {
    @Id
    @GeneratedValue
    @Column(name = "Id")
    private UUID id;

    @Column(name = "DisplayName")
    private String displayName;

    @Column(name="Discipline")
    private  String discipline;
}
