using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class Incidencia : IValidable
    {
        public int Id { get; set; }
        public int RojasDirectas { get; set; }       
        public int Amarillas { get; set; }       
        public int RojasAcumAmarillas { get; set; }       
        public Seleccion Seleccion { get; set; }
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
