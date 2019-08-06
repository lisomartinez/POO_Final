using System;

namespace POO_Final
{
    public class AlumnoLocal : Alumno
    {
        public AlumnoLocal(Legajo legajo, string nombre, string apellido, DateTime fechaIngreso) : base(legajo, nombre, apellido, fechaIngreso)
        {

        }


        //Permite calcular la antiguedad en base al formato escogido.
        public override int Antiguedad(Formato formato = Formato.Dia)
        {
            int diferencia = 0;
            DateTime hoy = DateTime.Today;
            switch (formato)
            {
                case (Formato.Dia):
                {
                    TimeSpan dif = hoy - FechaIngreso;
                    diferencia = dif.Days;
                    break;
                }

                //Si mes es igual y el día de la fecha de ingreso es mayor al día de hoy, hay que restar uno
                case (Formato.Anio):
                {
                    diferencia = hoy.Year - FechaIngreso.Year;
                    if (FechaIngreso.Month > hoy.Month ||
                        (FechaIngreso.Month == hoy.Month && FechaIngreso.Day > hoy.Day))
                        diferencia--;
                    break;
                }

                //Si mes es superior hay que restar un año.
                //Si el mes es igual y el formato es superior hay que restar un año.
                //Si mes es menor no se resta.
                // si me es igual y el formato es menor no se resta.
                //no hay que redondear
                case (Formato.Mes):
                {
                    diferencia = (hoy.Year * 12 + hoy.Month) - (FechaIngreso.Year * 12 + FechaIngreso.Month);
                    if (FechaIngreso.Day > hoy.Day)
                        diferencia--;
                    break;
                }

                default:
                    throw new NotImplementedException();
            }

            return diferencia;
        }
    }
}