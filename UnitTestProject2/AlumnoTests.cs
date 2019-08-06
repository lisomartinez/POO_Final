using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Extensions;
using POO_Final;
using Xunit;

namespace UnitTestProject2
{
    public class AlumnoTests
    {
        [Fact]
        public void CrearAlumnoLocal()
        {
            Alumno alumno = new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", new DateTime(2019, 1, 1));

            alumno.Le.Should().Be(Legajo.Of("123"));
            alumno.Nombre.Should().Be("Lisandro");
            alumno.Apellido.Should().Be("Martinez");
            alumno.FechaIngreso.Should().Be(1.January(2019));
        }

        [Fact]
        public void CrearAlumnoExtranjero()
        {
            AlumnoExtranjero alumno = new AlumnoExtranjero(Dni.Of("123"), "Lisandro", "Martinez", new DateTime(2019, 1, 1), "UNAM", 25);

            alumno.Le.Should().Be(Dni.Of("123"));
            alumno.Nombre.Should().Be("Lisandro");
            alumno.Apellido.Should().Be("Martinez");
            alumno.FechaIngreso.Should().Be(1.January(2019));
            alumno.Universidad.Should().Be("UNAM");
            alumno.MateriasAprobadas.Should().Be(25);
        }

        [Fact]
        public void EliminarTelefonoNull()
        {
            Alumno alumno = new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", new DateTime(2019, 1, 1));
            var telefono = new Telefono("011", "48603242");

            alumno.AgregarTelefono(telefono);
            alumno.Telefonos.Should().Contain(telefono).And.HaveCount(1);
            alumno = null;

            telefono.Should().BeNull();
        }

        [Fact]
        public void AgregarTelefonoAAlumno_TelefonoNoDuplicado_AgregaTelefonoALista()
        {
            Alumno alumno = new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", new DateTime(2019, 1, 1));
            var telefono = new Telefono("011", "48603242");

            alumno.AgregarTelefono(telefono);
            alumno.Telefonos.Should().Contain(telefono).And.HaveCount(1);
            alumno = null;
        }

        [Fact]
        public void AgregarTelefonoAAlumno_TelefonoDuplicado_TiraExcepcion()
        {
            Alumno alumno = new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", new DateTime(2019, 1, 1));
            alumno.AgregarTelefono(new Telefono("011", "48603242"));
            Action act = () => alumno.AgregarTelefono(new Telefono("011", "48603242"));
            act.Should().Throw<TelefonoDuplicadoException>()
                .WithMessage("El telefono 011-48603242 ya se encuentra presente en el alumno");

        }

        [Fact]
        public void IdentificadorConNumeroNuloTiraException()
        {
            Action act = () => Dni.Of(null);
            act.Should().Throw<NumeroDeIdentificadorVacioException>().WithMessage("El identificador no puede ser nulo.");
        }


        [Fact]
        public void IdentificadorConNumeroVacioException()
        {
            Action act = () => Dni.Of("");
            act.Should().Throw<NumeroDeIdentificadorVacioException>().WithMessage("El identificador no puede ser nulo.");
        }


        [Fact]
        public void IdentificadorConNumeroSoloEspaciosTiraException()
        {
            Action act = () => Dni.Of(" ");
            act.Should().Throw<NumeroDeIdentificadorVacioException>().WithMessage("El identificador no puede ser nulo.");
        }


        [Fact]
        public void CompararDosIdentificadoresDelDiferenteTiposYMismoNumeroDebeDevolverFalso()
        {
            IIdentificador id1 = Dni.Of("1");
            IIdentificador id2 = Legajo.Of("1");
            id1.Should().NotBe(id2);
        }

        [Fact]
        public void CompararDosIdentificadoresDelMismoTipoYMismoNumeroDebeDevolverVerdadero()
        {
            IIdentificador id1 = Dni.Of("1");
            IIdentificador id2 = Dni.Of("1");
            id1.Should().Be(id2);
        }

