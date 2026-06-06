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

                using (Ping ping = new Ping())
                {
                    for (int i = 0; i < 2; i++)
                    {
                        PingReply respuesta =
                            ping.Send(
                                direccionIP,
                                500);

                        if (respuesta.Status
                            == IPStatus.Success)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
