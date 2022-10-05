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
        public IRepositorio<Incidencia> RepoIncidencias { get; set; }

        public ObtenerIncidencias(IRepositorio<Incidencia> repoIncidencia)
        {
            RepoIncidencias = repoIncidencia;
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
