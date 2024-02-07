using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// Interfaz para implementar el patrón
    /// <a href="https://refactoring.guru/design-patterns/chain-of-responsibility">Chain of Responsibility</a>. En ese
    /// patrón se pasa un mensaje a través de una cadena de "handlers" que pueden procesar o no el mensaje. Cada
    /// "handler" decide si procesa el mensaje, o si se lo pasa al siguiente. Esta interfaz define un atributo para
    /// definir el próximo "handler" y una una operación para recibir el mensaje y pasarlo al siguiente "handler" en
    /// caso que el mensaje no sea procesado. La responsabilidad de decidir si el mensaje se procesa o no, y de
    /// procesarlo, se realiza en las clases que implementan esta interfaz.
    /// <remarks>
    /// La interfaz se crea en función del <a href="https://github.com/ucudal/PII_Principios_Patrones/blob/master/DIP.md">
    /// principio de inversión de dependencias</a>, para que los clientes de la cadena de responsabilidad, que pueden
    /// ser concretos, no dependan de una clase "handler" que potencialmente es abstracta.
    /// </remarks>
    /// <remarks>
    /// Esta clase aplica el <a href="https://github.com/ucudal/PII_Principios_Patrones/blob/master/LSP.md">principio de
    /// sustitución de Liskov</a> pues el comportamiento de procesar un mensaje no cambia al sustituir objetos que
    /// implementan esta interfaz unos por otros –todos pueden ser parte de la cadena de responsabilidad– pues las
    /// clases de esos objetos son subtipos del tipo definido en esta interfaz.
    /// </remarks>
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Obtiene el próximo "handler".
        /// </summary>
        /// <value>El "handler" que será invocado si este "handler" no procesa el mensaje.</value>
        IHandler? Next { get; set; }

        /// <summary>
        /// Procesa el mensaje o la pasa al siguiente "handler" si existe.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>El "handler" que procesó el mensaje si el mensaje fue procesado; null en caso contrario.</returns>
        IHandler? Handle(Message message, out string response);

        /// <summary>
        /// Retorna este "handler" al estado inicial y cancela el próximo "handler" si existe. Es utilizado para que los
        /// "handlers" que procesan varios mensajes cambiando de estado entre mensajes puedan volver al estado inicial en
        /// caso de error por ejemplo.
        /// </summary>
        void Cancel(Message message);
    }
}