namespace BlocoDeNotas.api.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Conteudo { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; }


        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; }
    }
}
