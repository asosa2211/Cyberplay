using Cyberplay.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class MovimientoSaldo
    {
        public Guid Id { get; set; }

        public string NombreCuenta { get; set; }

        public DateTime Fecha { get; set; }

        public TipoMovimientoSaldo Tipo { get; set; }

        public decimal Monto { get; set; }

        public decimal SaldoAnterior { get; set; }

        public decimal SaldoPosterior { get; set; }

        public string Observacion { get; set; }

        public string Cajero { get; set; }

        public int? NumeroCaja { get; set; }

        public Guid? TicketId { get; set; }
    }
}
