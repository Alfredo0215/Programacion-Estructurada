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
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }

        public void ConvierteFAC_Click(object sender, EventArgs e)
        {
            double Resultado;

            Resultado = ConvertirGradosFAC(Convert.ToDouble(TbxGradosF.Text));

            TbxResultado2.Text = Resultado.ToString();
        }
        private void ConvierteCaF_Click(object sender, EventArgs e)
        {
            double Resultado;

            Resultado = ConvertirGradosCAF(Convert.ToDouble(TbxGradosC.Text));

            TbxResultado1.Text = Resultado.ToString();
        }

        //-------------------------------------------------------------------------
        // Función que convierte grados Fahrenheit a Celsius.
        //-------------------------------------------------------------------------
        private double ConvertirGradosFAC(double Fahrenheit)
        {
            double C;

            C = (Fahrenheit - 32) / 1.8;

            return C;
        }

        //-------------------------------------------------------------------------
        // Función que convierte grados Celsius a Fahrenheit.
        //-------------------------------------------------------------------------
        private double ConvertirGradosCAF(double Centígrado)
        {
            double F;

            F = (Centígrado * 1.8) + 32;

            return F;
        }

 
    }
}
