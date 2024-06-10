using PR_24_TUBERCULOSIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_24_TUBERCULOSIS.Interface
{
    internal interface ISeguimientoPeso : IBase<SeguimientoPeso>
    {
        SeguimientoPeso Get(int id);
    }
}
