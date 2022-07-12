
namespace sysdemo
{
    partial class FrmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu01 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu0101 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu0102 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu02 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu0201 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu03 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu0301 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu0302 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu04 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu0401 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu05 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu0501 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu06 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu0601 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu0602 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu0603 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu0604 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.año = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu01,
            this.menu02,
            this.menu03,
            this.menu04,
            this.menu05,
            this.menu06});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu01
            // 
            this.menu01.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu0101,
            this.menu0102});
            this.menu01.Name = "menu01";
            this.menu01.Size = new System.Drawing.Size(52, 23);
            this.menu01.Text = "Citas";
            // 
            // menu0101
            // 
            this.menu0101.Name = "menu0101";
            this.menu0101.Size = new System.Drawing.Size(190, 24);
            this.menu0101.Text = "Registro de Citas";
            // 
            // menu0102
            // 
            this.menu0102.Name = "menu0102";
            this.menu0102.Size = new System.Drawing.Size(190, 24);
            this.menu0102.Text = "Estadistica de Cita";
            // 
            // menu02
            // 
            this.menu02.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu0201});
            this.menu02.Name = "menu02";
            this.menu02.Size = new System.Drawing.Size(72, 23);
            this.menu02.Text = "Paciente";
            // 
            // menu0201
            // 
            this.menu0201.Name = "menu0201";
            this.menu0201.Size = new System.Drawing.Size(202, 24);
            this.menu0201.Text = "Historia del Paciente";
            // 
            // menu03
            // 
            this.menu03.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu0301,
            this.menu0302});
            this.menu03.Name = "menu03";
            this.menu03.Size = new System.Drawing.Size(68, 23);
            this.menu03.Text = "Médico";
            // 
            // menu0301
            // 
            this.menu0301.Name = "menu0301";
            this.menu0301.Size = new System.Drawing.Size(232, 24);
            this.menu0301.Text = "Registro de Médico";
            this.menu0301.Click += new System.EventHandler(this.menu0301_Click);
            // 
            // menu0302
            // 
            this.menu0302.Name = "menu0302";
            this.menu0302.Size = new System.Drawing.Size(232, 24);
            this.menu0302.Text = "Programación de Médico";
            // 
            // menu04
            // 
            this.menu04.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu0401});
            this.menu04.Name = "menu04";
            this.menu04.Size = new System.Drawing.Size(111, 23);
            this.menu04.Text = "Comprobantes";
            // 
            // menu0401
            // 
            this.menu0401.Name = "menu0401";
            this.menu0401.Size = new System.Drawing.Size(162, 24);
            this.menu0401.Text = "Comprobante";
            // 
            // menu05
            // 
            this.menu05.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu0501});
            this.menu05.Name = "menu05";
            this.menu05.Size = new System.Drawing.Size(77, 23);
            this.menu05.Text = "Farmacia";
            // 
            // menu0501
            // 
            this.menu0501.Name = "menu0501";
            this.menu0501.Size = new System.Drawing.Size(180, 24);
            this.menu0501.Text = "Listado de Guías";
            this.menu0501.Click += new System.EventHandler(this.menu0501_Click);
            // 
            // menu06
            // 
            this.menu06.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu0601,
            this.menu0602,
            this.menu0603,
            this.menu0604});
            this.menu06.Name = "menu06";
            this.menu06.Size = new System.Drawing.Size(116, 23);
            this.menu06.Text = "Mantenimientos";
            // 
            // menu0601
            // 
            this.menu0601.Name = "menu0601";
            this.menu0601.Size = new System.Drawing.Size(154, 24);
            this.menu0601.Text = "Especialidad";
            this.menu0601.Click += new System.EventHandler(this.menu0601_Click);
            // 
            // menu0602
            // 
            this.menu0602.Name = "menu0602";
            this.menu0602.Size = new System.Drawing.Size(154, 24);
            this.menu0602.Text = "Consultorio";
            // 
            // menu0603
            // 
            this.menu0603.Name = "menu0603";
            this.menu0603.Size = new System.Drawing.Size(154, 24);
            this.menu0603.Text = "Distrito";
            // 
            // menu0604
            // 
            this.menu0604.Name = "menu0604";
            this.menu0604.Size = new System.Drawing.Size(154, 24);
            this.menu0604.Text = "Producto";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.año});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // año
            // 
            this.año.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.año.Name = "año";
            this.año.Size = new System.Drawing.Size(118, 17);
            this.año.Text = "toolStripStatusLabel1";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.Text = "FrmMenu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu01;
        private System.Windows.Forms.ToolStripMenuItem menu0101;
        private System.Windows.Forms.ToolStripMenuItem menu0102;
        private System.Windows.Forms.ToolStripMenuItem menu02;
        private System.Windows.Forms.ToolStripMenuItem menu0201;
        private System.Windows.Forms.ToolStripMenuItem menu03;
        private System.Windows.Forms.ToolStripMenuItem menu0301;
        private System.Windows.Forms.ToolStripMenuItem menu0302;
        private System.Windows.Forms.ToolStripMenuItem menu04;
        private System.Windows.Forms.ToolStripMenuItem menu0401;
        private System.Windows.Forms.ToolStripMenuItem menu05;
        private System.Windows.Forms.ToolStripMenuItem menu0501;
        private System.Windows.Forms.ToolStripMenuItem menu06;
        private System.Windows.Forms.ToolStripMenuItem menu0601;
        private System.Windows.Forms.ToolStripMenuItem menu0602;
        private System.Windows.Forms.ToolStripMenuItem menu0603;
        private System.Windows.Forms.ToolStripMenuItem menu0604;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel año;
    }
}