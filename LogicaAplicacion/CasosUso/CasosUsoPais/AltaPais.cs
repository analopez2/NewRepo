using LogicaAplicacion.InterfacesCasosUso.ICasosUsoPais;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class AltaPais : IAltaPais
    {
        public IRepositorioPaises RepoPaises { get; set; }

        public AltaPais(IRepositorioPaises repoPaises)
        {
            RepoPaises = repoPaises;
        }

        public void Add(Pais nuevo)
        {
            try
            {
                nuevo.Validar();
                RepoPaises.Add(nuevo);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo dar de alta el pais", e);
            }
        }
    }
}
