using LogicaAplicacion.InterfacesCasosUso.ICasosUsoEstado;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoEstado
{
    public class ActualizarEstado: IActualizarEstado
    {
        public IRepositorioEstados RepoEstados { get; set; }

        public ActualizarEstado(IRepositorioEstados repoEstados)
        {
            RepoEstados = repoEstados;
        }

        public void Update(Estado nuevo)
        {
            try
            {
                RepoEstados.Update(nuevo);
            }
            catch (Exception e)
            {
                throw new Exception("No se actualizar el estado", e);
            }
        }
    }
}
