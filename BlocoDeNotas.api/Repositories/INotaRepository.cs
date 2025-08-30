using BlocoDeNotas.api.Models;

namespace BlocoDeNotas.api.Repositories
{
    public interface INotaRepository
    {
        Task<IEnumerable<Nota>> GetAllAsync(string userId);
        Task<Nota?> GetByIdAsync(int id, string userId);
        Task<Nota> AddAsync (Nota nota);
        Task<Nota> UpdateAsync (Nota nota);
        Task<bool> DeleteAsync (int id, string userId);

    }
}
