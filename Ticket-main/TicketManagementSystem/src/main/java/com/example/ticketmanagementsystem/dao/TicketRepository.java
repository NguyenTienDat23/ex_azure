package com.example.ticketmanagementsystem.dao;

import com.example.ticketmanagementsystem.entity.Ticket;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface TicketRepository extends JpaRepository<Ticket, Integer> {
    public List<Ticket> findAllByOrderByIdAsc();

//    public List<Ticket> findTicketById();
}
