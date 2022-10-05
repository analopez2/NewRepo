using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InterfacesRepositorios
{
     public interface IRepositorioGrupos:IRepositorio<Grupo>
    {
        IEnumerable<Partido> DatosPartidos(Grupo grupo);
    }
}
