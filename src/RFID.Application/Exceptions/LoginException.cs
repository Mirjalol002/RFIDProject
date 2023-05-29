﻿namespace RFID.Application.Exceptions
{
    public class LoginException : Exception
    {
        private const string _message = "UserName or Password is wrong";
        public LoginException() : base(_message) { }
        public LoginException(Exception innerException) : base(_message, innerException) { }
    }
}
