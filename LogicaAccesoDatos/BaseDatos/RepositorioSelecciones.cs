using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoDatos.BaseDatos
{
     public class RepositorioSelecciones:IRepositorioSelecciones
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioSelecciones(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public int CalcularPuntos(List<Partido> partidos)
        {
            throw new NotImplementedException();
        }

        public void Add(Seleccion obj)
        {
            try
            {
                obj.Validar();
                Contexto.Selecciones.Add(obj);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo dar de alta la Seleccion", e);
            }
        }

        public void Remove(int Id)
        {
            try
            {
                Seleccion seleccionABorrar = FindById(Id);
                if (seleccionABorrar == null) throw new Exception("No existe la seleccion a borrar");
                if (seleccionABorrar.PaisId!=0) throw new Exception("No se puede borrar la seleccion porque esta asociada a un pais");
                if (seleccionABorrar.GrupoId!= 0) throw new Exception("No se puede borrar la seleccion porque esta asociada a un grupo");

                Contexto.Selecciones.Remove(seleccionABorrar);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo borrar la seleccion", e);
            }
        }

        public void Update(Seleccion obj)
        {
            try
            {
                obj.Validar();
                Contexto.Selecciones.Update(obj);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo actualizar la seleccion", e);
            }
        }

        public Seleccion FindById(int Id)
        {
            try
            {
                if (Id == 0) throw new Exception("El id de seleccion no puede ser 0");
                return Contexto.Selecciones.Find(Id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo encontrar la seleccion", e);
            }
        }

        public IEnumerable<Seleccion> FindAll()
        {
            try
            {
                return Contexto.Selecciones.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron encontrar selecciones", e);
            }
        }
    }
}
