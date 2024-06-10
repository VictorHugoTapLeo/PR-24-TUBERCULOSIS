using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_24_TUBERCULOSIS.Model
{
    public class ClControlTratamiento : BaseModel
    {
        public int IdControl { get; set; }
        public string Basiloscopia { get; set; }
        public string Cultivo { get; set; }
        public string AumentoDosis { get; set; }
        public int PersonaIdPersona { get; set; }
        public int OrdenIdOrden { get; set; }
        public string genExpert { get; set; }
        public string Nombre { get; set; }

        /// <summary>
        /// insert
        /// </summary>
        /// <param name="idControl"></param>
        /// <param name="basiloscopia"></param>
        /// <param name="cultivo"></param>
        /// <param name="aumentoDosis"></param>
        /// <param name="personaIdPersona"></param>
        /// <param name="ordenIdOrden"></param>
        public ClControlTratamiento(int idControl, string basiloscopia, string cultivo, string aumentoDosis, int personaIdPersona, int ordenIdOrden)
        {
            IdControl = idControl;
            Basiloscopia = basiloscopia;
            Cultivo = cultivo;
            AumentoDosis = aumentoDosis;
            PersonaIdPersona = personaIdPersona;
            OrdenIdOrden = ordenIdOrden;
        }
        public ClControlTratamiento() { }
    }
}

