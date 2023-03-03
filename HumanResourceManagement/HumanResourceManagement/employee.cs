using System;
using Microsoft.EntityFrameworkCore;
namespace HumanResourceManagement
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
