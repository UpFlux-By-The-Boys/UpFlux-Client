﻿using Upflux_WebService.Core.Models;
using Upflux_WebService.Data;
using Upflux_WebService.Repository.Interfaces;

namespace Upflux_WebService.Repository
{

	public class LicenceRepository : Repository<Licence>, ILicenceRepository
	{
		private readonly ApplicationDbContext _context;

		public LicenceRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}


		/// <summary>
		/// Example use of the Table specific repository
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public Task<IEnumerable<Licence>> GetValidLicencesAsync()
		{
			throw new NotImplementedException();
		}
	}
}