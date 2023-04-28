using FlujosInsttantt.Core.Model;

namespace EjecutorFlujosInsttantt.ViewModels
{
    public class FlujoCreado: Auditoria
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

    public class CamposCreados : Auditoria
    {
        public string CodigoCampoDispo { get; set; }
        //public string CodigoPaso { get; set; }
        public string CodigoFlujo { get; set; }
        public List<ValidacionesCreadas> ValidacionesCreadas { get; set; }

    }
    public class ValidacionesCreadas : Auditoria
    {
        public string CodigoValidacionxCampo { get; set; }
        public string MsgErrorValidacion { get; set; }
        public string Tipo { get; set; }
        public string CodigoCampoDispo { get; set; }

    }

}
