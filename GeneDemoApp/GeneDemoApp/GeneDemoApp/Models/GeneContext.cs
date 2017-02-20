using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GeneDemoApp.Models
{
    public class GeneContext : DbContext
    {
        public GeneContext() : base("name=GeneModel")
        {

        }

        public virtual DbSet<Status> Statuses { get; set; }

        public virtual DbSet<Sample> Samples { get; set; }

        public virtual DbSet<User> Users { get; set; }

    }
}