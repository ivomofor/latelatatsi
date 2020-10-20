using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Pilot.Models
{
    public class CasualEmployee
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
        [DisplayName("Select Role")]
        public string Role { get; set; }
        [DisplayName("Chose Rate Per Hour")]
        [Range(1, 12, ErrorMessage = "Chose a number between 1 ... 12")]
        public int RatePerHour { get; set; }
        [DisplayName("Chose Task")]
        public string Task { get; set; }
    }
}
