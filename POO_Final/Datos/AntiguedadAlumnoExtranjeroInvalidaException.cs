using System;

namespace POO_Final
{
    public class AntiguedadAlumnoExtranjeroInvalidaException : Exception
    {
        public override string Message => "la antiguedad de los alumnos extranjeros solo puede calcularse por día";
    }
}