namespace Consumo_de_APIs
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
            btnConsultar = new Button();
            txtLugar = new TextBox();
            lblNombreLugar = new Label();
            lblCoordenadas = new Label();
            lblClima = new Label();
            pictureBoxMapa = new PictureBox();
            btnLimpiar = new Button();
            btnguardar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMapa).BeginInit();
            SuspendLayout();
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(343, 392);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(75, 23);
            btnConsultar.TabIndex = 0;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // txtLugar
            // 
            txtLugar.Location = new Point(307, 334);
            txtLugar.Name = "txtLugar";
            txtLugar.Size = new Size(163, 23);
            txtLugar.TabIndex = 1;
            txtLugar.TextChanged += txtLugar_TextChanged;
            // 
            // lblNombreLugar
            // 
            lblNombreLugar.AutoSize = true;
            lblNombreLugar.Location = new Point(58, 105);
            lblNombreLugar.Name = "lblNombreLugar";
            lblNombreLugar.Size = new Size(0, 15);
            lblNombreLugar.TabIndex = 2;
            // 
            // lblCoordenadas
            // 
            lblCoordenadas.AutoSize = true;
            lblCoordenadas.Location = new Point(58, 156);
            lblCoordenadas.Name = "lblCoordenadas";
            lblCoordenadas.Size = new Size(0, 15);
            lblCoordenadas.TabIndex = 3;
            // 
            // lblClima
            // 
            lblClima.AutoSize = true;
            lblClima.Location = new Point(365, 290);
            lblClima.Name = "lblClima";
            lblClima.Size = new Size(0, 15);
            lblClima.TabIndex = 4;
            lblClima.Click += lblClima_Click;
            // 
            // pictureBoxMapa
            // 
            pictureBoxMapa.Location = new Point(206, 30);
            pictureBoxMapa.Name = "pictureBoxMapa";
            pictureBoxMapa.Size = new Size(364, 242);
            pictureBoxMapa.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMapa.TabIndex = 5;
            pictureBoxMapa.TabStop = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(696, 401);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnguardar
            // 
            btnguardar.Location = new Point(26, 401);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(75, 23);
            btnguardar.TabIndex = 7;
            btnguardar.Text = "Guardar";
            btnguardar.UseVisualStyleBackColor = true;
            btnguardar.Click += btnguardar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnguardar);
            Controls.Add(btnLimpiar);
            Controls.Add(pictureBoxMapa);
            Controls.Add(lblClima);
            Controls.Add(lblCoordenadas);
            Controls.Add(lblNombreLugar);
            Controls.Add(txtLugar);
            Controls.Add(btnConsultar);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxMapa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConsultar;
        private TextBox txtLugar;
        private Label lblNombreLugar;
        private Label lblCoordenadas;
        private Label lblClima;
        private PictureBox pictureBoxMapa;
        private Button btnLimpiar;
        private Button btnguardar;
    }
}
