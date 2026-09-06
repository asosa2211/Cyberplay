using Cyberplay.Helpers;
using Cyberplay.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Persistencia
{
    public class PersistenciaTickets
    {
        // =====================
        // RUTA
        // =====================

        private string ruta =
            Path.Combine(
                Rutas.Data,
                "contador_tickets.json");

        // =====================
        // OBTENER SIGUIENTE
        // =====================

        public int ObtenerSiguienteTicket()
        {
            // =====================
            // ASEGURAR DATA
            // =====================

            Directory.CreateDirectory(
                Rutas.Data);

            // =====================
            // CONTADOR
            // =====================

            ContadorTickets contador;

            // =====================
            // NO EXISTE
            // =====================

            if (!File.Exists(ruta))
            {
                contador =
                    new ContadorTickets()
                    {
                        UltimoTicket = 0
                    };

                Guardar(contador);
            }

            contador =
                PersistenciaJsonAtomica
                .Cargar<ContadorTickets>(
                    ruta,
                    null);

            // =====================
            // NULL
            // =====================

            if (contador == null)
            {
                contador =
                    new ContadorTickets()
                    {
                        UltimoTicket = 0
                    };
            }

            // =====================
            // INCREMENTAR
            // =====================

            contador.UltimoTicket++;

            // =====================
            // GUARDAR
            // =====================

            Guardar(contador);

            // =====================
            // RETORNAR
            // =====================

            return
                contador
                    .UltimoTicket;
        }

        // =====================
        // GUARDAR
        // =====================

        private void Guardar(
            ContadorTickets contador)
        {
            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    contador);
        }
    }
}
