using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    
    public class JugadorTest
    {

        [Test]
        public void ColocarBarcos_ColocaBarcosEnUbicacionValida()
        {
            
            Jugador pedro = new Jugador("pedro", 77);
            IBarco barco = new Barco2x1();
            pedro.Barcos.Add(barco);
            barco.Ubicacion=new Coordenada(2,2);
            pedro.ColocarBarcos();

            
            Assert.IsNotNull(barco.Ubicacion);
        }



    }
}