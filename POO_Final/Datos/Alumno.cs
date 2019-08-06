using System;
using System.Collections.Generic;

namespace POO_Final
{
    public abstract class Alumno
    {
        public IIdentificador Le { get; set;  }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaIngreso { get; }
        public List<Telefono> Telefonos { get; set; }

        protected Alumno(IIdentificador le, string nombre, string apellido, DateTime fechaIngreso)
        {
            Le = le;
            Nombre = nombre;
            Apellido = apellido;
            FechaIngreso = fechaIngreso;
            Telefonos = new List<Telefono>();
        }

        public void AgregarTelefono(Telefono telefono)
        {
            if (Telefonos.Exists(t => t.Equals(telefono))) throw new TelefonoDuplicadoException(telefono);
            Telefonos.Add(telefono);
        }

        public abstract int Antiguedad(Formato formato = Formato.Dia);

        public class Asc : IComparer<Alumno>
        {
            public int Compare(Alumno x, Alumno y)
            {
                return String.Compare(x.Apellido, y.Apellido);
            }
        }

        public class Desc : IComparer<Alumno>
        {
            public int Compare(Alumno x, Alumno y)
            {
                return String.Compare(x.Apellido, y.Apellido) * -1;
            }
        }
    }

}