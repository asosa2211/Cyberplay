using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Servicios
{
    public static class MonitorRed
    {
        public static bool EstaEncendido(
            string direccionIP)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    direccionIP))
                {
                    return false;
                }

                using (Ping ping =
                    new Ping())
                {
                    PingReply respuesta =
                        ping.Send(
                            direccionIP,
                            1000);

                    return respuesta.Status
                        == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
