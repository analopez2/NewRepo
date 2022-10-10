using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class Horario
    {
        public int Id { get; set; }
        public string Hora { get; set; }
        public void Validar()
        {
            ValidarHora();
        }

        public void ValidarHora()
        {
            List<string> horas = new List<string> { "07:00", "10:00", "13:00", "16:00" };
            if (!horas.Contains(Hora))
            {
                throw new Exception("ERROR HORARIO | El horario del partido debe ser válido");
            }

        }


    }

}
