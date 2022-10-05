using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
   public class Seleccion : IValidable
    {
        public int Id { get; set; }
        public Pais Pais { get; set; }
        public int PaisId { get; set; }
        public string  Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int CantPotencialApostadores { get; set; }
        public int Puntos { get; set; }
        public Grupo Grupo { get; set; }
        public int GrupoId { get; set; }

        public IEnumerable<SeleccionPartido> SeleccionPartido { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
