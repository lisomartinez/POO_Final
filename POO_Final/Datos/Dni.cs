using System;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

namespace POO_Final
{
    public class Dni : IIdentificador, IEquatable<Dni>
    {
        private Regex _valido = new Regex("^[0-9]*$");
        public override string ToString()
        {
            return $"Dni: {Numero}";
        }

        public string Numero { get; }
        public static Dni Vacio => new Dni("0");

        public Dni(string numero)
        {
            if (String.IsNullOrWhiteSpace(numero) || !_valido.IsMatch(numero)) throw new NumeroDeIdentificadorVacioException();

            Numero = numero;
        }

        public static Dni Of(string numero) => new Dni(numero);

        public bool Equals(Dni other)
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
            return Equals((Dni) obj);
        }

        public override int GetHashCode()
        {
            return (Numero != null ? Numero.GetHashCode() : 0);
        }
    }
}