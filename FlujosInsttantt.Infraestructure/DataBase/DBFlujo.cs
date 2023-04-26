using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlujosInsttantt.Core.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using FlujosInsttantt.Core.Interfaces;

namespace FlujosInsttantt.Infraestructure.DataBase
{
    public class DBFlujo: IDBFLujo
    {
        private BD_Conexion conexion = new BD_Conexion();

        public async Task<List<CamposDisponibles>> CargarCamposDisponibles()
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_BuscarCamposDisponibles";
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = null;
            rdr = comando.ExecuteReader();
            List<CamposDisponibles> lstdata = new List<CamposDisponibles>();

            while (rdr.Read())
            {
               
                var CamposDisponibles = new CamposDisponibles()
                {
                    CodigoCampoDispo= rdr["CodigoCampoDispo"].ToString(),
                    Nombre = rdr["Nombre"].ToString(),
                    CodigoTipoCampo= rdr["CodigoTipoCampo"].ToString()

                };

                lstdata.Add(CamposDisponibles);              

            }
            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return lstdata;
        }

        public Flujos ConsultarFlujo(string CodigoFlujo)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_BuscarFlujo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodigoFlujo", CodigoFlujo);

            SqlDataReader rdr = null;
            rdr = comando.ExecuteReader();
            Flujos DataFLujo = new Flujos();

            while (rdr.Read())
            {

                var InfoFLujo = new Flujos()
                {
                    CodigoFlujo = rdr["CodigoFlujo"].ToString(),
                    Nombre = rdr["Nombre"].ToString(),
                    Categoria = rdr["Categoria"].ToString(),
                    FechaCreacion = Convert.ToDateTime(rdr["FechaCreacion"]),
                    CreadorFlujo= rdr["CreadorFlujo"].ToString()


                };

                DataFLujo = InfoFLujo;
            }

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return DataFLujo;
        }

        public bool Eliminar(CamposDisponibles camposDisponibles)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(CamposDisponibles camposDisponibles)
        {
            throw new NotImplementedException();
        }
    }
}
