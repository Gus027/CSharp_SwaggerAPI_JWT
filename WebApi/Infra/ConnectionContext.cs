﻿using Microsoft.EntityFrameworkCore;
using WebApi.Domain.model;

namespace WebApi.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         =>   optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=employee_simple;" +
                "User Id=postgres;" +
                "Password=123456;"
            );
        


    }
}
