using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class Testdeusuario1
    {
        [Test]
        public void IniciarPartida_EsperarSegundoJugador()
        {
            
            Administrador administrador = new Administrador();
            Jugador jugador1 = new Jugador("Jugador1", 1122);
            Jugador jugador2 = new Jugador("Jugador2", 112233);

            
            Partida partida = administrador.UnirseAPartida(jugador1);
            administrador.AsignarJugador(partida, jugador2.Id);

            
            Assert.IsTrue(partida.Comenzada);
            Assert.IsFalse(partida.Terminada);
        }
    }
}

