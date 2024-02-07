using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    public class AdministradorTest
    {
        [Test]
        public void CrearPartida_UnirJugador()
        {
            
            Administrador admin = Administrador.Instance; 
            Jugador jugador = new Jugador("martin", 123);
            admin.jugadores.Add(jugador);
            Partida partida = admin.UnirseAPartida(jugador);


            
            Assert.IsTrue(partida.Jugadores.Contains(jugador));
        }

        [Test]
        public void ObtenerPartidasComenzadas_PartidaComenzada()
        {
            
            Administrador admin = new Administrador();
            Jugador jugador = new Jugador("nacho", 1234);
            admin.jugadores.Add(jugador);
            Partida partida = admin.UnirseAPartida(jugador);
            partida.ComenzarPartida();

            
            var partidasComenzadas = admin.ObtenerPartidasComenzadas();

            Assert.Contains(partida, partidasComenzadas);
        }

    }

    
}
