namespace GeneDemoApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GeneModel : DbContext
    {
        public GeneModel()
            : base("name=GeneModel")
        {
        }

        public virtual DbSet<Sample> Samples { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>()
                .Property(e => e.Barcode)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Status1)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Samples)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Samples)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);
        }
    }
}
