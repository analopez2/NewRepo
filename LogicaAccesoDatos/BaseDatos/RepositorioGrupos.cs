using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
                if (e.Message.Contains("ERROR GRUPO")) throw e;
                throw new Exception("No se puedo dar de alta el grupo");
            }
        }

        public IEnumerable<Grupo> FindAll()
        {
            try
            {
                return Contexto.Grupos.ToList();
            } catch (Exception e)
            {
                throw new Exception("No se pudo encontrar grupo", e);
            }
        }

        public Grupo FindById(int Id)
        {
            try
            {
                if (Id == 0) throw new Exception("ERROR GRUPO | El id de grupo no puede ser 0");
                return Contexto.Grupos.Find(Id);
            } catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el grupo", e);
            }
        }

        public void Remove(int Id)
        {
            try
            {            
                //Validar que no se encuentre vinculado con ninguna seleccion o partido. 
                Grupo grupoABorrar = FindById(Id);
                if (grupoABorrar == null) throw new Exception("ERROR GRUPO | No existe el grupo a borrar");

                Contexto.Grupos.Remove(grupoABorrar);
                Contexto.SaveChanges();
            } catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el grupo", e);
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
                throw new Exception("No se pudo encontrar el grupo", e);
            }
        }

        public IEnumerable<Grupo> DatosPartidos(string nomGrupo)
        {

            try
            {
                return Contexto.Grupos
                           .Where(g => g.Nombre == nomGrupo)
                           .Include(g => g.PartidoGrupo)
                           .ThenInclude(pg => pg.Partido)
                           .ThenInclude(p => p.Incidencias)
                           .ThenInclude(ip => ip.Incidencia)
                           .Include(g => g.PartidoGrupo)
                           .ThenInclude(pg => pg.Partido)
                           .ThenInclude(p => p.Estado)
                           .Include(g => g.PartidoGrupo)
                           .ThenInclude(pg => pg.Partido)
                           .ThenInclude(p => p.Hora)
                           .Include(g => g.PartidoGrupo)
                           .ThenInclude(pg => pg.Partido)
                           .ThenInclude(p => p.SeleccionPartido)
                           .ThenInclude(sp => sp.Seleccion)
                           .ThenInclude(s => s.Pais)
                           .ToList();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el grupo", e);
            }

       }
    }
}
