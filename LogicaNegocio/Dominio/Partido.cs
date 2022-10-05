using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class Partido : IValidable
    {
        public int Id { get; set; }       
        public IEnumerable<SeleccionPartido> SeleccionPartido { get; set; }
        public DateTime Fecha { get; set; }
        public Horario Hora { get; set; }       
        public Estado Estado { get; set; }
        public IEnumerable<IncidenciaPartido> Incidencias { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
