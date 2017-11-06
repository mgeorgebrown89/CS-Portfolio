using hw5b.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hw5b.DAL
{
    public class DMVFormContext : DbContext
    {
        public DMVFormContext() : base("name=OurDBContext")
        { }

        public virtual DbSet<DMVForm> DMVForms { get; set; }
    }
}