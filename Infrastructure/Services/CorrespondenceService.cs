using Microsoft.Data.SqlClient;
using SADIG_API.Application.DTOs;
using SADIG_API.Application.Interfaces;
using System.Data;

namespace SADIG_API.Infrastructure.Services
{
    public class CorrespondenceService : ICorrespondenceService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly HttpClient _httpClient;

        public CorrespondenceService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _httpClient = httpClient;
        }

        public async Task<bool> AddCorrespondence(CorrespondenceDto correspondence)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddNewCorrespondence", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@InternalNumber", correspondence.InternalNumber);
            cmd.Parameters.AddWithValue("@FKDepartmentOrigin", correspondence.FKDepartmentOrigin);
            cmd.Parameters.AddWithValue("@FKUserOrigin",correspondence.FKUserOrigin);
            cmd.Parameters.AddWithValue("@FKDepartmentDestination", correspondence.FKDepartmentDestination);
            cmd.Parameters.AddWithValue("@FKUserDestination", correspondence.FKUserDestination);
            cmd.Parameters.AddWithValue("@DateReceived", correspondence.DateReceived);
            cmd.Parameters.AddWithValue("@Subject", correspondence.Subject);
            cmd.Parameters.AddWithValue("@FKShiftType", correspondence.FKShiftType);
            cmd.Parameters.AddWithValue("@FKUserCreator", correspondence.FKUserCreator);

            await connection.OpenAsync();

            var rowsAffected = await cmd.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }
    }
}
