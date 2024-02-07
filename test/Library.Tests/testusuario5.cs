namespace Library.Tests
{
    [TestFixture]
    public class Testdeusuario5
    {
                [Test]
        public void Disparo_Y_Respuesta_AGUA()
        {
            Tablero tablero = new Tablero();
            Jugador jugador1 = new Jugador("Jugador1",222);
            Jugador jugador2 = new Jugador("Jugador2",333);
            Disparo disparo = new Disparo();
            IBarco barco2x1 = new Barco2x1();
            
    
            jugador2.Barcos.Add(barco2x1); // Agregar un barco al jugador 2
            jugador2.ColocarBarcos();
            barco2x1.Ubicacion = new Coordenada(7, 5);
            Orientacion orientacion = Orientacion.Vertical;
            int coordenadaDeDisparo = 74;
            tablero.AgregarBarcosAlTablero(barco2x1, orientacion);

            bool disparoResult = disparo.ImpactoEnBarco(barco2x1, coordenadaDeDisparo);

            barco2x1.ActualizarEstado();

            Assert.IsFalse(disparoResult);
            
            

        }

        [Test]
        public void Disparo_Y_Respuesta_TOCADO()
        {
            Tablero tablero = new Tablero();
            Jugador jugador1 = new Jugador("Jugador1",222);
            Jugador jugador2 = new Jugador("Jugador2",333);
            Disparo disparo = new Disparo();
            IBarco barco2x1 = new Barco2x1();
            
    
            jugador2.Barcos.Add(barco2x1); // Agregar un barco al jugador 2
            jugador2.ColocarBarcos();
            barco2x1.Ubicacion = new Coordenada(7, 5);
            Orientacion orientacion = Orientacion.Vertical;
            int coordenadaDeDisparo = 75;
            tablero.AgregarBarcosAlTablero(barco2x1, orientacion);

            bool disparoResult = disparo.ImpactoEnBarco(barco2x1, coordenadaDeDisparo);

            barco2x1.ActualizarEstado();

            Assert.AreEqual("Tocado", barco2x1.Estado);
            

        }

        [Test]
        public void Disparo_Y_Respuesta_HUNDIDO()
        {
            Tablero tablero = new Tablero();
            Jugador jugador1 = new Jugador("Jugador1",222);
            Jugador jugador2 = new Jugador("Jugador2",333);
            Disparo disparo = new Disparo();
            IBarco barco2x1 = new Barco2x1();
            
    
            jugador2.Barcos.Add(barco2x1); // Agregar un barco al jugador 2
            jugador2.ColocarBarcos();
            barco2x1.Ubicacion = new Coordenada(7, 5);
            Orientacion orientacion = Orientacion.Vertical;
            int coordenadaDeDisparo = 76;
            tablero.AgregarBarcosAlTablero(barco2x1, orientacion);

            bool disparoResult = disparo.ImpactoEnBarco(barco2x1, coordenadaDeDisparo);

            barco2x1.ActualizarEstado();

             Assert.AreEqual("Hundido", barco2x1.Estado);
            

        }
    }
}