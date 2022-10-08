using LogicaAplicacion.InterfacesCasosUso.ICasosUsoEstado;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class AltaEstado: IAltaEstado
    {
        public IRepositorioEstados RepoEstados { get; set; }

        public AltaEstado(IRepositorioEstados repoEstados)
        {
            RepoEstados = repoEstados;
        }

        public void Add(Estado nuevo)
        {
            try
            {
                RepoEstados.Add(nuevo);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo dar de alta el estado", e);
            }
        }
    }
}
