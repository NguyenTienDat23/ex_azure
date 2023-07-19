package com.example.ticketmanagementsystem.entity;

import javax.persistence.*;
import java.sql.Date;

@Entity
@Table(name = "tickets")
public class Ticket {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    public int id;

    @Column(name = "time")
    public Date time;

    @Column(name = "price")
    public Double price;

    @Column(name = "type")
    public String type;

    @Column(name = "detail")
    public String detail;

    public Ticket() {

    }

    public Ticket(int id, Date time, Double price, String type, String detail) {
        this.id = id;
        this.time = time;
        this.price = price;
        this.type = type;
        this.detail = detail;
    }

    public Ticket(Date time, Double price, String type, String detail) {
        this.time = time;
        this.price = price;
        this.type = type;
        this.detail = detail;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Date getTime() {
        return time;
    }

    public void setTime(Date time) {
        this.time = time;
    }

    public Double getPrice() {
        return price;
    }

    public void setPrice(Double price) {
        this.price = price;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getDetail() {
        return detail;
    }

    public void setDetail(String detail) {
        this.detail = detail;
    }
}
