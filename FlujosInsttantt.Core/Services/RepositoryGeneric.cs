using FlujosInsttantt.Core.Interfaces;
using FlujosInsttantt.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Services
{
    public class RepositoryGenericCamposDisponbles: IRepositoryFlujo<CamposDisponibles>
    {
       private  IDBFLujo _dBFLujo;
        public RepositoryGenericCamposDisponbles(IDBFLujo dBFLujo)
        {
            _dBFLujo = dBFLujo;
        }
        public CamposDisponibles Consultar()
        {
            throw new NotImplementedException();
        }

        public bool ConsultarId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Editar(CamposDisponibles objeto)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(CamposDisponibles objeto)
        {
            throw new NotImplementedException();
        }

        public Task<List<CamposDisponibles>> Listar()
        {
            return  _dBFLujo.CargarCamposDisponibles();
        }


        public Task<List<CamposDisponibles>> ListarTodos()
        {
            return _dBFLujo.CargarCamposDisponibles();
        }

    }
}
