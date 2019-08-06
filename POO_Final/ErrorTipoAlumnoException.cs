using System;

namespace POO_Final
{
    public class ErrorTipoAlumnoException : Exception
    {
        public override string Message => "error al escoger tipo";
    }
}