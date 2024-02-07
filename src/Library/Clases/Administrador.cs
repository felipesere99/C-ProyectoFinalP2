using System;
using System.Collections.Generic;
using Library;

/**
*La clase Administrador implementa el patrón Singleton, asegurando que solo haya una instancia de la clase
**/
public class Administrador
{
    public List<Partida> partidas = new List<Partida>();
    public List<Jugador> jugadores = new List<Jugador>();
    public static readonly object locker = new object();
    public static Administrador? _Administrador = null;
    public static Administrador Instance
     {
        get
        {
            lock(locker){
                if (_Administrador == null)
                {
                    _Administrador = new Administrador();
                }
                return _Administrador;
            }
        }
    }

    public Jugador RegistrarJugador()
    {
        Console.WriteLine("Dame tu nombre");
        string nombre = Console.ReadLine();
        Random random = new Random();
        Jugador jugador= new Jugador(nombre, random.Next(1000, 9999));
        jugadores.Add(jugador);
        return jugador;
    }


    public Partida UnirseAPartida(Jugador jugador)
    {
        Partida partida = ObtenerPartidaDisponible();

        if (partida == null)
        {
            partida = CrearPartida(jugador.Id);
        }

        if (partida.Jugadores.Count < 2)
        {
            AsignarJugador(partida, jugador.Id);
            return partida;
        }
        
        else
        {
            throw new PartidaLlenaException("No puede unirse a esta partida porque ya tiene dos jugadores");
        }
    }

    public Partida CrearPartida(long id)
    {
        Partida partida = new Partida();
        Random random = new Random();
        Jugador jugador = ObtenerJugadorPorId(id);
        partida.Id = random.Next(1000, 9999);
        partidas.Add(partida);
        jugadores.Add(jugador);
        return partida;
    }

    public Partida ObtenerPartidaPorId(int idPartida)
    {
        return partidas.Find(partida => partida.Id == idPartida);
    }

    public Partida devolverPartida(long idJugador){
        lock(locker)
        {
            Partida partida = partidas.FirstOrDefault(p => 
            p.Jugadores.Exists(jugador => jugador.Id == idJugador) && !p.Terminada);
            return partida;
        }
    }

    public void AsignarJugador(Partida partida, long id)
    {
        if (partida.Jugadores.Count >= 2)
        {
            throw new PartidaLlenaException("La partida ya tiene dos jugadores");
        }

        Jugador jugador = ObtenerJugadorPorId(id);

        if (jugador != null)
        {
            // Agregar el jugador a la lista de jugadores de la partida
            partida.Jugadores.Add(jugador);
            Console.WriteLine($"Jugador {jugador.Nombre} asignado a la partida {partida.Id}");
        }
        else
        {
            throw new JugadorNoEncontradoException("El jugador no se encuentra en la lista.");
        }
    }

    
    public Jugador ObtenerJugadorPorId(long id)
    {
        return jugadores.Find(jugador => jugador.Id == id);
    }
    public Partida ObtenerPartidaDisponible()
    {
        foreach (var partida in partidas)
        {
            if (!partida.Comenzada && partida.Jugadores.Count < 2)
            {
                return partida;
            }
        }
        return null;
    }

    public List<Partida> ObtenerPartidasComenzadas()
    {
        return partidas.FindAll(partida => partida.Comenzada);
    }

    public List<Partida> ObtenerPartidasConJugadoresEsperando()
    {
        return partidas.FindAll(partida => !partida.Comenzada && partida.Jugadores.Count < 2);
    }

    public void FinalizarPartida(Partida partida)
    {
        ////hay que agregar la logica if para finalizar una partida si un jugador gana u otro abandona
        partidas.Remove(partida);
    }

}