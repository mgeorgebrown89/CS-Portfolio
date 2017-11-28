namespace hw7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SearchRequest
    {
        public int ID { get; set; }

        [Required]
        [StringLength(256)]
        public string Request { get; set; }

        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(128)]
        public string IPAddress { get; set; }

        [Required]
        [StringLength(128)]
        public string BrowserClient { get; set; }
    }
}
