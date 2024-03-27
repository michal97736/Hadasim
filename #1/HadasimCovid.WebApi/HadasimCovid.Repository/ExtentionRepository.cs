using HadasimCovid.Repository.Entity;
using HadasimCovid.Repository.Interface;
using HadasimCovid.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadasimCovid.Repository
{

	namespace HadasimCovid.Repository
	{
		public static class ExtentionRepository
		{
			public static IServiceCollection AddRepository(this IServiceCollection services)
			{
				services.AddScoped<ICrud<Member>, MemberRepository>();
				services.AddScoped<ICrud<Vaccination>, VaccinationRepository>();
				services.AddScoped<ICrud<CovidDetails>, CovidDetailsRepository>();
				return services;
			}
		}
	}
}
