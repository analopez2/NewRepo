using LogicaAplicacion.InterfacesCasosUso.ICasosUsoRegion;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoRegion
{
   public class ObtenerRegion : IObtenerRegion
    {
        public IRepositorioRegiones RepoRegiones { get; set; }

        public ObtenerRegion(IRepositorioRegiones repoRegiones)
        {
            RepoRegiones = repoRegiones;
        }

        public void FindById(int id)
        {
            try
            {
                RepoRegiones.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo obtener la region con el id indicado", e);
            }
            
        }
    }
}
