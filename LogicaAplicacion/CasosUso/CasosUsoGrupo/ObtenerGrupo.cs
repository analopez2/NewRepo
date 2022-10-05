using LogicaAplicacion.InterfacesCasosUso.ICasosUsoGrupos;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class ObtenerGrupo : IObtenerGrupo
    {
        public IRepositorioGrupos RepoGrupos { get; set; }

        public ObtenerGrupo(IRepositorioGrupos repoGrupos)
        {
            RepoGrupos = repoGrupos;
        }

        public void FindById(int id)
        {
            try
            {
                RepoGrupos.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo obter el grupo con el id indicado", e);
            }
        }
    }
}
