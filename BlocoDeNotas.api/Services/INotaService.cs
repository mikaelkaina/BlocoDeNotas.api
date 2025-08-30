using BlocoDeNotas.api.DTOs;
using BlocoDeNotas.api.Models;

namespace BlocoDeNotas.api.Services
{
    public interface INotaService
    {
        Task<IEnumerable<Nota>> GetNotasAsync(string userId);
        Task<Nota?> GetNotaByIdAsync(int id, string userId);
        Task<Nota> CriarNotaAsync(NotaCreateDto dto, string userId);
        Task<Nota?> AtualizarNotaAsync(int id, NotaCreateDto dto, string userId);
        Task<bool> DeletarNotaAsync(int id, string userId);
    }
}
