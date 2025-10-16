using System;
using System.Collections.Generic;

namespace agregar_tareas
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


        /// <summary>
        /// Permite al usuario agregar una nueva tarea a la lista estática 'tareas'.
        /// </summary>
        
    }
}
