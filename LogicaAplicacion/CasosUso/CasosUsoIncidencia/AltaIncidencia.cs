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
        public IRepositorio<Incidencia> RepoIncidencias { get; set; }

        public AltaIncidencia(IRepositorio<Incidencia> repoIncidencia)
        {
            RepoIncidencias = repoIncidencia;
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
