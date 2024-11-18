namespace Serivicios.Entity
{
    public class Notificacion
    {
        public int NotificacionId { get; set; }
        public int UsuarioId { get; set; }
        public TiposNot Tipo { get; set; } 
        public string? Titulo { get; set; }
        public bool Leido { get; set; }
        public DateTime Fecha_Envio { get; set; }
    }

    public enum TiposNot
    {
        sms, email, llamada
    }
}