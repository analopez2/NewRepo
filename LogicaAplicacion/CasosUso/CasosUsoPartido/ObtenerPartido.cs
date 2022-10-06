using LogicaAplicacion.InterfacesCasosUso.ICasosUsoPartido;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoPartido
{
    public class ObtenerPartido : IObtenerPartido
    {

        public IRepositorioPartidos RepoPartidos { get; set; }

        public ObtenerPartido(IRepositorioPartidos repoPartidos)
        {
            RepoPartidos = repoPartidos;
        }

        public void FindById(int id)
        {
            try
            {
                RepoPartidos.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo obter el pais con el id indicado", e);
            }
        }
    }
}
