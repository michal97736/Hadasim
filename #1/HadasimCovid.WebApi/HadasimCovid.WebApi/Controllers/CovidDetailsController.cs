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
	public class CovidDetailsController : ControllerBase
	{
		private readonly ICrudService<CovidDetails> _covidDetailsService;
		private readonly IMapper _mapper;
		public CovidDetailsController(ICrudService<CovidDetails> covidDetailsService, IMapper mapper)
		{
			_covidDetailsService = covidDetailsService;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<List<CovidDetailsModel>> Get()
		{
			return _mapper.Map<List<CovidDetailsModel>>(await _covidDetailsService.GetAllAsync());
		}
		[HttpGet("{id}")]
		public async Task<CovidDetailsModel> GetById(int id)
		{
			return _mapper.Map<CovidDetailsModel>(await _covidDetailsService.GetByIdAsync(id));
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _covidDetailsService.DeleteAsync(id);
		}
		[HttpPut("{id}")]
		public async Task<CovidDetailsModel> Put(int id, [FromBody] CovidDetailsModel covidDetailsModel)
		{

			return _mapper.Map<CovidDetailsModel>(await _covidDetailsService.UpdateAsync(id, new CovidDetails
			{
				IdMember = covidDetailsModel.IdMember,
				DateOfPositiveResult = covidDetailsModel.DateOfPositiveResult,
				DateOfRecovery = covidDetailsModel.DateOfRecovery,
			}));
		}
		[HttpPost]
		public async Task<CovidDetailsModel> Post([FromBody] CovidDetailsModel covidDetailsModel)
		{
			return _mapper.Map<CovidDetailsModel>(await _covidDetailsService.AddAsync(_mapper.Map<CovidDetails>(covidDetailsModel)));
		}
	}
}
