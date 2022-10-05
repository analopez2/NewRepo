using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosUso
{
     public interface IObtenerObjeto<T>
    {
        void FindById(int id);
    }
}
