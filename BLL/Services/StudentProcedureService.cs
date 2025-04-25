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
    public class StudentProcedureService : IStudentProcedureService
    {
        private readonly AppDbContext _context;

        public StudentProcedureService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(string imie, string nazwisko, int grupaId)
        {
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "AddStudent";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            var p1 = cmd.CreateParameter(); p1.ParameterName = "@Imie"; p1.Value = imie;
            var p2 = cmd.CreateParameter(); p2.ParameterName = "@Nazwisko"; p2.Value = nazwisko;
            var p3 = cmd.CreateParameter(); p3.ParameterName = "@GrupaID"; p3.Value = grupaId;

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);

            await cmd.ExecuteNonQueryAsync();
            await conn.CloseAsync();
        }
    }

}
