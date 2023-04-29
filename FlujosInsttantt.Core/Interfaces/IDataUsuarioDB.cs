using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlujosInsttantt.Core.Model;
using static FlujosInsttantt.Core.Model.GuardarFlujoUsuario;

namespace FlujosInsttantt.Core.Interfaces
{
    public interface IDataUsuarioDB
    {
        Task<string> GuardarUsuario(Usuarios ObjUsuario);

        Task<string> GuardarFlujoUsuario(FlujoUsuarios ObjUsuario);

        Task<string> GuardarPasoUsuario(PasosUsuarios ObjPaso);

        Task<string> BuscarPasoUsuario(PasoFlujo ObjBuscarPasoUsuario);

    }
}
