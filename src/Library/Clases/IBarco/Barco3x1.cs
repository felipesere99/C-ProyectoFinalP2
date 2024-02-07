namespace Library;
//Patron Creator
public class Barco3x1: IBarco
{
    public int Largo { get; set; }
    public string Estado { get; set; }
    public Coordenada Ubicacion { get; set; }
    public Orientacion Orientacion { get; set; }
    public List<int> DisparosRecibidos { get; private set; }

    public Barco3x1()
    {
        Largo=3;
        Estado = "Intacto";
        DisparosRecibidos = new List<int>(); //Lista para llevar un registro de los disparos que impactan(se agregarían las coordenadas)
    }

    public Coordenada[] ObtenerCoordenadas(Coordenada ubicacionInicial)
    {
        // Lógica para obtener las coordenadas del barco basándote en la orientación y el largo.

        int fila = ubicacionInicial.Fila;
        int columna = ubicacionInicial.Columna;

        Coordenada[] coordenadas = new Coordenada[Largo];

        for (int i = 0; i < Largo; i++)
        {
            if (Orientacion == Orientacion.Horizontal)
            {
                coordenadas[i] = new Coordenada(fila, columna + i);
            }
            else if (Orientacion == Orientacion.Vertical)
            {
                coordenadas[i] = new Coordenada(fila + i, columna);
            }
            
        }

        return coordenadas;
    }

    public void RegistrarDisparo(int coordenada)
    {
        DisparosRecibidos.Add(coordenada);
    }
    
    public void ActualizarEstado()
    {
        if (DisparosRecibidos.Count >= Largo)
        {
            Estado = "Hundido";
        }
        else if (DisparosRecibidos.Count >=1)
        {
            Estado = "Tocado";
        }
    }
}