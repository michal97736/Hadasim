using System.ComponentModel.DataAnnotations.Schema;

namespace HadasimCovid.WebApi.Models
{
	public class CovidDetailsModel
	{
		public int Id { get; set; }
		public int? IdMember { get; set; }

		public DateTime? DateOfPositiveResult { get; set; }
		public DateTime? DateOfRecovery { get; set; }


	}
}
