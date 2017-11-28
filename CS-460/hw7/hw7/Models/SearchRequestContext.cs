using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace hw7.Models
{
    public class SearchRequestContext : DbContext
    {
        public SearchRequestContext() : base("name=SearchRequest")
        { }

        public virtual DbSet<SearchRequest> SearchRequests { get; set; }
    }
}