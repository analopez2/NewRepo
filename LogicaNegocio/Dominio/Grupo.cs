using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class Grupo : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<PartidoGrupo> PartidoGrupo { get; set; }
        public IEnumerable<SeleccionGrupo> SeleccionGrupo { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
