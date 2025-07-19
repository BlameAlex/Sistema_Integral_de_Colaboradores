// Scripts/AgregarEmpleado.cs
using System;
using sic.Models;    // Usa el namespace real donde está tu modelo
using sic.Data;      // Usa el namespace real donde está tu DbContext

namespace sic.Scripts
{
    public class AgregarGradoTipo
    {
        public static void Ejecutar()
        {
            using var context = new SicDbContext();

            var nuevo = new ColabGradosTipo
            {
                GradoTipoId =111, // Asigna un ID si es necesario, o deja que la base de datos lo genere
                GradoTipo = 111 // Asigna el valor que necesites
            };

            context.ColabGradosTipos.Add(nuevo);
            context.SaveChanges();

            Console.WriteLine("✅ Registro agregado correctamente desde CLI");
        }
    }
}
