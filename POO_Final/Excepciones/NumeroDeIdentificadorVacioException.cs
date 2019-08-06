using System;

namespace POO_Final
{
    public class NumeroDeIdentificadorVacioException : Exception
    {
        public override string Message => "El identificador no puede ser nulo.";
    }
}