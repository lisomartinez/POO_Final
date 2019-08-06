using System;
using System.Text.RegularExpressions;

namespace POO_Final
{
    public sealed class Legajo : IIdentificador, IEquatable<Legajo>
    {
        public string Numero { get; }
        public static Legajo Vacio => new Legajo("0");
        private Regex _valido = new Regex("^[0-9]*$");

        public static Legajo Of(string numero) => new Legajo(numero);

        public Legajo(string numero)
        {
            if (String.IsNullOrWhiteSpace(numero) || !_valido.IsMatch(numero)) throw new NumeroDeIdentificadorVacioException();
            Numero = numero;
        }

        public bool Equals(Legajo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Numero, other.Numero);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Legajo) obj);
        }

        public override int GetHashCode()
        {
            return (Numero != null ? Numero.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return $"Legajo: {Numero}";
        }
    }
}