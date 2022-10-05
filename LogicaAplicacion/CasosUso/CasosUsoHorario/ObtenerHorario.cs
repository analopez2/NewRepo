using LogicaAplicacion.InterfacesCasosUso.ICasosUsoHorario;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoHorario
{
    class ObtenerHorario : IObtenerHorario
    {
        public IRepositorio<Horario> RepoHorarios { get; set; }

        public ObtenerHorario(IRepositorio<Horario> repoHorario)
        {
            RepoHorarios = repoHorario;
        }
        public void FindById(int id)
        {
            try
            {
                RepoHorarios.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo obter el horario con el id indicado", e);
            }
        }
    }
}
