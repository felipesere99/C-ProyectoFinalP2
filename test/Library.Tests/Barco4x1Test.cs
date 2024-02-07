using NUnit.Framework;
using Library;

namespace Library.Tests
{
    public class Barco4x1Tests
    {
        [Test]
        public void ActualizarEstado_BarcoIntacto()
        {
           
            Barco4x1 barco = new Barco4x1();
            Coordenada ubicacionInicial = new Coordenada(0, 3);
            barco.Ubicacion = ubicacionInicial;
            barco.Orientacion = Orientacion.Horizontal;

            barco.ActualizarEstado();

            Assert.AreEqual("Intacto", barco.Estado);
        }
    

        [Test]
        public void ActualizarEstado_BarcoTocado()
        {
            Barco4x1 barco = new Barco4x1();
            Coordenada ubicacionInicial = new Coordenada(0, 3);
            barco.Ubicacion = ubicacionInicial;

            int coordenada = 00;
            barco.RegistrarDisparo(coordenada);

            barco.ActualizarEstado();

            Assert.AreEqual("Tocado", barco.Estado);
        }
        

        [Test]
        public void ActualizarEstado_BarcoHundido()
        {
            
            Barco4x1 barco = new Barco4x1();
            Coordenada ubicacionInicial = new Coordenada(0, 3);
            barco.Ubicacion = ubicacionInicial;

            int coordenada = 00;
            barco.RegistrarDisparo(coordenada);
            int coordenada2 = 01;
            barco.RegistrarDisparo(coordenada2);
            int coordenada3 = 02;
            barco.RegistrarDisparo(coordenada3);
            int coordenada4 = 03;
            barco.RegistrarDisparo(coordenada4);

            
            barco.ActualizarEstado();

            
            Assert.AreEqual("Hundido", barco.Estado);
        }
    }
}