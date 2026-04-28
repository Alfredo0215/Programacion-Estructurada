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



    //FSA 18/20/2026
    public partial class DlgMesaPracticas2 : Form
    {

        //---------------------------------------------------------------------
        // Atributos.
        //---------------------------------------------------------------------
        private List<Point> coordenadas;
        public DlgMesaPracticas2()
        {
            InitializeComponent();
            DgvMatriz1.CellPainting += DgvMatriz1CellPainting;
            DgvMatriz2.CellPainting += DgvMatriz2CellPainting;
            coordenadas = new List<Point>();

        }

        //---------------------------------------------------------------------
        //Muestra el panel 1 y esconde los demás.
        //---------------------------------------------------------------------
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

        //---------------------------------------------------------------------
        //Muestra el panel 2 y esconde los demás.
        //---------------------------------------------------------------------
        
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

        //---------------------------------------------------------------------
        //Muestra el panel 3 y esconde los demás.
        //---------------------------------------------------------------------
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

        //---------------------------------------------------------------------
        //Muestra el panel 4 y esconde los demás.
        //---------------------------------------------------------------------
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
        // Genera una matriz en DgvMatriz 1.
        //---------------------------------------------------------------------

        private void BtnPractica1Pnl1_Click(object sender, EventArgs e)
        {

            bool entradaValida;

            entradaValida = Helper.InputHelper.ValidarEntradas(
                (TbxCaptura1, "Filas"),
                (TbxCaptura2, "Columas"),
                (TbxCaptura3, "Ancho Columnas"),
                (TbxCaptura4, "Alto Columas"));

            if (!entradaValida)
                return;

            Helper.GridHelper.GenerarMatriz(
                DgvMatriz1,
                Convert.ToInt32(TbxCaptura1.Text),
                Convert.ToInt32(TbxCaptura2.Text),
                Convert.ToInt32(TbxCaptura3.Text),
                Convert.ToInt32(TbxCaptura4.Text)
                );
        }

        //Función que determina si la entrada es un numero.
        private bool EsNumero(string valor)
        {
            int num;
            bool resultado;
            resultado = int.TryParse(valor, out num);
            return resultado;
        }


        //---------------------------------------------------------------------
        // Llena la matriz DgvMatriz1 de numeros aleatorios.
        //---------------------------------------------------------------------
        private void BtnPractica2Pnl1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DgvMatriz1.RowCount; i++)
            {

                for (int j = 0; j < DgvMatriz1.Columns.Count; j++)
                {

                    DgvMatriz1.Rows[i].Cells[j].Value = Helper.MathHelper.CrearNumeroRandom(0, 10);
                    DgvMatriz1.Rows[i].Cells[j].Style.BackColor = Color.White;


                }



            }
        }


        //---------------------------------------------------------------------
        // Pinta cada celda de la tabla.
        //---------------------------------------------------------------------

        private void DgvMatriz1CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            object Valor;
            int Numero;
            bool EsNumero;
            Point CentroCelda;
            Point Destino;
            Random NumeroRandomX;
            Random NumeroRandomY;

            Pen Pluma1, Pluma2, Pluma3, Pluma4, Pluma5, Pluma6, Pluma7, Pluma8, Pluma9, Pluma0;
            
            Rectangle RectanguloCelda;

            //Prepara objetos de trabajo;

            Pluma1 = new Pen(Color.Red, 5);
            Pluma2 = new Pen(Color.Blue, 2);
            Pluma3 = new Pen(Color.Aqua, 4);
            Pluma4 = new Pen(Color.Beige, 2);
            Pluma5 = new Pen(Color.Cyan, 6);
            Pluma6 = new Pen(Color.Green, 6);
            Pluma7 = new Pen(Color.Yellow, 3);
            Pluma8 = new Pen(Color.Orange, 3);
            Pluma9 = new Pen(Color.Purple, 2);
            Pluma0 = new Pen(Color.Gray, 4);

            NumeroRandomX = new Random();
            NumeroRandomY = new Random();
            Destino = new Point();
            Destino.X = NumeroRandomX.Next(0, DgvMatriz1.Width);
            Destino.Y = NumeroRandomY.Next(0, DgvMatriz1.Height);
            

            CentroCelda = new Point();

            //Descarta encabezados

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            //Pinta la celda normal.

            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            //Determina el valor de la celda

            Valor = e.Value;
            if (Valor != null )
            {
                EsNumero = int.TryParse(Valor.ToString(), out Numero);

                if (EsNumero)
                {

                    //Obtiene límites de la celda.

                    RectanguloCelda = e.CellBounds;

                    //Calcula cnetro de celda.

                    CentroCelda.X = RectanguloCelda.Left + RectanguloCelda.Width / 2;
                    CentroCelda.Y = RectanguloCelda.Top + RectanguloCelda.Height / 2;

                    //Dibuja línea.
                    switch (Numero)
                    {
                        case 1:
                        e.Graphics.DrawLine(Pluma1, CentroCelda.X, CentroCelda.Y, Destino.X, Destino.Y);
                        break;
                        case 2:
                            e.Graphics.DrawLine(Pluma2, CentroCelda.X, CentroCelda.Y, Destino.X, Destino.Y);
                            break;
                        case 3:
                            e.Graphics.DrawLine(Pluma3, CentroCelda.X, CentroCelda.Y, Destino.X, Destino.Y);
                            break;
                        case 4:
                            e.Graphics.DrawLine(Pluma4, CentroCelda.X, CentroCelda.Y, Destino.X, Destino.Y);
                            break;
                        case 5:
                            e.Graphics.DrawLine(Pluma5, CentroCelda.X, CentroCelda.Y, Destino.X, Destino.Y);
                            break;
                        case 6:
                            e.Graphics.DrawLine(Pluma6, CentroCelda.X, CentroCelda.Y, Destino.X, Destino.Y);
                            break;
                        case 7:
                            e.Graphics.DrawLine(Pluma7, CentroCelda.X, CentroCelda.Y, Destino.X, Destino.Y);
                            break;
                        case 8:
                            e.Graphics.DrawLine(Pluma8, CentroCelda.X, CentroCelda.Y, Destino.X, Destino.Y);
                            break;
                        case 9:
                            e.Graphics.DrawLine(Pluma9, CentroCelda.X, CentroCelda.Y, Destino.X, Destino.Y);
                            break;
                        case 0:
                            e.Graphics.DrawLine(Pluma0, CentroCelda.X, CentroCelda.Y, Destino.X, Destino.Y);
                            break;



                    }


                }
            }

            e.Handled = true;
        }

        //---------------------------------------------------------------------
        // Genera la matriz en el DgvMatriz2.
        //---------------------------------------------------------------------
        private void BtnPractica1Pnl2_Click(object sender, EventArgs e)
        {
            bool entradaValida;

            entradaValida = Helper.InputHelper.ValidarEntradas(
                (TbxCaptura1, "Filas"),
                (TbxCaptura2, "Columas"),
                (TbxCaptura3, "Ancho Columnas"),
                (TbxCaptura4, "Alto Columas"));

            if (!entradaValida)
                return;

            Helper.GridHelper.GenerarMatriz(
                DgvMatriz2,
                Convert.ToInt32(TbxCaptura1.Text),
                Convert.ToInt32(TbxCaptura2.Text),
                Convert.ToInt32(TbxCaptura3.Text),
                Convert.ToInt32(TbxCaptura4.Text)
                );
        }

        //---------------------------------------------------------------------
        // Llena la matriz DgvMatriz2 de letras aleatorias.
        //---------------------------------------------------------------------

        private void BtnPractica2Pnl2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < DgvMatriz2.RowCount; i++)
            {

                for (int j = 0; j < DgvMatriz2.Columns.Count; j++)
                {

                    DgvMatriz2.Rows[i].Cells[j].Value = (char)Helper.MathHelper.CrearNumeroRandom('A', 'Z' + 1);
                    DgvMatriz2.Rows[i].Cells[j].Style.BackColor = Color.White;


                }
            }
        }


        //---------------------------------------------------------------------
        // Traza lineas para formar la palabra capturada por el usuario.
        //---------------------------------------------------------------------
        private void BtnPractica3Pnl2_Click(object sender, EventArgs e)
        {
            string texto;
            int k;
           
            bool PalabraTerminada;
            PalabraTerminada = false;
            texto = TbxCaptura5.Text.ToUpper();
            texto = texto.Replace(" ", "");
            texto = texto.Replace(".", "");
            texto = texto.Replace(",", "");


            coordenadas.Clear();


           
            k = 0;
            for (int i = 0; i < DgvMatriz2.RowCount; i++)
            {
                

                for (int j = 0; j < DgvMatriz2.ColumnCount; j++)
                {
                    char Letra;
                    Letra = (char)DgvMatriz2.Rows[i].Cells[j].Value;
                    DgvMatriz2.Rows[i].Cells[j].Style.BackColor = Color.White;
                    if (!PalabraTerminada)
                    {
                        if (Letra == texto[k])
                        {
                            DgvMatriz2.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                            k++;

                            if (k == texto.Length)
                            {
                                PalabraTerminada = true;
                            }
                        }
                    }
                }


            }

           
        }

        private void DgvMatriz2CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            object Valor;
            Point CentroCelda;
            Point Destino;

            Pen Pluma1;
            Rectangle RectanguloCelda;

            //Prepara objetos de trabajo;

            Pluma1 = new Pen(Color.Red, 5);
            Destino = new Point();
            CentroCelda = new Point();

            //Descarta encabezados

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            //Pinta la celda normal.

            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            //Determina el valor de la celda

            Valor = e.Value;

            
            if (Valor != null)
            {
                if (e.CellStyle.BackColor == Color.Yellow) 
                {



                    //Obtiene límites de la celda.

                    RectanguloCelda = e.CellBounds;

                    //Calcula cnetro de celda.

                    CentroCelda.X = RectanguloCelda.Left + RectanguloCelda.Width / 2;
                    CentroCelda.Y = RectanguloCelda.Top + RectanguloCelda.Height / 2;

                    //Almacena coordenadas del centro de las celdas.
                    coordenadas.Add(CentroCelda);

                    //e.Graphics.DrawLine(Pluma1, CentroCelda.X, CentroCelda.Y, CentroCelda.X - 100, CentroCelda.Y);
                }
            }
            e.Handled = true;
        }

        private void BtnPractica1Pnl3_Click(object sender, EventArgs e)
        {
           
        }

        

        //---------------------------------------------------------------------
        // Llena la matriz DgvMatriz3 con números random
        //---------------------------------------------------------------------

        private void BtnPractica2Pnl3_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnPractica4Pnl2_Click(object sender, EventArgs e)
        {
            // Gráficos lienzo
            Graphics graficos;
            Pen pluma;

            pluma = new Pen(Color.Red, 1);

            /*foreach( Point coordenada in coordenadas)
            {
                MessageBox.Show(coordenada.ToString());
            }*/
            graficos = DgvMatriz2.CreateGraphics();
            graficos.DrawLines(pluma, coordenadas.ToArray());

        }

        private void PnlPracticas3_Paint(object sender, PaintEventArgs e)
        {
           
            
        }

        private void PnlPracticas3_MouseMove(object sender, MouseEventArgs e)
        {
            int x;
            Pen pluma;
            int y;
            Random numeroRandom;
            Graphics lienzoGrafico;
            Color ColorAleatorio;


            numeroRandom = new Random();

            ColorAleatorio = Color.FromArgb(numeroRandom.Next(0, 256), numeroRandom.Next(0, 256), numeroRandom.Next(0, 256));

            x = e.Location.X;
            y = e.Location.Y;

            pluma = new Pen(ColorAleatorio, 1);
            lienzoGrafico = PnlPracticas3.CreateGraphics();
            lienzoGrafico.DrawLine(pluma,
                Helper.MathHelper.CrearNumeroRandom(0, PnlPracticas3.Width),
                Helper.MathHelper.CrearNumeroRandom(0, PnlPracticas3.Width), x, y);
        }
    }

}
