﻿using HadasimCovid.Repository.Entity;
using HadasimCovid.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HadasimCovid.Repository.Repository
{
	public class MemberRepository : ICrud<Member>
	{
		private readonly MyDbContext _context;


		public MemberRepository(MyDbContext context)
		{
			_context = context;
		}
		public async Task<Member> AddAsync(Member entity)
		{
			var newMember = _context.Members.Add(entity);
			await _context.SaveChangesAsync();
			return newMember.Entity;
		}

		public async Task DeleteAsync(int id)
		{
			var memeberToDelete = _context.Members
			.Include(p => p.CovidDetails).Include(v=>v.Vaccinations)
			.SingleOrDefault(p => p.IdMember == id);

			if (memeberToDelete != null)
			{
				_context.Members.Remove(memeberToDelete);
				_context.SaveChanges();
			}
		}

		public async Task<List<Member>> GetAllAsync()
		{
			return await _context.Members.ToListAsync();

		}

		public  async Task<Member> GetByIdAsync(int id)
		{
			return await _context.Members.Include(m => m.CovidDetails).Include(m => m.Vaccinations).Where
				(m => m.IdMember == id).FirstOrDefaultAsync();
		}

		public async Task<Member> UpdateAsync(int id, Member entity)
		{
			var updatedMember = await GetByIdAsync(id);
			updatedMember.FirstName = entity.FirstName;
			updatedMember.LastName = entity.LastName;
			updatedMember.Tz = entity.Tz;
			updatedMember.City = entity.City;
			updatedMember.Street = entity.Street;
			updatedMember.NumBuilding = entity.NumBuilding;
			updatedMember.DateOfBitrth = entity.DateOfBitrth;
			updatedMember.Phone = entity.Phone;
			updatedMember.MobilePhone = entity.MobilePhone;
			await _context.SaveChangesAsync();
			return updatedMember;

		}
	}
}
