using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class Region : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<PaisRegion> PaisRegion { get; set; }

        public void Validar()
        {
            ValidarRegion();
        }

        private void ValidarRegion()
        {
            List<string> regiones = new List<string> { "África", "América", "Asia", "Europa", "Oceania" };
            if (!regiones.Contains(Nombre))
            {
                throw new Exception("La región debe ser un continente válido");
            }
        }
    }
}
