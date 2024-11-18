namespace Serivicios.Entity
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int Usuario_Id { get; set; }
        public int Instalacion_Id { get; set; }
        public DateTime Fecha_Reserva { get; set; }
        public DateTime Hora_Inicio { get; set; }
        public DateTime Hora_Fin { get; set; }
        public decimal Tarifa { get; set; }
        public Estadopago Estado { get; set; } 
        public DateTime Creacion { get; set; }
    }
}