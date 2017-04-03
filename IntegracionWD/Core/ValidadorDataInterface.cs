using System;
using System.Collections.Generic;
using System.Text;

namespace IntegracionWD.Core
{
    public interface ValidadorDataInterface<T>
    {
        T Validar(T data);
    }
}
