namespace Library.Tests;

public class TableroTest
{
    [Test]
    public void ColocarBarcosEnTablero()
    {
        IBarco barco = new Barco3x1();
        IBarco barco1 = new Barco2x1();
        Jugador jugador = new Jugador("Test", 111);
        Tablero tablero = new Tablero();
        jugador.Barcos.Add(barco);
        jugador.Barcos.Add(barco1);
        jugador.ColocarBarcos();

        tablero.AgregarBarcosAlTablero(barco, Orientacion.Horizontal);
        tablero.AgregarBarcosAlTablero(barco1, Orientacion.Vertical);
        
        Assert.That(jugador.Barcos.Count, Is.EqualTo(2));
        Assert.IsTrue(tablero.tablero[2,6] == 0);
    }
}