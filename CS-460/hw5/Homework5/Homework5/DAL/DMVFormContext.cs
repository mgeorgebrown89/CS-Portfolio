using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Homework5.Models;

namespace Homework5.DAL
{
    public class DMVFormContext : DbContext
    {
        public DMVFormContext() : base("name=DMVdb")
        { }

        public virtual DbSet<DMVForm> forms { get; set; }

    }
} 