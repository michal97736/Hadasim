using System.ComponentModel.DataAnnotations.Schema;

namespace HadasimCovid.WebApi.Models
{
	public class VaccinationModel
	{
		public int Id { get; set; }

		public int? IdMember { get; set; }

		public DateTime? DateOfReceivingVaccine { get; set; }
		public string? Manufacturer { get; set; }
	}
}
