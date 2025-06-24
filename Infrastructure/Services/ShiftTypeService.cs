using Microsoft.Data.SqlClient;
using SADIG_API.Application.Interfaces;
using SADIG_API.Domain.Entities;
using System.Data;

namespace SADIG_API.Infrastructure.Services
{
    public class ShiftTypeService : IShiftTypeService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly HttpClient _httpClient;

        public ShiftTypeService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ShiftTypeViewModel>> GetShiftTypes(bool available)
        {
            var shiftTypes = new List<ShiftTypeViewModel>();

            using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllShiftTypes", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Available", available);

            await connection.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                shiftTypes.Add(new ShiftTypeViewModel
                {
                    PKShiftType = reader.GetInt32(0),
                    ShiftType   = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Available   = reader.GetBoolean(3)
                });
            }

            return shiftTypes;
        }
    }
}
