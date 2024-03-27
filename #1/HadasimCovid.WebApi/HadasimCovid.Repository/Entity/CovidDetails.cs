using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadasimCovid.Repository.Entity
{
	public class CovidDetails
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Member")]
		public int? IdMember { get; set; }
		public Member? Member { get; set; }

		public DateTime? DateOfPositiveResult{ get; set; }
		public DateTime? DateOfRecovery { get; set; }


	}
}