        //Testear las fechas de ingreso
        [Theory]
        [MemberData(nameof(FechasDeIngresoYAntiguedadAlumnoLocalDias))]
        public void VerificarAntiguedad(DateTime ingreso, int antiguedadEsperada)
        {
            Alumno local = new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", ingreso);
            int antiguedad = local.Antiguedad(Formato.Dia);
            antiguedad.Should().Be(antiguedadEsperada);
        }

        [Theory]
        [MemberData(nameof(FechasDeIngresoYAntiguedadAlumnoLocalAnios))]
        public void VerificarAntiguedadAnos(DateTime ingreso, int antiguedadEsperada)
        {
            Alumno local = new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", ingreso);
            int antiguedad = local.Antiguedad(Formato.Anio);
            antiguedad.Should().Be(antiguedadEsperada);
        }


        [Theory]
        [MemberData(nameof(FechasDeIngresoYAntiguedadAlumnoLocalMes))]
        public void VerificarAntiguedadMes(DateTime ingreso, int antiguedadEsperada)
        {
            Alumno local = new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", ingreso);
            int antiguedad = local.Antiguedad(Formato.Mes);
            antiguedad.Should().Be(antiguedadEsperada);
        }



        public static IEnumerable<object[]> FechasDeIngresoYAntiguedadAlumnoLocalDias()
        {
            yield return new object[] {new DateTime(2019, 1, 1), 216};
            yield return new object[] {new DateTime(2018, 1, 1), 581};
            yield return new object[] {new DateTime(2019, 8, 4), 1};
        }


        public static IEnumerable<object[]> FechasDeIngresoYAntiguedadAlumnoLocalAnios()
        {
            yield return new object[] { new DateTime(2017, 9, 1), 1 };
            yield return new object[] { new DateTime(2017, 8, 10), 1 };
            yield return new object[] { new DateTime(2017, 7, 4), 2 };
            yield return new object[] { new DateTime(2017, 8, 1), 2 };
        }


        public static IEnumerable<object[]> FechasDeIngresoYAntiguedadAlumnoLocalMes()
        {
            yield return new object[] { new DateTime(2017, 9, 1), 23};
            yield return new object[] { new DateTime(2017, 8, 10), 23};
            yield return new object[] { new DateTime(2017, 7, 4), 25};
            yield return new object[] { new DateTime(2017, 8, 1), 24};
        }

        [Fact]
        public void BuscarTelefonosDuplicadosEnTodosLosAlumnos()
        {
            Alumno local1 = new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", new DateTime(2019, 1, 1));
            Alumno local2 = new AlumnoLocal(Legajo.Of("1233"), "Pedro", "Martinez", new DateTime(2019, 1, 1));
            Alumno local3 = new AlumnoLocal(Legajo.Of("12344"), "Juan", "Martinez", new DateTime(2019, 1, 1));

            var tel1 = Telefono.Of("011", "1234");
            var tel2 = Telefono.Of("012", "43123");

            local1.AgregarTelefono(tel1);
            local2.AgregarTelefono(tel2);
            local3.AgregarTelefono(tel1);

            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(local1);
            alumnos.Add(local2);
            alumnos.Add(local3);

            //SOLO IMPORTA ESTO.
            //Busca en todos los telefonos de los alumnos los que tengan el mismo prefijo y numero.
            //Devuelve una lsita de los alumnos que cumplan con esa condicion.
            //Podes verificar que la lista este vacia para validarlo, si te devuelve un Count distitno de cero
            //podes usar los datos del alumno para tirar una excepcion.

            var list = alumnos.Where(alumno =>
                alumno.Telefonos.Any(telefono =>
                    telefono.Prefijo == tel1.Prefijo && telefono.Numero == tel1.Numero)).ToList();
            //
            
            list.Should().ContainInOrder(local1, local3).And.HaveCount(2);
        }

