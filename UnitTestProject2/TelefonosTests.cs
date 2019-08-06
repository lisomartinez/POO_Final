using System;
using FluentAssertions;
using POO_Final;
using Xunit;

namespace UnitTestProject2
{
    public class TelefonosTests
    {
        //mover a clase aparte
        [Fact]
        public void DadosDosTelefonosIgualsEqualsDevuelveVerdadero()
        {
            Telefono a = new Telefono("011", "48603242");
            Telefono b = new Telefono("011", "48603242");
            a.Equals(b).Should().BeTrue();
            b.Equals(a).Should().BeTrue();
        }

        [Fact]
        public void DadosDosTelefonosDistintosEqualsDevuelveFalso()
        {
            Telefono a = new Telefono("0", "48603242");
            Telefono b = new Telefono("011", "48603242");
            a.Equals(b).Should().BeFalse();
            b.Equals(a).Should().BeFalse();
        }

        [Fact]
        public void ModificarDatosTelefonos()
        {
            Telefono a = new Telefono("0", "48603242");
            a.Numero = "1";
            a.Prefijo = "011";
            a.Numero.Should().Be("1");
            a.Prefijo.Should().Be("011");
        }

        [Fact]
        public void ModificarPrefijoVacioTiraExcepcion()
        {
            Telefono a = new Telefono("0", "48603242");
            var exception = Record.Exception(() => a.Prefijo = " ");
            Action act = () => a.Prefijo = " ";
            act.Should().Throw<PrefijoDeTelefonoEstaEnBlancoException>()
                .WithMessage("El prefijo del teléfono no puede estar en blanco.");
        }

        [Fact]
        public void ModificarNumeroVacioTiraExcepcion()
        {
            Telefono a = new Telefono("0", "48603242");
            Action act = () => a.Numero = " ";
            act.Should()
                .Throw<NumeroDeTelefonoNoPuedeEstarEnBlancoException>("El numero de telefono no puede estar en blanco");
        }

        [Fact]
        public void CrearTelefonoSinNumeroTiraExcepcion()
        {
            Action act = () => new Telefono("0", "");
            act.Should()
                .Throw<NumeroDeTelefonoNoPuedeEstarEnBlancoException>("El numero de telefono no puede estar en blanco");
        }

        [Fact]
        public void CrearTelefonoSinPrefijoTiraExcepcion()
        {
            Action act = () => new Telefono("", "111");
            act.Should()
                .Throw<PrefijoDeTelefonoEstaEnBlancoException>("El prefijo del teléfono no puede estar en blanco.");
        }
    }
}