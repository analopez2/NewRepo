using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class Incidencia : IValidable
    {
        public int Id { get; set; }
        public int RojasDirectas { get; set; }
        public int Amarillas { get; set; }
        public int Goles { get; set; }
        public int RojasAcumAmarillas { get; set; }
        public Seleccion Seleccion { get; set; }
        public int SeleccionId { get; set; }

        public IEnumerable<IncidenciaPartido> PartidoIncidencia { get; set; }

        public void Validar()
        {
            ValidarNumeros();
            ValidarPartidoIncidencia();
        }

        private void ValidarNumeros()
        {
            if (RojasDirectas < 0)
            {
                throw new Exception("ERROR INICIDENCIA | Los valores datos numéricos deben ser mayor a 0");
            }

            if (Amarillas < 0)
            {
                throw new Exception("ERROR INICIDENCIA | Los valores datos numéricos deben ser mayor a 0");
            }

            if (Goles < 0)
            {
                throw new Exception("ERROR INICIDENCIA | Los valores datos numéricos deben ser mayor a 0");
            }

            if (RojasAcumAmarillas < 0)
            {
                throw new Exception("ERROR INICIDENCIA | Los valores datos numéricos deben ser mayor a 0");
            }
        }


        private void ValidarPartidoIncidencia()
        {
            if( PartidoIncidencia.Count() != 1)
            {
                throw new Exception("ERROR INICIDENCIA |La incidencia debe tener exactamente un partido asociado.");
            }
        }
    }
}
