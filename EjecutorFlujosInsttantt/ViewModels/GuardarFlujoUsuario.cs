namespace EjecutorFlujosInsttantt.ViewModels
{
    public class GuardarFlujoUsuario
    {
        public class Usuarios
        {
            public string CodigoUsuario { get; set; }
            public string NombreUsuario { get; set; }
            public string Clave { get; set; }
            public List<FlujoUsuarios> PasosUsuarios { get; set; }
        }

        public class FlujoUsuarios
        {
            public string FechaVencimiento { get; set; }
            public string EstadoFlujo { get; set; }
            public string CodigoUsuario { get; set; }
            public string CodigoFlujoUsuario { get; set; }

            public List<PasosUsuarios> PasosUsuarios { get; set; }
        }

        public class PasosUsuarios
        {
            public string CodigoFlujoUsuario { get; set; }
            public string CodigoPasoUsuario { get; set; }
            public string Estado { get; set; }

            public List<CamposPasosPreviosRequeridos> CamposPasosPreviosRequeridos { get; set; }
        }

        public class CamposPasosPreviosRequeridos
        {
            public string CodigoPasoPrevioRequerido { get; set; }
            public string CodigoCampoPasoPrevioRequerido { get; set; }

        }
    }
}
