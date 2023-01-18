namespace Zeem.Core.Exception
{
    public class ZeemNotFoundException : System.Exception
    {
        public int Code { get; set; }

        public ZeemNotFoundException()
        {

        }

        public ZeemNotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Exception Message</param>
        /// <param name="code">Rap Custom Code</param>
        public ZeemNotFoundException(string message, int code = 0) : base(message)
        {
            Code = code;
        }
    }
}
