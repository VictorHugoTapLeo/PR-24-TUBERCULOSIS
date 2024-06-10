
using PR_24_TUBERCULOSIS.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_24_TUBERCULOSIS.Model
{
    public class SeguimientoPeso: BaseModel
    {

        /// <summary>
        /// insert
        /// </summary>
        /// <param name="peso"></param>
        /// <param name="idPersona"></param>
        public SeguimientoPeso(byte peso, int idPersona)
        {
            this.peso = peso;
            this.idPersona = idPersona;
        }
        /// <summary>
        /// get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="peso"></param>
        /// <param name="idPersona"></param>

        /// <param name="estado"></param>
        /// <param name="fechacreacion"></param>
        /// <param name="fechaactualizacion"></param>
        public SeguimientoPeso(int id, byte peso, int idPersona, byte estado, DateTime fechacreacion, DateTime fechaactualizacion)
            :base (estado,fechacreacion,fechaactualizacion)
        {
            this.id = id;
            this.peso = peso;
            this.idPersona = idPersona;

        }

        public int id { get; set; }
        public byte peso { get; set; }
        public int idPersona { get; set; }
        public string FechaRegistro; // Propiedad para la fecha de registro
        public string Paciente;

        
    }
}
