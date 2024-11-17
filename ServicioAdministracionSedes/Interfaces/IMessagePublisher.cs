using Proyecto.Messages;

namespace Proyecto.Interfaces
{
    public interface IMessagePublisher
    {
          Task Publish(string queueName,SedeMessage Sede);
    }

}