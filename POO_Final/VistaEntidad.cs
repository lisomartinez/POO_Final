using POO_Final;

namespace POO_Final
{
    //Vista entidad con un solo tipo de antiguedad
    public class VistaEntidad
    {
        public string Nombre => _alumno.Nombre;
        public string Apellido => _alumno.Apellido;
        public string FechaIngreso => _alumno.FechaIngreso.ToString();
        public string Identificador => _alumno.Le.ToString();
        private Alumno _alumno;
        private Formato _formato;

        //Si hay una sola antiguedad en el caso de los alumnos locales se utiliza la variable de instancia _formato para escoger el formato.
        //Si es un alumno extranjero se lo ordena por días (no se pasa parámetro porque el método antiguedad tieen por defecto el valor Formato.Dia.
        //Si por error se le pasases un parámetro a una instancia de Alumno extranjero tira una excepcion.
        public string Antiguedad => _alumno is AlumnoExtranjero ? _alumno.Antiguedad().ToString() : _alumno.Antiguedad(_formato).ToString();
        public string Universidad => _alumno is AlumnoExtranjero e ? e.Universidad : "No aplica" ;


        public VistaEntidad(Alumno alumno)
        {
            _alumno = alumno;
        }

        public Alumno ObtenerAlumno() => _alumno;

        //si se cambia el formato de calculos de la antiguedad del DGV hay que recorrer la lista de vistaEntidades 
        //para establecer el formato.
        public void EstablecerFormato(Formato formato) => _formato = formato;
    }

    //Vista entidad con varios tipos de antiguedades tipo de antiguedad
    public class VistaEntidadMultiplesAntiguedades
    {
        public string Nombre => _alumno.Nombre;
        public string Apellido => _alumno.Apellido;
        public string FechaIngreso => _alumno.FechaIngreso.ToString();
        public string Identificador => _alumno.Le.ToString();
        private Alumno _alumno;

        //no se pasa parametro porque por defecto el metodo antiguedad tiene el formato de d'ias.
        public string AntiguedadDia => _alumno.Antiguedad().ToString();
        public string AntiguedadMes => _alumno is AlumnoLocal l ? _alumno.Antiguedad(Formato.Mes).ToString() : "No aplica";
        public string AntiguedadAnio => _alumno is AlumnoLocal l ? _alumno.Antiguedad(Formato.Anio).ToString() : "No aplica";
        public string Universidad => _alumno is AlumnoExtranjero e ? e.Universidad : "No aplica";


        public VistaEntidadMultiplesAntiguedades(Alumno alumno)
        {
            _alumno = alumno;
        }

        public Alumno ObtenerAlumno() => _alumno;

    }
}