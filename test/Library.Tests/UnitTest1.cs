namespace Library.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        IBarco barco = new Barco3x1();

        Assert.That(barco.Largo, Is.EqualTo(3));

        Disparo disparo = new Disparo();

        string disparoFallado = "missed";
        

        Jugador jugador1 = new Jugador("Jugador 1", 1199);

        Assert.IsNotEmpty(jugador1.Nombre);
    }
}