using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioIncidencias : IRepositorioIncidencias
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioIncidencias(LibreriaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Incidencia obj)
        {
            try
            {
                obj.Validar();
                Contexto.Incidencias.Add(obj);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo dar de alta la incidencia", e);
            }
        }

        public IEnumerable<Incidencia> FindAll()
        {
            try
            {
                return Contexto.Incidencias.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron encontrar Incidencias", e);
            }
        }

        public Incidencia FindById(int Id)
        {
            try
            {
                if (Id == 0) throw new Exception("El id de la Incidencia no puede ser 0");
                return Contexto.Incidencias.Find(Id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo encontrar la incidencia", e);
            }
        }

            public void Remove(int Id)
        {
            try
            {
                //Validar que no se encuentre vinculada con ningun partido. 
                Incidencia incidenciaABorrar = FindById(Id);
                if (incidenciaABorrar == null) throw new Exception("No existe la incidencia a borrar");
                Contexto.Incidencias.Remove(incidenciaABorrar);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo borrar la incidencia", e);
            }
        }

        public void Update(Incidencia obj)
        {
            try
            {
                obj.Validar();
                Contexto.Incidencias.Update(obj);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo actualizar la incidencia", e);
            }
        }
    }
}
