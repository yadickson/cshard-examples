using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Domain;
using IntegracionWD.Util;

namespace IntegracionWD.Core
{
    public class ValidadorDataVehiculoImpl : ValidadorDataInterface<DataVehiculo>
    {
        public DataVehiculo Validar(DataVehiculo data)
        {
            DataVehiculo output = new DataVehiculo();

            output.Patente = new ValidadorPatente().Validar(data.Patente);
            output.Marca = new ValidadorMarca().Validar(data.Marca);
            output.Modelo = new ValidadorModelo().Validar(data.Modelo);
            output.Anio = new ValidadorAnioVehiculo().Validar(data.Anio);
            output.Tipo_Vehiculo = new ValidadorTipoVehiculo().Validar(data.Tipo_Vehiculo);
            output.Contrato = new ValidadorContrato().Validar(data.Contrato);
            output.Razon_Social = new ValidadorRazonSocial().Validar(data.Razon_Social);
            output.Fecha_Expiracion = new ValidadorFechaExpiracionVehiculo().Validar(data.Fecha_Expiracion);
            output.Motivo_Rechazo = new ValidadorMotivoRechazoVehiculo().Validar(data.Motivo_Rechazo);

            return output;
        }
    }
}
