namespace ServicioAdministracionSedes.Messages{
      public class SedeMessage
    {
        public int Id { get; set; }
        public string ?Nombre { get; set; }
        public string ?Direccion { get; set; }
        public string ?Ciudad { get; set; }
        public string ?Estado { get; set; } 
        public string ?Horario { get; set; }
        public string ?Telefono { get; set; }
        public string ?Email { get; set; }
        public string ?TipoOperacion { get; set; } // "CREAR", "MODIFICAR" o "CONSULTAR"
    }
}