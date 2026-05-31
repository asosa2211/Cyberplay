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
            NormalizarConfiguracion(
                configuracion);

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

                if (cargada == null)
                {
                    cargada =
                        CrearConfiguracionDefault();
                }

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

            configuracion.InicioEstaciones = 1;

            CrearEstacionesDesdeTipos(
                configuracion);

            return configuracion;
        }

        private void NormalizarConfiguracion(
            ConfiguracionSistema configuracion)
        {
            if (configuracion == null)
            {
                return;
            }

            if (configuracion.InicioEstaciones <= 0)
            {
                configuracion.InicioEstaciones =
                    configuracion.Estaciones != null
                    && configuracion.Estaciones.Any(
                        e =>
                        e != null
                        && e.Activa
                        && e.NumeroEquipo > 0)
                    ? configuracion
                        .Estaciones
                        .Where(
                            e =>
                            e != null
                            && e.Activa
                            && e.NumeroEquipo > 0)
                        .Min(
                            e =>
                            e.NumeroEquipo)
                    : 1;
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

            if (configuracion.Estaciones == null)
            {
                configuracion.Estaciones =
                    new List<EstacionConfiguracion>();
            }

            if (configuracion.Estaciones.Count == 0)
            {
                CrearEstacionesDesdeTipos(
                    configuracion);
            }

            configuracion.Estaciones =
                configuracion.Estaciones
                .Where(
                    e =>
                    e != null
                    && e.NumeroEquipo > 0
                    && !string.IsNullOrWhiteSpace(
                        e.TipoEquipo))
                .GroupBy(
                    e =>
                    e.NumeroEquipo)
                .Select(
                    g =>
                    g.First())
                .OrderBy(
                    e =>
                    e.NumeroEquipo)
                .ToList();

            foreach (EstacionConfiguracion estacion
                in configuracion.Estaciones)
            {
                if (!configuracion.TiposEquipo.Any(
                    t =>
                    t.Nombre == estacion.TipoEquipo))
                {
                    estacion.Activa =
                    false;
                }
            }

            foreach (TipoEquipoConfiguracion tipo
                in configuracion.TiposEquipo)
            {
                tipo.Cantidad =
                    configuracion
                    .Estaciones
                    .Count(
                        e =>
                        e.Activa
                        && e.TipoEquipo == tipo.Nombre);

                AplicarColoresPorDefecto(
                    tipo);
            }

            configuracion.Categorias =
                configuracion.Categorias
                .OrderBy(
                    c =>
                    c)
                .ToList();
        }

        private void AplicarColoresPorDefecto(
            TipoEquipoConfiguracion tipo)
        {
            if (tipo == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(tipo.ColorLibre))
            {
                tipo.ColorLibre = "#E3E3E3";
            }

            if (string.IsNullOrWhiteSpace(tipo.Color2M))
            {
                tipo.Color2M = "#11BDED";
            }

            if (string.IsNullOrWhiteSpace(tipo.Color3M))
            {
                tipo.Color3M = "#E9ED1F";
            }

            if (string.IsNullOrWhiteSpace(tipo.Color4M))
            {
                tipo.Color4M = "#2DED1F";
            }

            if (string.IsNullOrWhiteSpace(tipo.ColorPausado))
            {
                tipo.ColorPausado = "#DFBFF2";
            }
        }

        private void CrearEstacionesDesdeTipos(
            ConfiguracionSistema configuracion)
        {
            if (configuracion == null
                || configuracion.TiposEquipo == null)
            {
                return;
            }

            configuracion.Estaciones =
                new List<EstacionConfiguracion>();

            int numeroEquipo =
                configuracion.InicioEstaciones > 0
                ? configuracion.InicioEstaciones
                : 1;

            foreach (TipoEquipoConfiguracion tipo
                in configuracion.TiposEquipo)
            {
                for (int i = 1;
                    i <= tipo.Cantidad;
                    i++)
                {
                    configuracion.Estaciones.Add(
                        new EstacionConfiguracion()
                        {
                            NumeroEquipo =
                                numeroEquipo,

                            TipoEquipo =
                                tipo.Nombre,

                            Activa =
                                true
                        });

                    numeroEquipo++;
                }
            }
        }
    }
}
