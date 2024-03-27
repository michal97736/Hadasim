using HadasimCovid.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HadasimCovid.Repository.Entity
{
	public class MyDbContext : DbContext, IContext
	{

		public DbSet<Member> Members { get; set; }
		public DbSet<CovidDetails> CovidDetails { get; set; }
		public DbSet<Vaccination> Vaccinations { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"server=(localDb)\msSQlLocalDb;database=HadasimCovid;Trusted_Connection=True");
		}
		protected override void OnModelCreating(ModelBuilder modelbulider)
		{
			base.OnModelCreating(modelbulider);

		}
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
		{
		}
	}
}
