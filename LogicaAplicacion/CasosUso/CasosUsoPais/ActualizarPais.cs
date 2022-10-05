﻿using LogicaAplicacion.InterfacesCasosUso.ICasosUsoPais;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class ActualizarPais: IActualizarPais
    {
        public IRepositorioPaises RepoPaises { get; set; }

        public ActualizarPais(IRepositorioPaises repoPaises)
        {
            RepoPaises = repoPaises;
        }

        public void Update(Pais nuevo)
        {
            try
            {
                nuevo.Validar();
                RepoPaises.Update(nuevo);
            }
            catch (Exception e)
            {
                throw new Exception("No se actualizar el pais", e);
            }
        }
    }
}
