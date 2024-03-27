using HadasimCovid.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadasimCovid.Repository.Interface
{
	public interface IContext
	{
		DbSet<Member> Members { get; set; }
		DbSet<CovidDetails> CovidDetails { get; set; }
		DbSet<Vaccination> Vaccinations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

	}
}
