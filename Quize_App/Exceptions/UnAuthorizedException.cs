using System;
namespace Quize_App.Exceptions
{
    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException(string msg) : base(msg) { }
    }
}

