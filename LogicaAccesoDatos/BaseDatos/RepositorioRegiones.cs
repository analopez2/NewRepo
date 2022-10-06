using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioRegiones : IRepositorioRegiones
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioRegiones(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Region obj)
        {
            try
            {
                obj.Validar();
                Contexto.Regiones.Add(obj);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo dar de alta la region", e);
            }
        }

        public IEnumerable<Region> FindAll()
        {
            try
            {
                return Contexto.Regiones.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron encontrar Regiones", e);
            }
        }

        public Region FindById(int Id)
        {
            try
            {
                if (Id == 0) throw new Exception("El id de region no puede ser 0");
                return Contexto.Regiones.Find(Id);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo encontrar la region", e);
            }
        }

        public IEnumerable<Pais> PaisesPorRegion(Region region)
        {
            return Contexto.Paises.Where(pais=>pais.Region.Id==region.Id).ToList();

        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Region obj)
        {
            throw new NotImplementedException();
        }
    }
}
