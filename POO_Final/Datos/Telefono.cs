using System;
using System.Text.RegularExpressions;

namespace POO_Final
{
    public sealed class Telefono
    {
        private string _prefijo;
        private string _numero;
        private Regex _valido = new Regex("^[0-9]*$");
        public string Prefijo
        {
            get => _prefijo;
            set
            {
                ValidarPrefijo(value);
                _prefijo = value;
            }
        }
        
        public string Numero
        {
            get => _numero;
            set
            {
                ValidarNumero(value);
                _numero = value;
            }
        }
       
        public Telefono(string prefijo, string numero)
        {
            ValidarPrefijo(prefijo);
            ValidarNumero(numero);
            this.Prefijo = prefijo;
            this.Numero = numero;
        }

        private void ValidarPrefijo(string prefijo)
        {
            if (string.IsNullOrWhiteSpace(prefijo) || !_valido.IsMatch(prefijo)) throw new PrefijoDeTelefonoEstaEnBlancoException();
        }

        private void ValidarNumero(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero) || !_valido.IsMatch(numero)) throw new NumeroDeTelefonoNoPuedeEstarEnBlancoException();
        }

        public override bool Equals(object o)
        {
            if (o is null) return false;
            if (ReferenceEquals(this, o)) return true;
            if (o is Telefono t)
            {
                return String.Equals(Prefijo, t.Prefijo) && String.Equals(Numero, t.Numero);
            }

            return false;
        }

        //revisar
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Prefijo != null ? Prefijo.GetHashCode() : 0) * 397) ^ (Numero != null ? Numero.GetHashCode() : 0);
            }
        }

        public static Telefono Of(string prefijo, string numero) => new Telefono(prefijo, numero);
    }
}