using LogicaAplicacion.InterfacesCasosUso.ICasosUsoSeleccion;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoSeleccion
{
    class AltaSeleccion : IAltaSeleccion
    {
        public IRepositorio<Seleccion> RepoSelecciones { get; set; }

        public AltaSeleccion(IRepositorio<Seleccion> repoSeleccion)
        {
            RepoSelecciones = repoSeleccion;
        }
        public void Add(Seleccion seleccion)
        {
            try
            {
                RepoSelecciones.Add(seleccion);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo dar de alta la seleccion", e);
            }

            //comentarios para agergar
        }
    }
}
