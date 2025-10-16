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

        public static void ListarTareas()
        {
            // Mostrar encabezado
            Console.WriteLine("--- LISTA DE TAREAS ---");

            // Verificar si la lista está vacía
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Recorrer y mostrar cada tarea con formato
            for (int i = 0; i < tareas.Count; i++)
            {
                var tarea = tareas[i];
                Console.WriteLine($"{i + 1}. {tarea.Descripcion}");
                Console.WriteLine($"   Fecha de vencimiento: {tarea.FechaVencimiento:dd/MM/yyyy}");
                string estado = tarea.Completada ? "✅ Completada" : "⏳ Pendiente";
                Console.WriteLine($"   Estado: {estado}\n");
            }

            // Pausar la consola al final
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
