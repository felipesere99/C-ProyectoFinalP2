using System.Dynamic;

namespace Library;

    /**
    *La clase tiene presente al SRP porque se encarga de gestionar el estado del tablero, verificar la validez de las ubicaciones y agregar barcos al tablero. Cada método tiene una responsabilidad única.
    **/
public class Tablero
{
    public int Largo {get; set;}
    public int Ancho {get; set;}
    public int[,] tablero {get; set;}

    public Tablero()
    {
        /**
        * Se establece clase Tablero. La misma gestiona el mismo. Se trata de una pieza 10x10, basada en el juego de mesa original. A eso se le agrega un metodo que se encarga de modificar el display del tablero, marcando en uno los cuadros ubicados por los barcos, y en otro, los cuadros a los que se ha disparado.
        **/
        Largo = 10;
        Ancho = 10;

        tablero = new int[Largo, Ancho];
        for (int fila = 0; fila < Ancho; fila++)
        {
            for (int columna = 0; columna < Largo; columna++)
            {
                /**
                *Asignar valores a las celdas (por ejemplo, 0 para celda vacía, 1 para un barco)
                **/
                tablero[fila, columna] = 0;
            }
        }
    }

     public bool EsUbicacionValida(Coordenada ubicacion, int tamanoBarco)
    {
        /**
        *Comprobar si las coordenadas están dentro de los límites del tablero
        **
        if (ubicacion.Fila < 0 || ubicacion.Fila >= 10 || ubicacion.Columna < 0 || ubicacion.Columna >= 10)
        {
            return false;
        }

        /**
        *Comprobar si hay superposición con otros barcos
        **/
        for (int i = 0; i < tamanoBarco; i++)
        {
            if (tablero[ubicacion.Fila, ubicacion.Columna + i] != 0)
            {
                /**
                *Hay superposición
                **/
                return false;
            }
        }

        /**
        *Si no hay superposición y las coordenadas están dentro de los límites, la ubicación es válida
        **/
        return true;
    }

    /**
    *Verificar si ya hay un barco del mismo tamaño en el tablero
    **/
    public bool TieneBarcoDelMismoTamano(int tamanoBarco)
    {
        /**
        *Verificar si ya hay un barco del mismo tamaño en el tablero
        **/

        /**
        *Iterar sobre el tablero y verificar si hay algún barco del mismo tamaño
        **/
        foreach (int celda in tablero)
        {
            if (celda == tamanoBarco)
            {
                /**
                *Ya hay un barco del mismo tamaño
                **/
                return true;
            }
        }

        /**
        *Si no se encuentra un barco del mismo tamaño, devolver false
        **/
        return false;
    }


    public void AgregarBarcosAlTablero(IBarco Barco, Orientacion orientacion)
    {
        
        if (orientacion == Orientacion.Horizontal){
            int indiceF = Barco.Ubicacion.Fila;
            for (int x = Barco.Ubicacion.Columna ; x< Barco.Ubicacion.Columna + Barco.Largo; x++){
                tablero[indiceF,x] = 1;}
        }
        else{
            int indiceC = Barco.Ubicacion.Columna;
            for (int x = Barco.Ubicacion.Fila ; x< Barco.Ubicacion.Fila + Barco.Largo; x++){
                tablero[x, indiceC] = 1;}
        }
    }
}
