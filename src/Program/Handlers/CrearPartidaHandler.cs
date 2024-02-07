using Library;
using Telegram.Bot.Types;

namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "chau".
    /// </summary>
    public class CrearPartidaHandler : BaseHandler
    {
        Administrador administrador = Administrador.Instance;
        public CrearPartidaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "crearpartida", "crear partida" };
        }

        protected override void InternalHandle(Message message, out string response)
        {
            Partida partida = administrador.CrearPartida(message.Chat.Id);
            response = $"Se ha creado la partida,Id: {partida.Id}";
        }
    }
}