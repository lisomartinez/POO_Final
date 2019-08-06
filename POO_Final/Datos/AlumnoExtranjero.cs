using System;
using POO_Final;

namespace POO_Final
{
    public class AlumnoExtranjero : Alumno
    {
        public string Universidad { get; set; }
        public int MateriasAprobadas { get; set; }

        public AlumnoExtranjero(Dni dni, string nombre, string apellido, DateTime fechaIngreso, string universidad, int materiasAprobadas) : base(dni, nombre, apellido, fechaIngreso)
        {
            Universidad = universidad;
            MateriasAprobadas = materiasAprobadas;
        }

        public override int Antiguedad(Formato formato = Formato.Dia)
        {
            if (formato != Formato.Dia) throw new AntiguedadAlumnoExtranjeroInvalidaException();
            TimeSpan dif = DateTime.Today - FechaIngreso;
            return dif.Days;
        }
    }
}