using FlujosInsttantt.Core.Interfaces;
using FlujosInsttantt.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlujosInsttantt.Core.Model.GuardarFlujoUsuario;

namespace FlujosInsttantt.Core.Services
{
    public class RepositoryGenericFlujo: IRepositoryFlujo<ConstruccionFlujos>
    {
        private  IDBFLujo _dBFLujo;
        public RepositoryGenericFlujo(IDBFLujo dBFLujo)
        {
            _dBFLujo = dBFLujo;
        }

        public CamposValidacionesDispo CargarCamposValidacionesDispo()
        {
            CamposValidacionesDispo CamposValidacionesDispo = new();
            List<RptaCamposValidacionesDispoDB> RespuestaDB = _dBFLujo.CargarCamposValidacionesDispo();

            //Recupera los pasos del flujo de la data
            List<CamposDisponibles> Campos = RespuestaDB
                        .Select(a => new { a.CodigoCampoDispo, a.TituloCampo, a.TipoCampo })
                        .OrderBy(n => n.CodigoCampoDispo)
                        .Distinct()
                        .ToList().ConvertAll(a =>
                        {
                            return new CamposDisponibles()
                            {
                                CodigoCampoDispo = a.CodigoCampoDispo,
                                TituloCampo = a.TituloCampo,
                                TipoCampo = a.TipoCampo
                                
                            };

                        });
            CamposValidacionesDispo.CamposDisponibles = Campos;

            foreach (var itemCampo in Campos)
            {
                List<ValidacionesDisponibles> Validaciones = new();

                foreach (var itemValid in RespuestaDB)
                {
                    if (itemValid.CodigoCampoDispo == itemCampo.CodigoCampoDispo)
                    {
                        var VD = new ValidacionesDisponibles()
                        {
                            CodigoValidacionDispo = itemValid.CodigoValidacionDisponible,
                            MsgErrorValidacion = itemValid.MsgErrorValidacion,
                            Tipo = itemValid.Tipo
                        };
                        Validaciones.Add(VD);
                    }
                }

                foreach (var item in CamposValidacionesDispo.CamposDisponibles)
                {
                    if (item.CodigoCampoDispo == itemCampo.CodigoCampoDispo)
                    {
                        item.ValidacionesDisponibles = Validaciones;
                        break;
                    }

                }

            }

            return CamposValidacionesDispo;

        }

        public Task<ConstruccionFlujos> ConsultarFlujo(string CodigoFlujo)
        {
            return _dBFLujo.ConsultarFlujo(CodigoFlujo);
        }

        public Task<string> GuardarConfiguracionFlujo(FlujoCreado ObjFlujo)
        {
            return _dBFLujo.GuardarConfiguracionFlujo(ObjFlujo);
        }
        public Task<string> GuardarConfiguracionPaso(PasoCreado ObjPaso)
        {
            return _dBFLujo.GuardarConfiguracionPaso(ObjPaso);
        }


    }
}
