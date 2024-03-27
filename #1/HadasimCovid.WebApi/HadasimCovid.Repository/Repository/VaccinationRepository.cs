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
	internal class VaccinationRepository:ICrud<Vaccination>
	{
		private readonly MyDbContext _context;

		public VaccinationRepository(MyDbContext context)
		{
			_context = context;
		}
		public async Task<Vaccination> AddAsync(Vaccination entity)
		{
			var newVaccination = _context.Vaccinations.Add(entity);
			await _context.SaveChangesAsync();
			return newVaccination.Entity;
		}

		public async Task DeleteAsync(int id)
		{
			_context.Vaccinations.Remove(await GetByIdAsync(id));
			await _context.SaveChangesAsync();
		}

		public async Task<List<Vaccination>> GetAllAsync()
		{
			return await _context.Vaccinations.ToListAsync();

		}

		public async Task<Vaccination> GetByIdAsync(int id)
		{
			return await _context.Vaccinations.FindAsync(id);

		}

		public async Task<Vaccination> UpdateAsync(int id, Vaccination entity)
		{
			var updatedVaccination = await GetByIdAsync(id);
			if (updatedVaccination != null)
			{
				updatedVaccination.IdMember = entity.IdMember;
				updatedVaccination.Manufacturer = entity.Manufacturer;
				updatedVaccination.DateOfReceivingVaccine = entity.DateOfReceivingVaccine;
				await _context.SaveChangesAsync();
				return updatedVaccination;
			}
			else
			{
				var temp=AddAsync(entity).Result;
				temp.IdMember = entity.IdMember;
				return  temp;
			}

		}
	}
}
