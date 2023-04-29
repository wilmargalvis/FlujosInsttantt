using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlujosInsttantt.Core.Model.GuardarFlujoUsuario;

namespace FlujosInsttantt.Core.Interfaces
{
    public interface IRepositoryDataUsuario<T> where T : class
    {
        Task<string> GuardarUsuario(Usuarios ObjUsuario);

        Task<string> GuardarFlujoUsuario(T ObjUsuario);

        Task<string> GuardarPasoUsuario(PasosUsuarios ObjFlujo);

        Task<string> BuscarPasoUsuario(PasoFlujo ObjBuscarPasoUsuario);



    }
}
