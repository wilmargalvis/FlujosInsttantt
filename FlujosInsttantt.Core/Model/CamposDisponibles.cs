using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Model
{
    public class CamposDisponibles: Auditoria
    {
        public string  CodigoCampoDispo { get; set; }
        public string Nombre { get; set; }
        public string CodigoTipoCampo { get; set; }

    }
}
