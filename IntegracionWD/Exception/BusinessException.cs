using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace IntegracionWD.Exception
{
    [Serializable]
    public class BusinessException : System.Exception
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BusinessException));

        private string code;

        public BusinessException(string message, string code)
            : base(message)
        {
            this.code = code;
            log.Error(Message + ": " + code);
        }

        public BusinessException(string message, string code, System.Exception inner)
            : base(message, inner)
        {
            this.code = code;
            log.Error(Message + ": " + code, inner);
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public string Code
        {
            get { return code; }
        }
    }
}
