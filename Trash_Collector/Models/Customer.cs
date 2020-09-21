using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } // how to parse this from user registration from the Name input?

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]

        public string StreetAddress { get; set; }

        public string City { get; set; }


        public string State { get; set; }

        [Display(Name = "Zip Code")]

        public int ZipCode { get; set; }

        [Display(Name = "Current Balance")]

        public double CurrentBalance { get; set; } // monthly balance - how would this show past due balance for a new month?

        [ForeignKey("PickUpDay")]
        [Display(Name = "Pickup Day")]
        public int PickUpDayId { get; set; }
        public PickUpDay PickUpDay { get; set; }

        public DateTime? ExtraPickUpDay { get; set; }

        [NotMapped]
        public SelectList Days { get; set; }

      

        public bool IsSuspended { get; set; }
        public DateTime? SuspendStartDate { get; set; }
        public DateTime? SuspendEndDate { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

    }

  
}
