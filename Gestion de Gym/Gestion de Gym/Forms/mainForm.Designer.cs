namespace Gestion_de_Gym.Forms
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.actualizar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.Pago = new Bunifu.Framework.UI.BunifuThinButton2();
            this.agregar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.Lista = new Bunifu.Framework.UI.BunifuThinButton2();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AgregarUsuario = new Bunifu.Framework.UI.BunifuThinButton2();
            this.labelFechaYHora = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.actualizar);
            this.panel1.Controls.Add(this.Pago);
            this.panel1.Controls.Add(this.agregar);
            this.panel1.Controls.Add(this.Lista);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 52);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Gestion_de_Gym.Properties.Resources.icons8_pesa_64;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(84, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // actualizar
            // 
            this.actualizar.ActiveBorderThickness = 1;
            this.actualizar.ActiveCornerRadius = 20;
            this.actualizar.ActiveFillColor = System.Drawing.Color.Crimson;
            this.actualizar.ActiveForecolor = System.Drawing.Color.White;
            this.actualizar.ActiveLineColor = System.Drawing.Color.Crimson;
            this.actualizar.BackColor = System.Drawing.SystemColors.Control;
            this.actualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("actualizar.BackgroundImage")));
            this.actualizar.ButtonText = "Actualizar/Eliminar";
            this.actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actualizar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualizar.ForeColor = System.Drawing.Color.SeaGreen;
            this.actualizar.IdleBorderThickness = 1;
            this.actualizar.IdleCornerRadius = 30;
            this.actualizar.IdleFillColor = System.Drawing.Color.White;
            this.actualizar.IdleForecolor = System.Drawing.Color.Crimson;
            this.actualizar.IdleLineColor = System.Drawing.Color.White;
            this.actualizar.Location = new System.Drawing.Point(313, 5);
            this.actualizar.Margin = new System.Windows.Forms.Padding(5);
            this.actualizar.Name = "actualizar";
            this.actualizar.Size = new System.Drawing.Size(164, 42);
            this.actualizar.TabIndex = 2;
            this.actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.actualizar.Click += new System.EventHandler(this.actualizar_Click);
            // 
            // Pago
            // 
            this.Pago.ActiveBorderThickness = 1;
            this.Pago.ActiveCornerRadius = 20;
            this.Pago.ActiveFillColor = System.Drawing.Color.Crimson;
            this.Pago.ActiveForecolor = System.Drawing.Color.White;
            this.Pago.ActiveLineColor = System.Drawing.Color.Crimson;
            this.Pago.BackColor = System.Drawing.SystemColors.Control;
            this.Pago.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Pago.BackgroundImage")));
            this.Pago.ButtonText = "Pago";
            this.Pago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pago.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pago.ForeColor = System.Drawing.Color.SeaGreen;
            this.Pago.IdleBorderThickness = 1;
            this.Pago.IdleCornerRadius = 30;
            this.Pago.IdleFillColor = System.Drawing.Color.White;
            this.Pago.IdleForecolor = System.Drawing.Color.Crimson;
            this.Pago.IdleLineColor = System.Drawing.Color.White;
            this.Pago.Location = new System.Drawing.Point(633, 5);
            this.Pago.Margin = new System.Windows.Forms.Padding(5);
            this.Pago.Name = "Pago";
            this.Pago.Size = new System.Drawing.Size(154, 42);
            this.Pago.TabIndex = 4;
            this.Pago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Pago.Click += new System.EventHandler(this.Pago_Click);
            // 
            // agregar
            // 
            this.agregar.ActiveBorderThickness = 1;
            this.agregar.ActiveCornerRadius = 20;
            this.agregar.ActiveFillColor = System.Drawing.Color.Crimson;
            this.agregar.ActiveForecolor = System.Drawing.Color.White;
            this.agregar.ActiveLineColor = System.Drawing.Color.Crimson;
            this.agregar.BackColor = System.Drawing.SystemColors.Control;
            this.agregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("agregar.BackgroundImage")));
            this.agregar.ButtonText = "Agregar Miembro";
            this.agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.agregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregar.ForeColor = System.Drawing.Color.SeaGreen;
            this.agregar.IdleBorderThickness = 1;
            this.agregar.IdleCornerRadius = 30;
            this.agregar.IdleFillColor = System.Drawing.Color.White;
            this.agregar.IdleForecolor = System.Drawing.Color.Crimson;
            this.agregar.IdleLineColor = System.Drawing.Color.White;
            this.agregar.Location = new System.Drawing.Point(149, 5);
            this.agregar.Margin = new System.Windows.Forms.Padding(5);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(154, 42);
            this.agregar.TabIndex = 5;
            this.agregar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.agregar.Click += new System.EventHandler(this.agregar_Click);
            // 
            // Lista
            // 
            this.Lista.ActiveBorderThickness = 1;
            this.Lista.ActiveCornerRadius = 20;
            this.Lista.ActiveFillColor = System.Drawing.Color.Crimson;
            this.Lista.ActiveForecolor = System.Drawing.Color.White;
            this.Lista.ActiveLineColor = System.Drawing.Color.Crimson;
            this.Lista.BackColor = System.Drawing.SystemColors.Control;
            this.Lista.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Lista.BackgroundImage")));
            this.Lista.ButtonText = "Lista";
            this.Lista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Lista.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lista.ForeColor = System.Drawing.Color.SeaGreen;
            this.Lista.IdleBorderThickness = 1;
            this.Lista.IdleCornerRadius = 30;
            this.Lista.IdleFillColor = System.Drawing.Color.White;
            this.Lista.IdleForecolor = System.Drawing.Color.Crimson;
            this.Lista.IdleLineColor = System.Drawing.Color.White;
            this.Lista.Location = new System.Drawing.Point(487, 5);
            this.Lista.Margin = new System.Windows.Forms.Padding(5);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(136, 42);
            this.Lista.TabIndex = 3;
            this.Lista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lista.Click += new System.EventHandler(this.Lista_Click);
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Enabled = false;
            this.textBoxUsuario.Location = new System.Drawing.Point(12, 58);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(153, 20);
            this.textBoxUsuario.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Gestion_de_Gym.Properties.Resources.cabecera_diseno_integral_gimnasio_s;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AgregarUsuario
            // 
            this.AgregarUsuario.ActiveBorderThickness = 1;
            this.AgregarUsuario.ActiveCornerRadius = 20;
            this.AgregarUsuario.ActiveFillColor = System.Drawing.Color.Crimson;
            this.AgregarUsuario.ActiveForecolor = System.Drawing.Color.White;
            this.AgregarUsuario.ActiveLineColor = System.Drawing.Color.Crimson;
            this.AgregarUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.AgregarUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AgregarUsuario.BackgroundImage")));
            this.AgregarUsuario.ButtonText = "Agregar Usuario";
            this.AgregarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AgregarUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarUsuario.ForeColor = System.Drawing.Color.SeaGreen;
            this.AgregarUsuario.IdleBorderThickness = 1;
            this.AgregarUsuario.IdleCornerRadius = 30;
            this.AgregarUsuario.IdleFillColor = System.Drawing.Color.White;
            this.AgregarUsuario.IdleForecolor = System.Drawing.Color.Crimson;
            this.AgregarUsuario.IdleLineColor = System.Drawing.Color.White;
            this.AgregarUsuario.Location = new System.Drawing.Point(641, 394);
            this.AgregarUsuario.Margin = new System.Windows.Forms.Padding(5);
            this.AgregarUsuario.Name = "AgregarUsuario";
            this.AgregarUsuario.Size = new System.Drawing.Size(154, 42);
            this.AgregarUsuario.TabIndex = 9;
            this.AgregarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AgregarUsuario.Click += new System.EventHandler(this.AgregarUsuario_Click);
            // 
            // labelFechaYHora
            // 
            this.labelFechaYHora.Enabled = false;
            this.labelFechaYHora.Location = new System.Drawing.Point(583, 58);
            this.labelFechaYHora.Name = "labelFechaYHora";
            this.labelFechaYHora.Size = new System.Drawing.Size(212, 20);
            this.labelFechaYHora.TabIndex = 10;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelFechaYHora);
            this.Controls.Add(this.AgregarUsuario);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 actualizar;
        private Bunifu.Framework.UI.BunifuThinButton2 Lista;
        private Bunifu.Framework.UI.BunifuThinButton2 Pago;
        private Bunifu.Framework.UI.BunifuThinButton2 agregar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private Bunifu.Framework.UI.BunifuThinButton2 AgregarUsuario;
        private System.Windows.Forms.TextBox labelFechaYHora;
    }
}