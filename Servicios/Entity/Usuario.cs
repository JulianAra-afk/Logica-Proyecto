namespace Serivicios.Entity
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string? Tipo_Documento { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Password { get; set; }
        public Tipousuario Tipo_Usuario { get; set; } // Mirar
        public DateTime Fecha_Registro { get; set; }
        public bool Estado { get; set; }
    }
    public enum Tipousuario{
        Admin,Beneficiario,Afiliado,Normal
    }
}