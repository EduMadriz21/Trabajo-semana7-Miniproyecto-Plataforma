using System;

namespace GestorDeTareas
{
    /// <summary>
    /// Métodos estáticos para ayudar con la interfaz de usuario de la consola.
    /// </summary>
    public static class UIHelper
    {
        public static void MostrarMenu()
        {
            Console.Clear(); // Limpia la pantalla
            Console.WriteLine("===== GESTOR DE TAREAS =====");
            Console.WriteLine("1. Agregar nueva tarea");
            Console.WriteLine("2. Listar tareas");
            Console.WriteLine("3. Marcar tarea como completada");
            Console.WriteLine("4. Eliminar tarea");
            Console.WriteLine("0. Salir");
            Console.WriteLine("============================");
        }

        /// <summary>
        /// Pausa la consola esperando que el usuario presione Enter.
        /// </summary>
        public static void ContinuePrompt()
        {
            Console.WriteLine("\nPulse ENTER para continuar...");
            Console.ReadLine();
        }

        /// <summary>
        /// Lee la opción del usuario y la valida.
        /// </summary>
        public static int LeerOpcion()
        {
            Console.Write("Seleccione una opción: ");
            var entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out int opcion))
            {
                Console.WriteLine("Entrada inválida. Introduzca solo el número.");
                ContinuePrompt();
                return -1; // Retorna -1 para re-intentar
            }
            return opcion;
        }
    }
}
