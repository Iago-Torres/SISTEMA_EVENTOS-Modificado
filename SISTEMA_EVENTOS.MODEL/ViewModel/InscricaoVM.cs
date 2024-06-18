using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SISTEMA_EVENTOS.MODEL.ViewModel
{
    public class InscricaoVM
    {
        public int Id { get; set; }
        public int ParticipanteId { get; set; }
        public int EventoId { get; set; }
        public DateTime DataInscricao { get; set; }
    }
}

