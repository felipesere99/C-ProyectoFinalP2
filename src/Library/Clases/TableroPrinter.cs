using System.Dynamic;

namespace Library;

/**
* La clase TableroPrinter es bastante autoexplicativa, es una clase que utlizando como base la interfaz IPrinter, se encarga de implimir lo creado en la clase tablero. La clase implementa la interfaz IPrinter y proporciona implementaciones específicas para los métodos ImprimirTableroConBarcos e ImprimirTableroConDisparos. Esto sigue el principio de ISP al asegurarse de que las clases no estén obligadas a implementar métodos que no utilizan.
La clase tambien tiene la responsabilidad de imprimir tableros, pero no de gestionar la lógica del juego ni de almacenar la información del tablero, esto sigue el SRP.
**/
public class TableroPrinter : IPrinter
{
    /**
    * Este primer tablero, le muestra al jugador el tablero que contiene sus barcos
    **/
    public string ImprimirTableroConBarcos(Jugador jugador)
    {
        string mensajetablerobarcos = "";
        Console.WriteLine("---------------------");
        mensajetablerobarcos += "---------------------\n";
        Console.WriteLine($"Tablero de {jugador.Nombre}");
        mensajetablerobarcos += $"Tablero de {jugador.Nombre}\n";
        Console.WriteLine("---------------------");
        mensajetablerobarcos += "---------------------\n";

        for (int fila = 0; fila < jugador.Tablero.Ancho; fila++)
        {
            for (int columna = 0; columna < jugador.Tablero.Largo; columna++)
            {
                Console.Write(jugador.Tablero.tablero[fila, columna] + " ");
                mensajetablerobarcos += jugador.Tablero.tablero[fila, columna] + " ";
            }
            Console.WriteLine(); // Salto de línea para pasar a la siguiente fila
            mensajetablerobarcos += "\n";
        }
        Console.WriteLine("---------------------");
        mensajetablerobarcos += "---------------------\n";

        return mensajetablerobarcos;
    }
    /**
    * Este segundo tablero le muestra al jugador el tablero con los lugares a donde ha disparado anteriormente
    **/
    public string ImprimirTableroConDisparos(Jugador jugador)
    {
        string mensajetablerodisparos = "";
        Console.WriteLine("---------------------");
        mensajetablerodisparos += "---------------------\n";
        Console.WriteLine($"Tablero de {jugador.Nombre}");
        mensajetablerodisparos += $"Tablero de {jugador.Nombre}\n";
        Console.WriteLine("---------------------");
        mensajetablerodisparos += "---------------------\n";
        Tablero tableroConDisparos = new Tablero();
        foreach(int ubiDisparo in jugador.DisparosRealizados)
        {
            for (int fila = 0; fila < jugador.Tablero.Ancho; fila++)
        {
            for (int columna = 0; columna < tableroConDisparos.Largo; columna++)
            {
                Console.Write(tableroConDisparos.tablero[fila, columna] + " ");
                mensajetablerodisparos += tableroConDisparos.tablero[fila, columna] + " ";

            }
            Console.WriteLine(); // Salto de línea para pasar a la siguiente fila
            mensajetablerodisparos += "\n";
        }
        }
        Console.WriteLine("---------------------");
        mensajetablerodisparos += "---------------------\n";

        return mensajetablerodisparos;
        
    }
}