import { Component } from '@angular/core';
import { Employee } from '../../models/employee';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-employees',
  imports: [DatePipe],
  templateUrl: './employees.html',
  styleUrl: './employees.css',
})
export class Employees {
   employees:Employee[] = [
    {
      id: 101,
      name: "Ravi Kumar",
      salary: 55000,
      imageUrl: "https://randomuser.me/api/portraits/men/32.jpg",
      phoneNo: "9876543210",
      dateOfJoining: new Date("2022-03-15"),
      email: "ravi.kumar@company.com"
    },
    {
      id: 102,
      name: "Priya Sharma",
      salary: 62000,
      imageUrl: "https://randomuser.me/api/portraits/women/45.jpg",
      phoneNo: "9123456780",
      dateOfJoining: new Date("2021-11-20"),
      email: "priya.sharma@company.com"
    },
    {
      id: 103,
      name: "Amit Verma",
      salary: 48000,
      imageUrl: "https://randomuser.me/api/portraits/men/76.jpg",
      phoneNo: "9988776655",
      dateOfJoining: new Date("2021-11-20"),
      email: "amit.verma@company.com"
    },
    {
      id: 104,
      name: "Sneha Reddy",
      salary: 70000,
      imageUrl: "https://randomuser.me/api/portraits/women/68.jpg",
      phoneNo: "9090909090",
      dateOfJoining:new Date("2021-11-20"),
      email: "sneha.reddy@company.com"
    },
    {
      id: 105,
      name: "Arjun Mehta",
      salary: 85000,
      imageUrl: "https://randomuser.me/api/portraits/men/12.jpg",
      phoneNo: "9345678123",
      dateOfJoining: new Date("2021-11-20"),
      email: "arjun.mehta@company.com"
    }
  ];
}
