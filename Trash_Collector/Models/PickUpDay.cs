﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector.Models
{
    public class PickUpDay
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "Pickup Day")]
        public string Date { get; set; }


    }
}
