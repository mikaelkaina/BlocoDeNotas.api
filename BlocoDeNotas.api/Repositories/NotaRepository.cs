using Azure.Core;
using BlocoDeNotas.api.Data;
using BlocoDeNotas.api.Models;
using Microsoft.EntityFrameworkCore;

namespace BlocoDeNotas.api.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly AppDbContext _context;

        public NotaRepository (AppDbContext context)
        {
            _context = context;
        }   

        public async Task<IEnumerable<Nota>> GetAllAsync(string userId)
        {
            return await _context.Notas
                .Where(n  => n.UserId == userId)
                .ToListAsync();
        }

        public async Task<Nota?> GetByIdAsync(int id,string userId)
        {
            return await _context.Notas
                .FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);
        }

        public async Task<Nota> AddAsync(Nota nota)
        {
            _context.Notas.Add(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<bool> DeleteAsync(int id,string userId)
        {
            var nota = await _context.Notas
                .FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);
            if (nota == null) return false;

            _context.Notas.Remove(nota);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Nota> UpdateAsync(Nota nota)
        {
            _context.Notas.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }
    }
}
