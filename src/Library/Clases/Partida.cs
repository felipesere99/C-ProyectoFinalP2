namespace Library;

/**
* La clase Partida, lleva un control sobre lo que esta siendo jugado. Lleva a los Jugadores y un control sobre a quien le toca, una vez termindad, da lugar a una nueva partida.
**/
public class Partida
{
    public int turnoactual;
    public int Id { get; set; }
    public List<Jugador> Jugadores { get; set; }
    public bool Comenzada { get; set; }
    public bool Terminada { get; set; }

    public Partida()
    {
        Jugadores = new List<Jugador>();
        turnoactual = 0;
        Terminada = false;
        this.Id = GenerarIdPartida();
    }

    private int GenerarIdPartida()
    {
        Random random = new Random();
        int result =  random.Next(1000, 9999);
        return result;
    }
    public void ComenzarPartida()
    {
        Comenzada = true;
    }

    public void CambiarTurno()
    {
        // Cambia al siguiente jugador en la lista circular
        turnoactual = (turnoactual + 1) % Jugadores.Count;
    }
    private void EvaluarGanador()
    {
        Jugador jugadorActual = Jugadores[turnoactual];
        Jugador oponente = Jugadores[(turnoactual + 1) % Jugadores.Count];

       
        if (oponente.Barcos.All(barco => barco.Estado == "Hundido"))
        {
                TerminarPartida(jugadorActual);
        }
    }

    private void TerminarPartida(Jugador ganador)
    {
        Terminada = true;
        Console.WriteLine($"La partida {Id} ha terminado. Ganador: {ganador.Nombre}");

        
    }
}
