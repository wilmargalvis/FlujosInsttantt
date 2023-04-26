using FlujosInsttantt.Core.Interfaces;
using FlujosInsttantt.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Services
{
    public class RepositoryFlujo : IRepositoryFlujo<Flujos>
    {
        public Flujos Consultar()
        {
            throw new NotImplementedException();
        }

        public bool ConsultarId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Editar(Flujos objeto)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(Flujos objeto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Flujos>> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
