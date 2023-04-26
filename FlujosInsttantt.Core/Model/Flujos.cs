using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Model
{
    public class Flujos:Auditoria
    {
        public string CodigoFlujo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadorFlujo { get; set; }
    }
}
