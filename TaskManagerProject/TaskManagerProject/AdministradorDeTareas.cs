using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagerProject
{
    public class AdministradorDeTareas //comentario para probar git
    {
        private List<Tarea> tareas = new List<Tarea>();

        public void AddTask(Tarea tarea)
        {
            tareas.Add(tarea);
        }
        /// <summary>
        /// Marca una tarea como completada según su ID.
        /// </summary>
        /// <param name="id">ID de la tarea a completar</param>
        /// <returns>True si se completó, false si no se encontró</returns>
        public bool CompleteTask(int id)
        {
            var tarea = tareas.Find(t => t.Id == id);
            if (tarea != null)
            {
                tarea.IsCompleted = true;
                return true;
            }
            return false;
        }

        public void ListTasks()
        {
            foreach (var tarea in tareas)
            {
                Console.WriteLine($"ID: {tarea.Id}, Desc: {tarea.Description}, Completada: {tarea.IsCompleted}");
            }
        }
    }

}

