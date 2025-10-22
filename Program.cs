using System;
using System.Collections.Generic;
using System.Globalization;

namespace GestorDeTareas
{
    class Program
    {
        // Lista estática que mantiene las tareas en memoria durante la ejecución.
        static List<Tarea> Tareas = new List<Tarea>();

        static void Main(string[] args)
        {
            Console.Title = "GestorDeTareas";
            int opcion;
            do
            {
                MostrarMenu();
                Console.Write("Seleccione una opción: ");
                var entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine("Entrada inválida. Introduzca el número de la opción.");
                    ContinuePrompt();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        AgregarTarea();
                        break;
                    case 2:
                        ListarTareas();
                        break;
                    case 3:
                        MarcarTareaCompletada();
                        break;
                    case 4:
                        EliminarTarea();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no reconocida.");
                        break;
                }

            } while (opcion != 0);
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("===== GESTOR DE TAREAS =====");
            Console.WriteLine("1. Agregar nueva tarea");
            Console.WriteLine("2. Listar tareas");
            Console.WriteLine("3. Marcar tarea como completada");
            Console.WriteLine("4. Eliminar tarea");
            Console.WriteLine("0. Salir");
            Console.WriteLine("============================");
        }

        static void AgregarTarea()
        {
            Console.WriteLine("\n--- Agregar nueva tarea ---");
            Console.Write("Descripción: ");
            var descripcion = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                Console.WriteLine("La descripción no puede estar vacía.");
                ContinuePrompt();
                return;
            }

            Console.Write("Fecha de vencimiento (dd/MM/yyyy) o ENTER para sin fecha: ");
            var fechaEntrada = Console.ReadLine();
            DateTime fecha = DateTime.MinValue;
            if (!string.IsNullOrWhiteSpace(fechaEntrada))
            {
                if (!DateTime.TryParseExact(fechaEntrada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
                {
                    Console.WriteLine("Formato de fecha inválido. Use dd/MM/yyyy. La tarea se guardará sin fecha.");
                    fecha = DateTime.MinValue;
                }
            }

            Tareas.Add(new Tarea(descripcion, fecha));
            Console.WriteLine("Tarea agregada correctamente.");
            ContinuePrompt();
        }

        static void ListarTareas()
        {
            Console.WriteLine("\n--- Lista de tareas ---");
            if (Tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
                ContinuePrompt();
                return;
            }

            for (int i = 0; i < Tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Tareas[i]}");
            }

            ContinuePrompt();
        }

        static void MarcarTareaCompletada()
        {
            Console.WriteLine("\n--- Marcar tarea como completada ---");
            if (!SolicitarIndice(out int indice)) return;

            var tarea = Tareas[indice];
            if (tarea.Completada)
            {
                Console.WriteLine("La tarea ya está marcada como completada.");
            }
            else
            {
                tarea.Completada = true;
                Console.WriteLine("Tarea marcada como completada.");
            }

            ContinuePrompt();
        }

        static void EliminarTarea()
        {
            Console.WriteLine("\n--- Eliminar tarea ---");
            if (!SolicitarIndice(out int indice)) return;

            Console.Write($"¿Confirma eliminación de la tarea \"{Tareas[indice].Descripcion}\"? (s/n): ");
            var confirmar = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(confirmar) && confirmar.Trim().ToLowerInvariant().StartsWith("s"))
            {
                Tareas.RemoveAt(indice);
                Console.WriteLine("Tarea eliminada.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }

            ContinuePrompt();
        }

        // Solicita un índice al usuario y lo valida. Retorna true si obtuvo un índice válido (0-based).
        static bool SolicitarIndice(out int indiceValido)
        {
            indiceValido = -1;
            if (Tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas para seleccionar.");
                ContinuePrompt();
                return false;
            }

            ListarResumen();
            Console.Write("Ingrese el número de la tarea: ");
            var entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out int numero) || numero < 1 || numero > Tareas.Count)
            {
                Console.WriteLine("Número de tarea inválido.");
                ContinuePrompt();
                return false;
            }

            indiceValido = numero - 1;
            return true;
        }

        // Muestra una versión corta de la lista (índice y descripción) para selección.
        static void ListarResumen()
        {
            for (int i = 0; i < Tareas.Count; i++)
            {
                var fecha = Tareas[i].FechaVencimiento == DateTime.MinValue ? "Sin fecha" : Tareas[i].FechaVencimiento.ToString("dd/MM/yyyy");
                var estado = Tareas[i].Completada ? "Completada" : "Pendiente";
                Console.WriteLine($"{i + 1}. {Tareas[i].Descripcion} - {fecha} - {estado}");
            }
        }

        static void ContinuePrompt()
        {
            Console.WriteLine("\nPulse ENTER para continuar...");
            Console.ReadLine();
        }
    }
}