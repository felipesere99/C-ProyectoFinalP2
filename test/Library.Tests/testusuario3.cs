using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class Testdeusuario3
    {
        [Test]
        public void PosicionarNaves_Y_PrimerMovimiento()
        {
            
            Administrador administrador = new Administrador();
            Jugador jugador1 = new Jugador("Jugador1", 444);
            Jugador jugador2 = new Jugador("Jugador2",8765);

            Partida partida = administrador.UnirseAPartida(jugador1);
            administrador.AsignarJugador(partida, jugador2.Id);

            jugador1.ColocarBarcos();

            jugador2.ColocarBarcos();

            Assert.IsTrue(jugador1.Barcos.All(barco => barco.Ubicacion != null));
            Assert.IsTrue(jugador2.Barcos.All(barco => barco.Ubicacion != null));

            Juego juego = new Juego();
            juego.RealizarJugada(jugador1, partida);

            Assert.IsTrue(partida.Comenzada);
            Assert.IsFalse(partida.Terminada);
        }
    }
}
