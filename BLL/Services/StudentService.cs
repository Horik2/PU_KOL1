using BLL.DTOs;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            return await _context.Studenci
                .Select(s => new StudentDto(s.ID, s.Imie, s.Nazwisko, s.GrupaID))
                .ToListAsync();
        }

        public async Task<StudentDto?> GetAsync(int id)
        {
            var s = await _context.Studenci.FindAsync(id);
            return s is null ? null : new StudentDto(s.ID, s.Imie, s.Nazwisko, s.GrupaID);
        }

        public async Task AddAsync(StudentDto dto)
        {
            var s = new Student { Imie = dto.Imie, Nazwisko = dto.Nazwisko, GrupaID = dto.GrupaID };
            _context.Studenci.Add(s);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentDto dto)
        {
            var s = await _context.Studenci.FindAsync(dto.ID);
            if (s == null) return;

            s.Imie = dto.Imie;
            s.Nazwisko = dto.Nazwisko;
            s.GrupaID = dto.GrupaID;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var s = await _context.Studenci.FindAsync(id);
            if (s != null)
            {
                _context.Studenci.Remove(s);
                await _context.SaveChangesAsync();
            }
        }
    }

}
