using NUnit.Framework;
using Library;

namespace Library.Tests
{
    public class Barco3x1Tests
    {
        [Test]
        public void ActualizarEstado_BarcoIntacto()
        {
           
            Barco3x1 barco = new Barco3x1();
            Coordenada ubicacionInicial = new Coordenada(0, 2);
            barco.Ubicacion = ubicacionInicial;
            barco.Orientacion = Orientacion.Horizontal;

            barco.ActualizarEstado();

            Assert.AreEqual("Intacto", barco.Estado);
        }
    

        [Test]
        public void ActualizarEstado_BarcoTocado()
        {
            Barco3x1 barco = new Barco3x1();
            Coordenada ubicacionInicial = new Coordenada(0, 2);
            barco.Ubicacion = ubicacionInicial;

            int coordenada = 00;
            barco.RegistrarDisparo(coordenada);

            barco.ActualizarEstado();

            Assert.AreEqual("Tocado", barco.Estado);
        }
        

        [Test]
        public void ActualizarEstado_BarcoHundido()
        {
            
            Barco3x1 barco = new Barco3x1();
            Coordenada ubicacionInicial = new Coordenada(0, 0);
            barco.Ubicacion = ubicacionInicial;

            int coordenada = 00;
            barco.RegistrarDisparo(coordenada);
            int coordenada2 = 01;
            barco.RegistrarDisparo(coordenada2);
            int coordenada3 = 02;
            barco.RegistrarDisparo(coordenada3);

            
            barco.ActualizarEstado();

            
            Assert.AreEqual("Hundido", barco.Estado);
        }
    }
}