using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Model
{
    public class RespuestaDB
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
    public class Flujos:Auditoria
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
        //public string CodigoValidacionxCampo { get; set; }

        public List<ValidacionesxCampo> ValidacionesxCampo { get; set; }

    }

    public class ValidacionesxCampo
    {
        public string CodigoValidacionxCampo { get; set; }
        public string MsgErrorValidacion { get; set; }
        public string Tipo { get; set; }
        public string CodigoCampoDispo { get; set; }

    }
}
