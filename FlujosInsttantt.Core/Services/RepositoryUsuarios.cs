using FlujosInsttantt.Core.Interfaces;
using FlujosInsttantt.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Services
{
    public class RepositoryGenericUsuarios : IRepositoryFlujo<ConstruccionFlujos>
    {
        public ConstruccionFlujos Consultar()
        {
            throw new NotImplementedException();
        }

        public bool ConsultarId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Editar(ConstruccionFlujos objeto)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(ConstruccionFlujos objeto)
        {
            throw new NotImplementedException();
        }

        public Task<List<ConstruccionFlujos>> CargarCamposValidacionesDispo()
        {
            throw new NotImplementedException();
        }
    }
}
