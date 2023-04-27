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
            List<RespuestaDB> RespuestaDB = new();

            //Lleva a un modelo de respuesta del SP ejecutado
            while (rdr.Read())
            {

                var FlujoRdr = new RespuestaDB()
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

            Flujos DataFLujo = new();

            //Agrega al objeto del flujo a devolver, la información general del mismo
            if (RespuestaDB.Count> 0 && RespuestaDB != null)
            {
                RespuestaDB regFirs = RespuestaDB.FirstOrDefault();

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
                                .Where(p => p.CodigoCampoDispo == itemValid.CodigoCampoDispo)
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
