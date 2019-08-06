using System;

namespace POO_Final
{
    public class NumeroDeTelefonoNoPuedeEstarEnBlancoException : Exception
    {
        public override string Message => "El numero de telefono no puede estar en blanco";
    }
}