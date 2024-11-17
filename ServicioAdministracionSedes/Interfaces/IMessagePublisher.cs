using ServicioAdministracionSedes.Messages;

namespace ServicioAdministracionSedes.Interfaces
{
    public interface IMessagePublisher
    {
          Task Publish(string queueName,SedeMessage Sede);
    }

}