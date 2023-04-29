using FlujosInsttantt.Core.Interfaces;
using FlujosInsttantt.Core.Services;
using Microsoft.AspNetCore.Mvc;
using static FlujosInsttantt.Core.Model.GuardarFlujoUsuario;

namespace EjecutorFlujosInsttantt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcesamientoUsuarioController : Controller
    {

        // GET: ConstruccionFlujoController

        RepositoryGenericDataUsuario _repository;

        public ProcesamientoUsuarioController(IDataUsuarioDB IDataUsuarioDB)
        {
            RepositoryGenericDataUsuario repository = new(IDataUsuarioDB);
            _repository = repository;
        }


        /// <summary>
        /// Guarda los datos del usuario que va a diligenciar el flujo
        /// </summary>
        /// <param name="ObjUsuario"></param>
        /// <returns></returns>
        [HttpPost("guardarusuario")]
        public async Task<ActionResult> GuardarUsuario(Usuarios ObjUsuario)
        {
            string result;

            try
            {
                result = await _repository.GuardarUsuario(ObjUsuario);

                if (result == "")
                {
                    return BadRequest("No fue posible guardar la información del usuario");

                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

            return new OkObjectResult("Código usuario guardado: " + result);

        }


        /// <summary>
        /// Guarda los datos del flujo a completar, antes se diligenciar el 1mer paso
        /// </summary>
        /// <param name="ObjFlujoUsuario"></param>
        /// <returns></returns>
        [HttpPost("guardarflujousuario")]
        public async Task<ActionResult> GuardarFlujoUsuario(FlujoUsuarios ObjFlujoUsuario)
        {
            string result;

            try
            {
                result = await _repository.GuardarFlujoUsuario(ObjFlujoUsuario);

                if (result == "")
                {
                    return BadRequest("No fue posible guardar la información del flujo del usuario");

                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

            return new OkObjectResult("Código flujo guardado: " + result);

        }


        /// <summary>
        /// Guarda cada paso con los campos completados
        /// </summary>
        /// <param name="ObjPasoUsuario"></param>
        /// <returns></returns>
        [HttpPost("guardarpasousuario")]
        public async Task<ActionResult> GuardarPasoUsuario(PasosUsuarios ObjPasoUsuario)
        {
            string result;

            try
            {
                result = await _repository.GuardarPasoUsuario(ObjPasoUsuario);

                if (result == "")
                {
                    return BadRequest("No fue posible guardar la información del paso del flujo del usuario");

                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

            return new OkObjectResult("Código paso guardado: " + result);

        }

        /// <summary>
        /// Busca la data del paso actual del flujo
        /// Por tiempo no fue posible terminar la lógia de este método.
        /// Por el momento solo confirma si el paso fue encontrado, pero no devuelve la data.
        /// Se debe buscar en la tbl CamposxPasoxFlujoxUsuario la data del paso
        /// los campos del paso, para cargarlos en la vista.
        /// Al mismo tiempo se valida en la CamposPasosPreviosRequeridos si todos los pasos requisitos
        /// del siguiente ya fueron llenos, para poder continuar.
        /// </summary>
        /// <param name="ObjBuscarPasoUsuario"></param>
        /// <returns></returns>
        [HttpPost("buscarpasousuario")]
        public async Task<ActionResult> BuscarPasoUsuario(PasoFlujo ObjBuscarPasoUsuario)
        {
            string result;

            try
            {
                result = await _repository.BuscarPasoUsuario(ObjBuscarPasoUsuario);

                if (result == "" || result == null)
                {
                    return new OkObjectResult("Paso no encontrado");

                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

            return new OkObjectResult("Paso encontrado: " + result + " por falta de tiempo no devolví los campos hallados");

        }

        // Por falta de tiempo, No pude hacer el método para consultar la data de todos los pasos del flujo dado 

    }
}
