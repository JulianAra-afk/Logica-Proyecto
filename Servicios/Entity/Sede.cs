namespace Serivicios.Entity
{
    public class Sede
    {
        public int SedeId { get; set; }
        public string? Nombre { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }
        public string? Horario { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }

    }
}