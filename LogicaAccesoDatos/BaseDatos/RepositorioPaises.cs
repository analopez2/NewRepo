﻿using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using System.Linq;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioPaises : IRepositorioPaises
    {
       public LibreriaContext Contexto { get; set; }

       public RepositorioPaises(LibreriaContext ctx)
        {
            Contexto = ctx;
        }   
        
        public void Add(Pais nuevo)
        {
            try
            {
                nuevo.Validar();
                Contexto.Paises.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("No se pudo dar de alta el pais", e);
            }
        }

        public Pais BuscarPorCodAlfa(string codAlfa)
        {
            try
            {
                Pais p = Contexto.Paises.Where(pais => pais.Codigo == codAlfa).SingleOrDefault();
                return p;
            } catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el país", e);
            }

        }


        public IEnumerable<Pais> FindAll()
        {
            try
            {
                return Contexto.Paises.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron encontrar países", e);
            }
        }

        public Pais FindById(int Id)
        {
            try
            {
                if (Id == 0) throw new Exception("El id de país no puede ser 0");
                return Contexto.Paises.Find(Id);
            } catch (Exception e)
            {
                throw new Exception("No se pudo encontrar el país", e);
            }
        }

        public IEnumerable<Pais> PaisesPorRegion(int regionId)
        {
            try {
                return Contexto.Paises.Where(pais => pais.RegionInd == regionId).ToList();
            } catch (Exception e)
            {
                throw new Exception("No se encontraron paises", e);
            }
        }


        public void Remove(int Id)
        {
            try
            {
                Pais paisABorrar = FindById(Id);
                if (paisABorrar == null) throw new Exception("No existe el país a borrar");

                var selecciones = Contexto.Selecciones.Where(s => s.Pais.Id == Id);
                bool haySeleccionesDelPais = selecciones.Count() > 0;

                if (haySeleccionesDelPais) throw new Exception("No se puede borrar el pais porque existen selecciones pertenecientes a dicho país");
                
                Contexto.Paises.Remove(paisABorrar);
                Contexto.SaveChanges();

            } catch (Exception e)
            {
                throw new Exception("No se pudo borrar el país", e);
            }
        }

        public void Update(Pais nuevo)
        {
            try
            {
                nuevo.Validar();
                Contexto.Paises.Update(nuevo);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo actualizar el país", e);
            } 
        }
    }
}
