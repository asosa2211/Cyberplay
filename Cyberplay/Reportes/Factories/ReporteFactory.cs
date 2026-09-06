using Cyberplay.Reportes.Atributos;
using Cyberplay.Reportes.Core;
using Cyberplay.Reportes.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cyberplay.Reportes.Factories
{
    public static class ReporteFactory
    {
        public static ReporteTabla DesdeLista<T>(
            IEnumerable<T> datos)
        {
            ReporteTabla tabla = new ReporteTabla();

            if (datos == null)
                return tabla;

            //=========================================
            // OBTENER TODAS LAS PROPIEDADES DEL MODELO
            //=========================================

            PropertyInfo[] propiedades =
    typeof(T)
        .GetProperties()
        .OrderBy(p =>
        {
            var atributo =
                p.GetCustomAttribute<ReporteColumnaAttribute>();

            return atributo?.Orden ?? int.MaxValue;
        })
        .ToArray();

            //=========================================
            // CREAR COLUMNAS
            //=========================================

            foreach (PropertyInfo propiedad in propiedades)
            {
                var atributo =
    propiedad.GetCustomAttribute<ReporteColumnaAttribute>();

                ReporteColumna columna =
                    new ReporteColumna()
                    {
                        Titulo =
                            atributo?.Titulo ?? propiedad.Name,

                        Ancho =
                            atributo?.Ancho
                            ?? ObtenerAncho(propiedad.PropertyType),

                        Visible =
                            atributo?.Visible ?? true,

                        Formato =
                            atributo?.Formato ?? "",

                        Alineacion =
                            atributo?.Alineacion
                            ?? ObtenerAlineacion(propiedad.PropertyType)
                    };

                tabla.AgregarColumna(columna);
            }

            //=========================================
            // CREAR FILAS
            //=========================================

            foreach (T item in datos)
            {
                ReporteFila fila = new ReporteFila();

                foreach (PropertyInfo propiedad in propiedades)
                {
                    object valor = propiedad.GetValue(item);

                    var atributo = propiedad.GetCustomAttribute<ReporteColumnaAttribute>();

                    fila.Agregar(ReporteFormatter.Formatear(valor, atributo));
                }

                tabla.AgregarFila(fila);
            }

            return tabla;
        }

        //---------------------------------------------------
        // Métodos auxiliares
        //---------------------------------------------------

        private static int ObtenerAncho(
            Type tipo)
        {
            if (tipo == typeof(string))
                return 3;

            return 2;
        }

        private static AlineacionColumna ObtenerAlineacion(
            Type tipo)
        {
            if (tipo == typeof(decimal) ||
                tipo == typeof(double) ||
                tipo == typeof(float) ||
                tipo == typeof(int) ||
                tipo == typeof(long) ||
                tipo == typeof(short))
            {
                return AlineacionColumna.Derecha;
            }

            if (tipo == typeof(DateTime))
            {
                return AlineacionColumna.Centro;
            }

            return AlineacionColumna.Izquierda;
        }

    }
}