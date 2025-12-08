using BE;
using BLL;
using System.Diagnostics;

namespace IU
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Enunciado: Se desea simular un mini-juego de gestión de una granja, en el cual el jugador interactúa con distintas parcelas de tierra. Cada parcela puede encontrarse en varios estados, y dependiendo del estado actual, las acciones disponibles y los resultados posibles son diferentes.
        /// El propietario de la granja puede realizar tres acciones principales sobre una parcela: Plantar una semilla, Regar la tierra/semilla, Cosechar el cultivo
        /// La parcela debe cambiar de estado en función de las acciones realizadas por el jugador, cumpliendo el siguiente ciclo de crecimiento: 
        /// 1. TierraLibre: no hay cultivo; si el jugador planta, pasa al estado SemillaPlantada.
        /// 2. SemillaPlantada: si se riega por primera vez, pasa al estado Creciendo.
        /// 3. Creciendo: si se riega por segunda vez, pasa al estado ListaParaCosechar.
        /// 4. ListaParaCosechar: si el jugador cosecha, vuelve al estado TierraLibre.
        /// Cada estado debe definir su propio comportamiento ante las acciones Plantar, Regar y Cosechar, pudiendo permitirlas o ignorarlas según corresponda.No deben utilizarse estructuras condicionales extensas; la lógica debe organizarse utilizando el patrón de diseño State, delegando el comportamiento en clases concretas que representen cada estado.
        /// </summary>

        private Manager _manager = new Manager();
        private List<Parcela> _parcelas = new List<Parcela>();
        private Parcela _parcelaSeleccionada = new Parcela();
        private PictureBox _ultimoSeleccionado;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            picLogo.Image = Properties.Resources.logo;
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo2.Image = Properties.Resources.logo2;
            picLogo2.SizeMode = PictureBoxSizeMode.Zoom;

            await CargarParcelasAsync();
            await CargarMetricasAsync();
        }

        private async Task CargarMetricasAsync()
        {
            var total = await _manager.ObtenerTotalCosechasAsync();
            lblTotalCosechas.Text = $"Total cosechas: {total}";

            dgvCosechas.DataSource = null;
            dgvCosechas.DataSource = await _manager.ObtenerCosechasPorParcelaAsync();
            dgvCosechas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async Task CargarParcelasAsync()
        {
            flpParcelas.Controls.Clear();
            btnPlantar.Enabled = false;
            btnRegar.Enabled = false;
            btnCosechar.Enabled = false;

            _parcelas = await _manager.ListarParcelasAsync();

            foreach (var parcela in _parcelas)
            {
                PictureBox pb = new PictureBox
                {
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = parcela // guardamos la parcela
                };

                pb.Image = ObtenerImagenEstado(parcela);

                pb.Click += Pb_Click;

                flpParcelas.Controls.Add(pb);
            }
        }

        private Image ObtenerImagenEstado(Parcela p)
        {
            string estado = p.ObtenerNombreEstado();

            return estado switch
            {
                "TierraLibre" => Properties.Resources.tierra_libre,
                "SemillaPlantada" => Properties.Resources.semilla_plantada,
                "Creciendo" => Properties.Resources.creciendo,
                "ListaParaCosechar" => Properties.Resources.lista_para_cosechar,
                _ => Properties.Resources.tierra_libre
            };
        }

        private void Pb_Click(object? sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            var parcela = pb.Tag as Parcela;

            // Quitar selección previa
            if (_ultimoSeleccionado != null)
            {
                _ultimoSeleccionado.BorderStyle = BorderStyle.FixedSingle;
            }

            _parcelaSeleccionada = parcela;

            pb.BorderStyle = BorderStyle.Fixed3D;  // borde más grueso y hundido
            _ultimoSeleccionado = pb;

            lblSeleccionada.Text = $"Parcela: {parcela.Nombre}";
            lblEstado.Text = $"Estado: {parcela.ObtenerNombreEstado()}";

            ActualizarBotonesSegunEstado(parcela);
        }

        private void ActualizarBotonesSegunEstado(Parcela p)
        {
            string estado = p.ObtenerNombreEstado();

            btnPlantar.Enabled = (estado == "TierraLibre");
            btnRegar.Enabled = (estado == "SemillaPlantada" || estado == "Creciendo");
            btnCosechar.Enabled = (estado == "ListaParaCosechar");
        }

        private async void btnRegar_Click(object sender, EventArgs e)
        {
            if (_parcelaSeleccionada == null) return;

            _parcelaSeleccionada.Regar();
            await _manager.GuardarEstadoAsync(_parcelas);

            await CargarParcelasAsync();
            await CargarMetricasAsync();
        }

        private async void btnPlantar_Click(object sender, EventArgs e)
        {
            if (_parcelaSeleccionada == null) return;

            _parcelaSeleccionada.Plantar();
            await _manager.GuardarEstadoAsync(_parcelas);

            await CargarParcelasAsync();
            await CargarMetricasAsync();
        }

        private async void btnCosechar_Click(object sender, EventArgs e)
        {
            if (_parcelaSeleccionada == null) return;

            _parcelaSeleccionada.Cosechar();
            await _manager.GuardarEstadoAsync(_parcelas);

            await CargarParcelasAsync();
            await CargarMetricasAsync();
        }

    }
}
