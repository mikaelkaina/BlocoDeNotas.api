using BlocoDeNotas.api.DTOs;
using BlocoDeNotas.api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlocoDeNotas.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotasController : ControllerBase
    {
        private readonly INotaService _service;
        public NotasController(INotaService service)
        {
            _service = service;
        }

        private string GetUserId() =>
            User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new Exception("Usuário não autenticado");
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var notas = await _service.GetNotasAsync(userId);
            return Ok(notas);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = GetUserId();
            var nota = await _service.GetNotaByIdAsync(id, userId);
            if (nota == null) return NotFound();
            return Ok(nota);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NotaCreateDto dto)
        {
            var userId = GetUserId();
            var nota = await _service.CriarNotaAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = nota.Id }, nota);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, NotaCreateDto dto)
        {
            var userId = GetUserId();
            var nota = await _service.AtualizarNotaAsync(id, dto, userId);
            if (nota == null) return NotFound();
            return Ok(nota);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();
            var result = await _service.DeletarNotaAsync(id, userId);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
