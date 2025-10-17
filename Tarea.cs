using System;

namespace GestorDeTareas
{
    /// <summary>
    /// Representa una tarea simple con descripción, fecha de vencimiento y estado.
    /// FechaVencimiento usa DateTime; DateTime.MinValue indica "sin fecha".
    /// </summary>
    public class Tarea
    {
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; } // DateTime.MinValue => sin fecha
        public bool Completada { get; set; }

        public Tarea(string descripcion, DateTime fechaVencimiento)
        {
            Descripcion = descripcion ?? string.Empty;
            FechaVencimiento = fechaVencimiento;
            Completada = false;
        }

        public override string ToString()
        {
            var fecha = FechaVencimiento == DateTime.MinValue ? "Sin fecha" : FechaVencimiento.ToString("dd/MM/yyyy");
            var estado = Completada ? "Completada" : "Pendiente";
            return $"{(Completada ? "[X]" : "[ ]")} {Descripcion} - {fecha} - {estado}";
        }
    }
}