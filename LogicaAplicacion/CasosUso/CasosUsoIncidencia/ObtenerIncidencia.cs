using LogicaAplicacion.InterfacesCasosUso.ICasosUsoIncidencia;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoIncidencia
{
    public class ObtenerIncidencia : IObtenerIncidencia
    {
        public IRepositorioIncidencias RepoIncidencias { get; set; }

        public ObtenerIncidencia(IRepositorioIncidencias repoIncidencias)
        {
            RepoIncidencias = repoIncidencias;
        }

        public void FindById(int id)
        {
            try
            {
                RepoIncidencias.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo obter la incidencia con el id indicado", e);
            }
        }
    }
}
