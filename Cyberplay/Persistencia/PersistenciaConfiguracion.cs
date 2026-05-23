using Cyberplay.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            // PC
            // =====================

            configuracion
                .TiposEquipo
                .Add(
                    new TipoEquipoConfiguracion()
                    {
                        Nombre = "PC",

                        Cantidad = 4,

                        TarifaLibre = 3,

                        UsaTarifasMultijugador
                            = false
                    });

            // =====================
            // PS4
            // =====================

            configuracion
                .TiposEquipo
                .Add(
                    new TipoEquipoConfiguracion()
                    {
                        Nombre = "PS4",

                        Cantidad = 9,

                        TarifaLibre = 0,

                        UsaTarifasMultijugador
                            = true,

                        TarifaM2 = 10,

                        TarifaM3 = 12,

                        TarifaM4 = 14
                    });

            // =====================
            // TOLERANCIA
            // =====================

            configuracion
                .ToleranciaMinutos = 5;

            return configuracion;
        }
    }
}
