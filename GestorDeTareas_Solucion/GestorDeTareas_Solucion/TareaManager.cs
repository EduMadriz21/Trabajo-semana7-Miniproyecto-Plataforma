using System;
using System.Collections.Generic;
using System.Globalization;

namespace GestorDeTareas
{
    /// <summary>
    /// Gestiona la lista de tareas y las operaciones sobre ella.
    /// </summary>
    public class TareaManager
    {
        // Esta es la ÚNICA lista de tareas. Es privada.
        private List<Tarea> _tareas = new List<Tarea>();

        public void AgregarTarea()
        {
            Console.WriteLine("\n--- Agregar nueva tarea ---");
            Console.Write("Descripción: ");
            var descripcion = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                Console.WriteLine("La descripción no puede estar vacía.");
                UIHelper.ContinuePrompt();
                return;
            }

            Console.Write("Fecha de vencimiento (dd/MM/yyyy) o ENTER para sin fecha: ");
            var fechaEntrada = Console.ReadLine();
            DateTime fecha = DateTime.MinValue; // Fecha por defecto si no se ingresa

            if (!string.IsNullOrWhiteSpace(fechaEntrada))
            {
                if (!DateTime.TryParseExact(fechaEntrada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
                {
                    Console.WriteLine("Formato de fecha inválido. La tarea se guardará sin fecha.");
                    fecha = DateTime.MinValue;
                }
            }

            _tareas.Add(new Tarea(descripcion, fecha));
            Console.WriteLine("Tarea agregada correctamente.");
            UIHelper.ContinuePrompt();
        }

        public void ListarTareas()
        {
            Console.WriteLine("\n--- Lista de tareas ---");
            if (_tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
                UIHelper.ContinuePrompt();
                return;
            }

            for (int i = 0; i < _tareas.Count; i++)
            {
                // Usamos el método ToString() que definimos en la clase Tarea
                Console.WriteLine($"{i + 1}. {_tareas[i]}");
            }

            UIHelper.ContinuePrompt();
        }

        public void MarcarTareaCompletada()
        {
            Console.WriteLine("\n--- Marcar tarea como completada ---");
            if (!SolicitarIndice(out int indice)) return;

            var tarea = _tareas[indice];
            if (tarea.Completada)
            {
                Console.WriteLine("La tarea ya está marcada como completada.");
            }
            else
            {
                tarea.Completada = true;
                Console.WriteLine("Tarea marcada como completada.");
            }

            UIHelper.ContinuePrompt();
        }

        public void EliminarTarea()
        {
            Console.WriteLine("\n--- Eliminar tarea ---");
            if (!SolicitarIndice(out int indice)) return;

            Console.Write($"¿Confirma eliminación de la tarea \"{_tareas[indice].Descripcion}\"? (s/n): ");
            var confirmar = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(confirmar) && confirmar.Trim().ToLowerInvariant().StartsWith("s"))
            {
                _tareas.RemoveAt(indice);
                Console.WriteLine("Tarea eliminada.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }

            UIHelper.ContinuePrompt();
        }

        // Muestra una lista corta para seleccionar una tarea
        private void ListarResumen()
        {
            for (int i = 0; i < _tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_tareas[i].Descripcion}");
            }
        }

        // Método privado para pedir al usuario un número de tarea válido
        private bool SolicitarIndice(out int indiceValido)
        {
            indiceValido = -1;
            if (_tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas para seleccionar.");
                UIHelper.ContinuePrompt();
                return false;
            }

            ListarResumen(); // Muestra la lista de tareas
            Console.Write("Ingrese el número de la tarea: ");
            var entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out int numero) || numero < 1 || numero > _tareas.Count)
            {
                Console.WriteLine("Número de tarea inválido.");
                UIHelper.ContinuePrompt();
                return false;
            }

            indiceValido = numero - 1; // La lista está base 0, el usuario ve base 1
            return true;
        }
    }
}
