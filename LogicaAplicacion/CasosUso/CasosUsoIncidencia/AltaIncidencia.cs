using LogicaAplicacion.InterfacesCasosUso.ICasosUsoIncidencia;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoIncidencia
{
    public class AltaIncidencia : IAltaIncidencia
    {
        public IRepositorioIncidencias RepoIncidencias { get; set; }

        public AltaIncidencia(IRepositorioIncidencias repoIncidencias)
        {
            RepoIncidencias = repoIncidencias;
        }


        public void Add(Incidencia obj)
        {
            try
            {
                RepoIncidencias.Add(obj);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo dar de alta la incidencia", e);
            }
        }
    }
}
