using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Infraestructure.DataBase
{
    public class BD_Conexion
    {

        private SqlConnection Conexion = new SqlConnection("Server=PMVM207\\SQL2019;DataBase=EjecutorFlujosInsttantt;Integrated Security=true;Encrypt=False");
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
