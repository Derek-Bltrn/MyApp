namespace MyApp.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Destinatario { get; set; } = null!;
    }
}
