using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector.Models.ViewModels
{
    public class CustomersByPickUpDay
    {
        public IEnumerable<Customer> Customers { get; set; }

        public SelectList PickUpDaySelections { get; set; }

        [Display(Name = "Select the pick up day you would like to view!")]
        public string PickUpDaySelection { get; set; }
    }
}
