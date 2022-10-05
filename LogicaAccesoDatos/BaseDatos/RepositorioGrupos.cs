using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using System.Linq;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioGrupos : IRepositorioGrupos
    {
        public LibreriaContext Contexto { get; set; }

       public RepositorioGrupos(LibreriaContext ctx)
        {
            Contexto = ctx;
        }   
        
        public void Add(Grupo nuevo)
        {
            try
            {
                nuevo.Validar();
                Contexto.Grupos.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("No se pudo dar de alta el grupo", e);
            }
        }

        public IEnumerable<Grupo> FindAll()
        {
            try
            {
                return Contexto.Grupos.ToList();
            } catch (Exception e)
            {
                throw new Exception("No se pudo encontrar paises", e);
            }
        }

        public Grupo FindById(int Id)
        {
            try
            {
                if (Id == 0) throw new Exception("El id de grupo no puede ser 0");
                return Contexto.Grupos.Find(Id);
            } catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el país", e);
            }
        }

        public void Remove(int Id)
        {
            try
            {            
                //Validar que no se encuentre vinculado con ninguna seleccion o partido. 
                Grupo grupoABorrar = FindById(Id);
                if (grupoABorrar == null) throw new Exception("No existe el grupo a borrar");

                Contexto.Grupos.Remove(grupoABorrar);
                Contexto.SaveChanges();
            } catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el país", e);
            }

        }

        public void Update(Grupo nuevo)
        {
            try
            {
                nuevo.Validar();
                Contexto.Grupos.Update(nuevo);
                Contexto.SaveChanges();
            } catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el país", e);
            }
        }

        public IEnumerable<Partido> DatosPartidos(Grupo grupo)
        {
            //Implementar cuando se tenga el repo de partidos...
            throw new NotImplementedException();
        }
    }
}
