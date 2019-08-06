using System;

namespace POO_Final
{
    internal class AlumnoDuplicadoException : Exception
    {
        public AlumnoDuplicadoException(IIdentificador id)
        {
            Message = $"El alumno con id = {id.Numero} ya existe";
        }

        public override string Message { get; }
    }
}