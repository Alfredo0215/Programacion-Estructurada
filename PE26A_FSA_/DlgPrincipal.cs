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
using System.Globalization;

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
        private DateTime HoraActual;
        private string TextoBotonActual;
        bool sidePanelExpand = true;


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
            Helper.DrawHelper.RedondearBoton(PnlUsuario, 20);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;


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
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }
        //---------------------------------------------------------------------
        //Función que cierra el formulario abierto actualmente.
        //---------------------------------------------------------------------
        private void CerrarFormulario(Form formulario)
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
            ObtenerTextoControl(BtnHolaMundo);
            LblBotonAcrtual2.Text = "El punto de partida para construir nuevas soluciones.";
            var resultado = DialogResult.Yes;


            resultado = MessageBox.Show(
                "¿Está seguro de que desea salir del programa?", "Éxito", MessageBoxButtons.YesNo
                );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
            else

                if(activeForm != null)
                    CerrarFormulario(activeForm);

                DesactivarBoton();
                HideSubMenu();



        }

        //---------------------------------------------------------------------
        //Botón que invoca al formulario Calculadora.
        //---------------------------------------------------------------------
        private void BtnCalculadora1_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender, Colors.color2);
            AbrirFormularioHijo(new Calculadora());
            ObtenerTextoControl(BtnCalculadora);
            LblBotonAcrtual2.Text = "El inicio del pensamiento modular en programación.";

            HideSubMenu();
        }

        //---------------------------------------------------------------------
        //Botón que despliega el SubMenuMesas.
        //---------------------------------------------------------------------
        private void BtnMesasPracticas1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                CerrarFormulario(activeForm);
            ActivarBoton(sender, Colors.color3);
            LblBotonAcrtual2.Text = "Organizando el aprendizaje, una práctica a la vez.";
            ObtenerTextoControl(BtnMesasPracticas);
            ShowSubMenu(SubMenuMesas);

        }

        //-------------------------------------------------------------------------
        // Función que ejecuta la mesa de practicas 1
        //-------------------------------------------------------------------------
        private void MesaPracticas1_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new DlgMesaPracticas1());
            ObtenerTextoControl(new DlgMesaPracticas1());
            LblBotonAcrtual2.Text = "Organizar, recorrer y transformar información.";
            HideSubMenu();

        }

        private void MesaPracticas2_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new DlgMesaPracticas2());
            ObtenerTextoControl(new DlgMesaPracticas2());
            LblBotonAcrtual2.Text = "Una práctica donde la lógica también puede verse.";
            HideSubMenu();
        }

        private void MesaPracticas3_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new DlgMesaPracticas3());
            ObtenerTextoControl(new DlgMesaPracticas3());
            LblBotonAcrtual2.Text = "Un espacio reservado para las próximas ideas.";
            HideSubMenu();
        }

        private void MesaPracticas4_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new DlgMesaPracticas4());
            ObtenerTextoControl(new DlgMesaPracticas4());
            LblBotonAcrtual2.Text = "Un cierre que refleja evolución y experiencia.";
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
                //Icono del boton actual seleccionado
                IPbxBotonActual.IconChar = botonActual.IconChar;
                IPbxBotonActual.IconColor = botonActual.IconColor;
                
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
                //Panel
                leftBorderBtn.Hide();
                //Regresa el icono del titulo a "Home"
                IPbxBotonActual.IconChar = IconChar.Home;
                IPbxBotonActual.IconColor = Color.White;
                LblBotonActual.Text = "Home";
                LblBotonAcrtual2.Text = "Inicio";
            }
        }

        private void PbxHome_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                CerrarFormulario(activeForm);

            DesactivarBoton();
            HideSubMenu();


        }

        //Función que obtiene el texto del control actual
        private void ObtenerTextoControl(Control control)
        {
            if (control != null)
            {

                LblBotonActual.Text = control.Text;
            }
        }

        //---------------------------------------------------------------------
        //Par de funciones que permiten arrastrar la aplicación mediante el panel superior
        //---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void IPbxClose_Click(object sender, EventArgs e)
        {
            
            var resultado = DialogResult.Yes;


            resultado = MessageBox.Show(
                "¿Está seguro de que desea salir del programa?", "Éxito", MessageBoxButtons.YesNo
                );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
          



        }

        private void IPbxMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void IPbxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString("hh:mm:ss");

            LblFecha.Text = DateTime.Now.ToString("dddd dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES"));
        }

    }
}
    


