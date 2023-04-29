using FlujosInsttantt.Core.Interfaces;
using FlujosInsttantt.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlujosInsttantt.Core.Model.GuardarFlujoUsuario;

namespace FlujosInsttantt.Core.Services
{
    public class RepositoryGenericDataUsuario : IRepositoryDataUsuario<FlujoUsuarios>
    {
        public IDataUsuarioDB _IDataUsuarioDB;
        public RepositoryGenericDataUsuario(IDataUsuarioDB IDataUsuarioDB)
        {
            _IDataUsuarioDB = IDataUsuarioDB;
        }
        public Task<string> GuardarUsuario(Usuarios ObjUsuario)
        {
            return _IDataUsuarioDB.GuardarUsuario(ObjUsuario);
        }
        public Task<string> GuardarFlujoUsuario(FlujoUsuarios ObjUsuario)
        {
            return _IDataUsuarioDB.GuardarFlujoUsuario(ObjUsuario);
        }
        public Task<string> GuardarPasoUsuario(PasosUsuarios ObjFlujo)
        {
            return _IDataUsuarioDB.GuardarPasoUsuario(ObjFlujo);

        }

        public Task<string> BuscarPasoUsuario(PasoFlujo ObjBuscarPasoUsuario)
        {
            return _IDataUsuarioDB.BuscarPasoUsuario(ObjBuscarPasoUsuario);

        }
        

    }
}
