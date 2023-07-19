package com.example.ticketmanagementsystem.service;

import com.example.ticketmanagementsystem.entity.Ticket;

import java.util.List;

public interface TicketService {
    public List<Ticket> getAllTicket();
    public Ticket getTicketById(int theId);
    public void save(Ticket theTicket);
    public void deleteTicket(int theId);
//    public List<Ticket> searchTicketById(int theId);
}
