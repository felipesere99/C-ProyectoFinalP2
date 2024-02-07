using System.Formats.Asn1;
using Library;

/**
 * Se crea la clase Jugador. La misma representa al usuario, y sus habilidades dentro del juego. Tiene su nombre, su lista de barcos, y su acceso a los tableros. La clase cumple con el SRP porque tiene responsabilidades claras y únicas, como gestionar su información personal, la lista de barcos, el tablero, y realizar la colocación de barcos. La clase tambien tiene uso de Interfaces y Polimorfismo: La lista de barcos es de tipo List<IBarco>, lo que permite el polimorfismo al trabajar con diferentes tipos de barcos a través de la interfaz IBarco.
 **/
public class Jugador
{
    public string Nombre {get; set;}
    public List<IBarco> Barcos { get; set; }
    public Tablero Tablero { get; set; }
    public Coordenada UltimoDisparo { get; set; } = new Coordenada(0, 0);
    public List<int> DisparosRealizados {get; set;}
    public long Id {get; set;}


    public Jugador(string Nombre, long id)
    {
        this.Nombre=Nombre;
        this.Barcos = new List<IBarco>();
        Barcos.Add(new Barco2x1());
        Barcos.Add(new Barco2x1());
        Barcos.Add(new Barco3x1());
        Barcos.Add(new Barco4x1());
        Barcos.Add(new Barco5x1());
        this.Tablero= new Tablero();
        this.Id = id;
    }
    
    public Partida VerPartidasDisponiblesYUnirse()
    {
        Administrador administrador = Administrador.Instance;
        List<Partida> partidasDisponibles = administrador.ObtenerPartidasConJugadoresEsperando();

        if (partidasDisponibles.Count > 0)
        {
            Console.WriteLine("Partidas disponibles:");
            foreach (Partida partida in partidasDisponibles)
            {
                Console.WriteLine($"Partida {partida.Id}");
            }

            Console.WriteLine("Elige el número de la partida a la que quieres unirte:");
            if (int.TryParse(Console.ReadLine(), out int seleccion))
            {
                Partida partidaSeleccionada = partidasDisponibles.FirstOrDefault(p => p.Id == seleccion);

                if (partidaSeleccionada != null)
                {
                    ColocarBarcos();
                    return partidaSeleccionada;
                }
                else
                {
                    Console.WriteLine("Número de partida inválido. Inténtalo de nuevo.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Debes ingresar un número.");
            }
        }
        else
        {
            Console.WriteLine("No hay partidas disponibles. Debes esperar a que se inicie una nueva partida.");
        }

        return null;
    }
    public bool VerificarDisponibilidad(Coordenada[] coordenadas)
    {
        foreach (Coordenada coordenada in coordenadas)
        {
            /**
            * La celda no está disponible, está ocupada por otro barco
            **/
            if (Tablero.tablero[coordenada.Fila, coordenada.Columna] != 0)
            {
                return false;
            }
        }
        return true;
    }
  
  
  
    /**
    * Se introuce el metodo ColocarBarcos, introduce al jugador la capacidad de colocar en el tablero los barcos que le pertenecen y estan en su lista correspontiente. Para ello el metodo se basa en la logitud del barco en cuestion, y en base a las coordenadas que ocupa el barco, se lo posiciona en el mapa.
    **/
    public void ColocarBarcos()
    {
        /**
        *Solicita al jugador que especifique la ubicación de los barcos
        **/
        foreach (IBarco Barco in Barcos)
        {
            bool ubicacionValida = false;

            while (!ubicacionValida)
            {
                Console.WriteLine($"El tamaño del siguiente barco es {Barco.Largo}");
                Console.WriteLine("Las filas y las columnas van desde 0 hasta 9");
                Console.WriteLine("Introduce la ubicación del barco (Ej: '3,3' el primer número es la fila y el segundo es la columna): ");

                /**
                *Lee la entrada del usuario y la divide en fila y columna
                **/
                string[] coordenadasInput = Console.ReadLine().Split(',');

                try
                {
                    /**
                    *Preguntar al usuario la orientación
                    **/
                    Console.WriteLine("Introduce la orientación del barco (H para horizontal, V para vertical): ");
                    string inputOrientacion = Console.ReadLine();
                
                    Orientacion orientacion;

                    if (inputOrientacion.ToUpper() == "H")
                    {
                        orientacion = Orientacion.Horizontal;
                    }
                    else if (inputOrientacion.ToUpper() == "V")
                    {
                        orientacion = Orientacion.Vertical;
                    }
                    else
                    {
                        /**
                        * Reinicia el bucle para que el usuario ingrese valores válidos.
                        **/
                        Console.WriteLine("Orientación no válida. Inténtalo de nuevo.");
                        continue;
                    }

                    /**
                    * Verificamos que la entrada consista en dos números enteros
                    **/
                    if (coordenadasInput.Length == 2 &&
                        int.TryParse(coordenadasInput[0], out int fila) &&
                        int.TryParse(coordenadasInput[1], out int columna))
                    {
                        /**
                        *instancia de la clase Coordenada con la entrada del usuario
                        **/
                        Coordenada ubicacionBarco = new Coordenada(fila, columna);

                        /**
                        *Verifica si ya hay un barco del mismo tamaño en el tablero
                        **/
                        if (!Tablero.TieneBarcoDelMismoTamano(Barco.Largo))
                        {
                            /**
                            *Verifica si la ubicación es válida para el tamaño del barco y si está disponible en el tablero
                            **/
                            if (Tablero.EsUbicacionValida(ubicacionBarco, Barco.Largo) && VerificarDisponibilidad(Barco.ObtenerCoordenadas(ubicacionBarco))){

                                ubicacionValida = true; // Marca la ubicación como válida 
                                Barco.Ubicacion = ubicacionBarco; //asigna la ubicación al barco
                                Tablero.AgregarBarcosAlTablero(Barco, orientacion); //agrega el barco
                            }
                            else
                            {
                                Console.WriteLine("Ubicación no válida o ya ocupada por otro barco. Inténtalo de nuevo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Ya hay un barco del tamaño {Barco.Largo}. Introduce ubicación para otro tamaño.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Introduce dos números separados por coma.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Excepción encontrada. Detalles: " + e.Message);
                }
            }
        }
    }
}