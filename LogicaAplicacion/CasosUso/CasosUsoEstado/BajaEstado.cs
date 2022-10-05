using LogicaAplicacion.InterfacesCasosUso.ICasosUsoEstado;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoEstado
{
    public class BajaEstado: IBajaEstado
    {
        public IRepositorio<Estado> RepoEstados { get; set; }

        public BajaEstado(IRepositorio<Estado> repoEstado)
        {
            RepoEstados = repoEstado;
        }

        public void Remove(int id)
        {
            try
            {
                //Validar que no se encuentre vinculado con ningun partido. 
                RepoEstados.Remove(id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo borar el estado", e);
            }
        }
    }
}
