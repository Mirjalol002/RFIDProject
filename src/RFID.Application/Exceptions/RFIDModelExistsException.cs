namespace RFID.Application.Exceptions
{
    public class RFIDModelExistsException : Exception
    {
        private const string _message = "TagId is Exists";
        public RFIDModelExistsException() : base(_message) { }
    }
}