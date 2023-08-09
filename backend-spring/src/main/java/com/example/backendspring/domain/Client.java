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
@Table(name = "Clients")
@Entity
public class Client {
    @Id
    @Column(name = "Id")
    private UUID id;

    @Column(name = "DisplayName")
    private String DisplayName;
}
