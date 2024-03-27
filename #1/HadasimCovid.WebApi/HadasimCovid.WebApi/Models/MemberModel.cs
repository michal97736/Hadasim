using System.ComponentModel.DataAnnotations;

namespace HadasimCovid.WebApi.Models
{
	public class MemberModel
	{
		public int IdMember { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public int? Tz { get; set; }
		public string? City { get; set; }
		public string? Street { get; set; }
		public int? NumBuilding { get; set; }
		public DateTime? DateOfBitrth { get; set; }
		public string? Phone { get; set; }
		public string? MobilePhone { get; set; }
		public CovidDetailsModel? CovidDetails { get; set; }
		public List<VaccinationModel>? Vaccinations { get; set; }

	}
}
