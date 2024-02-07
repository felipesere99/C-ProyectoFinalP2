using NUnit.Framework;
using Library;

namespace Library.Tests
{
    
    [TestFixture] /*Test usuario*/
    public class JugadorTests
    {
        [Test]
        public void Jugador_PuedeVerPartidasIniciadasYUnirse()
        {
            Administrador administrador = Administrador.Instance;
            Jugador jugador1 = new Jugador("jugador1", 3452);
            Jugador jugador2 = new Jugador("jugador2", 7621);

            Partida partida1 = administrador.CrearPartida(jugador1.Id);
            administrador.AsignarJugador(partida1, jugador1.Id);

            Partida partida2 = administrador.CrearPartida(jugador2.Id);
            administrador.AsignarJugador(partida2, jugador2.Id);

            Partida partidaSeleccionada = jugador2.VerPartidasDisponiblesYUnirse();

            Assert.IsNotNull(partidaSeleccionada);
            Assert.AreEqual(2, partidaSeleccionada.Jugadores.Count);
            Assert.Contains(jugador1, partidaSeleccionada.Jugadores);
            Assert.Contains(jugador2, partidaSeleccionada.Jugadores);
        }
    }
}