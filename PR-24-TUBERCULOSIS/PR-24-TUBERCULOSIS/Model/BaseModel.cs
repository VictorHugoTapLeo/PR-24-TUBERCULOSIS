using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_24_TUBERCULOSIS.Model
{
    public class BaseModel
    {
        public byte estado { get; set; }
        public DateTime fechacreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }

        public BaseModel()
        {

        }
        public BaseModel(byte Estado, DateTime Fechacreacion, DateTime Fechaactualizacion)
        {
            estado = Estado;
            fechacreacion = Fechacreacion;
            fechaactualizacion = Fechaactualizacion;

        }
    }
}
