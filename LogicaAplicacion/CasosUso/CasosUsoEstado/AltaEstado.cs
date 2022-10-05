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
        public IRepositorio<Estado> RepoEstados { get; set; }

        public AltaEstado(IRepositorio<Estado> repoEstado)
        {
            RepoEstados = repoEstado;
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
