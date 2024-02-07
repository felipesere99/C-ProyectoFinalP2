
using Library;

namespace LibraryTests
{
    [TestFixture] /*Test usuario*/
    public class JuegoTests
    {
        [Test]
        public void VerFinalizarPartidaTest()
        {
            // Arrange
            Juego juego = new Juego();
            Partida partida = new Partida();
            Jugador jugador1 = new Jugador("Jugador1",3498);
            Jugador jugador2 = new Jugador("Jugador2",2288);
            IBarco barco2x1 = new Barco2x1();

            partida.Jugadores.Add(jugador1);
            partida.Jugadores.Add(jugador2);
            jugador1.Barcos.Add(barco2x1); // Agregar un barco al jugador 1
            juego.IniciarJuego(partida); // Iniciar la partida

            
            // marcar todas las naves del jugador 2 como hundidas
            foreach (IBarco barcoJugador2 in jugador2.Barcos)
            {
                barcoJugador2.Estado = "Hundido"; 
            }

            //  un turno
            juego.RealizarJugada(jugador1, partida);

            
            Assert.IsTrue(partida.Terminada);
            
        }

        
    }
}