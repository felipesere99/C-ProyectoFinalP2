using NUnit.Framework;
using Library;

namespace Library.Tests
{
    public class Barco2x1Tests
    {
        [Test]
        public void ActualizarEstado_BarcoIntacto()
        {
           
            Barco2x1 barco = new Barco2x1();
            Coordenada ubicacionInicial = new Coordenada(0, 1);
            barco.Ubicacion = ubicacionInicial;
            barco.Orientacion = Orientacion.Horizontal;

            barco.ActualizarEstado();

            Assert.AreEqual("Intacto", barco.Estado);
        }
    

        [Test]
        public void ActualizarEstado_BarcoTocado()
        {
            Barco2x1 barco = new Barco2x1();
            Coordenada ubicacionInicial = new Coordenada(0, 0);
            barco.Ubicacion = ubicacionInicial;

            int coordenada = 00;
            barco.RegistrarDisparo(coordenada);

            barco.ActualizarEstado();

            Assert.AreEqual("Tocado", barco.Estado);
        }
        

        [Test]
        public void ActualizarEstado_BarcoHundido()
        {
            
            Barco2x1 barco = new Barco2x1();
            Coordenada ubicacionInicial = new Coordenada(0, 0);
            barco.Ubicacion = ubicacionInicial;

            int coordenada = 00;
            barco.RegistrarDisparo(coordenada);
            int coordenada2 = 01;
            barco.RegistrarDisparo(coordenada2);

            
            barco.ActualizarEstado();

            
            Assert.AreEqual("Hundido", barco.Estado);
        }
    }
}