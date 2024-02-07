using Library;
using Telegram.Bot.Types;

namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "chau".
    /// </summary>
    public class ColocarBarcosHandler : BaseHandler
    {
        Administrador administrador = Administrador.Instance;
        public ColocarBarcosHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"colocarbarcos", "colocar barcos"};
        }

        protected override void InternalHandle(Message message, out string response)
        {
            Jugador jugador = administrador.ObtenerJugadorPorId(message.Chat.Id);
            jugador.ColocarBarcos();
            response = $"Barcos colocados!";
        }
    }
}