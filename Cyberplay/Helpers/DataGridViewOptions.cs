using System.Drawing;
using System.Windows.Forms;

namespace Cyberplay.Helpers
{
    public class DataGridViewOptions
    {
        #region Cabecera

        public int HeaderHeight { get; set; } = 25;

        public Color HeaderBackColor { get; set; } = Color.Blue;

        public Color HeaderForeColor { get; set; } = Color.White;

        public string HeaderFontName { get; set; } = "Segoe UI";

        public float HeaderFontSize { get; set; } = 9F;

        public FontStyle HeaderFontStyle { get; set; } = FontStyle.Bold;

        public DataGridViewContentAlignment HeaderAlignment { get; set; } =
            DataGridViewContentAlignment.MiddleCenter;

        #endregion

        #region Filas

        public int RowHeight { get; set; } = 22;

        public string RowFontName { get; set; } = "Segoe UI";

        public float RowFontSize { get; set; } = 9F;

        public FontStyle RowFontStyle { get; set; } = FontStyle.Regular;

        public Color RowBackColor { get; set; } = Color.White;

        public Color AlternateRowBackColor { get; set; } =
            Color.FromArgb(245, 245, 245);

        public Color RowForeColor { get; set; } = Color.Black;

        public DataGridViewContentAlignment CellAlignment { get; set; } =
            DataGridViewContentAlignment.MiddleLeft;

        #endregion

        #region Selección

        public Color SelectionBackColor { get; set; } =
            Color.DeepSkyBlue;

        public Color SelectionForeColor { get; set; } =
            Color.Black;


        #endregion

        #region Comportamiento

        public bool AllowSorting { get; set; } = false;
        public bool ReadOnly { get; set; } = true;

        public bool MultiSelect { get; set; } = false;

        public bool AllowAddRows { get; set; } = false;

        public bool AllowDeleteRows { get; set; } = false;

        public bool AllowResizeRows { get; set; } = false;

        public bool AllowResizeColumns { get; set; } = false;

        public bool ShowRowHeaders { get; set; } = false;

        public bool EnableDoubleBuffer { get; set; } = true;

        #endregion

        public Color BackgroundColor { get; set; }
    = SystemColors.Control;

        public BorderStyle BorderStyle { get; set; }
            = BorderStyle.None;

        public DataGridViewCellBorderStyle CellBorderStyle { get; set; }
            = DataGridViewCellBorderStyle.Single;

        public DataGridViewHeaderBorderStyle HeaderBorderStyle { get; set; }
            = DataGridViewHeaderBorderStyle.Single;
    }
}
