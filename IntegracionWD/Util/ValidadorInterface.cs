using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Util
{
    public interface ValidadorInterface<TO, TI>
    {
        TO Validar(TI input);
    }
}
