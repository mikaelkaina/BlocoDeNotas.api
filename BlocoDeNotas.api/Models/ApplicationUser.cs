using Microsoft.AspNetCore.Identity;

namespace BlocoDeNotas.api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Nota> Notas { get; set; } = new List<Nota>();
    }
}
