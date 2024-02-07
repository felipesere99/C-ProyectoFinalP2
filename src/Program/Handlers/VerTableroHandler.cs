using System.ComponentModel;
using System.Security;
using Library;
using Telegram.Bot.Types;

namespace Ucu.Poo.TelegramBot
{
    /// <summary> 
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "chau".
    /// </summary>
    public class VerTableroHandler : BaseHandler
    {
        Administrador administrador = Administrador.Instance;
        public VerTableroHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "vertablero", "ver tablero" };
        }
        protected override void InternalHandle(Message message, out string response)
        {
            /*Primero hay que crear jugador*/
            TableroPrinter tableroPrinter = new TableroPrinter();
            Jugador jugador = administrador.ObtenerJugadorPorId(message.Chat.Id);
            string tablero = tableroPrinter.ImprimirTableroConBarcos(jugador);
            response = tablero;
        }
    }
}