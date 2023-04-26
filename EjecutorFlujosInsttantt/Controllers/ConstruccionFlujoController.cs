using FlujosInsttantt.Core.Interfaces;
using FlujosInsttantt.Core.Model;
using FlujosInsttantt.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjecutorFlujosInsttantt.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ConstruccionFlujoController : Controller
    {
        // GET: ConstruccionFlujoController
        private RepositoryGenericCamposDisponbles _repository;
        private IDBFLujo dBFLujo;
        public ConstruccionFlujoController(IDBFLujo repository)
        {
            dBFLujo = repository;
        }



        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: ConstruccionFlujoController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: https://localhost:7124/ConstruccionFlujo?id=10

        [HttpGet("")]
        public async Task<ActionResult> ConsultarCamposDisponibles(string UsuarioCreador)
        {
            List<CamposDisponibles> data = await dBFLujo.CargarCamposDisponibles();

            if (data.Count == 0 || data == null)
            {
                return BadRequest("No fue posible recuperar los campos disponibles");

            }else
            {
                return new OkObjectResult(data);
            }

        }

        [HttpGet("consultarflujo")]
        public ActionResult ConsultarFlujo(string CodigoFlujo)
        {
            Flujos data = dBFLujo.ConsultarFlujo(CodigoFlujo);

            if (data == null)
            {
                return BadRequest("No fue posible recuperar la información del flujo");

            }
            else
            {
                return new OkObjectResult(data);
            }

        }

        //// GET: ConstruccionFlujoController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ConstruccionFlujoController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ConstruccionFlujoController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ConstruccionFlujoController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ConstruccionFlujoController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ConstruccionFlujoController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}
