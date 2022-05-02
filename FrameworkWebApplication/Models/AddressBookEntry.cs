using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrameworkWebApplication.Controllers
{
    public class AddressBookEntry
    {
        public string Id { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("E-Mail Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("Telephone Number")]
        public string TelephoneNumber { get; set; }
    }
}