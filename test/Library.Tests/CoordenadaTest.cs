using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class CoordenadaTest
    {
        [Test]
        public void ValoresCorrectos()
        {
            int fila = 2;
            int columna = 3;

            
            Coordenada coordenada = new Coordenada(fila, columna);

            
            Assert.AreEqual(fila, coordenada.Fila);
            Assert.AreEqual(columna, coordenada.Columna);
        }
    }
}