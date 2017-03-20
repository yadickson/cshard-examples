using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IntegracionWD
{
    [ServiceContract]
    public interface IPersonasRestService : IPersonasService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/")]
        string CheckService();

        [OperationContract]
        [WebInvoke(Method="POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AgregarPersona/")]
        string AgregarPersona();
    }
}
