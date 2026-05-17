using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    public class PersistenciaCobros
    {
        private string ruta = "cobros.txt";

        public decimal ObtenerTotalCobrado()
        {
            decimal total = 0;

            // =====================
            // CARGAR COBROS
            // =====================

            List<RegistroCobro> cobros =
                CargarCobros();

            // =====================
            // SUMAR
            // =====================

            foreach (RegistroCobro cobro
                in cobros)
            {
                total +=
                    cobro.TotalCobrado;
            }

            return total;
        }

        public List<RegistroCobro>
    CargarCobros()
        {
            List<RegistroCobro> cobros =
                new List<RegistroCobro>();

            // =====================
            // VALIDAR ARCHIVO
            // =====================

            if (!File.Exists(ruta))
            {
                return cobros;
            }

            // =====================
            // LEER LINEAS
            // =====================

            string[] lineas =
                File.ReadAllLines(ruta);

            // =====================
            // RECORRER
            // =====================

            foreach (string linea
                in lineas)
            {
                string[] datos =
                    linea.Split('|');

                RegistroCobro cobro =
                    new RegistroCobro(
                        datos[0],

                        DateTime.Parse(
                            datos[1]),

                        new TimeSpan(
                            long.Parse(
                                datos[2])),

                        decimal.Parse(
                            datos[3]),

                        (TipoTarifa)
                        Enum.Parse(
                            typeof(
                                TipoTarifa),
                            datos[4]));

                cobros.Add(
                    cobro);
            }

            return cobros;
        }
        public void GuardarCobro(
    RegistroCobro cobro)
        {
            using (StreamWriter writer =
                new StreamWriter(
                    ruta,
                    true))
            {
                string linea =
                    cobro.NombreCuenta
                    + "|"
                    + cobro.Fecha
                        .ToString("dd-MM-yyyy HH:mm:ss")
                    + "|"
                    + cobro.TiempoJugado
                        .Ticks
                    + "|"
                    + cobro.TotalCobrado
                    + "|"
                    + cobro.TarifaFinal;

                writer.WriteLine(
                    linea);
            }
        }
    }
}
