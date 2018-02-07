using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompany.Models
{
    public class InformationPassenger
    {
        public int InformationPassengerId { get; set; }

        [Required(ErrorMessage = "Name Passenger is required")]
        [StringLength(20)]
        public string NamePassenger { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime BirthdatePassenger { get; set; }

        [Required(ErrorMessage = "CNP is required")]
        [StringLength(13)]
        public long CNP { get; set; }
    }
}