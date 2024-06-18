using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_EVENTOS.MODEL.ViewModel
{
    public class EventoVM
    {
        public int Id { get; set; }
        public int OrganizadorId { get; set; }
        public int LocalId { get; set; }
        public string Nome { get; set; } = null!;
        public DateOnly Data { get; set; }
        public string? Descricao { get; set; }
        public string NomeOrganizador { get; set; } = null!;
        public string NomeLocal { get; set; } = null!;
    }
}
