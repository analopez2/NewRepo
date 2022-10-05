using LogicaAplicacion.InterfacesCasosUso.ICasosUsoPais;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoPais
{
    public class BajaPais : IBajaPais
    {
        public IRepositorioPaises RepoPaises { get; set; }

        public BajaPais(IRepositorioPaises repoPaises)
        {
            RepoPaises = repoPaises;
        }

        public void Remove(int id)
        {
            try
            {
                //Validar que no se encuentre vinculado con ninguna seleccion o región. 
                RepoPaises.Remove(id);
            } 
            catch (Exception e)
            {
                throw new Exception("No se pudo borar el país", e);
            }
        }
    }
}
