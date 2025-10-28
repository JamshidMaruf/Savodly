﻿namespace Savodly.Service.Exceptions
{
    public class ArgumentIsNotValidException : Exception
    {
        public int StatusCode { get; set; }
        public ArgumentIsNotValidException(string message) : base(message)
        {
            StatusCode = 400;
        }
    }
}
