namespace WindowsFormsApp1.Forms.User
{
    partial class CreateUser
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.inputNacionalidad = new System.Windows.Forms.ComboBox();
            this.inputRol = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblNacionalidad = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.inputDocumento = new System.Windows.Forms.TextBox();
            this.lblSApellido = new System.Windows.Forms.Label();
            this.inputSApellido = new System.Windows.Forms.TextBox();
            this.lblPApellido = new System.Windows.Forms.Label();
            this.inputPApellido = new System.Windows.Forms.TextBox();
            this.lblSNombre = new System.Windows.Forms.Label();
            this.inputSNombre = new System.Windows.Forms.TextBox();
            this.lblPNombre = new System.Windows.Forms.Label();
            this.inputPNombre = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.lblTitle.Text = "Crear usuario";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 428);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.btnSubmit);
            this.panel3.Controls.Add(this.inputNacionalidad);
            this.panel3.Controls.Add(this.inputRol);
            this.panel3.Controls.Add(this.lblRol);
            this.panel3.Controls.Add(this.lblNacionalidad);
            this.panel3.Controls.Add(this.lblDocumento);
            this.panel3.Controls.Add(this.inputDocumento);
            this.panel3.Controls.Add(this.lblSApellido);
            this.panel3.Controls.Add(this.inputSApellido);
            this.panel3.Controls.Add(this.lblPApellido);
            this.panel3.Controls.Add(this.inputPApellido);
            this.panel3.Controls.Add(this.lblSNombre);
            this.panel3.Controls.Add(this.inputSNombre);
            this.panel3.Controls.Add(this.lblPNombre);
            this.panel3.Controls.Add(this.inputPNombre);
            this.panel3.Location = new System.Drawing.Point(23, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 384);
            this.panel3.TabIndex = 0;
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
            this.btnSubmit.Location = new System.Drawing.Point(6, 340);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(285, 38);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Crear usuario";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // inputNacionalidad
            // 
            this.inputNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputNacionalidad.FormattingEnabled = true;
            this.inputNacionalidad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.inputNacionalidad.Items.AddRange(new object[] {
            "UYU",
            "ARG",
            "CHL",
            "BRA"});
            this.inputNacionalidad.Location = new System.Drawing.Point(6, 255);
            this.inputNacionalidad.Name = "inputNacionalidad";
            this.inputNacionalidad.Size = new System.Drawing.Size(285, 21);
            this.inputNacionalidad.TabIndex = 15;
            // 
            // inputRol
            // 
            this.inputRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputRol.FormattingEnabled = true;
            this.inputRol.Items.AddRange(new object[] {
            "Almacenero",
            "Camionero",
            "Administrador"});
            this.inputRol.Location = new System.Drawing.Point(6, 304);
            this.inputRol.Name = "inputRol";
            this.inputRol.Size = new System.Drawing.Size(285, 21);
            this.inputRol.TabIndex = 14;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(3, 287);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(23, 13);
            this.lblRol.TabIndex = 13;
            this.lblRol.Text = "Rol";
            // 
            // lblNacionalidad
            // 
            this.lblNacionalidad.AutoSize = true;
            this.lblNacionalidad.Location = new System.Drawing.Point(3, 239);
            this.lblNacionalidad.Name = "lblNacionalidad";
            this.lblNacionalidad.Size = new System.Drawing.Size(69, 13);
            this.lblNacionalidad.TabIndex = 12;
            this.lblNacionalidad.Text = "Nacionalidad";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(3, 191);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(77, 13);
            this.lblDocumento.TabIndex = 10;
            this.lblDocumento.Text = "Nº Documento";
            // 
            // inputDocumento
            // 
            this.inputDocumento.Location = new System.Drawing.Point(3, 207);
            this.inputDocumento.Name = "inputDocumento";
            this.inputDocumento.Size = new System.Drawing.Size(288, 20);
            this.inputDocumento.TabIndex = 9;
            // 
            // lblSApellido
            // 
            this.lblSApellido.AutoSize = true;
            this.lblSApellido.Location = new System.Drawing.Point(3, 143);
            this.lblSApellido.Name = "lblSApellido";
            this.lblSApellido.Size = new System.Drawing.Size(89, 13);
            this.lblSApellido.TabIndex = 8;
            this.lblSApellido.Text = "Segundo apellido";
            // 
            // inputSApellido
            // 
            this.inputSApellido.Location = new System.Drawing.Point(3, 159);
            this.inputSApellido.Name = "inputSApellido";
            this.inputSApellido.Size = new System.Drawing.Size(288, 20);
            this.inputSApellido.TabIndex = 7;
            // 
            // lblPApellido
            // 
            this.lblPApellido.AutoSize = true;
            this.lblPApellido.Location = new System.Drawing.Point(3, 95);
            this.lblPApellido.Name = "lblPApellido";
            this.lblPApellido.Size = new System.Drawing.Size(75, 13);
            this.lblPApellido.TabIndex = 6;
            this.lblPApellido.Text = "Primer apellido";
            // 
            // inputPApellido
            // 
            this.inputPApellido.Location = new System.Drawing.Point(3, 111);
            this.inputPApellido.Name = "inputPApellido";
            this.inputPApellido.Size = new System.Drawing.Size(288, 20);
            this.inputPApellido.TabIndex = 5;
            // 
            // lblSNombre
            // 
            this.lblSNombre.AutoSize = true;
            this.lblSNombre.Location = new System.Drawing.Point(3, 48);
            this.lblSNombre.Name = "lblSNombre";
            this.lblSNombre.Size = new System.Drawing.Size(88, 13);
            this.lblSNombre.TabIndex = 3;
            this.lblSNombre.Text = "Segundo nombre";
            // 
            // inputSNombre
            // 
            this.inputSNombre.Location = new System.Drawing.Point(3, 64);
            this.inputSNombre.Name = "inputSNombre";
            this.inputSNombre.Size = new System.Drawing.Size(288, 20);
            this.inputSNombre.TabIndex = 2;
            // 
            // lblPNombre
            // 
            this.lblPNombre.AutoSize = true;
            this.lblPNombre.Location = new System.Drawing.Point(3, 0);
            this.lblPNombre.Name = "lblPNombre";
            this.lblPNombre.Size = new System.Drawing.Size(74, 13);
            this.lblPNombre.TabIndex = 1;
            this.lblPNombre.Text = "Primer nombre";
            // 
            // inputPNombre
            // 
            this.inputPNombre.Location = new System.Drawing.Point(3, 16);
            this.inputPNombre.Name = "inputPNombre";
            this.inputPNombre.Size = new System.Drawing.Size(288, 20);
            this.inputPNombre.TabIndex = 0;
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 511);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(385, 550);
            this.MinimumSize = new System.Drawing.Size(385, 550);
            this.Name = "CreateUser";
            this.Text = "Crear usuario";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSNombre;
        private System.Windows.Forms.TextBox inputSNombre;
        private System.Windows.Forms.Label lblPNombre;
        private System.Windows.Forms.TextBox inputPNombre;
        private System.Windows.Forms.Label lblSApellido;
        private System.Windows.Forms.TextBox inputSApellido;
        private System.Windows.Forms.Label lblPApellido;
        private System.Windows.Forms.TextBox inputPApellido;
        private System.Windows.Forms.ComboBox inputRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblNacionalidad;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox inputDocumento;
        private System.Windows.Forms.ComboBox inputNacionalidad;
        private System.Windows.Forms.Button btnSubmit;
    }
}