using System;

namespace POO_Final
{
    public class PrefijoDeTelefonoEstaEnBlancoException : Exception
    {
        public override string Message { get; }
        public PrefijoDeTelefonoEstaEnBlancoException()
        {
            Message = "El prefijo del teléfono no puede estar en blanco.";
        }
    }
}