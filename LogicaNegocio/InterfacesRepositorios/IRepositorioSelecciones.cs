﻿using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InterfacesRepositorios
{
   public interface IRepositorioSelecciones:IRepositorio<Seleccion>
    {
        int CalcularPuntos(List<Partido> partidos);
    }
}
