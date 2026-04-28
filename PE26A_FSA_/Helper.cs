using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace PE26A_FSA_
{
    internal class Helper
    {

        public static class GridHelper
        {
            public static void GenerarMatriz(DataGridView Dgv, int Rows, int Cols, int cellWidht, int cellHeight)
            {

                // Configura y genera Columnas
                Dgv.Columns.Clear();
                for (int j = 0; j < Cols; j++)
                {
                    Dgv.Columns.Add($"Col{j}", $"HC{ j + 1}");
                    Dgv.Columns[j].Width = cellWidht;
                }

                // Configura y genera Filas.
                Dgv.Rows.Clear();
                for (int i = 0; i < Rows; i++)
                {
                    Dgv.Rows.Add();
                    Dgv.Rows[i].Height = cellHeight;
                }
            }
        }

        public static class InputHelper
        {
            public static bool ValidarEntradas(params (TextBox captura, string nombreCaptura)[] campos)
            {
                foreach (var campo in campos)
                {
                    if ( string.IsNullOrWhiteSpace(campo.captura.Text))
                    {
                        MessageBox.Show(
                            $"Capture {campo.nombreCaptura}",
                            "Captura inválida", 
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error );

                        campo.captura.Focus();
                        campo.captura.SelectAll();
                        return false;
                    }
                }
                return true;
            }
        }

        public static class MathHelper
        {
            private static Random _numeroRandom = new Random();
            public static int CrearNumeroRandom(int min, int max)
            {
                
                return _numeroRandom.Next(min, max);
            }
        }
    }
}
