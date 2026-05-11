using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE26A_FSA_
{
    public partial class DlgMesaPracticas1 : Form
    {

        int RA; //Renglón Actual P4Panel2 

        public DlgMesaPracticas1()
        {
            InitializeComponent();
            RA = 0;
        }

        //---------------------------------------------------------------------
        //Toggle de paneles 
        //---------------------------------------------------------------------

        //Muestra el panel 1 y esconde los demás.
        private void BtnPractica1_Click(object sender, EventArgs e)
        {

            //NOTA: La siguiente es una linea simplificada.
            // PnlPracticas1.Visible = !PnlPracticas1.Visible;

            if (PnlPracticas1.Visible)
            {
                PnlPracticas1.Visible = false;
            }
            else
            {
                PnlPracticas1.Visible = true;
                PnlPracticas2.Visible = false;
                PnlPracticas3.Visible = false;
                PnlPracticas4.Visible = false;
            }

        }

        //Muestra el panel 2 y esconde los demás.
        private void BtnPractica2_Click(object sender, EventArgs e)
        {
            if (PnlPracticas2.Visible)
            {
                PnlPracticas2.Visible = false;
            }
            else
            {
                PnlPracticas2.Visible = true;
                PnlPracticas1.Visible = false;
                PnlPracticas3.Visible = false;
                PnlPracticas4.Visible = false;
            }

        }

        //Muestra el panel 3 y esconde los demás.
        private void BtnPractica3_Click(object sender, EventArgs e)
        {
            if (PnlPracticas3.Visible)
            {
                PnlPracticas3.Visible = false;
            }
            else
            {
                PnlPracticas3.Visible = true;
                PnlPracticas1.Visible = false;
                PnlPracticas2.Visible = false;
                PnlPracticas4.Visible = false;
            }

        }

        //Muestra el panel 4 y esconde los demás.

        private void BtnPractica4_Click(object sender, EventArgs e)
        {
            if (PnlPracticas4.Visible)
            {
                PnlPracticas4.Visible = false;
            }
            else
            {
                PnlPracticas4.Visible = true;
                PnlPracticas1.Visible = false;
                PnlPracticas2.Visible = false;
                PnlPracticas3.Visible = false;
            }

        }

        //---------------------------------------------------------------------
        //Practica 1.
        //---------------------------------------------------------------------

        // Función geeneradora de matriz para ejercicios de llenado.
        private void BtnPractica1Pnl1_Click(object sender, EventArgs e)
        {
            int Tamaño;
            int AnchoConstante;


            //Valida el tamaño de la matriz en el campo 1.

            if (!EsNumero(TbxCaptura1.Text))
            {
                MessageBox.Show("Capture el tamaño de la matriz ");
                TbxCaptura1.Focus();
                return;
            }

            //Valida el ancho constante de las columnas en el campo 2.

            if (!EsNumero(TbxCaptura2.Text))
            {
                MessageBox.Show("Capture el ancho de las columnas de la matriz ");
                TbxCaptura2.Focus();
                return;
            }
            //Inicia las variables según el valor que capture el usuario

            Tamaño = Convert.ToInt32(TbxCaptura1.Text);
            AnchoConstante = Convert.ToInt32(TbxCaptura2.Text);

            //Limpia matrices generadas con anterioridad.
            DGVMatriz1.Columns.Clear();
            DGVMatriz1.Rows.Clear();

            //Genera columnas.
            for (int i = 0; i < Tamaño; i++)
            {
                DGVMatriz1.Columns.Add("Col" + i.ToString(), "HC" + i.ToString());
                if (i < Tamaño / 2)
                {
                    DGVMatriz1.Columns[i].Width = (i * 1) + AnchoConstante;
                }
                else
                {
                    DGVMatriz1.Columns[i].Width = (Tamaño - i) + AnchoConstante;
                }

            }

            //Genera filas.
            for (int r = 0; r < Tamaño; r++)
            {
                DGVMatriz1.Rows.Add();
            }
        }



        //Botón que rellena la matriz y colorea cada recuadro dependiendo del width de dicho recuadro
        private void BtnPractica2Pnl1_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < DGVMatriz1.Rows.Count; r++)
            {
                for (int c = 0; c < DGVMatriz1.Columns.Count; c++)
                {
                    DGVMatriz1.Rows[r].Cells[c].Value = DGVMatriz1.Columns[c].Width;
                    if (c < DGVMatriz1.Columns.Count / 2)
                    {
                        DGVMatriz1.Rows[r].Cells[c].Style.BackColor = Color.FromArgb(127 + (c * 8), 127 + (c * 8), 127 + (c * 8));
                    }
                    else
                        DGVMatriz1.Rows[r].Cells[c].Style.BackColor = Color.FromArgb(255 - (c - 15) * 8, 255 - (c - 15) * 8, 255 - (c - 15) * 8);

                }

            }

        }

        //Genera un llenado de prácticas. 
        private void BtnPractica3Pnl1_Click(object sender, EventArgs e)
        {
            int r;
            int c;
            int ValorRandom;

            Random Random;

            Random = new Random();
            r = 0;

            while (r < DGVMatriz1.RowCount)
            {
                c = 0;
                while (c < DGVMatriz1.Columns.Count)
                {

                    ValorRandom = Random.Next(0, 10);
                    DGVMatriz1.Rows[r].Cells[c].Value = ValorRandom;

                    if (ValorRandom == 9)
                    {
                        DGVMatriz1.Rows[r].Cells[c].Style.BackColor = Color.Red;
                    }
                    c++;
                }

                r++;
            }

        }

        private void BtnPractica1Pnl2_Click(object sender, EventArgs e)
        {
            RA = 0;
            int AnchoConstante;
            int AltoConstante;
            int Columnas;
            int Renglones;
            DGVMatriz2.AllowUserToAddRows = false;

            //Valida La cantidad de renglones en el campo 1.

            if (!EsNumero(TbxCaptura1.Text))
            {
                MessageBox.Show("Capture el numero de renglones de la matriz en el campo 1.");
                TbxCaptura1.Focus();
                return;
            }

            //Valida la cantidad de columnas en el campo 2.

            if (!EsNumero(TbxCaptura2.Text))
            {
                MessageBox.Show("Capture el numero de columnas de la matriz en el campo 2.");
                TbxCaptura2.Focus();
                return;
            }

            //Valida el ancho constante en el campo 3.
            if (!EsNumero(TbxCaptura3.Text))
            {
                MessageBox.Show("Capture el ancho de las columnas de la matriz en el campo 3.");
                TbxCaptura3.Focus();
                return;
            }

            //Valida la altura de renglones en el campo 4.
            if (!EsNumero(TbxCaptura3.Text))
            {
                MessageBox.Show("Capture el alto de los renglones en el campo 4.");
                TbxCaptura4.Focus();
                return;
            }

            //Inicia las variables según el valor que capture el usuario

            Renglones = Convert.ToInt32(TbxCaptura1.Text);
            Columnas = Convert.ToInt32(TbxCaptura2.Text);
            AnchoConstante = Convert.ToInt32(TbxCaptura3.Text);
            AltoConstante = Convert.ToInt32(TbxCaptura4.Text);

            //Limpia matrices generadas con anterioridad.
            DGVMatriz2.Columns.Clear();
            DGVMatriz2.Rows.Clear();

            //Genera columnas.
            if (Cbx1.Checked)
            {
                for (int i = 0; i < Columnas; i++)
                {
                    DGVMatriz2.Columns.Add("Col" + i.ToString(), "HC" + i.ToString());
                    if (i < Columnas / 2)
                    {
                        DGVMatriz2.Columns[i].Width = (i * 1) + AnchoConstante;
                    }
                    else
                    {
                        DGVMatriz2.Columns[i].Width = (Columnas - i) + AnchoConstante;
                    }

                }
            }
            else
            {
                for (int i = 0; i < Columnas; i++)
                {
                    DGVMatriz2.Columns.Add("Col" + i.ToString(), "HC" + i.ToString());
                    if (i < Columnas / 2)
                    {
                        DGVMatriz2.Columns[i].Width = AnchoConstante;
                    }
                    else
                    {
                        DGVMatriz2.Columns[i].Width = AnchoConstante;
                    }

                }
            }
            //Genera filas.
            for (int r = 0; r < Renglones; r++)
            {
                DGVMatriz2.Rows.Add();
                DGVMatriz2.Rows[r].Height = AltoConstante;

            }
        }

        //Función que determina si la entrada es un numero.
        private bool EsNumero(string valor)
        {
            int num;
            bool resultado;
            resultado = int.TryParse(valor, out num);
            return resultado;
        }

        private void BtnPractica2Pnl2_Click(object sender, EventArgs e)
        {
            int renglones;
            int columnas;
            renglones = DGVMatriz2.Rows.Count;
            columnas = DGVMatriz2.Columns.Count;

            for (int i = 0; i < renglones; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    DGVMatriz2.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(i, j, 0);
                }
            }
        }

        private void BtnPractica3Pnl2_Click(object sender, EventArgs e)
        {
            RA = 0;
            int ValorRandom;
            int ContadorPares = 0;
            int ContadorImpares = 0;
            int SumatoriaPares = 0;
            int SumatoriaImpares = 0;

            Random Random;

            Random = new Random();


            for (int r = 0; r < DGVMatriz2.RowCount; r++)
            {

                for (int c = 0; c < DGVMatriz2.Columns.Count; c++)
                {

                    ValorRandom = Random.Next(0, 10);
                    DGVMatriz2.Rows[r].Cells[c].Value = ValorRandom;

                    if (ValorRandom % 2 == 0)
                    {
                        DGVMatriz2.Rows[r].Cells[c].Style.BackColor = Color.Green;
                        SumatoriaPares += ValorRandom;
                        ContadorPares++;
                    }
                    else
                    {
                        DGVMatriz2.Rows[r].Cells[c].Style.BackColor = Color.Red;
                        SumatoriaImpares += ValorRandom;
                        ContadorImpares++;

                    }
                }
            }

            TbxNPares.Text = ContadorPares.ToString();
            TbxNImpares.Text = ContadorImpares.ToString();
            TbxSPares.Text = SumatoriaPares.ToString();
            TbxSImpares.Text = SumatoriaImpares.ToString();

        }

        //Ordena los dígitos de mayor a menor en cada renglón.
        private void BtnPractica4Pnl2_Click(object sender, EventArgs e)
        {

            bool EstaOrdenado = true;
            for (int c = 0; c < DGVMatriz2.ColumnCount - 1; c++)
            {
                int valor1 = Convert.ToInt32(DGVMatriz2.Rows[RA].Cells[c].Value);
                int valor2 = Convert.ToInt32(DGVMatriz2.Rows[RA].Cells[c + 1].Value);

                if (valor2 > valor1)
                {
                    DGVMatriz2.Rows[RA].Cells[c].Value = valor2;
                    DGVMatriz2.Rows[RA].Cells[c + 1].Value = valor1;
                    EstaOrdenado = false;

                }



            }
            if (EstaOrdenado)
            {
                for (int i = 0; i < DGVMatriz2.ColumnCount; i++)
                {
                    DGVMatriz2.Rows[RA].Cells[i].Style.BackColor = Color.Green;
                }

                RA++;
                if (RA == DGVMatriz2.RowCount)
                    RA = 0;
            }

        }

        private void BtnPractica1Pnl3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    DgvMatriz3.Columns.Add("Col", "Col" + j.ToString());
                }
            }
        }

        private void BtnPpractica5Pnl2_Click(object sender, EventArgs e)
        {

            bool EstaOrdenado = false;

            while (!EstaOrdenado)
            {
                for (int c = 0; c < DGVMatriz2.ColumnCount - 1; c++)
                {
                    EstaOrdenado = true;
                    int valor1 = Convert.ToInt32(DGVMatriz2.Rows[RA].Cells[c].Value);
                    int valor2 = Convert.ToInt32(DGVMatriz2.Rows[RA].Cells[c + 1].Value);

                    if (valor2 > valor1)
                    {
                        DGVMatriz2.Rows[RA].Cells[c].Value = valor2;
                        DGVMatriz2.Rows[RA].Cells[c + 1].Value = valor1;
                        c = -1;
                        EstaOrdenado = false;

                    }



                }
                if (EstaOrdenado)
                {
                    for (int i = 0; i < DGVMatriz2.ColumnCount; i++)
                    {
                        DGVMatriz2.Rows[RA].Cells[i].Style.BackColor = Color.Green;
                    }

                    RA++;
                    if (RA == DGVMatriz2.RowCount)
                        RA = 0;
                }

            }
        }

        
    }
}


