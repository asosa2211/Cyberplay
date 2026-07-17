using System.Collections.Generic;
using System.Linq;

namespace Cyberplay.Servicios
{
    public class GestorHistorialClientes
    {
        private readonly PersistenciaCobros persistenciaCobros;

        public GestorHistorialClientes()
        {
            persistenciaCobros = new PersistenciaCobros();
        }

        public List<RegistroCobro> ObtenerHistorial(string nombreCuenta)
        {
            List<RegistroCobro> cobros =
                persistenciaCobros.CargarCobros();

            return cobros
                .Where(c => c.NombreCuenta == nombreCuenta)
                .OrderByDescending(c => c.Fecha)
                .ToList();
        }
    }
}
