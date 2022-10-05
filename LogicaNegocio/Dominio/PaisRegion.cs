using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class PaisRegion
    {
        public Pais Pais { get; set; }
        public Region Region { get; set; }

        public int PaisId { get; set; }
        public int RegionId { get; set; }
    }
}
