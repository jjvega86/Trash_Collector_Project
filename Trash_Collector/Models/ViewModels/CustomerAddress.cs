using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector.Models.ViewModels
{
    public class CustomerAddress
    {
        public string StreetAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
    }
}
