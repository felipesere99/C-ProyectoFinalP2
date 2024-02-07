using Library;
using System.Runtime.InteropServices;
using System.Timers;
using System.Xml.XPath;

    /**
    *Esta clase cumple con SRP porque dividimos su funcionalidad en metodos mas pequeños y especificos. Ej:ObtenerCoordenada, RealizarDisparo y ImpactoEnBarco. Tambien cumple con Expert porque tiene la información necesaria para cumplir con las responasbilidades de Disparo
    **/

public class Disparo
{
    public int coordenadaDisInt { get; set; }
    public bool impacto { get; set; }

    /**
    *El metodo ObtenerCoordenada se encarga de pedir los datos al usuario para despues poder utilizarlos en RealizarDisparo
    **/
    private Coordenada ObtenerCoordenada() //coordenada puede ser null entonces verificamos
    {

        while (true)
        {
            Console.WriteLine("Ingrese las coordenadas (primero fila y después columna, ej; '46'):");
            string input = Console.ReadLine();

            try
            {
                int fila = int.Parse(input[0].ToString());
                int columna = int.Parse(input[1].ToString());
                return new Coordenada(fila, columna);
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de coordenada incorrecto. Inténtelo de nuevo.");
            }
        }
    }
    /**
    *RealizarDisparo se encarga de devolver el resultado del disparo realizado, toma a ambos jugadores, de esta forma al jugador que realiza el ataque se le añade a su lista de disparosRealizados el hecho por ultimo y al jugador que es atacado se le cambiara el estado del barco en caso de que haya sido golpeado.
    **/
    public string RealizarDisparo(Jugador jugadorAtacante, Jugador jugadorAtacado)
    {
        Coordenada coordenadaDis = ObtenerCoordenada();
        string mensajeDisparo = "";
        try
        {
            coordenadaDisInt = coordenadaDis.Fila * 10 + coordenadaDis.Columna;
            Console.WriteLine("Disparo realizado en la coordenada: " + coordenadaDisInt);
            mensajeDisparo = $"Se realizó un disparo en la coordenada: {coordenadaDisInt}";

            if (coordenadaDisInt < 0 || coordenadaDisInt >= 100)
            {
                Console.WriteLine("Disparo fuera de rango (rango entre 0 y 9)");
                mensajeDisparo = "Disparo fuera de rango (rango entre 0 y 9)";
                
            }

            impacto = false;

            foreach (IBarco barco in jugadorAtacado.Barcos)
            {
                if (ImpactoEnBarco(barco, coordenadaDisInt))
                {
                    impacto = true;
                    jugadorAtacante.DisparosRealizados.Add(coordenadaDisInt);
                    break;
                }
            }

            if (!impacto)
            {
                Console.WriteLine("No hubo impacto en ningún barco en la coordenada " + coordenadaDisInt);
                mensajeDisparo = $"No hubo impacto en ningún barco en la coordenada {coordenadaDisInt}";

            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Excepción encontrada // Detalles: " + e.Message);
            mensajeDisparo = $"Excepción encontrada // Detalles:  {e.Message}";
        }
        return mensajeDisparo;
    }

    /*ImpactoEnBarco contiene la logica la cual comprueba si las coordenadas del disparo son las mismas a la de algun barco. */
    public bool ImpactoEnBarco(IBarco barco, int coordenada)
    {
        Coordenada coordenadaBarco = barco.Ubicacion;

        // Verificar si la coordenada del disparo está dentro de las coordenadas del barco
        if (barco.Largo == 2 && coordenada == coordenadaBarco.Fila * 10 + coordenadaBarco.Columna)
        {
            ImpactoEnBarcoEstado(barco, true, coordenada);
            return true;
        }

        if (barco.Largo > 2 && barco.Largo <= 5)
        {
            int filaPrimerNumero = coordenadaBarco.Fila / 10;
            int columnaPrimerNumero = coordenadaBarco.Fila % 10;
            int filaSegundoNumero = coordenadaBarco.Columna / 10;
            int columnaSegundoNumero = coordenadaBarco.Columna % 10;

            // Verificar si la coordenada del disparo está dentro de las coordenadas del barco
            if (filaPrimerNumero == coordenada / 10 && columnaPrimerNumero <= coordenada % 10 && coordenada % 10 <= columnaSegundoNumero)
            {
                ImpactoEnBarcoEstado(barco, true, coordenada);
                return true;
            }

            if (columnaPrimerNumero == coordenada % 10 && filaPrimerNumero <= coordenada / 10 && coordenada / 10 <= filaSegundoNumero)
            {
                ImpactoEnBarcoEstado(barco, true, coordenada);
                return true;
                
            }
        }
        ImpactoEnBarcoEstado(barco, false, coordenada);
        return false;
    }

    /**
    *ImpactoEnBarcoEstado se encarga de guardar el disparo dentro del objeto Barco(esto para despues verificar cuando este se hunde) y tambien de actualizar su estado.
    **/
    private void ImpactoEnBarcoEstado(IBarco Barco, bool acierto, int coordenada)
    {
        if (acierto)
        {
            Barco.RegistrarDisparo(coordenada);
            Barco.ActualizarEstado();
            Console.WriteLine("Impacto la coordenada " + coordenada);
        }
        else {
            Console.WriteLine("Agua");
        }
    }
}