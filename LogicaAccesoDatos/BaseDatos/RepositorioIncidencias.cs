using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
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
        public void Add(Incidencia nueva)
        {
            try
            {
                nueva.Validar();

                List<Incidencia> incidenciasPartido = new List<Incidencia>();

                IEnumerable <Incidencia> incidencias = Contexto.Incidencias
                                                        .Include(i => i.PartidoIncidencia)
                                                        .ToList();

                foreach (var i in incidencias)
                {
                    if (i.PartidoIncidencia.First().PartidoId == nueva.PartidoIncidencia.First().PartidoId)
                    {
                        incidenciasPartido.Add(i);
                    }
                }

                if (incidenciasPartido.Count() > 0)
                {
                    if(incidenciasPartido.Count() >= 2) throw new Exception("ERROR INCIDENCIA | No se pueden cargar más de 2 incidencias por partido");

                    foreach (var i in incidenciasPartido)
                    {
                        if (i.SeleccionId == nueva.SeleccionId) throw new Exception("ERROR INCIDENCIA | Ya existe una incidencia para esta selección en este partido");
                        incidenciasPartido.Add(nueva);
                        ActualizarPuntosSelecciones(incidenciasPartido);
                        ActualizarEstadoPartido(i.PartidoIncidencia.First().PartidoId);
                        Contexto.Incidencias.Add(nueva);
                        Contexto.SaveChanges();
                    }
                } else
                {
                    Contexto.Incidencias.Add(nueva);
                    Contexto.SaveChanges();

                }                

            }
            catch (Exception e)
            {
                if (e.Message.Contains("ERROR INCIDENCIA")) throw e;
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
                if (Id == 0) throw new Exception("ERROR INCIDENCIA | El id de la Incidencia no puede ser 0");
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
                if (incidenciaABorrar == null) throw new Exception("ERROR INCIDENCIA | No existe la incidencia a borrar");
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

        private void ActualizarPuntosSelecciones(IEnumerable<Incidencia> incidencias)
        {
            int golesSelecion1 = incidencias.First().Goles;
            int golesSelecion2 = incidencias.Last().Goles;
            Seleccion seleccion1 = Contexto.Selecciones.Find(incidencias.First().SeleccionId);
            Seleccion seleccion2 = Contexto.Selecciones.Find(incidencias.Last().SeleccionId);
            if (golesSelecion1 > golesSelecion2)
            {
                int puntosSeleccion1 = 3;
                seleccion1.Puntos += puntosSeleccion1;

                Contexto.Selecciones.Update(seleccion1);
                Contexto.SaveChanges();
            }
            else if (golesSelecion1 < golesSelecion2)
            {
                int puntosSeleccion2 = 3;
                seleccion2.Puntos += puntosSeleccion2;

                Contexto.Selecciones.Update(seleccion2);
                Contexto.SaveChanges();
            }
            else
            {
                int puntosSeleccion1 = 1;
                int puntosSeleccion2 = 1;
                seleccion1.Puntos += puntosSeleccion1;
                seleccion2.Puntos += puntosSeleccion2;

                Contexto.Selecciones.Update(seleccion1);
                Contexto.SaveChanges();
                Contexto.Selecciones.Update(seleccion2);
                Contexto.SaveChanges();
            }
        }

        private void ActualizarEstadoPartido(int partidoId)
        {
            Partido partido = Contexto.Partidos.Find(partidoId);

            if (partido != null)
            {
                Estado estadoPartido = Contexto.Estados.Where(e => e.EstadoPartido == "FINALIZADO").SingleOrDefault();
                if (estadoPartido != null)
                {
                    partido.Estado = estadoPartido;
                }
            }


            Contexto.Partidos.Update(partido);
            Contexto.SaveChanges();
        }
    }
}
