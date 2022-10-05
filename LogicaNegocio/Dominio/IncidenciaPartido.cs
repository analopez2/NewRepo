using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class IncidenciaPartido
    {
        public Incidencia Incidencia { get; set; }
        public Partido Partido { get; set; }

        public int IncidenciaId { get; set; }
        public int PartidoId { get; set; }
    }
}
