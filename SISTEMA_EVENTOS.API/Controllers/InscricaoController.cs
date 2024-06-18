using Microsoft.AspNetCore.Mvc;
using SISTEMA_EVENTOS.MODEL.DTO;
using SISTEMA_EVENTOS.MODEL.Services;
using SISTEMA_EVENTOS.MODEL.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISTEMA_EVENTOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscricaoController : ControllerBase
    {
        private readonly ServiceInscricao _serviceInscricao;

        public InscricaoController(ServiceInscricao serviceInscricao)
        {
            _serviceInscricao = serviceInscricao;
        }

        [HttpPost]
        public async Task<ActionResult<InscricaoVM>> Post(InscricaoDTO inscricaoDTO, DateOnly dateTime)
        {
            var novaInscricao = await _serviceInscricao.RealizarInscricaoAsync(inscricaoDTO, dateTime);
            return CreatedAtAction(nameof(Get), new { id = novaInscricao.Id }, novaInscricao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceInscricao.CancelarInscricaoAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InscricaoVM>> Get(int id)
        {
            var inscricao = await _serviceInscricao.ObterInscricaoPorIdAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }
            return inscricao;
        }

        [HttpGet("evento/{eventoId}")]
        public async Task<ActionResult<List<InscricaoVM>>> GetByEvento(int eventoId)
        {
            var inscricoes = await _serviceInscricao.ObterInscricoesPorEventoAsync(eventoId);
            return inscricoes;
        }
    }
}
