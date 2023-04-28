using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Model
{

    public class RptaCamposValidacionesDispoDB
    {
        public string CodigoCampoDispo { get; set; }
        public string TituloCampo { get; set; }
        public string TipoCampo { get; set; }
        public string CodigoValidacionDisponible { get; set; }
        public string MsgErrorValidacion { get; set; }
        public string Tipo { get; set; }
    }
    public class CamposValidacionesDispo : Auditoria
    {
        public List<CamposDisponibles> CamposDisponibles { get; set; }

    }

    public class CamposDisponibles
    {
        public string CodigoCampoDispo { get; set; }
        public string TituloCampo { get; set; }
        public string TipoCampo { get; set; }
        public List<ValidacionesDisponibles> ValidacionesDisponibles { get; set; }
    }
    public class ValidacionesDisponibles
    {
        public string CodigoValidacionDispo { get; set; }
        public string MsgErrorValidacion { get; set; }
        public string Tipo { get; set; }
    }


    public class RptaBuscarFlujoDB
    {
        public string CodigoFlujo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadorFlujo { get; set; }

        public string CodigoPaso { get; set; }
        public string NombrePaso { get; set; }
        public string PasosPreviosRequeridos { get; set; }
        public string CodigoCampoDispo { get; set; }

        public string CodigoValidacionxCampo { get; set; }
        public string MsgErrorValidacion { get; set; }
        public string Tipo { get; set; }

    }
    public class ConstruccionFlujos:Auditoria
    {
        public string CodigoFlujo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadorFlujo { get; set; }

        public List<PasosFlujo> PasosFlujo { get; set; }
    }

    public class PasosFlujo
    {
        public string CodigoPaso { get; set; }
        public string NombrePaso { get; set; }
        public string PasosPreviosRequeridos { get; set; }
        public string CodigoFlujo { get; set; }
        public List<CamposxPasos> CamposxPasos { get; set; }

    }

    public class CamposxPasos
    {
        public string CodigoCampoDispo { get; set; }
        public string CodigoPaso { get; set; }

        public List<ValidacionesxCampo> ValidacionesxCampo { get; set; }

    }

    public class ValidacionesxCampo
    {
        public string CodigoValidacionxCampo { get; set; }
        public string MsgErrorValidacion { get; set; }
        public string Tipo { get; set; }
        public string CodigoCampoDispo { get; set; }

    }



    public class FlujoCreado : Auditoria
    {
        public string NombreFlujo { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadorFlujo { get; set; }

    }

    public class PasoCreado : Auditoria
    {
        public string NombrePaso { get; set; }
        public string PasosPreviosRequeridos { get; set; }
        public string CodigoFlujo { get; set; }

        public List<CamposCreados> CamposCreados { get; set; }

    }

    public class CamposCreados
    {
        public string CodigoCampoDispo { get; set; }
        //public string CodigoPaso { get; set; }
        public string CodigoFlujo { get; set; }

        public List<ValidacionesCreadas> ValidacionesCreadas { get; set; }

    }
    public class ValidacionesCreadas
    {
        public string CodigoValidacionxCampo { get; set; }
        public string MsgErrorValidacion { get; set; }
        public string Tipo { get; set; }
        public string CodigoCampoDispo { get; set; }

    }

}
