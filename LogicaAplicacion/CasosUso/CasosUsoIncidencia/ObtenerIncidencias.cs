using LogicaAplicacion.InterfacesCasosUso.ICasosUsoIncidencia;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoIncidencia
{
    public class ObtenerIncidencias : IObtenerIncidencias
    {
        public IRepositorioIncidencias RepoIncidencias { get; set; }

        public ObtenerIncidencias(IRepositorioIncidencias repoIncidencias)
        {
            RepoIncidencias = repoIncidencias;
        }
        public void FindAll(Incidencia obj)
        {
            try
            {
                RepoIncidencias.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron obtener las incidencias", e);
            }
        }
    }
}
