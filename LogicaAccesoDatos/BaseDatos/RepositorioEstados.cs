using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using System.Linq;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioEstados : IRepositorioEstados
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioEstados(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Estado nuevo)
        {
            try
            {
                Contexto.Estados.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo dar de alta el estado", e);
            }
        }

        public IEnumerable<Estado> FindAll()
        {
            try
            {            
                return Contexto.Estados.ToList();

            } catch (Exception e)
            {
                throw new Exception("No se pudieron encontrar los estados", e);
            }
        }

        public Estado FindById(int Id)
        {
            try
            {
                if (Id == 0) throw new Exception("El id de estado no puede ser 0");
                return Contexto.Estados.Find(Id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el estado", e);
            }
            
        }

        public void Remove(int Id)
        {
            try
            {
                Estado estadoABorrar = FindById(Id);
                if (estadoABorrar == null) throw new Exception("No existe el estado a borrar");

                Contexto.Estados.Remove(estadoABorrar);
                Contexto.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception("No se pudo borrar el estado", e);
            }

        }

        public void Update(Estado nuevo)
        {
            try
            {
                Contexto.Estados.Update(nuevo);
                Contexto.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception("No se pudo actualizar el estado", e);
            }

        }
    }
}
