using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GeneDemoApp.Models;

namespace GeneDemoApp.Controllers
{
    public class SamplesAPIController : ApiController
    {
        private GeneModel db = new GeneModel();

        public IEnumerable<SampleViewModel> GetSamples()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var samples = db.Samples.Include(s => s.Status).Include(s => s.User)
                .Select(x=> new SampleViewModel{ SampleId = x.SampleId, Barcode = x.Barcode, CreatedAt = x.CreatedAt,
                                                 FirstName = x.User.FirstName, LastName = x.User.LastName,
                                                 Status = x.Status.Status1});
            return samples;
        }

        public IEnumerable<SampleViewModel> GetSamples(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var samples = db.Samples.Include(s => s.Status).Include(s => s.User).Where(y=>y.StatusId == id)
                .Select(x => new SampleViewModel
                {
                    SampleId = x.SampleId,
                    Barcode = x.Barcode,
                    CreatedAt = x.CreatedAt,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Status = x.Status.Status1
                });
            return samples;
        }

        public IEnumerable<SampleViewModel> GetSamples(string name)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var samples = db.Samples.Include(s => s.Status).Include(s => s.User).Where(y => y.User.FirstName.Contains(name) || y.User.LastName.Contains(name))
                .Select(x => new SampleViewModel
                {
                    SampleId = x.SampleId,
                    Barcode = x.Barcode,
                    CreatedAt = x.CreatedAt,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Status = x.Status.Status1
                });
            return samples;
        }

    }
}
