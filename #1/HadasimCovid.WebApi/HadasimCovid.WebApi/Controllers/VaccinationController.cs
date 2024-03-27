using AutoMapper;
using HadasimCovid.Repository.Entity;
using HadasimCovid.Service.Interface;
using HadasimCovid.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HadasimCovid.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VaccinationController : ControllerBase
	{
		private readonly ICrudService<Vaccination> _vaccinationService;
		private readonly IMapper _mapper;
		public VaccinationController(ICrudService<Vaccination> vaccinationService, IMapper mapper)
		{
			_vaccinationService = vaccinationService;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<List<VaccinationModel>> Get()
		{
			return _mapper.Map<List<VaccinationModel>>(await _vaccinationService.GetAllAsync());
		}
		[HttpGet("{id}")]
		public async Task<VaccinationModel> GetById(int id)
		{
			return _mapper.Map<VaccinationModel>(await _vaccinationService.GetByIdAsync(id));
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _vaccinationService.DeleteAsync(id);
		}
		[HttpPut("{id}")]
		public async Task<VaccinationModel> Put(int id, [FromBody] VaccinationModel vaccinationModel)
		{

			return _mapper.Map<VaccinationModel>(await _vaccinationService.UpdateAsync(id, new Vaccination
			{
				DateOfReceivingVaccine = vaccinationModel.DateOfReceivingVaccine,
				Manufacturer = vaccinationModel.Manufacturer,
				IdMember = vaccinationModel.IdMember,
			}));
		}
		[HttpPost]
		public async Task<VaccinationModel[]> Post([FromBody] VaccinationModel[] vaccinationModel)
		{
			
				
			return _mapper.Map<VaccinationModel[]>(_vaccinationService.AddAsync(_mapper.Map<Vaccination>(vaccinationModel)).Result);
			
		
		}
	}
}
