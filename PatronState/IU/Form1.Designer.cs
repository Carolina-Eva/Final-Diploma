namespace IU
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCosechar = new Button();
            btnPlantar = new Button();
            btnRegar = new Button();
            flpParcelas = new FlowLayoutPanel();
            lblTotalCosechas = new Label();
            dgvCosechas = new DataGridView();
            lblSeleccionada = new Label();
            lblEstado = new Label();
            picLogo = new PictureBox();
            picLogo2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvCosechas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo2).BeginInit();
            SuspendLayout();
            // 
            // btnCosechar
            // 
            btnCosechar.Location = new Point(243, 387);
            btnCosechar.Name = "btnCosechar";
            btnCosechar.Size = new Size(75, 42);
            btnCosechar.TabIndex = 0;
            btnCosechar.Text = "Cosechar";
            btnCosechar.UseVisualStyleBackColor = true;
            btnCosechar.Click += btnCosechar_Click;
            // 
            // btnPlantar
            // 
            btnPlantar.Location = new Point(150, 387);
            btnPlantar.Name = "btnPlantar";
            btnPlantar.Size = new Size(77, 42);
            btnPlantar.TabIndex = 0;
            btnPlantar.Text = "Plantar";
            btnPlantar.UseVisualStyleBackColor = true;
            btnPlantar.Click += btnPlantar_Click;
            // 
            // btnRegar
            // 
            btnRegar.Location = new Point(55, 387);
            btnRegar.Name = "btnRegar";
            btnRegar.Size = new Size(78, 42);
            btnRegar.TabIndex = 0;
            btnRegar.Text = "Regar";
            btnRegar.UseVisualStyleBackColor = true;
            btnRegar.Click += btnRegar_Click;
            // 
            // flpParcelas
            // 
            flpParcelas.Location = new Point(55, 154);
            flpParcelas.Name = "flpParcelas";
            flpParcelas.Size = new Size(378, 215);
            flpParcelas.TabIndex = 1;
            // 
            // lblTotalCosechas
            // 
            lblTotalCosechas.AutoSize = true;
            lblTotalCosechas.Location = new Point(459, 354);
            lblTotalCosechas.Name = "lblTotalCosechas";
            lblTotalCosechas.Size = new Size(38, 15);
            lblTotalCosechas.TabIndex = 2;
            lblTotalCosechas.Text = "label1";
            // 
            // dgvCosechas
            // 
            dgvCosechas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCosechas.Location = new Point(459, 154);
            dgvCosechas.Name = "dgvCosechas";
            dgvCosechas.Size = new Size(279, 194);
            dgvCosechas.TabIndex = 3;
            // 
            // lblSeleccionada
            // 
            lblSeleccionada.AutoSize = true;
            lblSeleccionada.Location = new Point(346, 387);
            lblSeleccionada.Name = "lblSeleccionada";
            lblSeleccionada.Size = new Size(48, 15);
            lblSeleccionada.TabIndex = 4;
            lblSeleccionada.Text = "Parcela:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(346, 414);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 5;
            lblEstado.Text = "Estado:";
            // 
            // picLogo
            // 
            picLogo.Location = new Point(105, 12);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(245, 129);
            picLogo.TabIndex = 6;
            picLogo.TabStop = false;
            // 
            // picLogo2
            // 
            picLogo2.Location = new Point(471, 12);
            picLogo2.Name = "picLogo2";
            picLogo2.Size = new Size(258, 129);
            picLogo2.TabIndex = 7;
            picLogo2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(picLogo2);
            Controls.Add(picLogo);
            Controls.Add(lblEstado);
            Controls.Add(lblSeleccionada);
            Controls.Add(dgvCosechas);
            Controls.Add(lblTotalCosechas);
            Controls.Add(flpParcelas);
            Controls.Add(btnRegar);
            Controls.Add(btnPlantar);
            Controls.Add(btnCosechar);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCosechas).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCosechar;
        private Button btnPlantar;
        private Button btnRegar;
        private FlowLayoutPanel flpParcelas;
        private Label lblTotalCosechas;
        private DataGridView dgvCosechas;
        private Label lblSeleccionada;
        private Label lblEstado;
        private PictureBox picLogo;
        private PictureBox picLogo2;
    }
}
