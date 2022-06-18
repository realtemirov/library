using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Models
{
    public class Person
    {
        public string Name { get; set; }

        public Address Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public override string ToString()
        {
            return $"\n\t\t\t\t#\tName: {Name} \n\t\t\t\t#\tAddress: {Address.ToString()} \n\t\t\t\t#\tEmail: {Email} \n\t\t\t\t#\tPhone: {Phone}";
        }
    }
}
