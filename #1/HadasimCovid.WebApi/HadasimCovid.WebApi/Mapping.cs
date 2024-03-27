using AutoMapper;
using HadasimCovid.Repository.Entity;
using HadasimCovid.WebApi.Models;

namespace HadasimCovid.WebApi
{
	public class Mapping : Profile
	{
		public Mapping()
		{
			CreateMap<Member, MemberModel>().ReverseMap();
			CreateMap<CovidDetails, CovidDetailsModel>().ReverseMap();
			CreateMap<Vaccination, VaccinationModel>().ReverseMap();

		}
	}
}
