using System;

namespace UnitTestProject2
{
    public class IdentificadorErroneoException : Exception
    {
        public override string Message { get; }

        public IdentificadorErroneoException(string clase, string id)
        {
            Message = $"Los alumnos {clase} se identifican por {id}";
        }
    }
}