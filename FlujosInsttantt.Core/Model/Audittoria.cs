using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Model
{
    public abstract class Auditoria
    {

        public Auditoria()
        {
           
        }
        public string UserName { get; set; }
        public string FechaCreacion { get; set; }
    }
}
