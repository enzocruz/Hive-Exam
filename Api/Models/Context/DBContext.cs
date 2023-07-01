using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Models;
namespace Api.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }
        public DbSet<Record> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().HasData(
                new Record()
                {
                    ID = 1,
                    Name = "Ankur",
                    Company = "IBM",
                    Project = "Payroll",
                    Role = "Software Engineer"

                },
                new Record()
                {
                    ID = 2,
                    Name = "Akash",
                    Company = "IBM",
                    Project = "Chat Bot",
                    Role = "Software Engineer"

                },
                new Record()
                {
                    ID = 3,
                    Name = "Priya",
                    Company = "HP",
                    Project = "VR Gaming",
                    Role = "Project Manager"

                },
                new Record()
                {
                    ID = 4,
                    Name = "Asha",
                    Company = "Microsoft",
                    Project = "Payroll",
                    Role = "Solution Architect"
                },
                new Record()
                {
                    ID = 5,
                    Name = "Nandini",
                    Company = "HP",
                    Project = "Payroll",
                    Role = "Software Engineer"
                },
                new Record()
                {
                    ID = 6,
                    Name = "Piyush",
                    Company = "Microsoft",
                    Project = "Payroll",
                    Role = "Delivery Manager"
                },
                new Record()
                {
                    ID = 7,
                    Name = "Ankur",
                    Company = "HP",
                    Project = "Chat Bot",
                    Role = "Lead Engineer"
                },
                new Record()
                {
                    ID = 8,
                    Name = "Akash",
                    Company = "HP",
                    Project = "VR Gaming",
                    Role = "Software Engineer"
                },
                new Record()
                {
                    ID = 9,
                    Name = "Priya",
                    Company = "IBM",
                    Project = "Payroll",
                    Role = "Solution Architect"
                },
                new Record()
                {
                    ID = 10,
                    Name = "Asha",
                    Company = "HP",
                    Project = "Chat Bot",
                    Role = "Project Manager"
                },
                new Record()
                {
                    ID = 11,
                    Name = "Nandini",
                    Company = "HP",
                    Project = "VR Gaming",
                    Role = "Lead Engineer"
                },
                new Record()
                {
                    ID = 12,
                    Name = "Piyush",
                    Company = "Microsoft",
                    Project = "Chat Bot",
                    Role = "Delivery Manager"
                }

            );

        }





    }
}