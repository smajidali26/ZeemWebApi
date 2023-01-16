namespace Zeem.Core.Exception
{
    public class NotFoundException : System.Exception
    {
        public int Code { get; set; }

        public NotFoundException()
        {

        }

        public NotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Exception Message</param>
        /// <param name="code">Rap Custom Code</param>
        public NotFoundException(string message, int code = 0) : base(message)
        {
            Code = code;
        }
    }
}
