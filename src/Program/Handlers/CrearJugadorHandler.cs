using Library;
using Telegram.Bot.Types;

namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "chau".
    /// </summary>
    public class CrearJugadorHandler : BaseHandler
    {
        Administrador administrador = Administrador.Instance;
        public CrearJugadorHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "crearjugador", "crear jugador" };
        }

        protected override void InternalHandle(Message message, out string response)
        {
            Jugador jugador = new Jugador(message.From.FirstName, message.Chat.Id);
            administrador.jugadores.Add(jugador);
            response = $"Se ha creado tu jugador,Tu nombre: {jugador.Nombre}";
        }
    }
}