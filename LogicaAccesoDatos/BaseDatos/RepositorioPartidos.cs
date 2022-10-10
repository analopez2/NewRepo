using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioPartidos : IRepositorioPartidos
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPartidos(LibreriaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Partido nuevo)
        {
            try
            {

                nuevo.Validar();

                IEnumerable<SeleccionPartido> partidosSeleccion1 = Contexto.SeleccionPartido
                    .Where(ps1 => ps1.SeleccionId == nuevo.SeleccionPartido.First().SeleccionId)
                    .ToList();

                IEnumerable<SeleccionPartido> partidosSeleccion2 = Contexto.SeleccionPartido
                    .Where(ps1 => ps1.SeleccionId == nuevo.SeleccionPartido.Last().SeleccionId)
                    .ToList();

                if (partidosSeleccion1.Count() == 3 || partidosSeleccion2.Count() == 3)
                {
                    throw new Exception("El máximo de partidos por seleción es 3");
                }



                Contexto.Partidos.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo dar de alta el partido", e);
            }
        }

        public IEnumerable<Partido> FindAll()
        {
            try
            {
                return Contexto.Partidos.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron encontrar partidos", e);
            }
        }

        public Partido FindById(int Id)
        {
            try
            {
                if (Id == 0) throw new Exception("El id de partido no puede ser 0");
                return Contexto.Partidos.Find(Id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el partido", e);
            }
        }

        public void Remove(int Id)
        {
            try
            {
                //Validar que no se encuentre vinculado con ninguna seleccion o grupo. 
                Partido partidoABorrar = FindById(Id);
                if (partidoABorrar == null) throw new Exception("No existe el partido a borrar");
                Contexto.Partidos.Remove(partidoABorrar);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo borrar el partido", e);
            }
        }

        public void Update(Partido obj)
        {
            try
            {
                obj.Validar();
                Contexto.Partidos.Update(obj);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo actualizar el partido", e);
            }
        }
    }
}
