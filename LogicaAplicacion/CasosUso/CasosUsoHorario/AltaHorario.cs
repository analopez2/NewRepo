using LogicaAplicacion.InterfacesCasosUso.ICasosUsoHorario;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoHorario
{
    public class AltaHorario : IAltaHorario
    {
        public IRepositorio<Horario> RepoHorarios { get; set; }

        public AltaHorario(IRepositorio<Horario> repoHorario)
        {
            RepoHorarios = repoHorario;
        }
        public void Add(Horario obj)
        {
            try
            {
                RepoHorarios.Add(obj);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo dar de alta el Horario", e);
            }
        }
    }
}
