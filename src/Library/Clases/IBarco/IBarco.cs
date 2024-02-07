namespace Library;

/**
* En primera instancia se introduce la interfaz IBarco. La misma fue hecha para proporcionar a los demás barcos metodos, y propiedades que corresponden a todos los Barcos de nuestro juego. La interfaz sigue el ISP al proporcionar métodos específicos para los barcos sin obligar a las clases que la implementan a proporcionar funcionalidades que no necesitan. La interfaz tiene la responsabilidad de definir los métodos y propiedades relacionados con los barcos, como RegistrarDisparo, ActualizarEstado, Ubicacion, Largo, etc. Esto sigue el SRP al tener una única razón para cambiar: cambios en el comportamiento de los barcos.
**/
public enum Orientacion
{
    Horizontal,
    Vertical
}
public interface IBarco
{
    int Largo { get; set; }
    string Estado { get; set; }
    Coordenada Ubicacion { get; set; }
    List<int> DisparosRecibidos { get; }
    /**
    * RegistrarDisparo , es el metodo que registra, valga la redundancia, los disparos recibidos por la nave en cuestión. Esto toma las ubicaciones que ocupan los barcos y la ubicación a la que el disparo fue efectuado. Comparando ambas "ubicaciones" para decidir si el disparo golpeo el barco.
    */
    public void RegistrarDisparo(int coordenada);
    /**
    * El metodo ActualizarEstado, es un metodo que sirve como un doble check del impacto, este nos va a devolver en que condición está el barco tras recibir un disparo. Ej. si es 2x1,7 ocupa dos ubicaciones, si en el primer disparo se impactó una de esas coordenadas tenemos un cambio de Estado de "Intacto" a "Tocado". De suceder otra vez, es decir, un inpacto en la segunda coordenada, este barco pasará a estar "Hundido". 
    */
    public void ActualizarEstado();
    /**
    * Las siguientes propiedades: un int Ubicacion, un int Largo y un str Estado, representan las propiedades asignadas a los barcos. La Ubicacion representa donde está en el tablero, y parte de su uso puede ser observado en el metodo RegistrarDisparo. El Largo es la cantidad de ubicaiones en vertical u horizontal (una o la otra), que ocupan los barcos, en el caso de nuestro juego es de g2 a 5. El Estado representa la condicon del barco, como "Intacto", "Tocado" o "Hundido".
    */
    Orientacion Orientacion { get; set; }
    Coordenada[] ObtenerCoordenadas(Coordenada ubicacionInicial);
}