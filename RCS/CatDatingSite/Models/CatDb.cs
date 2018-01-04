using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatDatingSite.Models
{
    using System.Data.Entity;
    public class CatDb : DbContext
    {
        public DbSet<CatProfile> CatProfiles { get; set; }
    }
}