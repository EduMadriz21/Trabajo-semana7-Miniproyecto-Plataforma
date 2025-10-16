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

    
}
