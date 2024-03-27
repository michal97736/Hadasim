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
	public class MemberController : ControllerBase
	{
		private readonly ICrudService<Member> _memberService;
		private readonly ICrudService<CovidDetails> _covidDetailsService;
		private readonly ICrudService<Vaccination> _vaccinationService;

		private readonly IMapper _mapper;
		public MemberController(ICrudService<Member> memberService, ICrudService<CovidDetails> covidDetailsService, ICrudService<Vaccination> vaccinationService, IMapper mapper)
		{
			_memberService = memberService;
			_covidDetailsService = covidDetailsService;
			_vaccinationService = vaccinationService;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<List<MemberModel>> Get()
		{
			return _mapper.Map<List<MemberModel>>(await _memberService.GetAllAsync());
		}
		[HttpGet("{id}")]
		public async Task<MemberModel> GetById(int id)
		{
			return _mapper.Map<MemberModel>(await _memberService.GetByIdAsync(id));
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _memberService.DeleteAsync(id);
		}
		[HttpPut("{id}")]
		public async Task<MemberModel> Put(int id, [FromBody] MemberModel memberModel)
		{

			CovidDetailsModel covid = new CovidDetailsModel();
			List<VaccinationModel> vaccination = new List<VaccinationModel>();

			if (memberModel.CovidDetails != null)
				covid = _mapper.Map<CovidDetailsModel>(_covidDetailsService.UpdateAsync(memberModel.CovidDetails.Id, _mapper.Map<CovidDetails>(memberModel.CovidDetails)).Result);

			if (memberModel.Vaccinations != null)
			{
				if (memberModel.Vaccinations.Count > 4)
					throw new Exception("Vaccinations array length cannot be greater than 4");

				for (int i = 0; i < memberModel.Vaccinations.Count; i++)
					vaccination.Add(_mapper.Map<VaccinationModel>(_vaccinationService.UpdateAsync(memberModel.Vaccinations[i].Id, _mapper.Map<Vaccination>(memberModel.Vaccinations[i])).Result));
			}

			MemberModel newMember = _mapper.Map<MemberModel>(await _memberService.UpdateAsync(id, new Member
			{
				FirstName = memberModel.FirstName,
				LastName = memberModel.LastName,
				Tz = memberModel.Tz,
				City = memberModel.City,
				Street = memberModel.Street,
				NumBuilding = memberModel.NumBuilding,
				Phone = memberModel.Phone,
				MobilePhone = memberModel.MobilePhone,
				DateOfBitrth = memberModel.DateOfBitrth,
			}));
			newMember.CovidDetails = covid;
			newMember.Vaccinations = vaccination;
			return newMember;
		}
		[HttpPost]
		public async Task<MemberModel> Post([FromBody] MemberModel member)
		{
			CovidDetailsModel covid = new CovidDetailsModel();
			List<VaccinationModel> vaccination = new List<VaccinationModel>();
			MemberModel newMember = _mapper.Map<MemberModel>(_memberService.AddAsync(_mapper.Map<Member>(member)).Result);

			if (member.CovidDetails != null)
			{

				member.CovidDetails.IdMember = newMember.IdMember;
				covid = _mapper.Map<CovidDetailsModel>(_covidDetailsService.AddAsync(_mapper.Map<CovidDetails>(member.CovidDetails)).Result);
			}
			if (member.Vaccinations != null)
			{
				if (member.Vaccinations.Count > 4)
					throw new Exception("Vaccinations array length cannot be greater than 4");
				for (int i = 0; i < member.Vaccinations.Count; i++)
				{
					member.Vaccinations[i].IdMember = newMember.IdMember;
					vaccination.Add(_mapper.Map<VaccinationModel>(_vaccinationService.AddAsync(_mapper.Map<Vaccination>(member.Vaccinations[i])).Result));

				}
			}
			newMember.CovidDetails = covid;
			newMember.Vaccinations = vaccination;
			return newMember;
		}
	}
}
