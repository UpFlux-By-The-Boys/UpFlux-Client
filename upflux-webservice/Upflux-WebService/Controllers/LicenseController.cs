﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Upflux_WebService.Core.DTOs;
using Upflux_WebService.Services.Interfaces;

namespace Upflux_WebService.Controllers
{
	/// <summary>
	/// Licencing related controllers
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class LicenseController : ControllerBase
	{
		ILicenseManagementService _licenseManagementService;

		public LicenseController(ILicenseManagementService licenseManagementService)
		{
			_licenseManagementService = licenseManagementService;
		}

		/// <summary>
		/// Admin register a machine and create license for it.
		/// </summary>
		/// <param name="registerMachineDto">the register request containing machineId</param>
		//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		[HttpPost("admin/register")]
		public async Task<IActionResult> RegisterMachine([FromBody] RegisterMachineRequest registerMachineDto)
		{
			try
			{
				//var adminEmail = GetClaimValue(ClaimTypes.Email);
				//if (string.IsNullOrEmpty(adminEmail))
				//	return Unauthorized(new { Error = "Invalid admin token." });

				await _licenseManagementService.CreateLicence(registerMachineDto.MachineId);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(new { Error = ex.Message });
			}
		}

		/// <summary>
		/// Generate UUID that can used as a device's identifier
		/// </summary>
		//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
		[HttpGet("admin/generateId")]
		public IActionResult GenerateMachineId()
		{
			var machineId = Guid.NewGuid().ToString();

			return Ok(new { MachineId = machineId });
		}

		#region private methods

		// Helper method to get claim value
		private string? GetClaimValue(string claimType)
		{
			return User.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
		}
		#endregion
	}
}