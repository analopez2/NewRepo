using LogicaAplicacion.InterfacesCasosUso.ICasosUsoHorario;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoHorario
{
    public class ActualizarHorario : IActualizarHorario
    {
        public IRepositorio<Horario> RepoHorarios { get; set; }

        public ActualizarHorario(IRepositorio<Horario> repoHorario)
        {
            RepoHorarios = repoHorario;
        }
        public void Update(Horario obj)
        {
            try
            {
                RepoHorarios.Update(obj);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo actualizar el horario", e);
            }
        }
    }
}
