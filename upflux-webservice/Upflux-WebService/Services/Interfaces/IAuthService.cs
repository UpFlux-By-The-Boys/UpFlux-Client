﻿namespace Upflux_WebService.Services.Interfaces
{
    /// <summary>
    /// Interface for authentication-related services.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates an admin and generates a token.
        /// </summary>
        /// <param name="email">The admin's email address.</param>
        /// <param name="password">The admin's password.</param>
        /// <returns>A JWT token for the authenticated admin.</returns>
        string AdminLogin(string email, string password);

        /// <summary>
        /// Authenticates an engineer by email and retrieves machine access information.
        /// </summary>
        /// <param name="email">The engineer's email address.</param>
        /// <returns>A list of machine IDs the engineer has access to.</returns>
        List<string> EngineerLogin(string email);

        /// <summary>
        /// Generates a new token for an engineer with specified machine access.
        /// </summary>
        /// <param name="engineerEmail">The email address of the engineer.</param>
        /// <param name="machineIds">The list of machine IDs the engineer will have access to.</param>
        /// <param name="engineerName">Optional engineer's name, default is "Engineer".</param>
        /// <returns>A JWT token for the engineer with machine access information.</returns>
        string GenerateEngineerToken(string engineerEmail, List<string> machineIds, string engineerName = "Engineer");

        /// <summary>
        /// Parses a JWT token and extracts the claims as a dictionary.
        /// </summary>
        /// <param name="token">The JWT token to parse.</param>
        /// <returns>A dictionary containing the claims from the token.</returns>
        Dictionary<string, string> ParseToken(string token);

        /// <summary>
        /// Changes the password for an admin user.
        /// </summary>
        /// <param name="email">The admin's email address.</param>
        /// <param name="oldPassword">The current password of the admin.</param>
        /// <param name="newPassword">The new password to be set for the admin.</param>
        /// <returns>Returns <c>true</c> if the password change was successful, <c>false</c> otherwise.</returns>
        bool ChangeAdminPassword(string email, string oldPassword, string newPassword);

    }
}
