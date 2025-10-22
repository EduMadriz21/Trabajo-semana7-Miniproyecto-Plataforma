using System;

namespace GestorDeTareas
{
    /// <summary>
    /// Punto de entrada principal de la aplicación.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "GestorDeTareas";

            // Creamos UNA instancia del gestor que vivirá durante toda la app
            TareaManager manager = new TareaManager();
            int opcion;

            do
            {
                UIHelper.MostrarMenu();
                opcion = UIHelper.LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        manager.AgregarTarea();
                        break;
                    case 2:
                        manager.ListarTareas();
                        break;
                    case 3:
                        manager.MarcarTareaCompletada();
                        break;
                    case 4:
                        manager.EliminarTarea();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    case -1:
                        // Opción inválida, el bucle se repite
                        break;
                    default:
                        Console.WriteLine("Opción no reconocida.");
                        UIHelper.ContinuePrompt();
                        break;
                }

            } while (opcion != 0);
        }
    }
}
