using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } // how to parse this from user registration from the Name input?
        public string LastName { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public double CurrentBalance { get; set; } // monthly balance - how would this show past due balance for a new month?
        public string PickupDay { get; set; }

        public bool IsSuspended { get; set; }
        public string SuspendStartDate { get; set; }
        public string SuspendEndDate { get; set; }


    }
}
