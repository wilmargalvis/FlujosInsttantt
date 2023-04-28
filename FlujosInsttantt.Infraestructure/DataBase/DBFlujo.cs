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

        public List<RptaCamposValidacionesDispoDB> CargarCamposValidacionesDispo()
        {

            SqlCommand comando = new SqlCommand();
            List<RptaCamposValidacionesDispoDB> lstdata = new List<RptaCamposValidacionesDispoDB>();

            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "sp_BuscarCamposDisponibles";
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = null;
                rdr = comando.ExecuteReader();

                while (rdr.Read())
                {

                    var CamposValidacionesDispo = new RptaCamposValidacionesDispoDB()
                    {
                        CodigoCampoDispo = rdr["CodigoCampoDispo"].ToString(),
                        TituloCampo = rdr["TituloCampo"].ToString(),
                        TipoCampo = rdr["TipoCampo"].ToString(),
                        CodigoValidacionDisponible = rdr["CodigoValidacionDisponible"].ToString(),
                        MsgErrorValidacion = rdr["MsgErrorValidacion"].ToString(),
                        Tipo = rdr["Tipo"].ToString()

                    };

                    lstdata.Add(CamposValidacionesDispo);

                }
            }
            catch (Exception)
            {

                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
           
            return lstdata;
        }

        public async Task<ConstruccionFlujos> ConsultarFlujo(string CodigoFlujo)
        {
            SqlCommand comando = new SqlCommand();
            ConstruccionFlujos DataFLujo = new();

            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "sp_BuscarFlujo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodigoFlujo", CodigoFlujo);

                SqlDataReader rdr = null;
                rdr = comando.ExecuteReader();
                List<RptaBuscarFlujoDB> RespuestaDB = new();

                //Lleva a un modelo de respuesta del SP ejecutado
                while (rdr.Read())
                {

                    var FlujoRdr = new RptaBuscarFlujoDB()
                    {
                        CodigoFlujo = rdr["CodigoFlujo"].ToString(),
                        Nombre = rdr["Nombre"].ToString(),
                        Categoria = rdr["Categoria"].ToString(),
                        FechaCreacion = Convert.ToDateTime(rdr["FechaCreacion"]),
                        CreadorFlujo = rdr["CreadorFlujo"].ToString(),
                        CodigoPaso = rdr["CodigoPaso"].ToString(),
                        NombrePaso = rdr["NombrePaso"].ToString(),
                        PasosPreviosRequeridos = rdr["PasosPreviosRequeridos"].ToString(),
                        CodigoCampoDispo = rdr["CodigoCampoDispo"].ToString(),
                        CodigoValidacionxCampo = rdr["CodigoValidacionxCampo"].ToString(),
                        MsgErrorValidacion = rdr["MsgErrorValidacion"].ToString(),
                        Tipo = rdr["Tipo"].ToString()
                    };

                    RespuestaDB.Add(FlujoRdr);
                }

                //Agrega al objeto del flujo a devolver, la información general del mismo
                if (RespuestaDB.Count > 0 && RespuestaDB != null)
                {
                    RptaBuscarFlujoDB regFirs = RespuestaDB.FirstOrDefault();

                    DataFLujo.CodigoFlujo = regFirs.CodigoFlujo;
                    DataFLujo.Nombre = regFirs.Nombre;
                    DataFLujo.Categoria = regFirs.Categoria;
                    DataFLujo.FechaCreacion = regFirs.FechaCreacion;
                    DataFLujo.CreadorFlujo = regFirs.CreadorFlujo;

                }

                //Recupera los pasos del flujo de la data
                List<PasosFlujo> Pasos = RespuestaDB
                            .Select(a => new { a.CodigoPaso, a.NombrePaso, a.PasosPreviosRequeridos, a.CodigoFlujo })
                            .OrderBy(n => n.CodigoPaso)
                            .Distinct()
                            .ToList().ConvertAll(a =>
                            {
                                return new PasosFlujo()
                                {
                                    CodigoPaso = a.CodigoPaso,
                                    NombrePaso = a.NombrePaso,
                                    PasosPreviosRequeridos = a.PasosPreviosRequeridos,
                                    CodigoFlujo = a.CodigoFlujo
                                };

                            });

                DataFLujo.PasosFlujo = Pasos;

                //Recupera de la data, los campos de cada paso del flujo 

                foreach (var itemPaso in Pasos)
                {

                    List<CamposxPasos> Campos = RespuestaDB
                        .Where(p => p.CodigoPaso == itemPaso.CodigoPaso)
                        .Select(a => new { a.CodigoCampoDispo, a.CodigoPaso })
                        .OrderBy(n => n.CodigoCampoDispo)
                        .Distinct()
                        .ToList().ConvertAll(a =>
                        {
                            return new CamposxPasos()
                            {
                                CodigoPaso = a.CodigoPaso,
                                CodigoCampoDispo = a.CodigoCampoDispo
                            };

                        });

                    //Agrega a cada paso del flujo los campos identificados
                    foreach (var item in DataFLujo.PasosFlujo)
                    {
                        if (item.CodigoPaso == itemPaso.CodigoPaso)
                        {
                            item.CamposxPasos = Campos;

                            //Recupera de la data, las validaciones de los campos de cada paso del flujo 
                            foreach (var itemValid in item.CamposxPasos)
                            {
                                List<ValidacionesxCampo> Validaciones = RespuestaDB
                                    .Where(p => p.CodigoCampoDispo == itemValid.CodigoCampoDispo && p.CodigoPaso == itemValid.CodigoPaso)
                                    .Select(a => new { a.CodigoValidacionxCampo, a.MsgErrorValidacion, a.Tipo, a.CodigoCampoDispo })
                                    .OrderBy(n => n.CodigoValidacionxCampo)
                                    .Distinct()
                                    .ToList().ConvertAll(a =>
                                    {
                                        return new ValidacionesxCampo()
                                        {
                                            CodigoValidacionxCampo = a.CodigoValidacionxCampo,
                                            MsgErrorValidacion = a.MsgErrorValidacion,
                                            Tipo = a.Tipo,
                                            CodigoCampoDispo = a.CodigoCampoDispo
                                        };

                                    });

                                itemValid.ValidacionesxCampo = Validaciones;
                            }

                            break;
                        }
                    }

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

            return DataFLujo;
        }

        public async Task<string> GuardarConfiguracionFlujo(FlujoCreado ObjFlujo)
        {

            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "sp_GuardarConfiguracionFlujo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", ObjFlujo.NombreFlujo);
                comando.Parameters.AddWithValue("@Categoria", ObjFlujo.Categoria);
                comando.Parameters.AddWithValue("@FechaCreacion", Convert.ToDateTime(DateTime.Now));
                comando.Parameters.AddWithValue("@CreadorFlujo", ObjFlujo.CreadorFlujo);

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

        public async Task<string> GuardarConfiguracionPaso(PasoCreado ObjPaso)
        {
            string CodPaso;
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "sp_GuardarConfiguracionPaso";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@NombrePaso", ObjPaso.NombrePaso);
                comando.Parameters.AddWithValue("@PasosPreviosRequeridos", ObjPaso.PasosPreviosRequeridos);
                comando.Parameters.AddWithValue("@CodigoFlujo", ObjPaso.CodigoFlujo);

                CodPaso = (string)comando.ExecuteScalar();

                comando.Parameters.Clear();

                foreach (var campoItem in ObjPaso.CamposCreados)
                {
                    comando.CommandText = "sp_GuardarConfiguracionCampos";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodigoCampoDispo", campoItem.CodigoCampoDispo);
                    comando.Parameters.AddWithValue("@CodigoPaso", CodPaso);
                    comando.Parameters.AddWithValue("@CodigoFlujo", campoItem.CodigoFlujo);
                    comando.ExecuteScalar();

                    comando.Parameters.Clear();

                    foreach (var valItem in campoItem.ValidacionesCreadas)
                    {
                        comando.CommandText = "sp_GuardarConfiguracionValidaciones";
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@CodigoValidacionxCampo", valItem.CodigoValidacionxCampo);
                        comando.Parameters.AddWithValue("@Tipo", valItem.Tipo);
                        comando.Parameters.AddWithValue("@MsgErrorValidacion", valItem.MsgErrorValidacion);
                        comando.Parameters.AddWithValue("@CodigoFlujo", campoItem.CodigoFlujo);
                        comando.Parameters.AddWithValue("@CodigoPaso", CodPaso);
                        comando.Parameters.AddWithValue("@CodigoCampoDispo", campoItem.CodigoCampoDispo);                       
                        comando.ExecuteScalar();
                    }
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

        public bool Eliminar(CamposValidacionesDispo camposDisponibles)
        {
            throw new NotImplementedException();
        }
    }
}
