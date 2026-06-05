using Cyberplay.Core;
using Cyberplay.enums;
using Cyberplay.Formularios;
using Cyberplay.Helpers;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using Cyberplay.Servicios;
using Cyberplay.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberplay
{
    public partial class frmPrincipal : Form
    {
        private PersistenciaUsuarios persistenciaUsuarios = new PersistenciaUsuarios();
        private PersistenciaCobros persistenciaCobros = new PersistenciaCobros();
        private GestorUsuarios gestorUsuarios = new GestorUsuarios();
        //private List<ucPS4> consolas = new List<ucPS4>();
        public static List<ucPS4> Consolas = new List<ucPS4>();
        private PersistenciaSesiones persistenciaSesiones = new PersistenciaSesiones();
        private PersistenciaCaja persistenciaCaja = new PersistenciaCaja();
        private PersistenciaHistorialCajas persistenciaHistorialCajas =
                                            new PersistenciaHistorialCajas();

        private Process procesoAPI;
        GestorBackups gestor =  new GestorBackups();


        public frmPrincipal()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || DesignMode)
            {
                return;
            }
            tmrMonitorEquipos.Interval =
    SesionSistema
        .Configuracion
        .MinutosMonitoreoEquipos
        * 60
        * 1000;
            tmrMonitorEquipos.Start();
            tmrAutoSave.Start();
            lvProximasSalidas.Columns.Add("Nro", 50);
            lvProximasSalidas.Columns.Add("Tipo", 50);
            lvProximasSalidas.Columns.Add("Tiempo restante", 120);
            lvProximasSalidas.Location = new Point(1100, 70);

            this.AutoScroll = true;
            SesionSistema.CajaActual = persistenciaCaja.CargarCaja();
            if (SesionSistema.CajaActual
    != null
    &&
    SesionSistema
        .CajaActual
        .NumeroCaja == 0)
            {
                SesionSistema
                    .CajaActual
                    .NumeroCaja =
                        persistenciaHistorialCajas
                            .ObtenerSiguienteNumeroCaja();

                persistenciaCaja
                    .GuardarCaja(
                        SesionSistema
                            .CajaActual);
            }
            if (SesionSistema
    .CajaActual
    == null)
            {
                SesionSistema.CajaActual =
    new Caja()
    {
        NumeroCaja =
            persistenciaHistorialCajas
                .ObtenerSiguienteNumeroCaja(),

        Nombre =
            "Caja Principal",

        Cajero =
            SesionSistema
                .CajeroActual
                .Usuario,

        FechaApertura =
            DateTime.Now,

        TotalCobrado =
            0,

        Abierta =
            true
    };
            }
            CrearConsolas();
            CargarUsuarios();
            RestaurarSesiones();
            GuardarSesiones();
            ReconciliarCajaActual();
            ActualizarCaja();
            ActualizarInfoCaja();
            AplicarPermisos();

            // SesionSistema.CajeroActual = new Cajero("admin", "Administrador",
            //         "123", RolUsuario.Admin);


        }

        private async Task
    ActualizarVisitas()
        {
            try
            {
                // =====================
                // CLIENTE
                // =====================

                HttpClient client =
                    new HttpClient();

                // =====================
                // URL
                // =====================

                string url =
                    "http://localhost:5000/visitas/cantidad";

                // =====================
                // OBTENER
                // =====================

                string respuesta =
                    await client
                        .GetStringAsync(
                            url);

                // =====================
                // PARSEAR
                // =====================

                int cantidad =
                    int.Parse(
                        respuesta);

                // =====================
                // LABEL
                // =====================

                lblVisitas.Text =   "Viendo ahora: " + cantidad;

                lblVisitas.ForeColor =
                    Color.DeepSkyBlue;
            }
            catch
            {
                lblVisitas.Text =
                    "Visitas offline";

                lblVisitas.ForeColor =
                    Color.Red;
            }
        }

       

        private void
    IniciarAPI()
        {
            try
            {
                // =====================
                // RUTA API
                // =====================

                string rutaAPI =
                    Path.Combine(
                        AppDomain
                            .CurrentDomain
                            .BaseDirectory,

                        Path.Combine(Rutas.API, "CyberplayAPI.exe"));

                rutaAPI =
                    Path.GetFullPath(
                        rutaAPI);

                // =====================
                // VALIDAR
                // =====================

                if (!File.Exists(
                    rutaAPI))
                {
                    MessageBox.Show(
                        "No se encontró CyberplayAPI.exe");

                    return;
                }

                // =====================
                // VALIDAR ABIERTA
                // =====================

                Process[] procesos =
                    Process.GetProcessesByName(
                        "CyberplayAPI");

                if (procesos.Length > 0)
                {
                    return;
                }

                // =====================
                // INFO
                // =====================

                ProcessStartInfo info =
                    new ProcessStartInfo();

                info.FileName =
                    rutaAPI;

                info.WorkingDirectory =
                    Path.GetDirectoryName(
                        rutaAPI);

                info.CreateNoWindow =
                    true;

                info.WindowStyle =
                    ProcessWindowStyle.Hidden;

                info.UseShellExecute =
                    false;

                // =====================
                // INICIAR
                // =====================

                procesoAPI =
                    Process.Start(
                        info);
            }
            catch
            {

            }
        }

        private void
    GenerarEstadoWeb()
        {
            try
            {
                // =====================
                // LISTA
                // =====================

                List<EstadoEquipoWeb>
                    equipos =
                        new List<EstadoEquipoWeb>();

                // =====================
                // RECORRER
                // =====================

                foreach (ucPS4 consola
                    in Consolas)
                {
                    // =====================
                    // VALIDAR
                    // =====================

                    if (consola == null)
                    {
                        continue;
                    }

                    if (consola.Estacion == null)
                    {
                        continue;
                    }

                    // =====================
                    // IGNORAR PCS
                    // =====================

                    if (consola.Estacion
                        .TipoEquipo
                        .ToUpper()
                        == "PC")
                    {
                        continue;
                    }

                    // =====================
                    // DATOS
                    // =====================

                    bool activo =
                        false;

                    string tiempoRestante =
                        "Disponible";

                    // =====================
                    // SESION
                    // =====================

                    if (consola.Sesion != null)
                    {
                        activo = true;

                        TimeSpan restante =
                            consola.Sesion
                                .TiempoRestante;

                        // =====================
                        // ILIMITADO
                        // =====================

                        if (restante
                            == TimeSpan.Zero)
                        {
                            tiempoRestante =
                                "Ilimitado";

                        }
                        else
                        {
                            // =====================
                            // FINALIZANDO
                            // =====================

                            if (restante
                                < TimeSpan.Zero)
                            {
                                tiempoRestante =
                                    "Finalizando";
                            }
                            else
                            {
                                tiempoRestante =
                                    restante
                                    .ToString(
                                        @"hh\:mm\:ss");
                            }

                        }
                    }

                    // =====================
                    // NUMERO
                    // =====================

                    int numero =
                        consola
                            .Estacion
                            .NumeroEquipo;

                    // =====================
                    // AGREGAR
                    // =====================

                    equipos.Add(
                        new EstadoEquipoWeb()
                        {
                            Numero =
                                numero,

                            Tipo =
                                consola.Estacion
                                    .TipoEquipo,

                            TiempoRestante =
                                tiempoRestante,

                            Activo =
                                activo
                        });
                }

                // =====================
                // ORDENAR
                // =====================

                equipos =
                    equipos

                    // DISPONIBLES ARRIBA
                    .OrderBy(
                        x =>
                        x.TiempoRestante
                        != "Disponible")

                    // ILIMITADOS ABAJO
                    .ThenBy(
                        x =>
                        x.TiempoRestante
                        == "Ilimitado")

                    // ORDEN TIEMPOS
                    .ThenBy(
                        x =>
                        x.TiempoRestante)

                    .ToList();

                // =====================
                // JSON
                // =====================

                string json =
                    JsonConvert
                        .SerializeObject(
                            equipos,
                            Formatting.Indented);

                // =====================
                // RUTA
                // =====================

                string rutaWeb =
                    Path.Combine(
                        AppDomain
                            .CurrentDomain
                            .BaseDirectory,

                        Path.Combine(Rutas.Data, "estado_web.json"));

                rutaWeb =
                    Path.GetFullPath(
                        rutaWeb);

                // =====================
                // CARPETA
                // =====================

                string carpeta =
                    Path.GetDirectoryName(
                        rutaWeb);

                if (!Directory.Exists(
                    carpeta))
                {
                    Directory.CreateDirectory(
                        carpeta);
                }

                // =====================
                // GUARDAR
                // =====================

                using (FileStream stream =
                    new FileStream(
                        rutaWeb,
                        FileMode.Create,
                        FileAccess.Write,
                        FileShare.ReadWrite))
                {
                    using (StreamWriter writer =
                        new StreamWriter(
                            stream))
                    {
                        writer.Write(
                            json);
                    }
                }
            }
            catch
            {

            }
        }

        // APLICAR PERMISOS
        private void AplicarPermisos()
        {
            tsmiCerrarSesion.Text =
                SesionSistema.CajeroSuspendido == null
                ? "Cerrar sesión"
                : "Cerrar sesión admin";
        }


        private bool CajaTieneMovimientos()
        {
            int numeroCaja =
                SesionSistema
                    .CajaActual
                    .NumeroCaja;

            // =====================
            // COBROS
            // =====================

            PersistenciaCobros
                persistenciaCobros =
                    new PersistenciaCobros();

            bool tieneCobros =
                persistenciaCobros
                    .CargarCobros()
                    .Any(
                        x =>
                        x.NumeroCaja
                        == numeroCaja);

            if (tieneCobros)
            {
                return true;
            }

            // =====================
            // INGRESOS
            // =====================

            PersistenciaIngresosCaja
                persistenciaIngresos =
                    new PersistenciaIngresosCaja();

            bool tieneIngresos =
                persistenciaIngresos
                    .CargarIngresos()
                    .Any(
                        x =>
                        x.NumeroCaja
                        == numeroCaja);

            if (tieneIngresos)
            {
                return true;
            }

            // =====================
            // EGRESOS
            // =====================

            PersistenciaEgresosCaja
                persistenciaEgresos =
                    new PersistenciaEgresosCaja();

            bool tieneEgresos =
                persistenciaEgresos
                    .CargarEgresos()
                    .Any(
                        x =>
                        x.NumeroCaja
                        == numeroCaja);

            if (tieneEgresos)
            {
                return true;
            }

            // =====================
            // VENTAS PRODUCTOS
            // =====================

            PersistenciaVentasProductos
                persistenciaVentas =
                    new PersistenciaVentasProductos();

            bool tieneVentas =
                persistenciaVentas
                    .CargarVentas()
                    .Any(
                        x =>
                        x.NumeroCaja
                        == numeroCaja);

            return tieneVentas;
        }
        private void MostrarAccesoDenegado()
        {
            MessageBox.Show(
                "Acceso denegado",
                "Permisos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private bool RequiereAdmin()
        {
            if (Permisos.EsAdmin())
            {
                return true;
            }

            MostrarAccesoDenegado();

            return false;
        }
        //ACTUALIZAR ULTIMOS COBROS


        private void ActualizarProximasSalidas()
        {
            // =====================
            // LIMPIAR
            // =====================

            lvProximasSalidas.Items.Clear();

            // =====================
            // LISTA TEMPORAL
            // =====================

            List<
            (
                string numero,
                string tipo,
                TimeSpan? restante
            )>
            lista =
                new List<
                (
                    string,
                    string,
                    TimeSpan?
                )>();

            // =====================
            // RECORRER CONSOLAS
            // =====================

            foreach (ucPS4 consola
                in Consolas)
            {
                // =====================
                // OMITIR PCs
                // =====================

                if (consola.Estacion.Tipo
                    == TipoEstacion.PC)
                {
                    continue;
                }

                // =====================
                // SIN SESION
                // =====================

                if (!consola.SesionActiva)
                {
                    continue;
                }

                // =====================
                // OBTENER RESTANTE
                // =====================

                TimeSpan? restante =
                    consola.ObtenerTiempoRestante();

                // =====================
                // OBTENER PARTES
                // =====================

                string tipo =
                    consola
                        .Estacion
                        .TipoEquipo;

                string numero =
                    consola
                        .Estacion
                        .NumeroEquipo
                        .ToString();

                // =====================
                // AGREGAR
                // =====================

                lista.Add(
                    (
                        numero,
                        tipo,
                        restante
                    ));
            }

            // =====================
            // ORDENAR
            // =====================

            lista =
                lista
                .OrderBy(
                    x =>
                    x.restante == null)
                .ThenBy(
                    x =>
                    x.restante)
                .ToList();

            // =====================
            // AGREGAR LISTVIEW
            // =====================

            foreach (var item
                in lista)
            {
                string textoTiempo;

                // =====================
                // ILIMITADO
                // =====================

                if (item.restante
                    == null)
                {
                    textoTiempo =
                        "ILIMITADO";
                }

                // =====================
                // LIMITADO
                // =====================

                else
                {
                    textoTiempo =
                        item.restante.Value
                        .ToString(
                            @"hh\:mm\:ss");
                }

                // =====================
                // CREAR ITEM
                // =====================

                ListViewItem lv =
                    new ListViewItem(
                        item.numero);

                lv.SubItems.Add(
                    item.tipo);

                lv.SubItems.Add(
                    textoTiempo);

                // =====================
                // AGREGAR
                // =====================

                lvProximasSalidas
                    .Items
                    .Add(lv);
            }
        }


        private void ActualizarInfoCaja()
        {
            lblCajero.Text =
                "Cajero: "
                +
                SesionSistema
                    .CajeroActual
                    .Usuario;

            lblNumeroCaja.Text =
                "Caja N°: "
                +
                SesionSistema
                    .CajaActual
                    .NumeroCaja;
        }


        private void GuardarSesiones()
        {
            List<EstadoSesion>
                estados =
                    new List<EstadoSesion>();

            foreach (ucPS4 consola
                in Consolas)
            {
                if (consola.SesionActiva)
                {
                    estados.Add(
                        consola.ObtenerEstado());
                }
            }

            persistenciaSesiones
                .Guardar(estados);
        }

        private TipoEstacion
    ConvertirTipoEstacion(
        string nombre)
        {
            switch (nombre)
            {
                case "PC":

                    return TipoEstacion.PC;

                case "PS4":

                    return TipoEstacion.PS4;

                case "PS5":

                    return TipoEstacion.PS5;
            }

            return TipoEstacion.PC;
        }
        private void CrearConsolas()
        {
            // =====================
            // POSICION
            // =====================

            int x = 20;

            int y = 70;

            // =====================
            // RECORRER TIPOS
            // =====================

            foreach (
                EstacionConfiguracion estacionConfig
                in SesionSistema
                    .Configuracion
                    .Estaciones
                    .Where(
                        e =>
                        e.Activa)
                    .OrderBy(
                        e =>
                        e.NumeroEquipo))
            {
                TipoEquipoConfiguracion tipo =
                    SesionSistema
                    .Configuracion
                    .TiposEquipo
                    .FirstOrDefault(
                        t =>
                        t.Nombre
                        == estacionConfig.TipoEquipo);

                if (tipo == null)
                {
                    continue;
                }

                // =====================
                // ESTACION
                // =====================

                Estacion est =
                    new Estacion();

                est.IdEstacion =
                    estacionConfig.IdEstacion;

                est.NumeroEquipo =
                    estacionConfig.NumeroEquipo;

                // =====================
                // MULTIJUGADOR
                // =====================

                est.SoportaMultijugador =
                    tipo
                    .UsaTarifasMultijugador;

                // =====================
                // NOMBRE
                // =====================
                est.Nombre =
                    estacionConfig
                        .NumeroEquipo
                        .ToString();
                

                // =====================
                // TIPO
                // =====================

                est.Tipo =
                    ConvertirTipoEstacion(
                        tipo.Nombre);

                est.TipoEquipo =
                     tipo.Nombre;

               

                // =====================
                // TARIFA LIBRE
                // =====================

                est.TarifaCiclo =
                    tipo.TarifaLibre;

                est.MinutosCiclo =
                    tipo.CiclosPorHora > 0
                    ? 60 / tipo.CiclosPorHora
                    : 20;

                est.CiclosPorHora =
                    tipo.CiclosPorHora > 0
                    ? tipo.CiclosPorHora
                    : 3;

                // =====================
                // TOLERANCIA
                // =====================

                est.ToleranciaMinutos =
                    SesionSistema
                        .Configuracion
                        .ToleranciaMinutos;

                // =====================
                // TARIFAS MULTIJUGADOR
                // =====================

                est.Tarifa2M =
                    tipo.TarifaM2;

                est.Tarifa3M =
                    tipo.TarifaM3;

                est.Tarifa4M =
                    tipo.TarifaM4;

                // =====================
                // CREAR CONTROL
                // =====================

                ucPS4 consola =
                    new ucPS4(
                        gestorUsuarios,
                        est);

                // =====================
                // EVENTOS
                // =====================

                consola.CobroRealizado +=
                    ActualizarCaja;

                consola.EstadoSesionCambiado +=
                    GuardarSesiones;

                // =====================
                // POSICION
                // =====================

                consola.Location =
                    new Point(x, y);

                // =====================
                // AGREGAR
                // =====================

                Controls.Add(consola);

                Consolas.Add(consola);

                // =====================
                // SIGUIENTE POSICION
                // =====================

                x += consola.Width + 15;

                // =====================
                // SALTO FILA
                // =====================

                if (Consolas.Count % 5 == 0)
                {
                    x = 20;

                    y += consola.Height + 5;
                }
            }
        }
        private void GuardarUsuarios()
        {
            persistenciaUsuarios
                .GuardarUsuarios(
                    gestorUsuarios
                        .ObtenerUsuarios());
        }
        private void CargarUsuarios()
        {
            List<Usuario> usuarios =
                persistenciaUsuarios
                    .CargarUsuarios();

            foreach (Usuario usuario
                in usuarios)
            {
                gestorUsuarios
                    .AgregarUsuario(
                        usuario);
            }
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {

            // cajerosToolStripMenuItem.Visible = Permisos.EsAdmin();
            IniciarAPI();
            ActualizarEstadoAPI();
            tmrVisitas.Start();
            gestor.CrearBackup();
            tmrBackup.Start();
        }

        public void ActualizarCaja()
        {
            decimal total =
    SesionSistema
        .CajaActual
        .TotalCobrado;

            lblCaja.Text = "Recaudación: " +
                total.ToString("0.00")
                + " Bs";
            
        }

        private void ReconciliarCajaActual()
        {
            if (SesionSistema.CajaActual == null)
            {
                return;
            }

            decimal totalCalculado =
                CalcularTotalCajaActual();

            if (SesionSistema
                .CajaActual
                .TotalCobrado == totalCalculado)
            {
                return;
            }

            SesionSistema
                .CajaActual
                .TotalCobrado =
                    totalCalculado;

            persistenciaCaja
                .GuardarCaja(
                    SesionSistema
                        .CajaActual);
        }

        private decimal CalcularTotalCajaActual()
        {
            int numeroCaja =
                SesionSistema
                    .CajaActual
                    .NumeroCaja;

            List<RegistroCobro> cobros =
                persistenciaCobros
                    .CargarCobros()
                    .Where(
                        x =>
                        x.NumeroCaja
                        == numeroCaja)
                    .ToList();

            HashSet<Guid> idsVentasCobradasEnSesion =
                ObtenerIdsVentasCobradasEnSesion(
                    cobros);

            HashSet<Guid> idsVentasEnSesionesActivas =
                ObtenerIdsVentasEnSesionesActivas();

            PersistenciaVentasProductos persistenciaVentas =
                new PersistenciaVentasProductos();

            decimal totalVentas =
                persistenciaVentas
                    .CargarVentas()
                    .Where(
                        x =>
                        x.NumeroCaja
                        == numeroCaja
                        && !idsVentasEnSesionesActivas
                            .Contains(
                                x.Id)
                        && (!x.CobradaEnSesion
                            || idsVentasCobradasEnSesion
                                .Contains(
                                    x.Id)))
                    .Sum(
                        x =>
                        x.Total);

            PersistenciaIngresosCaja persistenciaIngresos =
                new PersistenciaIngresosCaja();

            decimal totalIngresosManuales =
                persistenciaIngresos
                    .CargarIngresos()
                    .Where(
                        x =>
                        x.NumeroCaja
                        == numeroCaja
                        && !EsIngresoAutomaticoContabilizado(
                            x))
                    .Sum(
                        x =>
                        x.Monto);

            PersistenciaEgresosCaja persistenciaEgresos =
                new PersistenciaEgresosCaja();

            decimal totalEgresos =
                persistenciaEgresos
                    .CargarEgresos()
                    .Where(
                        x =>
                        x.NumeroCaja
                        == numeroCaja)
                    .Sum(
                        x =>
                        x.Monto);

            return cobros
                .Sum(
                    x =>
                    ObtenerTotalTiempoCobro(
                        x))
                + totalVentas
                + totalIngresosManuales
                - totalEgresos;
        }

        private HashSet<Guid> ObtenerIdsVentasCobradasEnSesion(
            List<RegistroCobro> cobros)
        {
            HashSet<Guid> ids =
                new HashSet<Guid>();

            foreach (RegistroCobro cobro
                in cobros)
            {
                if (cobro.ProductosConsumidos == null)
                {
                    continue;
                }

                foreach (VentaProducto venta
                    in cobro.ProductosConsumidos)
                {
                    ids.Add(
                        venta.Id);
                }
            }

            return ids;
        }

        private HashSet<Guid> ObtenerIdsVentasEnSesionesActivas()
        {
            HashSet<Guid> ids =
                new HashSet<Guid>();

            foreach (ucPS4 consola
                in Consolas)
            {
                if (consola.Sesion == null
                    || consola
                        .Sesion
                        .ProductosConsumidos == null)
                {
                    continue;
                }

                foreach (VentaProducto venta
                    in consola
                        .Sesion
                        .ProductosConsumidos)
                {
                    ids.Add(
                        venta.Id);
                }
            }

            return ids;
        }

        private decimal ObtenerTotalTiempoCobro(
            RegistroCobro cobro)
        {
            if (cobro == null)
            {
                return 0;
            }

            if (cobro.TotalTiempoJugado > 0)
            {
                return cobro.TotalTiempoJugado;
            }

            decimal totalProductos =
                cobro
                    .ProductosConsumidos?
                    .Sum(
                        x =>
                        x.Total)
                ?? 0;

            decimal totalTiempo =
                cobro.TotalCobrado
                - totalProductos;

            return totalTiempo < 0
                ? 0
                : totalTiempo;
        }

        private bool EsIngresoAutomaticoContabilizado(
            IngresoCaja ingreso)
        {
            if (ingreso == null
                || string.IsNullOrWhiteSpace(
                    ingreso.Concepto))
            {
                return false;
            }

            string concepto =
                ingreso
                    .Concepto
                    .Trim();

            return concepto.Equals(
                    "Venta productos",
                    StringComparison.OrdinalIgnoreCase)
                || concepto.StartsWith(
                    "Cobro sesión:",
                    StringComparison.OrdinalIgnoreCase);
        }
        

        private void lblps5Tiempo_MouseUp(object sender, MouseEventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            frmHistorialCobros frm =
        new frmHistorialCobros();

            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  frmUsuarios frm = new frmUsuarios(gestorUsuarios);
            // frm.ShowDialog();
            List<RegistroCobro> cobros =
        persistenciaCobros
            .CargarCobros();

            MessageBox.Show(
                cobros.Count
                .ToString());
        }

        /* private void rbps52M_CheckedChanged(object sender, EventArgs e)
         {
             if (rb2M.Checked && sesion != null) 
                 sesion.CambiarTarifa(TipoTarifa.M2);
         }

         private void rbps53M_CheckedChanged(object sender, EventArgs e)
         {
             if (rb3M.Checked && sesion != null)
                 sesion.CambiarTarifa(TipoTarifa.M3);
         }

         private void rbps54M_CheckedChanged(object sender, EventArgs e)
         {
             if (rb4M.Checked && sesion != null)
                 sesion.CambiarTarifa(TipoTarifa.M4);  
         }*/

        /*private void lblUsuario_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR SESION
            // =====================

            if (sesion == null)
            {
                return;
            }

            // =====================
            // ABRIR FORM
            // =====================

            frmUsuarios frm =
                new frmUsuarios(
                    gestorUsuarios);

            // =====================
            // RESULTADO
            // =====================

            if (frm.ShowDialog()
                == DialogResult.OK)
            {
                sesion.CambiarUsuario(
                    frm.UsuarioSeleccionado);

                lblUsuario.Text =
                    sesion.UsuarioActual
                        .NombreCuenta;
            }
        }*/

        /* private void ReiniciarUI()
         {
             // =====================
             // LABELS
             // =====================

             lblCronometro.Text =
                 "00:00:00";

             lblTiempoLimite.Text =
                 "ILIMITADO";

             lblTotal.Text =
                 "0.00";

             lblUsuario.Text =
                 "invitado";


             // =====================
             // BOTON
             // =====================

             bntIniciar.Text =
                 "Iniciar";

             // =====================
             // RADIOBUTTONS
             // =====================

             rbLibre.Checked =
                 true;

             rb2M.Checked =
                 true;
         }*/

        /* private void btnCobrar_Click(object sender, EventArgs e)
         {


             // =====================
             // VALIDAR SESION
             // =====================

             if (sesion == null)
             {
                 return;
             }


             // =====================
             // TIEMPO FINAL
             // =====================

             TimeSpan tiempoFinal =
                 sesion.Cronometro
                 .TiempoTranscurrido;

             // =====================
             // DETENER
             // =====================

             sesion.Cronometro.Detener();

             // =====================
             // CALCULAR TOTAL
             // =====================

             decimal total =
                 calc.CalcularCosto(
                     sesion.TarifaInicial,
                     sesion.HistorialTarifas,
                     tiempoFinal);

             RegistroCobro cobro =
     new RegistroCobro(
         sesion.UsuarioActual
             .NombreCuenta,

         DateTime.Now,

         tiempoFinal,

         total,

         sesion.TarifaActual);

             persistenciaCobros
     .GuardarCobro(
         cobro);

             ActualizarCaja();

             // =====================
             // ACUMULAR USUARIO
             // =====================

             sesion.UsuarioActual
                 .TiempoTotalJugado +=
                     tiempoFinal;

             // =====================
             // MOSTRAR COBRO
             // =====================

             MessageBox.Show(
                 $"Usuario: {sesion.UsuarioActual.NombreCuenta}\n\n" +
                 $"Tiempo: {tiempoFinal:hh\\:mm\\:ss}\n" +
                 $"Total: {total:0.00} Bs",
                 "Cobro");

             // =====================
             // LIMPIAR SESION
             // =====================

             sesion = null;

             // =====================
             // REINICIAR UI
             // =====================

             ReiniciarUI();
         }*/

        private void
    ActualizarEstadoAPI()
        {
            try
            {
                // =====================
                // PROCESOS
                // =====================

                Process[] procesos =
                    Process.GetProcessesByName(
                        "CyberplayAPI");

                // =====================
                // ONLINE
                // =====================

                if (procesos.Length > 0)
                {
                    lblPuerto.Text =
                        "API Online :5000";

                    lblPuerto.ForeColor =
                        Color.LimeGreen;
                }
                else
                {
                    // =====================
                    // OFFLINE
                    // =====================

                    lblPuerto.Text =
                        "API Offline";

                    lblPuerto.ForeColor =
                        Color.Red;
                }
            }
            catch
            {

            }
        }
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

            
            // =====================
            // SESIONES ACTIVAS
            // =====================

            if (HaySesionesActivas())
            {
                MessageBox.Show(
                    "No se puede cerrar el sistema porque existen sesiones activas.",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                e.Cancel = true;

                return;
            }

            // =====================
            // EQUIPOS ENCENDIDOS
            // =====================

            frmEspera espera =
                null;

            try
            {
                espera =
                    frmEspera.Mostrar(
                        "Haciendo comprobaciones...\r\n\r\nPor favor espere...");

                if (HayEquiposEncendidos())
                {
                    MessageBox.Show(
                        "No se puede cerrar el sistema porque existen equipos encendidos."
                        + Environment.NewLine
                        + Environment.NewLine
                        + ObtenerEquiposEncendidos(),
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    e.Cancel = true;

                    return;
                }
            }
            finally
            {
                if (espera != null &&
                    !espera.IsDisposed)
                {
                    espera.Close();
                }
            }

            // =====================
            // CONFIRMAR CIERRE
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    "¿Está seguro que desea cerrar el sistema?",
                    "Confirmar cierre",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            // =====================
            // CANCELAR
            // =====================

            if (resultado
                == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                if (procesoAPI != null &&
                    !procesoAPI.HasExited)
                {
                    procesoAPI.Kill();
                }
            }
            catch
            {

            }
            GuardarUsuarios();
            GuardarSesiones();
            gestor.CrearBackup();

        }

        private bool HayEquiposEncendidos()
        {
            foreach (ucPS4 equipo in Consolas)
            {
                if (equipo == null)
                {
                    continue;
                }

                if (equipo.Estacion == null)
                {
                    continue;
                }

                EstacionConfiguracion configuracion =
                    SesionSistema
                        .Configuracion
                        .Estaciones
                        .FirstOrDefault(
                            x =>
                            x.NumeroEquipo ==
                            equipo.Estacion.NumeroEquipo);

                if (configuracion == null)
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(
                    configuracion.DireccionIP))
                {
                    continue;
                }

                bool encendido =
                    MonitorRed
                        .EstaEncendido(
                            configuracion.DireccionIP);

                if (encendido)
                {
                    return true;
                }
            }

            return false;
        }

        private string ObtenerEquiposEncendidos()
        {
            List<string> equipos =
                new List<string>();

            foreach (ucPS4 equipo in Consolas)
            {
                if (equipo == null)
                {
                    continue;
                }

                if (equipo.Estacion == null)
                {
                    continue;
                }

                EstacionConfiguracion configuracion =
                    SesionSistema
                        .Configuracion
                        .Estaciones
                        .FirstOrDefault(
                            x =>
                            x.NumeroEquipo ==
                            equipo.Estacion.NumeroEquipo);

                if (configuracion == null)
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(
                    configuracion.DireccionIP))
                {
                    continue;
                }

                bool encendido =
                    MonitorRed
                        .EstaEncendido(
                            configuracion.DireccionIP);

                if (encendido)
                {
                    equipos.Add(
                        EquipoIdentidad.Formatear(
                            equipo.Estacion.NumeroEquipo,
                            equipo.Estacion.TipoEquipo));
                }
            }

            return string.Join(
                Environment.NewLine,
                equipos);
        }

        private bool HaySesionesActivas()
        {
            // =====================
            // RECORRER CONTROLES
            // =====================

            foreach (Control control
                in Controls)
            {
                // =================
                // SOLO UCPS4
                // =================

                if (control is ucPS4 uc)
                {
                    // =============
                    // SESION
                    // =============

                    if (uc.SesionActiva)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private void RestaurarSesiones()
        {
            List<EstadoSesion>
                estados =
                    persistenciaSesiones
                        .Cargar();

            var offsetsLegados =
                estados
                .Where(
                    e =>
                    e.NumeroEquipo <= 0
                    && !string.IsNullOrWhiteSpace(e.NombreConsola))
                .Select(
                    e => new
                    {
                        Tipo =
                            EquipoIdentidad.ObtenerTipo(
                                e.NombreConsola),

                        Numero =
                            EquipoIdentidad.ObtenerNumero(
                                e.NombreConsola)
                    })
                .Where(
                    x =>
                    !string.IsNullOrWhiteSpace(x.Tipo)
                    && x.Numero > 0)
                .GroupBy(
                    x =>
                    x.Tipo)
                .ToDictionary(
                    g =>
                    g.Key,
                    g =>
                    Math.Max(0, g.Min(x => x.Numero) - 1));

            foreach (EstadoSesion estado
                in estados)
            {
                ucPS4 consola =
                    !string.IsNullOrWhiteSpace(
                        estado.IdEstacion)
                    ? Consolas
                        .FirstOrDefault(
                            c =>
                            c.Estacion.IdEstacion
                            == estado.IdEstacion)
                    : null;

                if (consola == null
                    && estado.NumeroEquipo > 0)
                {
                    consola =
                        Consolas
                        .FirstOrDefault(
                            c =>
                            c.Estacion.NumeroEquipo
                            == estado.NumeroEquipo
                            && c.Estacion.TipoEquipo
                            == estado.TipoEquipo);
                }

                if (consola == null)
                {
                    consola =
                        estado.NumeroEquipo > 0
                    ? Consolas
                        .FirstOrDefault(
                            c =>
                            c.Estacion.NumeroEquipo
                            == estado.NumeroEquipo)
                    : null;
                }

                if (consola == null)
                {
                    consola =
                        Consolas
                        .FirstOrDefault(
                            c =>
                            c.NombreConsola
                            == estado.NombreConsola);
                }

                if (consola == null
                    && !string.IsNullOrWhiteSpace(
                        estado.NombreConsola))
                {
                    string tipoLegado =
                        EquipoIdentidad.ObtenerTipo(
                            estado.NombreConsola);

                    int numeroLegado =
                        EquipoIdentidad.ObtenerNumero(
                            estado.NombreConsola);

                    int offset =
                        offsetsLegados.ContainsKey(
                            tipoLegado)
                        ? offsetsLegados[tipoLegado]
                        : 0;

                    int posicionTipo =
                        numeroLegado - offset;

                    consola =
                        Consolas
                        .Where(
                            c =>
                            c.Estacion.TipoEquipo
                            == tipoLegado)
                        .OrderBy(
                            c =>
                            c.Estacion.NumeroEquipo)
                        .Skip(
                            posicionTipo - 1)
                        .FirstOrDefault();
                }

                if (consola != null)
                {
                    consola.RestaurarEstado(
                        estado);
                }
            }
        }

        private void btnCerrarCaja_Click(
    object sender,
    EventArgs e)
        {
            DialogResult confirmacion =
                MessageBox.Show(
                    "¿Está seguro que desea cerrar la caja?",
                    "Confirmar cierre de caja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirmacion == DialogResult.No)
            {
                return;
            }

            // =====================
            // CERRAR CAJA
            // =====================

            SesionSistema
                .CajaActual
                .Abierta = false;

            SesionSistema
                .CajaActual
                .FechaCierre =
                    DateTime.Now;

            // =====================
            // PRODUCTOS
            // =====================

            PersistenciaProductos
                persistenciaProductos =
                    new PersistenciaProductos();

            List<Producto> productos =
                persistenciaProductos
                    .CargarProductos();

            // =====================
            // PERSISTENCIA
            // =====================

            PersistenciaMovimientoStock
                persistenciaMovimiento =
                    new PersistenciaMovimientoStock();

            // =====================
            // RECORRER
            // =====================

            foreach (Producto producto
                in productos)
            {
                MovimientoStock movimiento =
                    new MovimientoStock();

                movimiento.Producto =
                    producto.Nombre;

                movimiento.Categoria =
                    producto.Categoria;

                movimiento.Entregado =
                    producto.Stock;

                movimiento.NumeroCaja =
                    SesionSistema
                        .CajaActual
                        .NumeroCaja;

                persistenciaMovimiento
                    .GuardarMovimiento(
                        movimiento);
            }

            // =====================
            // GUARDAR HISTORIAL
            // =====================

            persistenciaHistorialCajas
                .GuardarCaja(
                    SesionSistema
                        .CajaActual);

            // =====================
            // CREAR NUEVA CAJA
            // =====================

            SesionSistema.CajaActual =
                new Caja()
                {
                    NumeroCaja =
                        persistenciaHistorialCajas
                            .ObtenerSiguienteNumeroCaja(),

                    Nombre =
                        "Caja Principal",

                    Cajero =
                        SesionSistema
                            .CajeroActual
                            .Usuario,

                    FechaApertura =
                        DateTime.Now,

                    TotalCobrado =
                        0,

                    Abierta =
                        true
                };

            // =====================
            // GUARDAR NUEVA CAJA
            // =====================

            persistenciaCaja
                .GuardarCaja(
                    SesionSistema
                        .CajaActual);

            // =====================
            // PRODUCTOS
            // =====================

            List<Producto> productosNuevaCaja =
                persistenciaProductos
                    .CargarProductos();

            // =====================
            // RECIBIDO
            // =====================

            foreach (Producto producto
                in productosNuevaCaja)
            {
                MovimientoStock movimiento =
                    new MovimientoStock();

                movimiento.Producto =
                    producto.Nombre;

                movimiento.Categoria =
                    producto.Categoria;

                movimiento.Recibido =
                    producto.Stock;

                movimiento.NumeroCaja =
                    SesionSistema
                        .CajaActual
                        .NumeroCaja;

                persistenciaMovimiento
                    .GuardarMovimiento(
                        movimiento);
            }

            // =====================
            // ACTUALIZAR UI
            // =====================

            ActualizarCaja();

            ActualizarInfoCaja();

            MessageBox.Show(
                "Caja cerrada correctamente.");

            SesionSistema.CajeroSuspendido =
                null;

            frmLogin login =
    new frmLogin();

            this.Hide();

            if (login.ShowDialog()
                == DialogResult.OK)
            {
                ActualizarInfoCaja();
                AplicarPermisos();
                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void timer_Tick(object sender, EventArgs e) 
        {
            ActualizarProximasSalidas();
            GenerarEstadoWeb();
        }

        private void gestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RequiereAdmin())
            {
                return;
            }
            frmGestionCajeros frm = new frmGestionCajeros();
            frm.Show();
        }

        private void gestionarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.Show();
        }

        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // =====================
            // FORM
            // =====================

            frmVentaProductos frm =
                new frmVentaProductos();

            // =====================
            // MOSTRAR
            // =====================

            frm.Show();
        }

        private void seguimientoFotocopiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeguimientoFotocopias frm =
                new frmSeguimientoFotocopias();

            frm.Show();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngresosCaja frm = new frmIngresosCaja();
            frm.IngresoRegistrado += ActualizarCaja;
            frm.Show();
            
        }

        private void egresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEgresosCaja frm = new frmEgresosCaja();
            frm.EgresoRegistrado += ActualizarCaja;
            frm.Show();
        }

        private void balanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RequiereAdmin())
            {
                return;
            }

            bool responde =
    MonitorRed
        .EstaEncendido(
            "192.168.1.225");

            MessageBox.Show(
                responde
                    ? "Encendida"
                    : "Apagada");

            /*frmBalance frm =
        new frmBalance();

            frm.ShowDialog();*/
        }

        private void tsmiPreferencias_Click(object sender, EventArgs e)
        {
            if (!RequiereAdmin())
            {
                return;
            }

            frmPreferencias frm = new frmPreferencias();

            frm.Show();
        }

        private void tmrAutoSave_Tick(object sender, EventArgs e)
        {
            try
            {
                GuardarUsuarios();
                GuardarSesiones();
            }
            catch
            {

            }
        }

        private void detalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* if (!RequiereAdmin())
            {
                return;
            }*/

            frmDetalleCaja frm = new frmDetalleCaja(SesionSistema.CajaActual.NumeroCaja);

            frm.Show();
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmHistorialCajas frm = new frmHistorialCajas();

            frm.Show();
        }

        private void tsmiCerrarSesion_Click(object sender, EventArgs e)
        {
            if (SesionSistema.CajeroSuspendido != null)
            {
                SesionSistema.CajeroActual =
                    SesionSistema.CajeroSuspendido;

                SesionSistema.CajeroSuspendido =
                    null;

                ActualizarInfoCaja();
                AplicarPermisos();

                MessageBox.Show(
                    "Sesión de cajero restaurada.");

                return;
            }

            if (Permisos.EsAdmin())
            {
                frmLogin login =
                    new frmLogin();

                if (login.ShowDialog() == DialogResult.OK)
                {
                    ActualizarInfoCaja();
                    AplicarPermisos();
                }

                return;
            }

            Cajero cajeroTemporal =
                SesionSistema.CajeroActual;

            frmLogin loginAdmin =
                new frmLogin(true);

            if (loginAdmin.ShowDialog() == DialogResult.OK)
            {
                SesionSistema.CajeroSuspendido =
                    cajeroTemporal;

                ActualizarInfoCaja();
                AplicarPermisos();
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await ActualizarVisitas();
        }

        private void cerrarCajaToolStripMenuItem_Click(
    object sender,
    EventArgs e)
        {
            // =====================
            // VALIDAR MOVIMIENTOS
            // =====================

            if (!CajaTieneMovimientos())
            {
                MessageBox.Show(
                    "No puede cerrar una caja sin movimientos registrados.",
                    "Caja",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult confirmacion =
                MessageBox.Show(
                    "¿Está seguro que desea cerrar la caja?",
                    "Confirmar cierre de caja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirmacion == DialogResult.No)
            {
                return;
            }

            // =====================
            // CERRAR CAJA ACTUAL
            // =====================

            SesionSistema
                .CajaActual
                .Abierta = false;

            SesionSistema
                .CajaActual
                .FechaCierre =
                    DateTime.Now;

            // =====================
            // PRODUCTOS
            // =====================

            PersistenciaProductos
                persistenciaProductos =
                    new PersistenciaProductos();

            List<Producto> productos =
                persistenciaProductos
                    .CargarProductos();

            // =====================
            // MOVIMIENTOS STOCK
            // =====================

            PersistenciaMovimientoStock
                persistenciaMovimiento =
                    new PersistenciaMovimientoStock();

            foreach (Producto producto
                in productos)
            {
                MovimientoStock movimiento =
                    new MovimientoStock();

                movimiento.Producto =
                    producto.Nombre;

                movimiento.Categoria =
                    producto.Categoria;

                movimiento.Entregado =
                    producto.Stock;

                movimiento.NumeroCaja =
                    SesionSistema
                        .CajaActual
                        .NumeroCaja;

                persistenciaMovimiento
                    .GuardarMovimiento(
                        movimiento);
            }

            // =====================
            // GUARDAR HISTORIAL
            // =====================

            persistenciaHistorialCajas
                .GuardarCaja(
                    SesionSistema
                        .CajaActual);

            // =====================
            // NUEVO LOGIN
            // =====================

            SesionSistema.CajeroSuspendido =
                null;

            frmLogin login =
                new frmLogin();

            if (login.ShowDialog()
                != DialogResult.OK)
            {
                Application.Exit();

                return;
            }

            // =====================
            // CREAR NUEVA CAJA
            // =====================

            SesionSistema.CajaActual =
                new Caja()
                {
                    NumeroCaja =
                        persistenciaHistorialCajas
                            .ObtenerSiguienteNumeroCaja(),

                    Nombre =
                        "Caja Principal",

                    Cajero =
                        SesionSistema
                            .CajeroActual
                            .Usuario,

                    FechaApertura =
                        DateTime.Now,

                    TotalCobrado =
                        0,

                    Abierta =
                        true
                };

            // =====================
            // GUARDAR NUEVA CAJA
            // =====================

            persistenciaCaja
                .GuardarCaja(
                    SesionSistema
                        .CajaActual);

            // =====================
            // STOCK INICIAL
            // =====================

            List<Producto> productosNuevaCaja =
                persistenciaProductos
                    .CargarProductos();

            foreach (Producto producto
                in productosNuevaCaja)
            {
                MovimientoStock movimiento =
                    new MovimientoStock();

                movimiento.Producto =
                    producto.Nombre;

                movimiento.Categoria =
                    producto.Categoria;

                movimiento.Recibido =
                    producto.Stock;

                movimiento.NumeroCaja =
                    SesionSistema
                        .CajaActual
                        .NumeroCaja;

                persistenciaMovimiento
                    .GuardarMovimiento(
                        movimiento);
            }

            // =====================
            // ACTUALIZAR UI
            // =====================

            ActualizarCaja();

            ActualizarInfoCaja();

            AplicarPermisos();

            this.Show();
        }

        private void historialCobrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorialCobros frm = new frmHistorialCobros();

            frm.Show();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios(gestorUsuarios);
            frm.Show();
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmVentaProductos frm =
                    new frmVentaProductos();

                frm.Show();
            }

            if (e.KeyCode == Keys.F3)
            {
                frmDetalleCaja frm =
                    new frmDetalleCaja(SesionSistema.CajaActual.NumeroCaja);

                frm.Show();
            }
        }

        private void tmrBackup_Tick(object sender, EventArgs e)
        {
            gestor.CrearBackup();
        }

        private void tmrMonitorEquipos_Tick(
    object sender,
    EventArgs e)
        {
            foreach (ucPS4 equipo
                in Consolas)
            {
                if (equipo == null)
                {
                    continue;
                }

                if (equipo.Estacion == null)
                {
                    continue;
                }

                EstacionConfiguracion configuracion =
                    SesionSistema
                        .Configuracion
                        .Estaciones
                        .FirstOrDefault(
                            x =>
                            x.NumeroEquipo
                            ==
                            equipo.Estacion.NumeroEquipo);

                if (configuracion == null)
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(
                    configuracion.DireccionIP))
                {
                    continue;
                }

                bool encendido =
                    MonitorRed
                        .EstaEncendido(
                            configuracion.DireccionIP);

                equipo.EquipoEncendido =
                    encendido;

                equipo.VerificarAdvertenciaEquipo();
            }
        }

        private void historialAlertasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuditoria frm = new frmAuditoria();
            
            frm.Show();
        }

        private void utilidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUtilidades frm = new frmUtilidades();

            frm.Show();
        }

        private void rankingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRankingClientes frm = new frmRankingClientes();
            frm.Show();
        }
    }
    
}
