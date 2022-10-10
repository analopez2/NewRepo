using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Hora.Validar();
            ValidarFecha();
            ValidarSelecciones();
        }

        public void ValidarFecha()
        {
            if( Fecha < new DateTime(2022,11,20) && Fecha > new DateTime(2022, 12, 02))
            {
                throw new Exception("ERROR PARTIDO | La fecha del partido debe estar entre el 20/11/2022 y el 02/12/2022");
            }
        }

        public void ValidarSelecciones()
        {
            if(SeleccionPartido.Count() !=  2)
            {
                throw new Exception("ERROR PARTIDO | Deben haber exactamente 2 selecciones por partido.");
            }

            if(SeleccionPartido.First() == SeleccionPartido.Last())
            {
                throw new Exception("ERROR PARTIDO | La seleccion no puede jugar contra si misma.");
            }

/*            if (SeleccionPartido.First().Seleccion.Grupo != SeleccionPartido.Last().Seleccion.Grupo)
            {
                throw new Exception("ERROR PARTIDO | Ambas selecciones deben pertenecer al mismo grupo.");
            }
*/
        }
    }
}
