using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Core
{
    public interface ValidadorDataInterface<T>
    {
        T Validar(T data);
    }
}
