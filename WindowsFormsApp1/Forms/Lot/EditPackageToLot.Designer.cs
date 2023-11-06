namespace WindowsFormsApp1.Forms.Lot
{
    partial class EditPackageToLot
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.input_lote = new System.Windows.Forms.TextBox();
            this.input_paquete = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lbl_id_almacen = new System.Windows.Forms.Label();
            this.lbl_id_externo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 65);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Poppins SemiBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(369, 65);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Editar paquete";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.input_lote);
            this.panel3.Controls.Add(this.input_paquete);
            this.panel3.Controls.Add(this.btnSubmit);
            this.panel3.Controls.Add(this.lbl_id_almacen);
            this.panel3.Controls.Add(this.lbl_id_externo);
            this.panel3.Location = new System.Drawing.Point(23, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 152);
            this.panel3.TabIndex = 0;
            // 
            // input_lote
            // 
            this.input_lote.Location = new System.Drawing.Point(6, 66);
            this.input_lote.Name = "input_lote";
            this.input_lote.Size = new System.Drawing.Size(285, 20);
            this.input_lote.TabIndex = 20;
            // 
            // input_paquete
            // 
            this.input_paquete.Location = new System.Drawing.Point(5, 17);
            this.input_paquete.Name = "input_paquete";
            this.input_paquete.Size = new System.Drawing.Size(285, 20);
            this.input_paquete.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(5, 108);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(285, 38);
            this.btnSubmit.TabIndex = 19;
            this.btnSubmit.Text = "Editar paquete";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbl_id_almacen
            // 
            this.lbl_id_almacen.AutoSize = true;
            this.lbl_id_almacen.Enabled = false;
            this.lbl_id_almacen.Location = new System.Drawing.Point(3, 48);
            this.lbl_id_almacen.Name = "lbl_id_almacen";
            this.lbl_id_almacen.Size = new System.Drawing.Size(42, 13);
            this.lbl_id_almacen.TabIndex = 6;
            this.lbl_id_almacen.Text = "ID Lote";
            // 
            // lbl_id_externo
            // 
            this.lbl_id_externo.AutoSize = true;
            this.lbl_id_externo.Location = new System.Drawing.Point(3, 1);
            this.lbl_id_externo.Name = "lbl_id_externo";
            this.lbl_id_externo.Size = new System.Drawing.Size(61, 13);
            this.lbl_id_externo.TabIndex = 3;
            this.lbl_id_externo.Text = "ID Paquete";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 213);
            this.panel2.TabIndex = 1;
            // 
            // EditPackageToLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 296);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(385, 335);
            this.MinimumSize = new System.Drawing.Size(385, 335);
            this.Name = "EditPackageToLot";
            this.Text = "Editar paquete";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_id_almacen;
        private System.Windows.Forms.Label lbl_id_externo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox input_lote;
        private System.Windows.Forms.TextBox input_paquete;
    }
}