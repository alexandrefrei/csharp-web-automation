using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomation.DTO
{
    public class Address
    {

        public Address()
        {
            State = new Dictionary<string, string>();
            Country = new Dictionary<string, string>();
        }
            

        public string AddressFirstName { get; set; }
        public string AddressLastName { get; set; }
        public string Company { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public Dictionary<string, string > State { get; set; }

        public string PostalCode { get; set; }

        public Dictionary<string, string> Country { get; set; }

        public string AdditionalInformation { get; set; }

        public string AddressAlias { get; set; }


    }
}
