using NUnit.Framework;
using System.Collections.Generic;
namespace Library.Tests
{
    public class Partida2Tests
    {
        [Test]
        public void CambioDeTurnoFuncionaCorrectamente()
        {
            Partida partida = new Partida();
            Jugador jugador1 = new Jugador("Jugador1", 98);
            Jugador jugador2 = new Jugador("Jugador2", 987);

            partida.Jugadores.Add(jugador1);
            partida.Jugadores.Add(jugador2);

            Juego juego = new Juego(); 
            partida.ComenzarPartida();

            Coordenada coordenada = new Coordenada(3, 4);
            juego.RealizarJugada(jugador1, partida);
            
            Assert.That(partida.Jugadores[partida.turnoactual], Is.SameAs(jugador2), "El turno no cambió correctamente");
        }
    }
}