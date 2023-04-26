using FlujosInsttantt.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Interfaces
{
    public interface IDBFLujo
    {
        public Task<List<CamposDisponibles>> CargarCamposDisponibles();

        public bool Guardar(CamposDisponibles camposDisponibles);
        public bool Eliminar(CamposDisponibles camposDisponibles);

        public Flujos ConsultarFlujo(string CodigoFlujo);
    }
}
