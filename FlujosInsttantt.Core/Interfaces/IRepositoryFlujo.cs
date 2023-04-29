using FlujosInsttantt.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Interfaces
{
    public interface IRepositoryFlujo<T> where T : class
    {
        CamposValidacionesDispo CargarCamposValidacionesDispo();
        Task<T> ConsultarFlujo(string CodigoFlujo);
        Task<string> GuardarConfiguracionFlujo(FlujoCreado ObjFlujo);
        Task<string> GuardarConfiguracionPaso(PasoCreado ObjPaso);

    }
}
