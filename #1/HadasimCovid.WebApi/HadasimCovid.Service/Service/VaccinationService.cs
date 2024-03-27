using HadasimCovid.Repository.Entity;
using HadasimCovid.Repository.Interface;
using HadasimCovid.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadasimCovid.Service.Service
{
	internal class VaccinationService:ICrudService<Vaccination>
	{
		private readonly ICrud<Vaccination> _vaccinationRepository;
		public VaccinationService(ICrud<Vaccination> vaccinationRepository)
		{
			_vaccinationRepository = vaccinationRepository;
		}

		public Task<Vaccination> AddAsync(Vaccination entity)
		{

			return _vaccinationRepository.AddAsync(entity);
		}

		public Task DeleteAsync(int id)
		{
			return _vaccinationRepository.DeleteAsync(id);
		}

		public Task<List<Vaccination>> GetAllAsync()
		{
			return _vaccinationRepository.GetAllAsync();
		}

		public Task<Vaccination> GetByIdAsync(int id)
		{
			return (_vaccinationRepository.GetByIdAsync(id));

		}

		public Task<Vaccination> UpdateAsync(int id, Vaccination entity)
		{
			return _vaccinationRepository.UpdateAsync(id,entity);

		}
	}
}
