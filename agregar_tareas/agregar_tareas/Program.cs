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
        public static void AgregarTarea()
        {
            // 1. Mostrar encabezado
            Console.WriteLine("=== Agregar Nueva Tarea ===");

            // 2. Solicitar descripción de la tarea
            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            // 2. Solicitar fecha de vencimiento
            DateTime fechaVencimiento;
            while (true)
            {
                Console.Write("Fecha de vencimiento (dd/MM/yyyy): ");
                string fechaInput = Console.ReadLine();

                // 3. Validar formato de fecha
                if (DateTime.TryParseExact(fechaInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaVencimiento))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Fecha inválida. Intente nuevamente.");
                }
            }

            // 4. Crear nueva tarea (por defecto Completada = false)
            Tarea nuevaTarea = new Tarea
            {
                Descripcion = descripcion,
                FechaVencimiento = fechaVencimiento,
                Completada = false
            };

            // 5. Agregar la tarea a la lista estática
            tareas.Add(nuevaTarea);

            // 6. Confirmar al usuario
            Console.WriteLine("Tarea agregada correctamente. Presione Enter para continuar...");

            // 7. Esperar que el usuario presione Enter
            Console.ReadLine();
        }
    }
}
