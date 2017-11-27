using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework5.Models
{
    public class DMVForm
    {
        [Required]
        public int ID { get; set; }

        public int ODL { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "Full Legals Name")]
        public string name { get; set; }

        public string street { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public int zip { get; set; }

        public string country { get; set; }




        public override string ToString()
        {
            return $"{base.ToString()}: Name = {name} DOB = {DOB}";
        }
    }

}