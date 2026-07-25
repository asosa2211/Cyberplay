using Cyberplay.enums;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberplay.Servicios
{
    public class GestorSaldoPromocional
    {
        private readonly PersistenciaMovimientosSaldo persistenciaMovimientos =
                        new PersistenciaMovimientosSaldo();

        private readonly GestorUsuarios gestorUsuarios;


        public GestorSaldoPromocional(
    GestorUsuarios gestorUsuarios)
        {
            this.gestorUsuarios = gestorUsuarios;
        }
        public decimal ObtenerSaldo(string nombreCuenta)
        {
            List<Usuario> usuarios =
    gestorUsuarios.ObtenerUsuarios();

            Usuario usuario =
                usuarios.FirstOrDefault(
                    u => u.NombreCuenta.Equals(
                        nombreCuenta,
                        StringComparison.OrdinalIgnoreCase));

            if (usuario == null)
            {
                return 0;
            }


            return usuario.SaldoPromocional;
        }

        public List<MovimientoSaldo> ObtenerHistorial(string nombreCuenta)
        {
            return persistenciaMovimientos
                .CargarMovimientos()
                .Where(
                    x =>
                    x.NombreCuenta.Equals(
                        nombreCuenta,
                        StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(
                    x => x.Fecha)
                .ToList();
        }

        public void AgregarSaldo(
    string nombreCuenta,
    decimal monto,
    TipoMovimientoSaldo tipo,
    string observacion,
    string cajero,
    int? numeroCaja)
        {
            if (monto <= 0)
            {
                throw new ArgumentException(
                    "El monto debe ser mayor que cero.");
            }

            List<Usuario> usuarios =
    gestorUsuarios.ObtenerUsuarios();

            Usuario usuario =
                usuarios.FirstOrDefault(
                    u => u.NombreCuenta.Equals(
                        nombreCuenta,
                        StringComparison.OrdinalIgnoreCase));

            if (usuario == null)
            {
                throw new InvalidOperationException(
                    "El usuario no existe.");
            }

            decimal saldoAnterior =
    usuario.SaldoPromocional;

            usuario.SaldoPromocional += monto;
            List<MovimientoSaldo> movimientos =
       persistenciaMovimientos
           .CargarMovimientos();

            gestorUsuarios.Guardar();

            movimientos.Add(
                new MovimientoSaldo()
                {
                    Id = Guid.NewGuid(),

                    NombreCuenta =
                        usuario.NombreCuenta,

                    Fecha =
                        DateTime.Now,

                    Tipo =
                        tipo,

                    Monto =
                        monto,

                    SaldoAnterior =
                        saldoAnterior,

                    SaldoPosterior =
                        usuario.SaldoPromocional,

                    Observacion =
                        observacion,

                    Cajero =
                        cajero,

                    NumeroCaja =
                        numeroCaja
                });

            persistenciaMovimientos
                .GuardarMovimientos(
                    movimientos);
        }

        public void CaducarSaldo(
    string nombreCuenta,
    string observacion,
    string cajero,
    int? numeroCaja)
        {
            // =====================
            // BUSCAR USUARIO
            // =====================

            List<Usuario> usuarios =
                gestorUsuarios.ObtenerUsuarios();

            Usuario usuario =
                usuarios.FirstOrDefault(
                    u =>
                    u.NombreCuenta.Equals(
                        nombreCuenta,
                        StringComparison.OrdinalIgnoreCase));

            if (usuario == null)
            {
                throw new InvalidOperationException(
                    "El usuario no existe.");
            }

            // =====================
            // VALIDAR SALDO
            // =====================

            if (usuario.SaldoPromocional <= 0)
            {
                throw new InvalidOperationException(
                    "El usuario no tiene saldo promocional.");
            }

            // =====================
            // DATOS
            // =====================

            decimal saldoAnterior =
                usuario.SaldoPromocional;

            // =====================
            // RESETEAR SALDO
            // =====================

            usuario.SaldoPromocional = 0;

            gestorUsuarios.Guardar();

            // =====================
            // REGISTRAR MOVIMIENTO
            // =====================

            List<MovimientoSaldo> movimientos =
                persistenciaMovimientos
                    .CargarMovimientos();

            movimientos.Add(
                new MovimientoSaldo()
                {
                    Id = Guid.NewGuid(),

                    NombreCuenta =
                        usuario.NombreCuenta,

                    Fecha =
                        DateTime.Now,

                    Tipo =
                        TipoMovimientoSaldo.ResetSaldo,

                    Monto =
                        saldoAnterior,

                    SaldoAnterior =
                        saldoAnterior,

                    SaldoPosterior =
                        0,

                    Observacion =
                        observacion,

                    Cajero =
                        cajero,

                    NumeroCaja =
                        numeroCaja
                });

            persistenciaMovimientos
                .GuardarMovimientos(
                    movimientos);
        }

        public bool ConsumirSaldo(
    string nombreCuenta,
    decimal monto,
    string ticketId,
    string cajero,
    int? numeroCaja)
        {
            if (monto <= 0)
            {
                throw new ArgumentException(
                    "El monto debe ser mayor que cero.");
            }

            List<Usuario> usuarios =
    gestorUsuarios.ObtenerUsuarios();

            Usuario usuario =
                usuarios.FirstOrDefault(
                    u => u.NombreCuenta.Equals(
                        nombreCuenta,
                        StringComparison.OrdinalIgnoreCase));

            if (usuario == null)
            {
                throw new InvalidOperationException(
                    "El usuario no existe.");
            }

            if (usuario.SaldoPromocional < monto)
            {
                return false;
            }

            decimal saldoAnterior =
                usuario.SaldoPromocional;

            usuario.SaldoPromocional -= monto;

            gestorUsuarios.Guardar();

            List<MovimientoSaldo> movimientos =
        persistenciaMovimientos
            .CargarMovimientos();

            movimientos.Add(
                new MovimientoSaldo()
                {
                    Id = Guid.NewGuid(),

                    NombreCuenta =
                        usuario.NombreCuenta,

                    Fecha =
                        DateTime.Now,

                    Tipo =
                        TipoMovimientoSaldo.Consumo,

                    Monto =
                        -monto,

                    SaldoAnterior =
                        saldoAnterior,

                    SaldoPosterior =
                        usuario.SaldoPromocional,

                    Observacion =
                        "Horas gratis",

                    Cajero =
                        cajero,

                    NumeroCaja =
                        numeroCaja,

                    TicketId =
                        ticketId
                });

            persistenciaMovimientos
                .GuardarMovimientos(
                    movimientos);

            return true;
        }
    }
}
