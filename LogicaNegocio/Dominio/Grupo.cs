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
       

        public void Validar()
        {
            ValidarGrupo();
        }

        private void ValidarGrupo()
        {
            List<string> grupos = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H"};
            if (!grupos.Contains(Nombre.ToUpper()))
            {
                throw new Exception("El nombre del grupo debe ser una letra de la A a la H");
            }
        }
    }
}
