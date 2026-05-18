using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cyberplay
{
    public class PersistenciaCobros
    {
        private string ruta = "cobros.json";

        public List<RegistroCobro>
    ObtenerCobros()
        {
            // =====================
            // NO EXISTE ARCHIVO
            // =====================

            if (!File.Exists(ruta))
            {
                return
                    new List<
                        RegistroCobro>();
            }

            // =====================
            // LEER JSON
            // =====================

            string json =
                File.ReadAllText(
                    ruta);

            // =====================
            // DESERIALIZAR
            // =====================

            List<RegistroCobro>
                cobros =
                    JsonConvert
                        .DeserializeObject
                        <List<RegistroCobro>>(
                            json);

            // =====================
            // NULL
            // =====================

            if (cobros == null)
            {
                return
                    new List<
                        RegistroCobro>();
            }

            return cobros;
        }
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
            if (!File.Exists(ruta))
            {
                return new List<RegistroCobro>();
            }

            string json =
                File.ReadAllText(ruta);

            List<RegistroCobro> cobros =
                JsonConvert.DeserializeObject
                    <List<RegistroCobro>>(json);

            if (cobros == null)
            {
                return new List<RegistroCobro>();
            }

            return cobros;
        }
        public void GuardarCobro(
    RegistroCobro cobro)
        {
            List<RegistroCobro> cobros =
                CargarCobros();

            cobros.Add(cobro);

            string json =
                JsonConvert.SerializeObject(
                    cobros,
                    Formatting.Indented);

            File.WriteAllText(
                ruta,
                json);
        }
    }
}
