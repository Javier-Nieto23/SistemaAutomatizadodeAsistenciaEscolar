using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAAE
{
    public partial class Cargando : Form
    {
        private string _username;
        private List<string> _loadingItems;
        private int _currentProgress;

        public Cargando(string username)
        {
            InitializeComponent();
            _username = username;

            // Configuración de la ventana
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;

            // Configuración del label
            label1.Text = "Iniciando sistema...";
            label1.ForeColor = Color.FromArgb(64, 64, 64);

            _currentProgress = 0;

            InitializeLoadingItems();
        }

        // Inicializa la lista de mensajes de carga
        private void InitializeLoadingItems()
        {
            _loadingItems = new List<string>
            {
                "Cargando configuración del sistema...",
                "Conectando a base de datos...",
                "Validando permisos de usuario...",
                "Cargando módulo de asistencia...",
                "Cargando módulo de participación...",
                "Cargando módulo de alumnos...",
                "Cargando módulo de actividades...",
                "Cargando módulo de tareas...",
                "Inicializando interfaz principal...",
                "Preparando dashboard...",
                "¡Sistema listo!"
            };
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await SimulateLoading();
        }

        private async Task SimulateLoading()
        {
            int totalItems = _loadingItems.Count;

            for (int i = 0; i < totalItems; i++)
            {
                label1.Text = _loadingItems[i];
                label1.Refresh();

                _currentProgress = (int)((i + 1) * 100.0 / totalItems);

                int delay = i == totalItems - 1 ? 800 : 250;
                await Task.Delay(delay);
            }

            await Task.Delay(300);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cargando_Load(object sender, EventArgs e)
        {

        }
    }
}
