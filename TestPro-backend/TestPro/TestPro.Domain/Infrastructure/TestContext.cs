using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPro.Domain.Entities;

namespace TestPro.Domain.Infrastructure
{
    public class TestContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }
    }
}
