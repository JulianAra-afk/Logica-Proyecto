namespace ServicioAdministracionSedes.Entity{
    public class Service
    {
        public int Id { get; set; }
        public string ?Nombre { get; set; }
        public string ?Descripcion { get; set; }
        public decimal Tarifa { get; set; }
        public int SedeId { get; set; }
        
    }
}