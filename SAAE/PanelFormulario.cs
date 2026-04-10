using System;
using System.Drawing;
using System.Windows.Forms;

namespace SAAE
{
    public partial class PanelFormulario : Form
    {
        private string _currentUser;
        private Form _activeForm;
        private Panel _contentPanel;
        private bool _isClosing = false;

        public PanelFormulario(string username)
        {
            InitializeComponent();
            _currentUser = username;

            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeContentPanel();

            button8.Click += Button8_Click;

            this.Resize += PanelFormulario_Resize;
            this.Load += PanelFormulario_Load;
            this.FormClosing += PanelFormulario_FormClosing;
        }

        private void InitializeContentPanel()
        {
            _contentPanel = new Panel
            {
                Name = "contentPanel",
                BackColor = Color.FromArgb(245, 247, 250),
                Dock = DockStyle.Fill
            };

            this.Controls.Add(_contentPanel);
            _contentPanel.SendToBack();
        }

        private void PanelFormulario_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Dashboard());
        }

        private void OpenChildForm(Form childForm)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            _contentPanel.Controls.Clear();
            _contentPanel.Controls.Add(childForm);
            _contentPanel.Tag = childForm;

            childForm.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            CloseSession();
        }

        private void CloseSession()
        {
            if (_isClosing)
                return;

            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea cerrar la sesión?",
                "Confirmar cierre de sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                _isClosing = true;
                Application.Exit();
            }
        }

        private void PanelFormulario_Resize(object sender, EventArgs e)
        {
            if (label5 != null)
            {
                label5.Location = new Point(this.ClientSize.Width - label5.Width - 10, 
                                           this.ClientSize.Height - label5.Height - 10);
            }

            if (_activeForm != null && _contentPanel != null)
            {
                AdjustChildFormControls(_activeForm);
            }
        }

        private void AdjustChildFormControls(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (control.Dock == DockStyle.Fill || control.Dock == DockStyle.None)
                {
                    if (control.Anchor == AnchorStyles.None)
                    {
                        control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    }
                }
            }
        }

        private void PanelFormulario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isClosing)
                return;

            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea cerrar la sesión?",
                "Confirmar cierre de sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                _isClosing = true;
                Application.Exit();
            }
        }

        public void ShowDashboard()
        {
            OpenChildForm(new Dashboard());
        }
    }
}
