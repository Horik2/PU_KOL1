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
    public class HistoriaService : IHistoriaService
    {
        private readonly AppDbContext _context;

        public HistoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<HistoriaDto>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.Historie
                .OrderByDescending(h => h.Data)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(h => new HistoriaDto(h.ID, h.Imie, h.Nazwisko, h.GrupaID, h.TypAkcji, h.Data))
                .ToListAsync();
        }
    }

}
