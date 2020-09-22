using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector.Models.ViewModels
{
    public class CustomerAddress
    {
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        public string FullAddress { get; set; }
    }
}
