using LogicaAplicacion.InterfacesCasosUso.ICasosUsoPais;
using LogicaAplicacion.InterfacesCasosUso.ICasosUsoRegion;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebMVC.Controllers
{
    public class PaisesController : Controller
    {
        public IAltaPais AltaPais  { get; set; }
        public IObtenerPaises ObtenerPaises  { get; set; }
        public IObtenerPais ObtenerPais { get; set; }
        public IBajaPais BajaPais { get; set; }
        public IActualizarPais ActualizarPais { get; set; }
        public IBuscarPaisesPorRegion BuscarPaisesPorRegion { get; set; }
        public IBuscarPaisPorCodigoAlfa BuscarPaisPorCodigo { get; set; }
        public IObtenerRegiones ObtenerRegiones { get; set; }
        public IWebHostEnvironment WHE { get; set; }

        public PaisesController(IActualizarPais actualizar,
                                IAltaPais alta, 
                                IBajaPais baja,
                                IObtenerPais obtenerPais,
                                IObtenerPaises obtenerPaises,
                                IBuscarPaisesPorRegion paisesPorRegion,
                                IBuscarPaisPorCodigoAlfa paisesPorCodigo,
                                IObtenerRegiones obtenerRegiones,
                                IWebHostEnvironment whe)
        {
            AltaPais = alta;
            BajaPais = baja;
            ActualizarPais = actualizar;
            ObtenerPais = obtenerPais;
            ObtenerPaises = obtenerPaises;
            BuscarPaisesPorRegion = paisesPorRegion;
            BuscarPaisPorCodigo = paisesPorCodigo;
            ObtenerRegiones = obtenerRegiones;
            WHE = whe;

        }
        // GET: PaisesController
        public ActionResult Index()
        {
            IEnumerable<Pais> paises = ObtenerPaises.FindAll();
            return View(paises);
        }

        // GET: PaisesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaisesController/Create
        public ActionResult Create()
        {
            PaisViewModel vm = new PaisViewModel();
            vm.Regiones = ObtenerRegiones.FindAll();
            return View(vm);          
            
        }

        // POST: PaisesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaisViewModel vm)
        {
            try
            {
                if (vm.Bandera == null)
                {
                    throw new Exception("ERROR PAIS |Debe seleccionar una bandera");
                }
                FileInfo fi = new FileInfo(vm.Bandera.FileName);
                
                string ext = fi.Extension;               
                string nomImagenBandera = vm.Pais.Codigo + ext;               
                vm.Pais.Bandera = nomImagenBandera;               
                string rutaRaiz = WHE.WebRootPath;                
                string rutaCarpeta = Path.Combine(rutaRaiz, "Banderas");
                string rutaArchivo = Path.Combine(rutaCarpeta, nomImagenBandera);
                vm.Pais.RegionId = vm.IdRegionSeleccionada;
                AltaPais.Add(vm.Pais);
                FileStream fs = new FileStream(rutaArchivo, FileMode.Create);               
                vm.Bandera.CopyTo(fs);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                vm.Regiones = ObtenerRegiones.FindAll();
                return View(vm);
            }
        }

        public ActionResult PaisesPorRegion(int codigo)
        {
            try
            {
                if (codigo == 0)
                {
                    throw new Exception("El codigo de region debe ser mayor a 0");
                }
                IEnumerable<Pais> paisesPorRegion = BuscarPaisesPorRegion.PaisesPorRegion(codigo);
                if (paisesPorRegion.Count() == 0)
                {
                    throw new Exception("No existen paises con codigo de region "+codigo);
                }
                return View(paisesPorRegion);
            }
            catch (Exception e)
            {
                ViewBag.Error=e.Message;
                return View("Error");

            }             
        }
       

        public ActionResult PaisesPorCodigoAlfa(string codigo)
        {
            try
            {
                if (codigo == null || codigo.Length!=3)
                {
                    throw new Exception("Debe ingresar un codigo Alfa3 valido");
                }
                Pais paisesPorCodigoAlfa = BuscarPaisPorCodigo.BuscarPorCodAlfa(codigo);
                if (paisesPorCodigoAlfa == null)
                {
                    throw new Exception("No existe pais con codigo Alfa3 " + codigo);
                }
                return View(paisesPorCodigoAlfa);
            }
            catch (Exception e)
            {

                ViewBag.Error = e.Message;
                return View("Error");
            }
           
        }

        public ActionResult PaisesPorId(int codigo)
        {
            try
            {
                if (codigo == 0)
                {
                    throw new Exception("Debe ingresar un Id mayor a 0");
                }
                Pais paisesPorId = ObtenerPais.FindById(codigo);
                if (paisesPorId == null)
                {
                    throw new Exception("No existe el pais con Id " + codigo);
                }
                return View(paisesPorId);
            }
            catch (Exception e)
            {

                ViewBag.Error = e.Message;
                return View("Error");
            }

        }

        // GET: PaisesController/Edit/5
        public ActionResult Edit(int id)
        {
            Pais aEditar = ObtenerPais.FindById(id);
            return View(aEditar);
        }

        // POST: PaisesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pais p)
        {
            try
            {
                ActualizarPais.Update(p);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        // GET: PaisesController/Delete/5
        public ActionResult Delete(int id)
        {
            Pais aBorrar = ObtenerPais.FindById(id);
            return View(aBorrar);
        }

        // POST: PaisesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pais pais)
        {
            try
            {

                BajaPais.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }
    }
}
