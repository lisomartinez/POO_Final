
using System;

namespace POO_Final
{
    public class CantidadDeMateriasAprobadasInvalidaException : Exception
    {
        public CantidadDeMateriasAprobadasInvalidaException(string aprobadasStr)
        {
            Message = $"Cantidad de materias aprobadas Invalidas = {aprobadasStr}";
        }

        public override string Message { get; }
    }
}