        [Fact]
        public void BuscarTelefonosDuplicadosEnTodosLosAlumnosConDelegados()
        {
            Alumno local1 = new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", new DateTime(2019, 1, 1));
            Alumno local2 = new AlumnoLocal(Legajo.Of("1233"), "Pedro", "Martinez", new DateTime(2019, 1, 1));
            Alumno local3 = new AlumnoLocal(Legajo.Of("12344"), "Juan", "Martinez", new DateTime(2019, 1, 1));

            var tel1 = Telefono.Of("011", "1234");
            var tel2 = Telefono.Of("012", "43123");

            local1.AgregarTelefono(tel1);
            local2.AgregarTelefono(tel2);
            local3.AgregarTelefono(tel1);

            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(local1);
            alumnos.Add(local2);
            alumnos.Add(local3);


            //SOLO IMPORTA ESTO.
            //Busca en todos los telefonos de los alumnos los que tengan el mismo prefijo y numero.
            //Devuelve una lsita de los alumnos que cumplan con esa condicion.
            //Podes verificar que la lista este vacia para validarlo, si te devuelve un Count distitno de cero
            //podes usar los datos del alumno para tirar una excepcion.

            Func<Telefono, Telefono, bool> esDuplicado = (t1, t2) => t1.Prefijo == t2.Prefijo && t1.Numero == t2.Numero;

            Func<Alumno, bool> tieneTelefono = alumno => alumno.Telefonos.Exists(t => esDuplicado(t, tel1));
            
            var list = alumnos.Where(tieneTelefono).ToList();
            //

            list.Should().ContainInOrder(local1, local3).And.HaveCount(2);
        }


        [Fact]
        public void BuscarTelefonosDuplicadosEnTodosLosAlumnosConForEach()
        {
            Alumno local1 = new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", new DateTime(2019, 1, 1));
            Alumno local2 = new AlumnoLocal(Legajo.Of("1233"), "Pedro", "Martinez", new DateTime(2019, 1, 1));
            Alumno local3 = new AlumnoLocal(Legajo.Of("12344"), "Juan", "Martinez", new DateTime(2019, 1, 1));

            var tel1 = Telefono.Of("011", "1234");
            var tel2 = Telefono.Of("012", "43123");

            local1.AgregarTelefono(tel1);
            local2.AgregarTelefono(tel2);
            local3.AgregarTelefono(tel1);

            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(local1);
            alumnos.Add(local2);
            alumnos.Add(local3);


            List<Alumno> list = new List<Alumno>();
            //SOLO IMPORTA ESTO.
            //Busca en todos los telefonos de los alumnos los que tengan el mismo prefijo y numero.
            //Devuelve una lsita de los alumnos que cumplan con esa condicion.
            //Podes verificar que la lista este vacia para validarlo, si te devuelve un Count distitno de cero
            //podes usar los datos del alumno para tirar una excepcion.

            foreach (var alumno in alumnos)
            {
                foreach (var alumnoTelefono in alumno.Telefonos)
                {
                    if (alumnoTelefono.Prefijo == tel1.Prefijo && alumnoTelefono.Numero == alumnoTelefono.Numero)
                    {
                        list.Add(alumno);
                    }
                }
            }
            //

            list.Should().ContainInOrder(local1, local3).And.HaveCount(2);
        }



        [Fact]
        public void EjemploDelegado()
        {
            Func<int, int> multiplicar = nro => nro * 2;
            List<int> numeros = new List<int>() {1, 2, 3, 4};
            var resultados = numeros.Select(multiplicar).ToList();
            resultados.Should().ContainInOrder(2, 4, 6, 8).And.HaveCount(4);
        }

        [Fact]
        public void EjemploDelegadoBool()
        {
            Func<int, bool> esPar = nro => nro % 2 == 0;
            List<int> numeros = new List<int>() { 1, 2, 3, 4 };
            var resultados = numeros.Where(esPar).ToList();
            resultados.Should().ContainInOrder(2, 4).And.HaveCount(2);

        }


