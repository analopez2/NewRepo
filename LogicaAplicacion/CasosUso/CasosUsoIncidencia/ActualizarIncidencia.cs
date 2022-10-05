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
        public IRepositorio<Incidencia> RepoIncidencias { get; set; }

        public ActualizarIncidencia(IRepositorio<Incidencia> repoIncidencia)
        {
            RepoIncidencias = repoIncidencia;
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
