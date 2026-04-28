using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace PE26A_FSA_
{
    //-------------------------------------------------------------------------
    // Programación estructurada 26A.
    //-------------------------------------------------------------------------
    //Diálogo del menú principal del proyecto final.
    //FSA. 04/02/26
    //-------------------------------------------------------------------------

    //Commit prueba.
    public partial class DlgPrincipal : Form
    {

        //Campos
        private IconButton botonActual;
        private Panel leftBorderBtn;

        //-------------------------------------------------------------------------
        // Constructor.
        //-------------------------------------------------------------------------
        public DlgPrincipal()
        {
            
            InitializeComponent();
            Diseño();
            PbxFondo.SizeMode = PictureBoxSizeMode.Zoom;
            PbxHome.SizeMode = PictureBoxSizeMode.Zoom;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 45);
            sidePnl.Controls.Add(leftBorderBtn);
        }

        //Estructuras
        private struct Colors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
        }
        private Form activeForm = null;
        
        //-------------------------------------------------------------------------
        // Función que pregunta al usuario si desea salir del programa. 
        //-------------------------------------------------------------------------


        //---------------------------------------------------------------------
        //Función que esconde los submenus.
        //---------------------------------------------------------------------

        private void HideSubMenu()
        {
            if (SubMenuMesas.Visible)
            {
                SubMenuMesas.Visible = false;
            }
        }

        //---------------------------------------------------------------------
        //Función que muestra los submenus.
        //---------------------------------------------------------------------
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }

            else 
                subMenu.Visible = false;
        }

        //---------------------------------------------------------------------
        //Función que esconde todos los submenús al abrir el programa.
        //---------------------------------------------------------------------
        private void Diseño()
        {
            SubMenuMesas.Visible = false;
        }

        //---------------------------------------------------------------------
        //Función que abre los formularios hijos.
        //---------------------------------------------------------------------

        private void AbrirFormularioHijo(Form formularioHijo)
        {
            if (activeForm != null)
            {
                activeForm.Close();

            }

            activeForm = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.Dock = DockStyle.Fill;
            PnlForms.Controls.Add(formularioHijo);
            PnlForms.Tag = formularioHijo;
            formularioHijo.BringToFront();  
            formularioHijo.Show();
        }
        //---------------------------------------------------------------------
        //Función que cierra el formulario abierto actualmente.
        //---------------------------------------------------------------------
        private void CerrarFormulario ( Form formulario)
        {
            
            activeForm = null;
            PnlForms.Controls.Remove(formulario);
            formulario.Close();
        }

        //---------------------------------------------------------------------
        //Botón hola mundo que pregunta si quieres salir del programa.
        //---------------------------------------------------------------------
        private void iconButton1_Click(object sender, EventArgs e)
        {
            
                ActivarBoton(sender, Colors.color1);
                var resultado = DialogResult.Yes;


                resultado = MessageBox.Show(
                    "¿Está seguro de que desea salir del programa?", "Éxito", MessageBoxButtons.YesNo
                    );

                if (resultado == DialogResult.Yes)
                {
                    Application.Exit();
                }
            HideSubMenu();



        }

        //---------------------------------------------------------------------
        //Botón que invoca al formulario Calculadora.
        //---------------------------------------------------------------------
        private void BtnCalculadora1_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender, Colors.color2);
            AbrirFormularioHijo(new Calculadora());
            HideSubMenu();
        }

        //---------------------------------------------------------------------
        //Botón que despliega el SubMenuMesas.
        //---------------------------------------------------------------------
        private void BtnMesasPracticas1_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender, Colors.color3);
            ShowSubMenu(SubMenuMesas);
            
        }

        //-------------------------------------------------------------------------
        // Función que ejecuta la mesa de practicas 1
        //-------------------------------------------------------------------------
        private void MesaPracticas1_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new DlgMesaPracticas1());
            HideSubMenu();

        }

        private void MesaPracticas2_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new DlgMesaPracticas2());
            HideSubMenu();
        }

        private void MesaPracticas3_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new DlgMesaPracticas3());
            HideSubMenu();
        }

        private void MesaPracticas4_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new DlgMesaPracticas4());
            HideSubMenu();
        }

        private void ActivarBoton(object senderBtn, Color color)
        {
            DesactivarBoton();
            if (senderBtn != null)
            {
                botonActual = (IconButton)senderBtn;
                botonActual.BackColor = Color.FromArgb(35, 22, 54);
                botonActual.ForeColor = color;
                botonActual.TextAlign = ContentAlignment.MiddleCenter;
                botonActual.IconColor = color;
                botonActual.ImageAlign = ContentAlignment.MiddleRight;
                botonActual.TextImageRelation = TextImageRelation.TextBeforeImage;
                //Panel
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, botonActual.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

            }
        }
        private void DesactivarBoton()
        {
            if (botonActual != null)
            {
               
                botonActual.BackColor = Color.FromArgb(11, 7, 17);
                botonActual.ForeColor = Color.Gainsboro;
                botonActual.TextAlign = ContentAlignment.MiddleLeft;
                botonActual.IconColor = Color.White;
                botonActual.ImageAlign = ContentAlignment.MiddleLeft;
                botonActual.TextImageRelation = TextImageRelation.ImageBeforeText;
                leftBorderBtn.Hide();
            }
        }

        private void PbxHome_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                DesactivarBoton();
                CerrarFormulario(activeForm);
                HideSubMenu();
            }
        }

    }

}
