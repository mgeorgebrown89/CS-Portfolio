using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework5.Models
{
    public class DMVForm
    {
        [Key]
        public int ODL { get; set; }

        public DateTime DOB { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "Full Legals Name")]
        public string name { get; set; }

        public string street { get; set; }

        public string city { get; set; }

        public string state { get; set; }
        
        public int zip { get; set; }

        public string country { get; set; }
    }
}