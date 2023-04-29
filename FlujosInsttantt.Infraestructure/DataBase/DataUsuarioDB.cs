using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlujosInsttantt.Core.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using FlujosInsttantt.Core.Interfaces;
using static FlujosInsttantt.Core.Model.GuardarFlujoUsuario;

namespace FlujosInsttantt.Infraestructure.DataBase
{
    public class DataUsuarioDB: IDataUsuarioDB
    {
        private BD_Conexion conexion = new BD_Conexion();
        public async Task<string> GuardarUsuario(Usuarios ObjFlujo)
        {

            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "sp_GuardarUsuario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodigoUsuario", ObjFlujo.CodigoUsuario);
                comando.Parameters.AddWithValue("@NombreUsuario", ObjFlujo.NombreUsuario);
                comando.Parameters.AddWithValue("@FechaCreacion", Convert.ToDateTime(DateTime.Now));
                comando.Parameters.AddWithValue("@Clave", ObjFlujo.Clave);

                return (string)comando.ExecuteScalar();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }

        }

        public async Task<string> GuardarFlujoUsuario(FlujoUsuarios ObjFlujo)
        {

            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "sp_GuardarFlujoUsuario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FechaVencimiento", Convert.ToDateTime(ObjFlujo.FechaVencimiento));
                comando.Parameters.AddWithValue("@EstadoFlujo", ObjFlujo.EstadoFlujo);
                comando.Parameters.AddWithValue("@CodigoUsuario", ObjFlujo.CodigoUsuario);
                comando.Parameters.AddWithValue("@CodigoFlujoUsuario", ObjFlujo.CodigoFlujoUsuario);

                return (string)comando.ExecuteScalar();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }

        }

        public async Task<string> GuardarPasoUsuario(PasosUsuarios ObjPaso)
        {
            string CodPaso;
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "sp_GuardarPasosUsuario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodigoUsuario", ObjPaso.CodigoUsuario);
                comando.Parameters.AddWithValue("@CodigoFlujoUsuario", ObjPaso.CodigoFlujoUsuario);
                comando.Parameters.AddWithValue("@CodigoPasoUsuario", ObjPaso.CodigoPasoUsuario);
                comando.Parameters.AddWithValue("@Estado", "Completado");

                CodPaso = (string)comando.ExecuteScalar();
                comando.Parameters.Clear();

                foreach (var campoItem in ObjPaso.CamposPasosUsuarios)
                {
                    comando.CommandText = "sp_GuardarCamposUsuario";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodigoUsuario", ObjPaso.CodigoUsuario);
                    comando.Parameters.AddWithValue("@CodigoFlujoUsuario", ObjPaso.CodigoFlujoUsuario);
                    comando.Parameters.AddWithValue("@CodigoPasoUsuario", ObjPaso.CodigoPasoUsuario);
                    comando.Parameters.AddWithValue("@TipoCampo", campoItem.TipoCampo);
                    comando.Parameters.AddWithValue("@DataCampo", campoItem.DataCampo);
                    comando.ExecuteScalar();

                }

                }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }

            return CodPaso;

        }

        public async Task<string> BuscarPasoUsuario(PasoFlujo ObjBuscarPasoUsuario)
        {
            string CodPaso="";
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "sp_BuscarPasoFlujoUsuario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodigoUsuario", ObjBuscarPasoUsuario.CodigoUsuario);
                comando.Parameters.AddWithValue("@CodigoFlujoUsuario", ObjBuscarPasoUsuario.CodigoFlujoUsuario);
                comando.Parameters.AddWithValue("@CodigoPasoUsuario", ObjBuscarPasoUsuario.CodigoPasoUsuario);

                CodPaso = (string)comando.ExecuteScalar();

            }
            catch (Exception)
            {

                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }

            return CodPaso;
        }
    }
}
