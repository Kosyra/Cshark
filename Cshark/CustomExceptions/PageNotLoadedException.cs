using System;
using OpenQA.Selenium;

namespace Cshark.CustomExceptions
{
    /// <summary>
    /// Exception that will be returned when page does not load correctly
    /// </summary>
    public class PageNotLoadedException : Exception
    {
        public PageNotLoadedException(){}
        public PageNotLoadedException(string message) : base( message){}
        public PageNotLoadedException(string message, Exception inner) : base(message, inner){}
    }
}