﻿using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InterfacesRepositorios
{
     public interface IRepositorioRegiones:IRepositorio<Region>
    {
        IEnumerable<Pais> PaisesPorRegion(Region region);
    }
}
