using LogicaAplicacion.InterfacesCasosUso.ICasosUsoHorario;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoHorario
{
    class ObtenerHorarios : IObtenerHorarios
    {
        public IRepositorio<Horario> RepoHorarios { get; set; }

        public ObtenerHorarios(IRepositorio<Horario> repoHorario)
        {
            RepoHorarios = repoHorario;
        }
        public void FindAll(Horario obj)
        {
            try
            {
                RepoHorarios.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron obtener los horarios", e);
            }
        }
    }
}
