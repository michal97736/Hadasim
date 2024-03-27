
using HadasimCovid.Repository.Entity;
using HadasimCovid.Repository.Interface;
using HadasimCovid.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HadasimCovid.Service.Service
{
	public class MemberService : ICrudService<Member>
	{
		private readonly ICrud<Member> _memberRepository;

		public MemberService(ICrud<Member> memberRepository)
		{
			_memberRepository = memberRepository;

		}

		public Task<Member> AddAsync(Member entity)
		{

			return _memberRepository.AddAsync(entity);
		}

		public Task DeleteAsync(int id)
		{
			return _memberRepository.DeleteAsync(id);
		}

		public Task<List<Member>> GetAllAsync()
		{
			return _memberRepository.GetAllAsync();
		}

		public  Task<Member> GetByIdAsync(int id)
		{
			var test = _memberRepository.GetByIdAsync(id);
			return test;

		}

		public Task<Member> UpdateAsync(int id, Member entity)
		{
			return _memberRepository.UpdateAsync(id, entity);

		}
	}
}
