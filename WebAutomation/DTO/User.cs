using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomation.DTO
{
    public class User
    {

        public User()
        {
            Adress = new Address();
            Phone = new Phone();
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderTitle { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateOfBirthDay { get; set; }
        public string DateOfBirthMonth { get; set; }
        public string DateOfBirthYear { get; set; }

        public Address Adress { get; set; }
        public Phone Phone { get; set; }

    }
}
