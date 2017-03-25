using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Constants;
using IntegracionWD.Exception;
using System.Data.SqlClient;
using System.Data;

namespace IntegracionWD.DataBase
{
    public class CommonDao
    {
        private SqlParameter resultado;
        private SqlParameter mensaje;

        public void AgregarParametrosSalida(SqlCommand cmd)
        {
            resultado = new SqlParameter("@Resultado", SqlDbType.NVarChar);
            resultado.Direction = ParameterDirection.Output;
            resultado.Size = 50;
            cmd.Parameters.Add(resultado);

            mensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar);
            mensaje.Direction = ParameterDirection.Output;
            mensaje.Size = 4000;
            cmd.Parameters.Add(mensaje);
        }

        public void ValidarResultado(string codigo)
        {
            string strResultado = Convert.ToString(resultado.Value).ToUpper();
            string strMensaje = Convert.ToString(mensaje.Value).ToUpper();

            if (!Messages.CODIGO_DAO_EXITOSO.Equals(strResultado))
            {
                throw new BusinessException(strMensaje, codigo + "-" + strResultado);
            }
        }

    }
}
