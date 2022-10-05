using LogicaAplicacion.InterfacesCasosUso.ICasosUsoIncidencia;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoIncidencia
{
    public class BajaIncidencia : IBajaIncidencia
    {
        public IRepositorio<Incidencia> RepoIncidencias { get; set; }

        public BajaIncidencia(IRepositorio<Incidencia> repoIncidencia)
        {
            RepoIncidencias = repoIncidencia;
        }
        public void Remove(int id)
        {
            try
            {
                //Validar que no se encuentre vinculado con ningun partido. 
                RepoIncidencias.Remove(id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo borar la Incidencia", e);
            }
        }
    }
}
