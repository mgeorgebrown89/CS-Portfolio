using Homework5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Homework5.DAL
{
    public class DMVcontext : DbContext
    {
        public DMVcontext() : base("name=DMVContext")
        { }

        public virtual DbSet<DMVform> DMVforms { get; set; }
    }
}