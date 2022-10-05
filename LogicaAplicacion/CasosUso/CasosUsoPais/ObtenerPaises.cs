using LogicaAplicacion.InterfacesCasosUso.ICasosUsoPais;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class ObtenerPaises : IObtenerPaises
    {
        public IRepositorioPaises RepoPaises { get; set; }

        public ObtenerPaises(IRepositorioPaises repoPaises)
        {
            RepoPaises = repoPaises;
        }


        public void FindAll(Pais obj)
        {
            try
            {
                RepoPaises.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron obtener los paises", e);
            }
        }
    }
}
