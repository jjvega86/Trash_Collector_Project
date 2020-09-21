using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trash_Collector.Models;

namespace Trash_Collector.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PickUpDay> PickUpDays { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<IdentityRole>()
        //        .HasData(
        //            new IdentityRole
        //            {
        //                Name = "Customer",
        //                NormalizedName = "CUSTOMER"
        //            }


        //        );

        //    builder.Entity<IdentityRole>()
        //        .HasData(
        //            new IdentityRole
        //            {
        //                Name = "Employee",
        //                NormalizedName = "EMPLOYEE"
        //            }


        //        );

        //    builder.Entity<PickUpDay>()
        //        .HasData(
        //        new PickUpDay
        //        {
        //            Id = 1,
        //            Date = "Monday"
        //        },
        //        new PickUpDay
        //        {
        //            Id = 2,
        //            Date = "Tuesday"
        //        },
        //        new PickUpDay
        //        {
        //            Id = 3,
        //            Date = "Wednesday"
        //        },
        //        new PickUpDay
        //        {
        //            Id = 4,
        //            Date = "Thursday"
        //        },
        //        new PickUpDay
        //        {
        //            Id = 5,
        //            Date = "Friday"
        //        }

        //        );

        //}
    }
}
