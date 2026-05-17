using Cyberplay.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Servicios
{
    public class GestorCajeros
    {
        private List<Cajero> cajeros =
            new List<Cajero>();

        public void AgregarCajero(
            Cajero cajero)
        {
            cajeros.Add(cajero);
        }

        public List<Cajero>
            ObtenerCajeros()
        {
            return cajeros;
        }

        public Cajero ValidarLogin(
            string usuario,
            string password)
        {
            return cajeros
                .FirstOrDefault(
                    c =>
                    c.Usuario == usuario
                    &&
                    c.Password == password);
        }
    }
}
