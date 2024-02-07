namespace Library;

/**
*Creacion de la clase Juego para quitar responsabilidades a partida y jugador.
    Cada metodo tiene una responsabilidad unica siguiendo el SRP.
    El código permite la extensión sin necesidad de modificar el código existente siguiendo el OCP
**/

public class Juego{
    private List<Partida> partidasEnCurso = new List<Partida>();
    Jugador jugador1 {get; set;}
    Jugador jugador2 {get; set;}

    public void IniciarJuego(Partida partida)
    {
        if (partida.Jugadores.Count == 2)
        {
            partida.ComenzarPartida();
            Console.WriteLine("¡Bienvenido al juego!");
        }
        if (partida.Comenzada == true)
        {
            partidasEnCurso.Add(partida);
            jugador1 = partida.Jugadores[0];
            jugador2 = partida.Jugadores[1];
            Disparo disparo = new Disparo();
            TableroPrinter tableroPrinter = new TableroPrinter();
            while(jugador1.Barcos.Count() > 0 || jugador2.Barcos.Count() > 0)
            {
                if (partida.turnoactual == 0){
                    disparo.RealizarDisparo(jugador1, jugador2);
                    tableroPrinter.ImprimirTableroConDisparos(jugador1);
                    tableroPrinter.ImprimirTableroConBarcos(jugador1);
                }
                if (partida.turnoactual == 1){
                    disparo.RealizarDisparo(jugador2, jugador1);
                    tableroPrinter.ImprimirTableroConDisparos(jugador2);
                    tableroPrinter.ImprimirTableroConBarcos(jugador2);
                }
                partida.CambiarTurno();
            }
            if(jugador1.Barcos.Count() > 0 && jugador2.Barcos.Count() == 0){
                Console.WriteLine($"El ganador es: {jugador1.Nombre}!!");
            }
            if(jugador1.Barcos.Count() == 0 && jugador2.Barcos.Count() > 0){
                Console.WriteLine($"El ganador es: {jugador2.Nombre}!!");
            }
            FinalizarJuego(partida);
        }
    }

    /**
    *Lógica para la finalización del juego
    **/
    public void FinalizarJuego(Partida partida)
    {
        partida.Terminada = true;
        Console.WriteLine("¡Gracias por jugar!");
    }
    /**
    *Lógica para realizar una jugada en el juego
    **/
    public void RealizarJugada(Jugador jugador, Partida partida)
    {
        if (partida.Comenzada)
        {
            try
            {
                /**
                *Chequeamos si es el turno del jugador
                **/
                if (partida.Jugadores[partida.turnoactual].Id == jugador.Id)
                {
                    /**
                    *Realizamos el disparo
                    **/
                    Disparo disparo = new Disparo();
                    string mensajeDisparo = disparo.RealizarDisparo(jugador, ObtenerJugadorContrario(partida, jugador));
                    partida.CambiarTurno();
                    
                    
                } 
                else
                {
                    throw new Exception("No es el turno de este jugador");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al realizar la jugada: {e.Message}");
            }
        }
        else
        {
            Console.WriteLine("La partida no está en curso o ya ha terminado.");
        }
    }

    /**
    *Lógica para verificar si la coordenada pertenece a un barco en la partida
    **/
    private bool EsCoordenadaDeBarco(Coordenada coordenada, Partida partida)
    {  
        return false; 
    }
      private Jugador ObtenerJugadorContrario(Partida partida, Jugador jugador)
    {
        return partida.Jugadores[(partida.turnoactual + 1) % partida.Jugadores.Count];
    }

}