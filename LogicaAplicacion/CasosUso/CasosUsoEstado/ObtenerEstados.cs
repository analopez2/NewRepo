using LogicaAplicacion.InterfacesCasosUso;
using LogicaAplicacion.InterfacesCasosUso.ICasosUsoEstado;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoEstado
{
    public class ObtenerEstados : IObtenerEstados
    {
        public IRepositorio<Estado> RepoEstados { get; set; }

        public ObtenerEstados(IRepositorio<Estado> repoEstado)
        {
            RepoEstados = repoEstado;
        }

        public void FindAll(Estado obj)
        {
            try
            {
                RepoEstados.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron obtener los estados", e);
            }
        }
    }
}
