using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class SeleccionGrupo
    {
        public Grupo Grupo { get; set; }
        public Seleccion Seleccion { get; set; }
        public int GrupoId { get; set; }
        public int SeleccionId { get; set; }

    }
}
