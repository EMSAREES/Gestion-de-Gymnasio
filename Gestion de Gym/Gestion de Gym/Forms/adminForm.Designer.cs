namespace Gestion_de_Gym.Forms
{
    partial class adminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminForm));
            this.btnClose = new System.Windows.Forms.Label();
            this.AgregarUsuario = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.agregarPlanBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(400, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(39, 38);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AgregarUsuario
            // 
            this.AgregarUsuario.ActiveBorderThickness = 1;
            this.AgregarUsuario.ActiveCornerRadius = 20;
            this.AgregarUsuario.ActiveFillColor = System.Drawing.Color.Crimson;
            this.AgregarUsuario.ActiveForecolor = System.Drawing.Color.White;
            this.AgregarUsuario.ActiveLineColor = System.Drawing.Color.Crimson;
            this.AgregarUsuario.BackColor = System.Drawing.Color.LightGray;
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
            this.AgregarUsuario.Location = new System.Drawing.Point(25, 88);
            this.AgregarUsuario.Margin = new System.Windows.Forms.Padding(5);
            this.AgregarUsuario.Name = "AgregarUsuario";
            this.AgregarUsuario.Size = new System.Drawing.Size(154, 116);
            this.AgregarUsuario.TabIndex = 52;
            this.AgregarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AgregarUsuario.Click += new System.EventHandler(this.AgregarUsuario_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(135, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 28);
            this.label1.TabIndex = 53;
            this.label1.Text = "FITNESS CENTER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(181, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 30);
            this.label2.TabIndex = 54;
            this.label2.Text = "Admin";
            // 
            // agregarPlanBtn
            // 
            this.agregarPlanBtn.ActiveBorderThickness = 1;
            this.agregarPlanBtn.ActiveCornerRadius = 20;
            this.agregarPlanBtn.ActiveFillColor = System.Drawing.Color.Crimson;
            this.agregarPlanBtn.ActiveForecolor = System.Drawing.Color.White;
            this.agregarPlanBtn.ActiveLineColor = System.Drawing.Color.Crimson;
            this.agregarPlanBtn.BackColor = System.Drawing.Color.LightGray;
            this.agregarPlanBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("agregarPlanBtn.BackgroundImage")));
            this.agregarPlanBtn.ButtonText = "Agregar Plan";
            this.agregarPlanBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.agregarPlanBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarPlanBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.agregarPlanBtn.IdleBorderThickness = 1;
            this.agregarPlanBtn.IdleCornerRadius = 30;
            this.agregarPlanBtn.IdleFillColor = System.Drawing.Color.White;
            this.agregarPlanBtn.IdleForecolor = System.Drawing.Color.Crimson;
            this.agregarPlanBtn.IdleLineColor = System.Drawing.Color.White;
            this.agregarPlanBtn.Location = new System.Drawing.Point(269, 88);
            this.agregarPlanBtn.Margin = new System.Windows.Forms.Padding(5);
            this.agregarPlanBtn.Name = "agregarPlanBtn";
            this.agregarPlanBtn.Size = new System.Drawing.Size(154, 116);
            this.agregarPlanBtn.TabIndex = 55;
            this.agregarPlanBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.agregarPlanBtn.Click += new System.EventHandler(this.agregarPlanBtn_Click);
            // 
            // adminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(451, 218);
            this.Controls.Add(this.agregarPlanBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AgregarUsuario);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "adminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btnClose;
        private Bunifu.Framework.UI.BunifuThinButton2 AgregarUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuThinButton2 agregarPlanBtn;
    }
}