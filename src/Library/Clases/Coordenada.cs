using System.Runtime.InteropServices;
using System.Xml.XPath;
using System;
using System.Collections.Generic;
using Library;
/**
*Creacion de la clase coordenada para quitar resposnabilidades a jugador barco y disparo. La clase tiene presente el encapsulamiento ya que Coordenada utiliza propiedades (Fila y Columna) para encapsular los campos privados (fila y columna). Esto proporciona un nivel de protección y control sobre la modificación de estos valores.
**/
public class Coordenada
{
    /**
    * La clase Coordenada establece una creacion clara de coordenadas. Dividiendolas en dos int, uno columna y otro fila esto para facilitar su localicación en el mapa.
    **/
    private int fila;
    private int columna;

    public int Fila
    {
        get { return fila; }
        set
        {
            if (value < 0)
            {
                throw new CoordenadaException("La fila no puede ser un valor negativo.");
            }
            fila = value;
        }
    }

    public int Columna
    {
        get { return columna; }
        set
        {
            if (value < 0)
            {
                throw new CoordenadaException("La columna no puede ser un valor negativo.");
            }
            columna = value;
        }
    }

    public Coordenada(int fila, int columna)
    {
        Fila = fila;
        Columna = columna;
    }
}
