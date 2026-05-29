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
    public class PersistenciaConfiguracion
    {
        // =====================
        // RUTA
        // =====================

        private string ruta = Path.Combine(Rutas.Data, "configuracion.json");

        // =====================
        // GUARDAR
        // =====================

        public void GuardarConfiguracion(ConfiguracionSistema configuracion)
        {
            string json =
                JsonConvert.SerializeObject(configuracion, Formatting.Indented);

            File.WriteAllText(ruta, json);
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

                ConfiguracionSistema cargada =
                    JsonConvert
                    .DeserializeObject
                    <ConfiguracionSistema>(
                        json);

                NormalizarConfiguracion(
                    cargada);

                return cargada;
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

        private ConfiguracionSistema CrearConfiguracionDefault()
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

                        CiclosPorHora = 3,

                        UsaTarifasMultijugador
                            = false,
                        ColorLibre =
                              "#E3E3E3",

                        ColorPausado =
                              "#DFBFF2"
                    });

            // =====================
            // PS4
            // =====================

            configuracion.TiposEquipo.Add(new TipoEquipoConfiguracion()
                    {
                        Nombre = "PS4",

                        Cantidad = 9,

                        TarifaLibre = 0,

                        CiclosPorHora = 4,

                        UsaTarifasMultijugador
                            = true,

                        TarifaM2 = 10,

                        TarifaM3 = 12,

                        TarifaM4 = 14,

                        Color2M =
                          "#11BDED",

                         Color3M =
                             "#E9ED1F",

                             Color4M =
                          "#2DED1F",

                             ColorPausado =
                         "#DFBFF2"
            });

            // =====================
            // TOLERANCIA
            // =====================

            configuracion.ToleranciaMinutos = 2;

            return configuracion;
        }

        private void NormalizarConfiguracion(
            ConfiguracionSistema configuracion)
        {
            if (configuracion == null)
            {
                return;
            }

            foreach (TipoEquipoConfiguracion tipo
                in configuracion.TiposEquipo)
            {
                if (tipo.CiclosPorHora > 0)
                {
                    continue;
                }

                tipo.CiclosPorHora =
                    tipo.UsaTarifasMultijugador
                    ? 4
                    : 3;
            }
        }
    }
}
