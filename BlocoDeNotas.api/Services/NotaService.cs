using BlocoDeNotas.api.DTOs;
using BlocoDeNotas.api.Models;
using BlocoDeNotas.api.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace BlocoDeNotas.api.Services
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _repo;
        public NotaService(INotaRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Nota>> GetNotasAsync(string userId) => 
            _repo.GetAllAsync(userId);

        public Task<Nota?> GetNotaByIdAsync(int id, string userId) =>
            _repo.GetByIdAsync(id, userId);

        public async Task<Nota?> AtualizarNotaAsync(int id, NotaCreateDto dto, string userId)
        {
            var notaExistente = await _repo.GetByIdAsync(id, userId);
            if (notaExistente == null) return null;

            notaExistente.Titulo = dto.Titulo;
            notaExistente.Conteudo = dto.Conteudo;
            notaExistente.AtualizadoEm = DateTime.UtcNow;

            return await _repo.UpdateAsync(notaExistente);
        }

        public async Task<Nota> CriarNotaAsync(NotaCreateDto dto, string userId)
        {
            var nota = new Nota
            {
                Titulo = dto.Titulo,
                Conteudo = dto.Conteudo,
                UserId = userId,
                CriadoEm = DateTime.UtcNow
            };

            return await _repo.AddAsync(nota);
        }

        public async Task<bool> DeletarNotaAsync(int id, string userId) =>
            await _repo.DeleteAsync(id, userId);

    }
}
