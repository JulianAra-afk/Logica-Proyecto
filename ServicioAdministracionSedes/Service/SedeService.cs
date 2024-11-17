
using Proyecto.Interfaces;
using Proyecto.Messages;



namespace Proyecto.Services
{
     public class SedesService
    {
        private readonly IMessagePublisher _messagePublisher;

        public SedesService(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        public void CrearSede(SedeMessage nuevaSede)
        {
            nuevaSede.TipoOperacion = "CREAR";
            _messagePublisher.Publish("sedes_queue", nuevaSede);
        }

        public void ModificarSede(SedeMessage sedeModificada)
        {
            sedeModificada.TipoOperacion = "MODIFICAR";
            _messagePublisher.Publish("sedes_queue", sedeModificada);
        }

        public void ObtenerSedePorId(int id)
        {
            var consultaSede = new SedeMessage { Id = id, TipoOperacion = "CONSULTAR" };
            _messagePublisher.Publish("sedes_queue", consultaSede);
        }
    }
}