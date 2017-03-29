using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;
using IntegracionWD.Util;

namespace IntegracionWD.Core
{
    public class ValidadorDataPersonaImpl : ValidarDataInterface<DataPersona>
    {
        public DataPersona Validar(DataPersona data)
        {
            DataPersona output = new DataPersona();

            output.Nombre = new ValidadorNombre().Validar(data.Nombre);
            output.Apellido = new ValidadorApellido().Validar(data.Apellido);
            output.RUT = new ValidadorRUT().Validar(data.RUT);
            output.Tarjeta = new ValidadorTarjeta().Validar(data.Tarjeta);
            output.TipoPase = new ValidadorTipoPase().Validar(data.TipoPase);
            output.Contrato = new ValidadorContrato().Validar(data.Contrato);
            output.RazonSocial = new ValidadorRazonSocial().Validar(data.RazonSocial);
            output.FechaExpiracionTrabajador = new ValidadorFechaExpiracionTrabajador().Validar(data.FechaExpiracionTrabajador);
            output.MotivoRechazoTrabajor = new ValidadorMotivoRechazoTrabajor().Validar(data.MotivoRechazoTrabajor);
            output.FechaExpiracionLicencia = new ValidadorFechaExpiracionTrabajador().Validar(data.FechaExpiracionLicencia);
            output.MotivoRechazoLicencia = new ValidadorMotivoRechazoLicencia().Validar(data.MotivoRechazoLicencia);

            return output;
        }
    }
}
