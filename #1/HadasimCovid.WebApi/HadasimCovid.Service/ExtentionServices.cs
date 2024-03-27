using HadasimCovid.Repository.Entity;
using HadasimCovid.Repository.HadasimCovid.Repository;
using HadasimCovid.Repository.Interface;
using HadasimCovid.Service.Interface;
using HadasimCovid.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HadasimCovid.Service
{
	public static class ExtentionServices
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<ICrudService<Member>, MemberService>();
			services.AddScoped<ICrudService<CovidDetails>, CovidDetailsService>();
			services.AddScoped<ICrudService<Vaccination>, VaccinationService>();
			//services.AddSingleton<IContext, MyDbContext>();


			return services;
		}
	}
}