using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hw5b.Models
{
    public class DMVForm
    {
        [Required]
        public int ID { get; set; }

        public int ODL { get; set; }

        public DateTime DOB { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "Full Legal Name")]
        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public string Country { get; set; }
    }
}