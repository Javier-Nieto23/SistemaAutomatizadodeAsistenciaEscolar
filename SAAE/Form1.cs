using SAAE.methods;
using System;
using System.Windows.Forms;

namespace SAAE
{
    public partial class Form1 : Form
    {
        private readonly AuthenticationService _authService;

        public Form1()
        {
            InitializeComponent();
            _authService = new AuthenticationService();

            this.StartPosition = FormStartPosition.CenterScreen;

            textBox2.PasswordChar = '*';
            textBox2.UseSystemPasswordChar = true;

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text.Trim();
                string password = textBox2.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Por favor, ingrese usuario y contraseña.", 
                                  "Campos vacíos", 
                                  MessageBoxButtons.OK, 
                                  MessageBoxIcon.Warning);
                    return;
                }

                if (_authService.ValidateUser(username, password))
                {
                    this.Hide();

                    Cargando loadingForm = new Cargando(username);
                    DialogResult result = loadingForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        PanelFormulario panelForm = new PanelFormulario(username);
                        panelForm.Show();
                    }
                    else
                    {
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", 
                                  "Error de autenticación", 
                                  MessageBoxButtons.OK, 
                                  MessageBoxIcon.Error);
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar sesión: {ex.Message}", 
                              "Error", 
                              MessageBoxButtons.OK, 
                              MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea salir del sistema?", 
                                                 "Confirmar salida", 
                                                 MessageBoxButtons.YesNo, 
                                                 MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
