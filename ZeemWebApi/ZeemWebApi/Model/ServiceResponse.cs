namespace ZeemWebApi.Model
{
    public class ServiceResponse<T>
    {
        public T Model { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ExceptionType { get; set; }

        public Exception Exception { get; set; }
    }
}
