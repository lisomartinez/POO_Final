using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace POO_Final
{
    public partial class Form1 : Form
    {
        List<Alumno> alumnos;

        private Func<Alumno, VistaEntidad> ConvertirAVistaEntidad = a => new VistaEntidad(a);
        private Func<Alumno, bool> esExtranjero = a => a is AlumnoExtranjero;
        public static DateTime FechaSinModificar = new DateTime(1, 1, 1);
        public Form1()
        {
            InitializeComponent();

            try
            {
                alumnos = new List<Alumno>();
                alumnos.Add(new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", new DateTime(2016, 11, 21)));
                alumnos.Add(new AlumnoLocal(Legajo.Of("456"), "Pedro", "Alfonso", new DateTime(2017, 9, 15)));
                alumnos.Add(new AlumnoLocal(Legajo.Of("789"), "Indio", "Solari", new DateTime(2018, 2, 18)));
                alumnos.Add(new AlumnoExtranjero(Dni.Of("89"), "Juan", "Perez", new DateTime(2011, 12, 8), "UNAM", 4));
                alumnos.Add(new AlumnoExtranjero(Dni.Of("9123"), "Jose", "Alonso", new DateTime(2012, 5, 16), "UAM", 14));
                alumnos.Add(new AlumnoExtranjero(Dni.Of("013123"), "Daniel", "Ferrari", new DateTime(2015, 7, 15), "CPM",
                    13));
                alumnos[0].AgregarTelefono(Telefono.Of("011", "12314"));
                alumnos[1].AgregarTelefono(Telefono.Of("011", "454545"));
                alumnos[5].AgregarTelefono(Telefono.Of("011", "676767"));
                alumnos[5].AgregarTelefono(Telefono.Of("0232", "24234"));
                alumnos[4].AgregarTelefono(Telefono.Of("0333", "62728"));
                alumnos.Sort(new Alumno.Asc());
            }
            catch (Exception e)
            {
                MostrarExcepcion(e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AscRadioButton.Checked = true;
                ActualizarAlumnosDGV();
                ActualizarAlumnosExtranjerosDGV();
                DiasRadioButton.Checked = true;
                LocalRadioButton.Checked = true;
            }
            catch (Exception exception)
            {
                MostrarExcepcion(exception);

            }

        }

        private void ActualizarAlumnosExtranjerosDGV()
        {
            try
            {
                AlumnosExtranjerosDGV.DataSource = null;
                AlumnosExtranjerosDGV.DataSource = alumnos.Where(esExtranjero).Select(ConvertirAVistaEntidad).ToList();
            }
            catch (Exception e)
            {
                MostrarExcepcion(e);
            }

        }

        private void AscRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (AscRadioButton.Checked)
                {
                    alumnos.Sort(new Alumno.Asc());
                }
                else
                {
                    alumnos.Sort(new Alumno.Desc());
                }

                ActualizarAlumnosDGV();
                ActualizarAlumnosExtranjerosDGV();
            }
            catch (Exception exception)
            {
                MostrarExcepcion(exception);
            }
            
        }

        private void ActualizarAlumnosDGV(Formato formato = Formato.Dia)
        {
            try
            {
                AlumnosDGV.DataSource = null;
                var lista = alumnos.Select(ConvertirAVistaEntidad).ToList();
                lista.ForEach(a => CambiarFormato(a, formato));
                AlumnosDGV.DataSource = lista;
            }
            catch (Exception exception)
            {
                MostrarExcepcion(exception);
            }

        }

        private void CambiarFormato(VistaEntidad vistaEntidad, Formato formato)
        {
            vistaEntidad.EstablecerFormato(formato);
        }

        private void AniosRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FormatoSeleccionado().Equals(Formato.Anio)) ActualizarAlumnosDGV(Formato.Anio);
        }

        private void MesesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FormatoSeleccionado().Equals(Formato.Mes)) ActualizarAlumnosDGV(Formato.Mes);
        }

        private void DiasRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FormatoSeleccionado().Equals(Formato.Dia)) ActualizarAlumnosDGV();
        }

        private void AlumnosDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var vistaEntidad = (VistaEntidad)AlumnosDGV.SelectedRows[0].DataBoundItem;
                var alumno = vistaEntidad.ObtenerAlumno();
                TelefonosDGV.DataSource = null;
                TelefonosDGV.DataSource = alumno.Telefonos;
            }
            catch (Exception exception)
            {
                MostrarExcepcion(exception);
            }

        }

        private void AgregarAlumnoButton_Click(object sender, EventArgs e)
        {
            try
            {

                Alumno alumno = null;
                if (LocalRadioButton.Checked)
                {
                    var datos = SolicitarDatosAlumnoLocal();
                    alumno = new AlumnoLocal(datos.Legajo, datos.Nombre, datos.Apellido, datos.Fecha);
                }
                else if (ExtranjeroRadioButton.Checked)
                {
                    var datos = SolicitarDatosAlumnoExtranjero();
                    alumno = new AlumnoExtranjero(datos.dni, datos.Nombre, datos.Apellido, datos.Fecha, datos.Universidad, datos.Aprobadas);
                }
                else
                {
                    throw new ErrorTipoAlumnoException();
                }
                alumnos.Add(alumno);
                ActualizarAlumnosDGV();
                ActualizarAlumnosExtranjerosDGV();
            }
            catch (Exception exception)
            {
                MostrarExcepcion(exception);
            }

        }

        private DatosAlumnoLocal SolicitarDatosAlumnoLocal(bool modificar = false)
        {
            var leg = SolicitarLegajo(modificar: true);
            var datos = SolicitarDatosAlumno(modificar);
            return new DatosAlumnoLocal(leg, datos.Item1, datos.Item2, datos.Item3);
        }

        private DatosAlumnoExtranjero SolicitarDatosAlumnoExtranjero(bool modificar = false)
        {
            var dni = SolicitarDni();
            var datosAlumno = SolicitarDatosAlumno();
            var universidad = Interaction.InputBox("Ingrese universidad de Origen");
            if (modificar == false && string.IsNullOrWhiteSpace(universidad))
            {
                throw new UniversidadEnBlancoException();
            }
            var aprobadas_str = Interaction.InputBox("Ingrese Cantidad de Materias Aprobadas");
            int aprobadas = AprobadasVacio;
            if (modificar == false && !string.IsNullOrWhiteSpace(aprobadas_str))
            {
                aprobadas = ParsearAprobada(aprobadas_str);
            }
            
            return new DatosAlumnoExtranjero(dni, datosAlumno.Item1, datosAlumno.Item2, datosAlumno.Item3, universidad, aprobadas );
        }

        private class DatosAlumnoExtranjero : DatosAlumno
        {
            public Dni dni { get; }
            public string Nombre { get; }
            public string Apellido { get; }
            public DateTime Fecha { get; }

            public string Universidad { get; }

            public int Aprobadas { get; }

            public DatosAlumnoExtranjero(Dni dni, string nombre, string apellido, DateTime fecha, string universidad, int aprobadas)
            {
                this.dni = dni;
                Nombre = nombre;
                Apellido = apellido;
                Fecha = fecha;
                Universidad = universidad;
                Aprobadas = aprobadas;
            }
        }

        private (string, string, DateTime) SolicitarDatosAlumno(bool modificar = false)
        {
            var nombre = Interaction.InputBox("Ingrese Nombre");
            if (modificar == false && string.IsNullOrWhiteSpace(nombre)) throw new NombreVacioException();
            var apellido = Interaction.InputBox("Ingrese apellido");

            if (modificar == false && string.IsNullOrWhiteSpace(nombre)) throw new ApellidoVacioException();
            var fecha_str = Interaction.InputBox("Ingrese fecha de ingreso DD/MM/AAAA");
            var fecha = ParsearFecha(fecha_str, modificar);
            return (nombre, apellido, fecha);

        }
        

        private Dni SolicitarDni(bool modificar = false)
        {
            var dni_str = Interaction.InputBox("Ingrese Número de Legajo");

            if (modificar && string.IsNullOrWhiteSpace(dni_str))
            {
                return Dni.Vacio;
            }
            var dni = Dni.Of(dni_str);
            VerificarDuplicados(dni);
            return dni;
        }

        private Legajo SolicitarLegajo(bool modificar = false)
        {
            var legajo = Interaction.InputBox("Ingrese Número de Legajo");
            if (modificar && string.IsNullOrWhiteSpace(legajo))
            {
                return Legajo.Vacio;
            }
            var leg = Legajo.Of(legajo);
            VerificarDuplicados(leg);
            return leg;
        }

        private void VerificarDuplicados(IIdentificador id)
        {
            var duplicado = alumnos.FirstOrDefault(a => a.Le.Equals(id));
            if (ReferenceEquals(duplicado, null) == false) throw new AlumnoDuplicadoException(id);
        }

        private int ParsearAprobada(string aprobadasStr)
        {
            try
            {
                return Int32.Parse(aprobadasStr);
            }
            catch (Exception e)
            {
                throw new CantidadDeMateriasAprobadasInvalidaException(aprobadasStr);
            }
        }

        private static DateTime ParsearFecha(string fecha_str, bool modificar = false)
        {
            try
            {
                if (modificar == false && string.IsNullOrWhiteSpace(fecha_str))
                {
                    throw new FormatoFechaInvalidoException(fecha_str);
                }
                else if (string.IsNullOrWhiteSpace(fecha_str))
                {
                    return FechaSinModificar;
                }

                var campos = fecha_str.Split('/');
                var dia = ParsearEntero(campos[0]);
                var mes = ParsearEntero(campos[1]);
                var anio = ParsearEntero(campos[2]);
                return new DateTime(anio, mes, dia);
            }
            catch (Exception e)
            {
                throw new FormatoFechaInvalidoException(fecha_str);
            }

        }

        private static int ParsearEntero(string s)
        {
            return Int32.Parse(s);
        }


        public void MostrarExcepcion(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void ModificarAlumnoButton_Click(object sender, EventArgs e)
        {
            try
            {
                var vistaEntidad = (VistaEntidad)AlumnosDGV.SelectedRows[0].DataBoundItem;
                Alumno alumno = vistaEntidad.ObtenerAlumno();
                MessageBox.Show("Deje en blanco los campos que no desea modificar.");

                //Si el alumno es un alumno extranjhero guardamelo en la variable extranjero.
                if (alumno is AlumnoExtranjero extranjero)
                {
                    //modifico los datos de extranjero.
                    var datos = SolicitarDatosAlumnoExtranjero(modificar: true);
                    ModificarCamposAlumnoExtranjero(extranjero, datos);
                }
                //Si no es extranjero, significa que es un alumno local
                else
                {
                    var datos = SolicitarDatosAlumnoLocal(modificar: true);
                    //Entonces lo puedo castear sin problemas con AS
                    ModificarCamposAlumnoLocal(alumno as AlumnoLocal, datos);
                }
            }
            catch (Exception exception)
            {
                MostrarExcepcion(exception);
            }
            ActualizarAlumnosDGV(FormatoSeleccionado());
            ActualizarAlumnosExtranjerosDGV();
        }

        private Formato FormatoSeleccionado()
        {
            if (AniosRadioButton.Checked) return Formato.Anio;
            if (MesesRadioButton.Checked) return Formato.Mes;
            if (DiasRadioButton.Checked) return Formato.Dia;
            throw new ArgumentException();
        }

        private void ModificarCamposAlumnoLocal(AlumnoLocal alumno, DatosAlumnoLocal datos)
        {

            if (!datos.Legajo.Equals(Legajo.Vacio))
            {
                alumno.Le = datos.Legajo;
            }

            if (!string.IsNullOrWhiteSpace(datos.Nombre))
            {
                alumno.Nombre = datos.Nombre;
            }

            if (!string.IsNullOrWhiteSpace(datos.Apellido))
            {
                alumno.Apellido = datos.Apellido;
            }
        }

        private void ModificarCamposAlumnoExtranjero(AlumnoExtranjero extranjero, DatosAlumnoExtranjero datos)
        {
            if (!datos.dni.Equals(Dni.Vacio))
            {
                extranjero.Le = datos.dni;
            }

            if (!string.IsNullOrWhiteSpace(datos.Nombre))
            {
                extranjero.Nombre = datos.Nombre;
            }

            if (!string.IsNullOrWhiteSpace(datos.Apellido))
            {
                extranjero.Apellido = datos.Apellido;
            }
            if (!string.IsNullOrWhiteSpace(datos.Universidad))
            {
                extranjero.Universidad = datos.Universidad;
            }

            if (datos.Aprobadas.Equals(AprobadasVacio))
            {
                extranjero.MateriasAprobadas = datos.Aprobadas;
            }

        }

        public int AprobadasVacio => -1;

        private void EliminarAlumnoButton_Click(object sender, EventArgs e)
        {
            if (AlumnosDGV.RowCount.Equals(0)) return;
            var vistaEntidad = (VistaEntidad) AlumnosDGV.SelectedRows[0].DataBoundItem;
            var alumno = vistaEntidad.ObtenerAlumno();
            alumnos.Remove(alumno);
            ActualizarAlumnosDGV();
            ActualizarAlumnosExtranjerosDGV();
            LimpiarTelefonos();
        }

        private void LimpiarTelefonos()
        {
            TelefonosDGV.DataSource = null;
        }

        private class DatosAlumnoLocal : DatosAlumno
        {

            public Legajo Legajo { get; }
            public string Nombre { get; }
            public string Apellido { get; }
            public DateTime Fecha { get; }

            public DatosAlumnoLocal(Legajo leg, string nombre, string apellido, DateTime fecha)
            {
                Legajo = leg;
                Nombre = nombre;
                Apellido = apellido;
                Fecha = fecha;
            }
        }


        private interface DatosAlumno
        {
            string Nombre { get; }
            string Apellido { get; }
            DateTime Fecha { get; }
        }
    }
}
