using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;


namespace LogicaNegocio.Dominio
{
    public class Pais: IValidable
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(100), Required(ErrorMessage = "El nombre es olbigatorio ingresarlo")]
        [RegularExpression("^[a-zA-Z]+((\\s[a-zA-Z]+)?)*$")]
        public string Nombre { get; set; }
        [MinLength(3), MaxLength(3), Required(ErrorMessage = "Es obligatorio ingresar un código alfa3")]
        [RegularExpression("^[a-zA-Z]+$")]
        public string Codigo { get; set; }
        public int Pbi { get; set; }
        public int Poblacion { get; set; }
        public string Bandera { get; set; }
        public Region Region { get; set; }

        public void Validar()
        {
            ValidarNombre();
            ValidarCodigo();
            ValidarRegion();
            ValidarNumeros();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre del país es obligatorio");
            }
            if (Nombre.Length < 3)
            {
                throw new Exception("El nombre del país debe tener al menos 3 caracteres");
            }

            if (!Regex.IsMatch(Nombre, "^[a-zA-Z]+((\\s[a-zA-Z]+)?)*$"))
            {
                throw new Exception("El nombre del país solo puede contener letras y espacios embebidos");
            }
        }

        private void ValidarCodigo()
        {
            if (string.IsNullOrEmpty(Codigo))
            {
                throw new Exception("El código del país es obligatorio");
            }

            if (Codigo.Length < 3 || Codigo.Length > 3)
            {
                throw new Exception("El código del país solo puede tener 3 caracteres");
            }

            string c = Codigo.ToCharArray()[0].ToString();
            string p = Nombre.ToCharArray()[0].ToString();

            if (c.ToLower() != p.ToLower())
            {
                throw new Exception("El código del país debe comenzar con la misma letra que el nombre del país");
            }
        }

        private void ValidarRegion()
        {
            List<string> regiones = new List<string> { "África", "América", "Asia", "Europa", "Oceania" };
            if (!regiones.Contains(Region.Nombre))
            {
                throw new Exception("La región debe ser un continente válido");
            }
        }

        private void ValidarNumeros()
        {
            if (Pbi < 0 )
            {
                throw new Exception("El Pbi debe ser mayor a 0");
            }

            if (Poblacion < 0)
            {
                throw new Exception("La Poblacion debe ser mayor a 0");
            }
        }
    }
}
