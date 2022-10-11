using LogicaAplicacion.InterfacesCasosUso.ICasosUsoPais;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso.CasosUsoPais
{
    public class AltaPais : IAltaPais
    {
        public IRepositorioPaises RepoPaises { get; set; }
        public IRepositorioRegiones RepoRegiones { get; set; }


        public AltaPais(IRepositorioPaises repoPaises, IRepositorioRegiones repoRegiones)
        {
            RepoPaises = repoPaises;
            RepoRegiones = repoRegiones;
        }

        public void Add(Pais nuevo)
        {
            try
            {
                nuevo.Validar();               
                RepoPaises.Add(nuevo);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("ERROR PAIS")) throw e;
                throw new Exception("No se pudo dar de alta el pais", e);
            }
        }

        public void ValidarRegion(int id)
        {
            Region region = RepoRegiones.FindById(id);
            List<string> regiones = new List<string> { "África", "América", "Asia", "Europa", "Oceania" };
            if (!regiones.Contains(region.Nombre))
            {
                throw new Exception("ERROR PAIS |La región debe ser un continente válido");
            }

        }
       
    }
}
