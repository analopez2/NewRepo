﻿using LogicaAplicacion.InterfacesCasosUso;
using LogicaAplicacion.InterfacesCasosUso.ICasosUsoEstado;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoEstado
{
    public class ObtenerEstados : IObtenerEstados
    {
        public IRepositorioEstados RepoEstados { get; set; }

        public ObtenerEstados(IRepositorioEstados repoEstados)
        {
            RepoEstados = repoEstados;
        }

       

        public IEnumerable<Estado> FindAll()
        {
            try
            {
                return RepoEstados.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron obtener los estados", e);
            }
        }
    }
}