        [Fact]
        public void CrearVistaEntidad()
        {
            Alumno local = new AlumnoLocal(Legajo.Of("123"), "Lisandro", "Martinez", new DateTime(2019, 1, 1));

            Alumno extra = new AlumnoExtranjero(Dni.Of("1"), "Lisandro", "Martinez", new DateTime(2019, 1, 1), "UNAM",
                25);

            List<Alumno> lista = new List<Alumno>();
            lista.Add(local);
            lista.Add(extra);

            var listaVistaEntidades = lista.Select(alumno => new VistaEntidad(alumno)).ToList();

        }

        //Testear las fechas de ingreso
        [Theory]
        [MemberData(nameof(FechasDeIngresoYAntiguedadAlumnoLocalDias))]
        public void VerificarAntiguedadNicolas(DateTime ingreso, int antiguedadEsperada)
        {
            var diferenciaFechas = CalculadoraFechas.Diferencia(ingreso, DateTime.Today, CalculadoraFechas.Modo.Dia);
            diferenciaFechas.Should().Be(antiguedadEsperada);
        }

        [Theory]
        [MemberData(nameof(FechasDeIngresoYAntiguedadAlumnoLocalAnios))]
        public void VerificarAntiguedadAnosNicolas(DateTime ingreso, int antiguedadEsperada)
        {
            var diferenciaFechas = CalculadoraFechas.Diferencia(ingreso, DateTime.Today, CalculadoraFechas.Modo.Ano);
            diferenciaFechas.Should().Be(antiguedadEsperada);
        }


        [Theory]
        [MemberData(nameof(FechasDeIngresoYAntiguedadAlumnoLocalMes))]
        public void VerificarAntiguedadMesNicolas(DateTime ingreso, int antiguedadEsperada)
        {
            var diferenciaFechas = CalculadoraFechas.Diferencia(ingreso, DateTime.Today, CalculadoraFechas.Modo.Mes);
            diferenciaFechas.Should().Be(antiguedadEsperada);
        }
    }



    public static class CalculadoraFechas
    {
        public enum Modo { Dia, Mes, Ano }

        public static int Diferencia(DateTime de, DateTime hasta, Modo modo)
        {
            if (de > hasta)
            {
                DateTime temp = de;
                de = hasta;
                hasta = temp;
            }
            int diferencia = 0;
            switch (modo)
            {
                case Modo.Dia:
                    diferencia = (hasta - de).Days;
                    break;
                case Modo.Mes:
                    diferencia = (hasta.Year * 12 + hasta.Month) - (de.Year * 12 + de.Month);
                    if (de.Day > hasta.Day)
                        diferencia--;
                    break;
                case Modo.Ano:
                    diferencia = hasta.Year - de.Year;
                    if (de.Month > hasta.Month || (de.Month == hasta.Month && de.Day > hasta.Day))
                        diferencia--;
                    break;
                default:
                    break;
            }
            return diferencia;
        }

        public static DiferenciaFechas Diferencia(DateTime de, DateTime hasta)
        {
            DateTime actual = new DateTime(de.Ticks);

            int anos = Diferencia(de, hasta, Modo.Ano);
            actual = actual.AddYears(anos);
            int meses = Diferencia(actual, hasta, Modo.Mes);
            actual = actual.AddMonths(meses);
            int dias = Diferencia(actual, hasta, Modo.Dia);

            return new DiferenciaFechas(dias, meses, anos);
        }

        public class DiferenciaFechas
        {
            public int Dias { get; }
            public int Meses { get; }
            public int Anos { get; }

            public DiferenciaFechas(int dias, int meses, int anos)
            {
                this.Dias = dias;
                this.Meses = meses;
                this.Anos = anos;
            }

            public override string ToString()
            {
                return string.Format("Dias: {0}, Meses: {1}, Años: {2}", Dias, Meses, Anos);
            }
        }
    }
}
