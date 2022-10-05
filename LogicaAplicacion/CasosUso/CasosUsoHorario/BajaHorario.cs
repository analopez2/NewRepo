using LogicaAplicacion.InterfacesCasosUso.ICasosUsoHorario;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoHorario
{
    public class BajaHorario : IBajaHorario
    {
        public IRepositorio<Horario> RepoHorarios { get; set; }

        public BajaHorario(IRepositorio<Horario> repoHorario)
        {
            RepoHorarios = repoHorario;
        }
        public void Remove(int id)
        {

            try
            {
                //Validar que no se encuentre vinculado con ningun partido. 
                RepoHorarios.Remove(id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo borar el horario", e);
            }
        }
    }
}
