using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Core
{
    public interface ValidarDataInterface<T>
    {
        T Validar(T data);
    }
}
