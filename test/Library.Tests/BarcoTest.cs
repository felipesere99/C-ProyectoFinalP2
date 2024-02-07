using NUnit.Framework;
using Library;

namespace Library.Tests
{
    public class BarcoTest
    {
        [Test]
        public void BarcoSeAgregaATablero()
        {
            Tablero tablero = new Tablero();

            Barco2x1 barco = new Barco2x1();
            Barco3x1 barco2 = new Barco3x1();

            barco.Ubicacion = new Coordenada(7, 5);
            Orientacion orientacion = Orientacion.Vertical;
            barco2.Ubicacion = new Coordenada(4, 5);
            Orientacion orientacion2 = Orientacion.Horizontal;

            tablero.AgregarBarcosAlTablero(barco, orientacion);
            tablero.AgregarBarcosAlTablero(barco2, orientacion2);

            Assert.AreEqual(tablero.tablero[7, 5], tablero.tablero[barco.Ubicacion.Fila, barco.Ubicacion.Columna]);
            Assert.AreEqual(tablero.tablero[8, 5], tablero.tablero[barco.Ubicacion.Fila + 1, barco.Ubicacion.Columna]);

            Assert.AreEqual(tablero.tablero[4, 5], tablero.tablero[barco2.Ubicacion.Fila, barco2.Ubicacion.Columna]);
            Assert.AreEqual(tablero.tablero[4, 6], tablero.tablero[barco2.Ubicacion.Fila, barco2.Ubicacion.Columna + 1]);
        }
    
        }
    }
