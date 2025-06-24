using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SADIG_API.Application.Interfaces;
using SADIG_API.Domain.Entities;
using System.Data;

namespace SADIG_API.Infrastructure.Services
{
    public class CorrespondenceTypeService : ICorrespondenceTypeService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly HttpClient _httpClient;

        public CorrespondenceTypeService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CorrespondenceTypeViewModel>> GetCorrespondenceTypes(bool available)
        {
            var correspondenceTypes = new List<CorrespondenceTypeViewModel>();

            using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllCorrespondenceType", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Available", available);

            await connection.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                correspondenceTypes.Add(new CorrespondenceTypeViewModel
                {
                    PKCorrespondenceType = reader.GetInt32(0),
                    CorrespondenceType = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Available = reader.GetBoolean(3)
                });
            }

            return correspondenceTypes;
        }

        public async Task<bool> AddCorrespondenceType(string correspondenceType, string description, bool available)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddCorrespondenceType", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CorrespondenceType", correspondenceType);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Available", available);

            await connection.OpenAsync();
            var rowsAffected = await cmd.ExecuteNonQueryAsync();

            return rowsAffected > 0;

        }
    }
}
