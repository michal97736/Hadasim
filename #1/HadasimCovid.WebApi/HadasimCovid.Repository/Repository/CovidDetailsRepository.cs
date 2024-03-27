using HadasimCovid.Repository.Entity;
using HadasimCovid.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadasimCovid.Repository.Repository
{
	public class CovidDetailsRepository : ICrud<CovidDetails>
	{
		private readonly MyDbContext _context;

		public CovidDetailsRepository(MyDbContext context)
		{
			_context = context;
		}
		public async Task<CovidDetails> AddAsync(CovidDetails entity)
		{
			var newCovidDetails = _context.CovidDetails.Add(entity);
			await _context.SaveChangesAsync();
			return newCovidDetails.Entity;
		}

		public async Task DeleteAsync(int id)
		{
			_context.CovidDetails.Remove(await GetByIdAsync(id));
			await _context.SaveChangesAsync();
		}

		public async Task<List<CovidDetails>> GetAllAsync()
		{
			return await _context.CovidDetails.ToListAsync();

		}

		public async Task<CovidDetails> GetByIdAsync(int id)
		{
			return await _context.CovidDetails.FindAsync(id);

		}
		public async Task<CovidDetails> GetByMemberIdAsync(int memberId)
		{
			return await _context.CovidDetails.Where(c => c.IdMember == memberId).FirstOrDefaultAsync();

		}

		public async Task<CovidDetails> UpdateAsync(int id, CovidDetails entity)
		{
			var updatedCovidDetaild = await GetByIdAsync(id);
			if (updatedCovidDetaild != null)
			{
				updatedCovidDetaild.IdMember = entity.IdMember;
				updatedCovidDetaild.DateOfPositiveResult = entity.DateOfPositiveResult;
				updatedCovidDetaild.DateOfRecovery = entity.DateOfRecovery;
				await _context.SaveChangesAsync();
				return updatedCovidDetaild;
			}
			else
			{
				var temp = AddAsync(entity).Result;
				temp.IdMember=entity.IdMember;
				return temp;
			}
		}
	}
}
