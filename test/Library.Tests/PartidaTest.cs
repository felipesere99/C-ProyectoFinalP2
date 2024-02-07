namespace Library.Tests
{
    class PartidaTest
    {
        [Test]
        public void CrearPartida()
        {
            Partida partida = new Partida();
            Assert.IsEmpty(partida.Jugadores);
        }

        [Test]
        public void ComenzarPartida()
        {
            Partida partida = new Partida();
            partida.ComenzarPartida();
            Assert.That(partida.Jugadores.Count, Is.EqualTo(0));
            Assert.IsTrue(partida.Comenzada);
        }

        /*[Test]
        public void Jugada()
        {
            Partida partida = new Partida();
            Jugador jugador1 = new Jugador("martin");
            Jugador jugador2 = new Jugador("pauli");
            partida.Jugadores.Add(jugador1);
            partida.Jugadores.Add(jugador2);
            partida.ComenzarPartida();

            partida.Jugada(jugador2, new Disparo());
            partida.Jugada(jugador1, new Disparo());

            //Assert.AreEqual(10, jugador2.Puntuacion);
            //Assert.AreEqual(5, jugador1.Puntuacion);
        }

        [Test]
        public void JugadaException()
        {
            Partida partida = new Partida();

            Jugador jugador1 = new Jugador("martin");
            try
            {
                partida.Jugada(jugador1,new Disparo());
            }catch(Exception e)
            {
                Assert.IsInstanceOf(typeof(PartidaNoComenzadaException), e);
            }
        }*/
    }
}
