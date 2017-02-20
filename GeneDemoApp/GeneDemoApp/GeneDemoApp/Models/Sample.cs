namespace GeneDemoApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sample
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SampleId { get; set; }

        [Required]
        [StringLength(100)]
        public string Barcode { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

        public virtual User User { get; set; }
    }
}
