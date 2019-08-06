using System;

namespace POO_Final
{
    public class FormatoFechaInvalidoException : Exception
    {
        public override string Message { get; }

        public FormatoFechaInvalidoException(string fechaStr)
        {
            Message = $"el formato ingresado es inválido {fechaStr}. Debe ser DD/MM/AAAA";
        }
    }
}