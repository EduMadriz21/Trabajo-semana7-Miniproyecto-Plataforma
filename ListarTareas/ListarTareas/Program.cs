namespace ListarTareas
{
    // Clase que representa una tarea
    public class Tarea
    {
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }
    }

    internal class Program
    {
        // Lista estática para almacenar las tareas
        static List<Tarea> tareas = new List<Tarea>();

        static void Main(string[] args)
        {
            
        }
    }
}
