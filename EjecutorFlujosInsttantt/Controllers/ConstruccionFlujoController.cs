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
        private RepositoryGenericFlujo _repository;
        public IDBFLujo dBFLujo;

        public ConstruccionFlujoController(IDBFLujo dBFLujox)
        {
            this.dBFLujo = dBFLujox;
            RepositoryGenericFlujo repoGeneric = new RepositoryGenericFlujo(dBFLujo);
            _repository = repoGeneric;
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

        /// <summary>
        /// Este método carga los campos en el front para poder iniciar la construcción de los pasos del flujo
        /// Queda registro de aufitoría de quien consultó
        /// </summary>
        /// <param name="Auditoria"></param>
        /// <returns></returns>
        [HttpGet("")]
        public ActionResult ConsultarCamposValidacionesDispo(string Usuario)
        {
            CamposValidacionesDispo data;

            try
            {
                data =  _repository.CargarCamposValidacionesDispo();

                if (data == null)
                {
                    return BadRequest("No fue posible recuperar los campos disponibles");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
                
            return new OkObjectResult(data);
            
        }

        /// <summary>
        /// Este médodo carga la configuración de un flujo seleccionado(CodigoFlujo) para ser completado por el usuario
        /// Ejemplo: FLJ-0001, FLJ-0002
        /// </summary>
        /// <param name="CodigoFlujo"></param>
        /// <returns></returns>
        [HttpGet("consultarflujo")]
        public async Task<ActionResult> ConsultarFlujo(string CodigoFlujo)
        {
            ConstruccionFlujos data;

            try
            {
                data = await _repository.ConsultarFlujo(CodigoFlujo);

                if (data == null)
                {
                    return BadRequest("No fue posible recuperar la información del flujo");

                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

            return new OkObjectResult(data);

        }

        /// <summary>
        /// Este médodo Guarda la configuración básica de un flujo que se está construllendo
        /// Se pide parámetros y descriptivos y de config general del flujo. El SP de BD genera el código
        /// </summary>
        /// <param name="ObjFlujo"></param>
        /// <returns></returns>
        [HttpPost("guardarconfigflujo")]
        public async Task<ActionResult> GuardarConfiguracionFlujo(FlujoCreado ObjFlujo)
        {
            string result;

            try
            {
                result = await _repository.GuardarConfiguracionFlujo(ObjFlujo);

                if (result == "")
                {
                    return BadRequest("No fue posible guardar la configuración del flujo");

                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

            return new OkObjectResult("Código flujo: " + result);

        }

        /// <summary>
        /// Este método solicita datos descriptivos del paso y si tiene un prerequisito del paso anterior
        /// No requiere indicarle el código del paso, porque el SP de BD lo genera
        /// Se requiere conocer código del flujo(CodigoFlujo). Ejemplo: FLJ-0001, FLJ-0002, porque este fue previamente creado y guardado
        /// Determiné guardar el paso junto con los campos y sus validaciones, por comportarse como un componente del flujo
        /// </summary>
        /// <param name="ObjPaso"></param>
        /// <returns></returns>
        [HttpPost("guardarconfigpaso")]
        public async Task<ActionResult> GuardarConfiguracionPaso(PasoCreado ObjPaso)
        {
            string resultPaso;

            try
            {
                resultPaso = await _repository.GuardarConfiguracionPaso(ObjPaso);

                if (resultPaso == "")
                {
                    return BadRequest("No fue posible guardar la configuración del paso");

                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

            return new OkObjectResult("Código paso: " + resultPaso);

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
