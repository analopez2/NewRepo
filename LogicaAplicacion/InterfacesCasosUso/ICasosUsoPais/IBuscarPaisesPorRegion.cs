using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosUso.ICasosUsoPais
{
    interface IBuscarPaisesPorRegion
    {
      IEnumerable<Pais> PaisesPorRegion(int regionId);
    }
}
