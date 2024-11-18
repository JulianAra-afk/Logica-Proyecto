namespace Serivicios.Entity{
    public class ProgramaDep
    {
        public int ProgramaId {get;set;}
        public int SedeId {get;set;}
        public string ? Nombre {get;set;}
        public string ? Descripcion {get;set;}
        public string ? Tipo_Actividad {get;set;} 
        public int Cupo {get;set;}
        public DateTime Fecha_Inicio {get;set;}
        public DateTime Fecha_Fin {get;set;}
        public decimal Tarifa_Afiliado {get;set;}
        public decimal Tarifa_No_Afiliado {get;set;}
        public bool Estado {get;set;}
    }
}