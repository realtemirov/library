using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Models
{
    public class Address
    {
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"{StreetAddress}, {City}, \n\t\t\t\t#\t{State}, {ZipCode}, {Country}";
        }
    }

    
}
