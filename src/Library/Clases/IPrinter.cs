namespace Library
{
    /* Se crea la interfaz IPrinter, su objetivo: controlar la impresion de los tableros.
        IPrinter sigue el principio ISP al tener metodos que se relacionan con una responsabilidad especifica.
        IPrinter tambien es una abstracción que define un contrato para las clases que la implementan.
        Tambien es un ejemplo de poliformismo e inversion de dependencias.*/

    public interface IPrinter
    {
         string ImprimirTableroConBarcos(Jugador jugador);
         string ImprimirTableroConDisparos(Jugador jugador);
    }
}