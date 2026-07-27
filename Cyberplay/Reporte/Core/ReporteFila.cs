using System.Collections.Generic;

namespace Cyberplay.Reportes.Core
{
    public class ReporteFila
    {
        public List<string> Celdas { get; set; }

        public ReporteFila()
        {
            Celdas = new List<string>();
        }

        public void Agregar(params string[] valores)
        {
            Celdas.AddRange(valores);
        }
    }
}