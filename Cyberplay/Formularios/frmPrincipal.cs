using Cyberplay.Core;
using Cyberplay.enums;
using Cyberplay.Formularios;
using Cyberplay.Helpers;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
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
using static System.Collections.Specialized.BitVector32;

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

                    int orden =
                        0;

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

                            orden = 2;
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

                            orden = 1;
                        }
                    }

                    // =====================
                    // NUMERO
                    // =====================

                    int numero = 0;

                    string[] partes =
                        consola.NombreConsola
                        .Split('-');

                    if (partes.Length > 1)
                    {
                        int.TryParse(
                            partes.Last(),
                            out numero);
                    }

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

                string[] partes =
                    consola.Estacion.Nombre
                    .Split('-');

                string tipo =
                    partes[0];

                string numero =
                    partes.Length > 1
                    ? partes[1]
                    : consola.Estacion.Nombre;

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
                estados.Add(
                    consola.ObtenerEstado());
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
                TipoEquipoConfiguracion tipo
                in SesionSistema
                    .Configuracion
                    .TiposEquipo)
            {
                // =====================
                // CREAR CANTIDAD
                // =====================

                for (int i = 1;
                    i <= tipo.Cantidad;
                    i++)
                {
                    // =====================
                    // ESTACION
                    // =====================

                    Estacion est =
                        new Estacion();

                    // =====================
                    // MULTIJUGADOR
                    // =====================

                    est.SoportaMultijugador =
                        tipo
                        .UsaTarifasMultijugador;

                    // =====================
                    // NOMBRE
                    // =====================
                    if (est.SoportaMultijugador)
                    {
                        est.Nombre = tipo.Nombre + "-" + (i+4);
                    }
                    else
                    {
                        est.Nombre = tipo.Nombre + "-" + i;
                    }
                    

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

            GuardarUsuarios();
            GuardarSesiones();
            gestor.CrearBackup();

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

            foreach (EstadoSesion estado
                in estados)
            {
                ucPS4 consola =
                    Consolas
                    .FirstOrDefault(
                        c =>
                        c.NombreConsola
                        == estado.NombreConsola);

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

            frmBalance frm =
        new frmBalance();

            frm.ShowDialog();
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

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
    
}
