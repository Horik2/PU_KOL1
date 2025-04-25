using BLL.DTOs;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class HistoriaProcedureService : IHistoriaProcedureService
    {
        private readonly AppDbContext _context;

        public HistoriaProcedureService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<HistoriaDto>> GetPagedAsync(int page, int pageSize)
        {
            var result = new List<HistoriaDto>();
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "GetPagedHistoria";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            var p1 = cmd.CreateParameter(); p1.ParameterName = "@Page"; p1.Value = page;
            var p2 = cmd.CreateParameter(); p2.ParameterName = "@PageSize"; p2.Value = pageSize;
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new HistoriaDto(
                    reader.GetInt32(0),                        
                    reader.GetString(1),                       
                    reader.GetString(2),                       
                    reader.IsDBNull(3) ? null : reader.GetInt32(3), 
                    reader.GetString(4),                       
                    reader.GetDateTime(5)                      
                ));
            }

            await conn.CloseAsync();
            return result;
        }
    }

}
