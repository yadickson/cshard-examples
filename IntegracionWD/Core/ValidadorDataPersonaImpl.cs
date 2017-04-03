using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;
using IntegracionWD.Util;

namespace IntegracionWD.Core
{
    public class ValidadorDataPersonaImpl : ValidadorDataInterface<DataPersona>
    {
        public DataPersona Validar(DataPersona data)
        {
            DataPersona output = new DataPersona();

            output.Nombre = new ValidadorNombre().Validar(data.Nombre);
            output.Apellido = new ValidadorApellido().Validar(data.Apellido);
            output.RUT = new ValidadorRUT().Validar(data.RUT);
            output.Tarjeta = new ValidadorTarjeta().Validar(data.Tarjeta);
            output.Tipo_Pase = new ValidadorTipoPase().Validar(data.Tipo_Pase);
            output.Contrato = new ValidadorContrato().Validar(data.Contrato);
            output.Razon_Social = new ValidadorRazonSocial().Validar(data.Razon_Social);
            output.Fecha_Expiracion_Trabajador = new ValidadorFechaExpiracionTrabajador().Validar(data.Fecha_Expiracion_Trabajador);
            output.Motivo_Rechazo_Trabajor = new ValidadorMotivoRechazoTrabajor().Validar(data.Motivo_Rechazo_Trabajor);
            output.Fecha_Expiracion_Licencia = new ValidadorFechaExpiracionLicencia().Validar(data.Fecha_Expiracion_Licencia);
            output.Motivo_Rechazo_Licencia = new ValidadorMotivoRechazoLicencia().Validar(data.Motivo_Rechazo_Licencia);

            return output;
        }
    }
}
