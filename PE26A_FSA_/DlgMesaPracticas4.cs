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
    public partial class DlgMesaPracticas4 : Form
    {

        const int ROWS = 30;
        const int COLS = 30;

        int[,] energy = new int[ROWS, COLS];
        bool[,] food = new bool[ROWS, COLS];
        double[,] reproductionRate = new double[ROWS, COLS];
        double[,] mutationRate = new double[ROWS, COLS];
        public DlgMesaPracticas4()
        {
            InitializeComponent();
            InitializeWorld();
            DrawWorld();
        }

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
                
            }
            
        }

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
               
            }

        }

        
        

        // Función geeneradora de matriz para ejercicios de llenado.
        private void BtnPractica1Pnl1_Click(object sender, EventArgs e)
        {
           
        }

        //Prepara estado inicial de la simulación.
        void InitializeWorld()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    energy[row, col] = 0;
                    food[row, col] = false;
                    reproductionRate[row, col] = 0;
                    mutationRate[row, col] = 0;
                }
            }

            // Individuo inicial de prueba
            energy[10, 10] = 10;
            reproductionRate[10, 10] = 0.3;
            mutationRate[10, 10] = 0.05;
        }

        // Dibuja la simulación dentro del Data Grid View.
        void DrawWorld()
        {
            DgvMatriz1.RowCount = ROWS;
            DgvMatriz1.ColumnCount = COLS;

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (energy[row, col] > 0)
                    {
                        DgvMatriz1[col, row].Value = "O";
                    }
                    else if (food[row, col])
                    {
                        DgvMatriz1[col, row].Value = "F";
                    }
                    else
                    {
                        DgvMatriz1[col, row].Value = "";
                    }
                }
            }
        }

    }
}
