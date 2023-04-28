using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Interfaces
{
    public interface IRepositoryFlujo<T> where T : class
    {
        //public List<T> CargarCamposValidacionesDispo();
        public T  Consultar();

        public bool Eliminar(T objeto);
        public bool Editar(T objeto);

        public bool ConsultarId(int  id);



    }
}
