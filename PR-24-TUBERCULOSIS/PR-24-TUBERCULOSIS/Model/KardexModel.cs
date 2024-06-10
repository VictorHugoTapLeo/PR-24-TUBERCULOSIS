using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_24_TUBERCULOSIS.Model
{
    public class KardexModel : BaseModel
    {
        
        public int idKardex { get; set; }
        public string tipoTuberculosis { get; set; }
        public string saturacion { get; set; }
        public string frecuenciaCardiaca { get; set; }
        public string frecuenciaRespiratoria { get; set; }
        public int diagnosticadoPor { get; set; }
        public int idPersona { get; set; }
        public string docificacionMedicamentos { get; set; }
        public string numeroDosis { get; set; }
        public string cultivo { get; set; }
        public string basiloscopia { get; set; }


        public KardexModel() { }
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="tipoTuberculosis"></param>
        /// <param name="saturacion"></param>
        /// <param name="frecuenciaCardiaca"></param>
        /// <param name="frecuenciaRespiratoria"></param>
        /// <param name="diagnosticadoPor"></param>
        /// <param name="idPersona"></param>
        /// <param name="docificacionMedicamentos"></param>
        /// <param name="numeroDosis"></param>
        /// <param name="cultivo"></param>
        /// <param name="basiloscopia"></param>
        public KardexModel(string tipoTuberculosis, string saturacion, string frecuenciaCardiaca, string frecuenciaRespiratoria, int diagnosticadoPor, int idPersona, string docificacionMedicamentos, string numeroDosis, string cultivo, string basiloscopia)
        {
            this.tipoTuberculosis = tipoTuberculosis;
            this.saturacion = saturacion;
            this.frecuenciaCardiaca = frecuenciaCardiaca;
            this.frecuenciaRespiratoria = frecuenciaRespiratoria;
            this.diagnosticadoPor = diagnosticadoPor;
            this.idPersona = idPersona;
            this.docificacionMedicamentos = docificacionMedicamentos;
            this.numeroDosis = numeroDosis;
            this.cultivo = cultivo;
            this.basiloscopia = basiloscopia;
        }
        /// <summary>
        /// GET
        /// </summary>
        /// <param name="idKardex"></param>
        /// <param name="tipoTuberculosis"></param>
        /// <param name="saturacion"></param>
        /// <param name="frecuenciaCardiaca"></param>
        /// <param name="frecuenciaRespiratoria"></param>
        /// <param name="diagnosticadoPor"></param>
        /// <param name="estado"></param>
        /// <param name="fechacreacion"></param>
        /// <param name="fechaactualizacion"></param>
        /// <param name="idPersona"></param>
        /// <param name="docificacionMedicamentos"></param>
        /// <param name="numeroDosis"></param>
        /// <param name="cultivo"></param>
        /// <param name="basiloscopia"></param>
        public KardexModel(int idKardex, string tipoTuberculosis, string saturacion, string frecuenciaCardiaca, string frecuenciaRespiratoria, int diagnosticadoPor, byte estado, DateTime fechacreacion, DateTime fechaactualizacion, int idPersona, string docificacionMedicamentos, string numeroDosis, string cultivo, string basiloscopia)
            : base(estado, fechacreacion, fechaactualizacion)
        {
            this.idKardex = idKardex;
            this.tipoTuberculosis = tipoTuberculosis;
            this.saturacion = saturacion;
            this.frecuenciaCardiaca = frecuenciaCardiaca;
            this.frecuenciaRespiratoria = frecuenciaRespiratoria;
            this.diagnosticadoPor = diagnosticadoPor;
            this.idPersona = idPersona;
            this.docificacionMedicamentos = docificacionMedicamentos;
            this.numeroDosis = numeroDosis;
            this.cultivo = cultivo;
            this.basiloscopia = basiloscopia;
        }
    }
}
