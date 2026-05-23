using Cyberplay.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Persistencia
{
    public class PersistenciaConfiguracion
    {
        // =====================
        // RUTA
        // =====================

        private string ruta =
            "configuracion.json";

        // =====================
        // GUARDAR
        // =====================

        public void GuardarConfiguracion(
            ConfiguracionSistema
                configuracion)
        {
            string json =
                JsonConvert
                .SerializeObject(
                    configuracion,
                    Formatting.Indented);

            File.WriteAllText(
                ruta,
                json);
        }

        // =====================
        // CARGAR
        // =====================

        public ConfiguracionSistema
            CargarConfiguracion()
        {
            // =====================
            // EXISTE
            // =====================

            if (File.Exists(ruta))
            {
                string json =
                    File.ReadAllText(
                        ruta);

                return JsonConvert
                    .DeserializeObject
                    <ConfiguracionSistema>(
                        json);
            }

            // =====================
            // CREAR DEFAULT
            // =====================

            ConfiguracionSistema
                configuracion =
                    CrearConfiguracionDefault();

            // =====================
            // GUARDAR
            // =====================

            GuardarConfiguracion(
                configuracion);

            return configuracion;
        }

        // =====================
        // DEFAULT
        // =====================

        private ConfiguracionSistema
            CrearConfiguracionDefault()
        {
            ConfiguracionSistema
                configuracion =
                    new ConfiguracionSistema();

            // =====================
            // CATEGORIAS
            // =====================

            configuracion
                .Categorias
                .Add("Bebidas");

            configuracion
                .Categorias
                .Add("Snacks");

            configuracion
                .Categorias
                .Add("Dulces");

            // =====================
            // TARIFAS
            // =====================

            configuracion
                .TarifaM2 = 10;

            configuracion
                .TarifaM3 = 12;

            configuracion
                .TarifaM4 = 14;

            // =====================
            // EQUIPOS
            // =====================

            configuracion
                .CantidadPC = 4;

            configuracion
                .CantidadPS4 = 9;

            // =====================
            // TOLERANCIA
            // =====================

            configuracion
                .ToleranciaMinutos = 5;

            return configuracion;
        }
    }
}
