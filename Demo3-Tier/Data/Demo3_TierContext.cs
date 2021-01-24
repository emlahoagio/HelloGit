using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Demo3_Tier.Data
{
    public class Demo3_TierContext : DbContext
    {
        public Demo3_TierContext (DbContextOptions<Demo3_TierContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Entities.Student> Student { get; set; }
    }
}
