namespace APITienda.Models
{
    public class Tienda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

        public Tienda(int nuevoId, string nuevoNombre, string nuevaUbicacion)
        {
            Id = nuevoId;
            Nombre = nuevoNombre;
            Ubicacion = nuevaUbicacion;
        }

        public Tienda()
        {
        }
    }
}