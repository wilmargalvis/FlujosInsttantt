﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujosInsttantt.Core.Model
{
    public class GuardarFlujoUsuario
    {
        public class Usuarios
        {
            public string CodigoUsuario { get; set; }
            public string NombreUsuario { get; set; }
            public string Clave { get; set; }
            //public List<FlujoUsuarios> PasosUsuarios { get; set; }
        }

        public class FlujoUsuarios
        {
            public string FechaVencimiento { get; set; }
            public string EstadoFlujo { get; set; }
            public string CodigoUsuario { get; set; }
            public string CodigoFlujoUsuario { get; set; }

            //public List<PasosUsuarios> PasosUsuarios { get; set; }
        }

        public class PasosUsuarios
        {
            public string CodigoUsuario { get; set; }
            public string CodigoFlujoUsuario { get; set; }
            public string CodigoPasoUsuario { get; set; }
            public string Estado { get; set; }

            public List<CamposPasosUsuarios> CamposPasosUsuarios { get; set; }
        }

        public class CamposPasosUsuarios
        {
            public string TipoCampo { get; set; }

            public string DataCampo { get; set; }

        }

        public class CamposPasosPreviosRequeridos
        {
            public string CodigoPasoPrevioRequerido { get; set; }
            public string CodigoCampoPasoPrevioRequerido { get; set; }

        }

        public class PasoFlujo
        {
            public string CodigoUsuario { get; set; }
            public string CodigoFlujoUsuario { get; set; }
            public string CodigoPasoUsuario { get; set; }

        }
    }
}
