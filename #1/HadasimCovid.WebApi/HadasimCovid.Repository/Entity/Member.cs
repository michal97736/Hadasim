using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadasimCovid.Repository.Entity
{
	public class Member
	{
		[Key]
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

	//	[NotMapped]
		public CovidDetails? CovidDetails { get; set; }
	//	[NotMapped]
		public List<Vaccination>? Vaccinations { get; set; }


	}
}
