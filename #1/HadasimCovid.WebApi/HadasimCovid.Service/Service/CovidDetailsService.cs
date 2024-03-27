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
	internal class CovidDetailsService:ICrudService<CovidDetails>
	{
		private readonly ICrud<CovidDetails> _covidDetailsRepository;
		public CovidDetailsService(ICrud<CovidDetails> covidDetailsRepository)
		{
			_covidDetailsRepository = covidDetailsRepository;
		}

		public Task<CovidDetails> AddAsync(CovidDetails entity)
		{
			return _covidDetailsRepository.AddAsync(entity);
		}

		public Task DeleteAsync(int id)
		{
			return _covidDetailsRepository.DeleteAsync(id);
		}

		public Task<List<CovidDetails>> GetAllAsync()
		{
			return _covidDetailsRepository.GetAllAsync();
		}

		public Task<CovidDetails> GetByIdAsync(int id)
		{
			return (_covidDetailsRepository.GetByIdAsync(id));

		}

		public Task<CovidDetails> UpdateAsync(int id,CovidDetails entity)
		{
			return _covidDetailsRepository.UpdateAsync(id,entity);

		}
	}
}
