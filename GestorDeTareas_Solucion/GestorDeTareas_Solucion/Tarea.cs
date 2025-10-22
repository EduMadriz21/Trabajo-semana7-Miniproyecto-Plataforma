using System;

namespace GestorDeTareas
{
    /// <summary>
    /// Representa una tarea individual con su descripción, fecha y estado.
    /// </summary>
    public class Tarea
    {
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }

        /// <summary>
        /// Constructor para crear una nueva tarea.
        /// </summary>
        public Tarea(string descripcion, DateTime fechaVencimiento)
        {
            Descripcion = descripcion;
            FechaVencimiento = fechaVencimiento;
            Completada = false; // Las tareas nuevas siempre empiezan como pendientes
        }

        /// <summary>
        /// Devuelve una representación en texto de la tarea (usado para listar).
        /// </summary>
        public override string ToString()
        {
            string estado = Completada ? "✅ Completada" : "⏳ Pendiente";
            string fecha = FechaVencimiento == DateTime.MinValue
                ? "Sin fecha"
                : FechaVencimiento.ToString("dd/MM/yyyy");

            return $"{Descripcion} - {fecha} - {estado}";
        }
    }
}
