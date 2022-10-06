using LogicaAplicacion.InterfacesCasosUso.ICasosUsoIncidencia;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoIncidencia
{
    public class ActualizarIncidencia : IActualizarIncidencia
    {
        public IRepositorioIncidencias RepoIncidencias { get; set; }

        public ActualizarIncidencia(IRepositorioIncidencias repoIncidencias)
        {
            RepoIncidencias = repoIncidencias;
        }
        public void Update(Incidencia obj)
        {

            try
            {
                RepoIncidencias.Update(obj);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo actualizar la Incidencia", e);
            }
        } 
    }
}
