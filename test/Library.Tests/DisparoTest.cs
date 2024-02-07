using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    public class DisparoTest
    { 
        [Test]
        public void DisparoConAcierto()
        { 
            Disparo disparo = new Disparo();

            Tablero tablero = new Tablero();
            Jugador pedro = new Jugador("Pedro",222);

            pedro.Barcos[0].Ubicacion = new Coordenada(1, 1);
            Orientacion orientacion = Orientacion.Vertical;
            int coordenadaDeDisparo = 11;
            tablero.AgregarBarcosAlTablero(pedro.Barcos[0], orientacion);

            pedro.Tablero = tablero;
            bool disparoResult = disparo.ImpactoEnBarco(pedro.Barcos[0], coordenadaDeDisparo);
            
            Assert.IsTrue(disparoResult);
        }
        
        public void DisparoConFallo()
        { 
            Disparo disparo = new Disparo();

            Tablero tablero = new Tablero();
            Jugador juan = new Jugador("Juan",333);

            juan.Barcos[0].Ubicacion = new Coordenada(2, 2);
            Orientacion orientacion = Orientacion.Horizontal;
            int coordenadaDeDisparo = 44;
            tablero.AgregarBarcosAlTablero(juan.Barcos[0], orientacion);

            juan.Tablero = tablero;
            bool disparoResult = disparo.ImpactoEnBarco(juan.Barcos[0], coordenadaDeDisparo);
            
            Assert.IsFalse(disparoResult);
        }
    } 
}