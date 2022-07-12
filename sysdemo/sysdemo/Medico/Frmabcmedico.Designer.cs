
namespace sysdemo.Medico
{
    partial class Frmabcmedico
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
            this.label1 = new System.Windows.Forms.Label();
            this.LblOpcion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LblId = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtapellidos = new System.Windows.Forms.TextBox();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.txtcolegiatura = new System.Windows.Forms.TextBox();
            this.txtmovil = new System.Windows.Forms.TextBox();
            this.btngrabar = new System.Windows.Forms.Button();
            this.btncancelar = new System.Windows.Forms.Button();
            this.cboEspecialidad1 = new sysdemo.Cusuario.CboEspecialidad();
            this.cboDistrito1 = new sysdemo.Cusuario.CboDistrito();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Médicos";
            // 
            // LblOpcion
            // 
            this.LblOpcion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LblOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOpcion.Location = new System.Drawing.Point(191, 59);
            this.LblOpcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblOpcion.Name = "LblOpcion";
            this.LblOpcion.Size = new System.Drawing.Size(103, 26);
            this.LblOpcion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Id Médico:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 186);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Apellidos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 224);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "D.N.I.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 263);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Distrito:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 309);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Especialidad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 352);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Nro. Colegiatura:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 383);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Movil:";
            // 
            // LblId
            // 
            this.LblId.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LblId.Location = new System.Drawing.Point(160, 110);
            this.LblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(133, 28);
            this.LblId.TabIndex = 10;
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(160, 146);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(176, 22);
            this.txtnombre.TabIndex = 11;
            // 
            // txtapellidos
            // 
            this.txtapellidos.Location = new System.Drawing.Point(160, 186);
            this.txtapellidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtapellidos.Name = "txtapellidos";
            this.txtapellidos.Size = new System.Drawing.Size(224, 22);
            this.txtapellidos.TabIndex = 12;
            // 
            // txtdni
            // 
            this.txtdni.Location = new System.Drawing.Point(160, 224);
            this.txtdni.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(132, 22);
            this.txtdni.TabIndex = 13;
            // 
            // txtcolegiatura
            // 
            this.txtcolegiatura.Location = new System.Drawing.Point(160, 343);
            this.txtcolegiatura.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtcolegiatura.Name = "txtcolegiatura";
            this.txtcolegiatura.Size = new System.Drawing.Size(132, 22);
            this.txtcolegiatura.TabIndex = 14;
            // 
            // txtmovil
            // 
            this.txtmovil.Location = new System.Drawing.Point(160, 383);
            this.txtmovil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtmovil.Name = "txtmovil";
            this.txtmovil.Size = new System.Drawing.Size(132, 22);
            this.txtmovil.TabIndex = 15;
            // 
            // btngrabar
            // 
            this.btngrabar.Location = new System.Drawing.Point(47, 455);
            this.btngrabar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btngrabar.Name = "btngrabar";
            this.btngrabar.Size = new System.Drawing.Size(100, 28);
            this.btngrabar.TabIndex = 16;
            this.btngrabar.Text = "Grabar";
            this.btngrabar.UseVisualStyleBackColor = true;
            this.btngrabar.Click += new System.EventHandler(this.btngrabar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.Location = new System.Drawing.Point(316, 455);
            this.btncancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(100, 28);
            this.btncancelar.TabIndex = 17;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            // 
            // cboEspecialidad1
            // 
            this.cboEspecialidad1.Location = new System.Drawing.Point(155, 297);
            this.cboEspecialidad1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cboEspecialidad1.Name = "cboEspecialidad1";
            this.cboEspecialidad1.Size = new System.Drawing.Size(195, 39);
            this.cboEspecialidad1.TabIndex = 19;
            // 
            // cboDistrito1
            // 
            this.cboDistrito1.Location = new System.Drawing.Point(157, 257);
            this.cboDistrito1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cboDistrito1.Name = "cboDistrito1";
            this.cboDistrito1.Size = new System.Drawing.Size(175, 32);
            this.cboDistrito1.TabIndex = 18;
            // 
            // Frmabcmedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 510);
            this.Controls.Add(this.cboEspecialidad1);
            this.Controls.Add(this.cboDistrito1);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btngrabar);
            this.Controls.Add(this.txtmovil);
            this.Controls.Add(this.txtcolegiatura);
            this.Controls.Add(this.txtdni);
            this.Controls.Add(this.txtapellidos);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.LblId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblOpcion);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frmabcmedico";
            this.Text = "Registro de Médico";
            this.Load += new System.EventHandler(this.Frmabcmedico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label LblOpcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label LblId;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtapellidos;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.TextBox txtcolegiatura;
        private System.Windows.Forms.TextBox txtmovil;
        public System.Windows.Forms.Button btngrabar;
        private System.Windows.Forms.Button btncancelar;
        private Cusuario.CboDistrito cboDistrito1;
        private Cusuario.CboEspecialidad cboEspecialidad1;
    }
}