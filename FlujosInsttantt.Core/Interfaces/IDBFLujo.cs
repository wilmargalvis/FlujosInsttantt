using FlujosInsttantt.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlujosInsttantt.Core.Model.GuardarFlujoUsuario;

namespace FlujosInsttantt.Core.Interfaces
{
    public interface IDBFLujo
    {
        public List<RptaCamposValidacionesDispoDB> CargarCamposValidacionesDispo();

        public Task<string> GuardarConfiguracionFlujo(FlujoCreado ObjFlujo);

        public Task<string> GuardarConfiguracionPaso(PasoCreado ObjPaso);

        public Task<ConstruccionFlujos> ConsultarFlujo(string CodigoFlujo);


    }
}
