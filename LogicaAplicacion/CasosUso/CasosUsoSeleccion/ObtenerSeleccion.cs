using LogicaAplicacion.InterfacesCasosUso.ICasosUsoSeleccion;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoSeleccion
{
     public class ObtenerSeleccion : IObtenerSeleccion
    {
        public IRepositorioSelecciones RepoSelecciones { get; set; }

        public ObtenerSeleccion(IRepositorioSelecciones repoSelecciones)
        {
            RepoSelecciones = repoSelecciones;
        }


        public void FindById(int id)
        {
            try
            {
                RepoSelecciones.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo obtener la seleccion con el id indicado", e);
            }
        }
    }
}
