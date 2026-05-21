using Cyberplay.Core;
using Cyberplay.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    internal class Permisos
    {
        // =====================
        // ES ADMIN
        // =====================

        public static bool EsAdmin()
        {
            return
                SesionSistema
                    .CajeroActual
                    .Rol
                == RolUsuario.Admin;
        }

        // =====================
        // ES CAJERO
        // =====================

        public static bool EsCajero()
        {
            return
                SesionSistema
                    .CajeroActual
                    .Rol
                == RolUsuario.Cajero;
        }
    }
}
