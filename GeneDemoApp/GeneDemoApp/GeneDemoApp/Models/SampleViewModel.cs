using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneDemoApp.Models
{
    public class SampleViewModel
    {
        public int SampleId { get; set; }
        public string Barcode { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }

    }
}