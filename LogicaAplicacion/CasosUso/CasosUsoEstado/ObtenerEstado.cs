using LogicaAplicacion.InterfacesCasosUso.ICasosUsoEstado;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoEstado
{
    public class ObtenerEstado: IObtenerEstado
    {
        public IRepositorioEstados RepoEstados { get; set; }

        public ObtenerEstado(IRepositorioEstados repoEstados)
        {
            RepoEstados = repoEstados;
        }

        public void FindById(int id)
        {
            try
            {
                RepoEstados.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo obter el estado con el id indicado", e);
            }
        }
    }
}
