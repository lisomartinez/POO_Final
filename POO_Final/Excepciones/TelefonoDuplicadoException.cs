using System;
using POO_Final;

namespace POO_Final
{
    public class TelefonoDuplicadoException : Exception
    {
        public override string Message { get; }

        public TelefonoDuplicadoException(Telefono telefono)
        {
            Message = $"El telefono {telefono.Prefijo}-{telefono.Numero} ya se encuentra presente en el alumno";
        }
    }
}