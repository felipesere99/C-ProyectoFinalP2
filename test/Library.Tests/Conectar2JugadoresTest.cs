using NUnit.Framework;
namespace Library.Tests
{
    [TestFixture] //Como administrador del juego, debo poder conectar dos jugadores que se encuentren esperando para jugar
    public class Conectar2JugadoresTest
    {
        [Test]
        public void UnirseAPartida2Jugadores()
        {
            Administrador admin = Administrador.Instance;
            Jugador jugador1 = new Jugador("Jugador1", 12345);
            Jugador jugador2 = new Jugador("Jugador2", 23);
            admin.jugadores.Add(jugador1);
            admin.jugadores.Add(jugador2);    

            Partida partida = admin.UnirseAPartida(jugador1);
            admin.UnirseAPartida(jugador2);

            Assert.AreEqual(partida, admin.devolverPartida(jugador1.Id), "Jugador1 y Jugador2 deberian estar en la misma partida");
            Assert.AreEqual(2, partida.Jugadores.Count, "La partida deberia tener dos jugadores");
        }

        [Test]

        public void CrearNuevaPartidaSiNoHayDisponible()
        {
            Administrador admin = Administrador.Instance;
            Jugador jugador1 = new Jugador("Clara", 5555);
            Jugador jugador2 = new Jugador("Juan", 6666);
            admin.jugadores.Add(jugador1);
            admin.jugadores.Add(jugador2);

            Partida partida1 = admin.UnirseAPartida(jugador1);
            Partida partida2 =  admin.UnirseAPartida(jugador2);

            Assert.AreNotEqual(partida1, partida2, "Se deberian crear dos partidas distintas");
            
            Assert.AreEqual(1, partida2.Jugadores.Count, "La segunda partida deberia tener un jugador");
        }
    }
}