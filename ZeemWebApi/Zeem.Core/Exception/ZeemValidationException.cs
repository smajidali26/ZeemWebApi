using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeem.Core.Exception
{
    public class ZeemValidationException : System.Exception
    {
        public int Code { get; set; }

        public ZeemValidationException()
        {

        }

        public ZeemValidationException(string message) : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Exception Message</param>
        /// <param name="code">Rap Custom Code</param>
        public ZeemValidationException(string message, int code = 0) : base(message)
        {
            Code = code;
        }
    }
}
