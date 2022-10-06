using LogicaAplicacion.InterfacesCasosUso.ICasosUsoRegion;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoRegion
{
    class ObtenerRegiones : IObtenerRegiones
    {
        public IRepositorioRegiones RepoRegiones { get; set; }

        public ObtenerRegiones(IRepositorioRegiones repoRegiones)
        {
            RepoRegiones = repoRegiones;
        }

        public void FindAll(Region obj)
        {
            try
            {
                RepoRegiones.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron obtener las regiones", e);
            }
        }
    }
}
