using System.ComponentModel;
using System.Security;
using Library;
using Telegram.Bot.Types;

namespace Ucu.Poo.TelegramBot
{
    /// <summary> 
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "chau".
    /// </summary>
    public class BuscarPartidaHandler : BaseHandler
    {
        Administrador administrador = Administrador.Instance;
        public BuscarPartidaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "buscarpartida", "buscar partida" };
        }
        protected override void InternalHandle(Message message, out string response)
        {
            List<int> id = new List<int>();
            if (administrador.partidas.Count != 0){
                for(int i = 0; administrador.partidas.Count > i; i++)
                {
                    id.Add(administrador.partidas[i].Id);
                }
            }
            response = $"Partidas diponibles: {id}";
        }
    }
}