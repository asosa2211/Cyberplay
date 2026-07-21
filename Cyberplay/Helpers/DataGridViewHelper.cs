using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberplay.Helpers
{
    public class DataGridViewHelper
    {
        /// <summary>
        /// Aplica el estilo estándar de Control Cyberplay.
        /// </summary>
        public static void Configurar(
    DataGridView dgv,
    DataGridViewOptions options = null)
        {
            if (dgv == null)
                return;

            if (options == null)
                options = new DataGridViewOptions();

            dgv.SuspendLayout();

            ConfigurarGeneral(dgv, options);
            ConfigurarCabecera(dgv, options);
            ConfigurarFilas(dgv, options);
            ConfigurarSeleccion(dgv, options);
            ConfigurarComportamiento(dgv, options);
            ConfigurarOrdenamiento(dgv, options);

            if (options.EnableDoubleBuffer)
                ActivarDoubleBuffer(dgv);

            dgv.ResumeLayout();
        }

        #region Métodos privados

        private static void ConfigurarGeneral(
     DataGridView dgv,
     DataGridViewOptions options)
        {
            dgv.BackgroundColor =
                options.BackgroundColor;

            dgv.BorderStyle =
                options.BorderStyle;

            dgv.EnableHeadersVisualStyles = false;

            dgv.RowHeadersVisible =
                options.ShowRowHeaders;

            dgv.CellBorderStyle =
                options.CellBorderStyle;

            dgv.ColumnHeadersBorderStyle =
                options.HeaderBorderStyle;
        }

        private static void ConfigurarOrdenamiento(
    DataGridView dgv,
    DataGridViewOptions options)
        {
            if (options.AllowSorting)
                return;

            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                columna.SortMode =
                    DataGridViewColumnSortMode.NotSortable;
            }
        }
        private static void ConfigurarCabecera(DataGridView dgv, DataGridViewOptions options)
        {
            dgv.ColumnHeadersHeight = options.HeaderHeight;
            dgv.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                options.HeaderBackColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                options.HeaderForeColor;

            dgv.ColumnHeadersDefaultCellStyle.Font =
    new Font(
        options.HeaderFontName,
        options.HeaderFontSize,
        options.HeaderFontStyle);

            dgv.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                options.HeaderBackColor;

            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                options.HeaderForeColor;

            dgv.AllowUserToResizeColumns = options.AllowResizeColumns;
        }

        private static void ConfigurarFilas(
    DataGridView dgv,
    DataGridViewOptions options)
        {
            dgv.DefaultCellStyle.Font =
    new Font(
        options.RowFontName,
        options.RowFontSize,
        options.RowFontStyle);

            dgv.DefaultCellStyle.BackColor = options.RowBackColor;

            dgv.DefaultCellStyle.ForeColor = options.RowForeColor;

            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                options.AlternateRowBackColor;

            dgv.DefaultCellStyle.Alignment =
                options.CellAlignment;

            dgv.RowTemplate.Height =
                options.RowHeight;
        }

        private static void ConfigurarSeleccion(
    DataGridView dgv,
    DataGridViewOptions options)
        {
            dgv.DefaultCellStyle.SelectionBackColor =
                options.SelectionBackColor;

            dgv.DefaultCellStyle.SelectionForeColor =
                options.SelectionForeColor;
        }

        private static void ConfigurarComportamiento(
    DataGridView dgv,
    DataGridViewOptions options)
        {
            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv.MultiSelect =
                options.MultiSelect;

            dgv.AllowUserToAddRows =
                options.AllowAddRows;

            dgv.AllowUserToDeleteRows =
                options.AllowDeleteRows;

            dgv.AllowUserToResizeRows =
                options.AllowResizeRows;

            dgv.ReadOnly =
                options.ReadOnly;
        }

        /// <summary>
        /// Reduce el parpadeo al desplazar o actualizar el DataGridView.
        /// </summary>
        private static void ActivarDoubleBuffer(DataGridView dgv)
        {
            typeof(DataGridView)
                .GetProperty("DoubleBuffered",
                    BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(dgv, true, null);
        }

        #endregion
    }
}
