using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerProject
{
    class Program
    {
        static void Main()
        {
            AdministradorDeTareas manager = new AdministradorDeTareas();

            manager.AddTask(new Tarea { Id = 1, Description = "Comprar leche" });

            bool completed = manager.CompleteTask(1);
            Console.WriteLine(completed ? "Tarea completada" : "Tarea no encontrada");
        }
    }


}
