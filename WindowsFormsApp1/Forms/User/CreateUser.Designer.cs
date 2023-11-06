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
            this.inputCorreo = new System.Windows.Forms.TextBox();
            this.input_correo = new System.Windows.Forms.Label();
            this.inputContrasena = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputNacionalidad = new System.Windows.Forms.ComboBox();
            this.inputDocumento = new System.Windows.Forms.TextBox();
            this.inputSApellido = new System.Windows.Forms.TextBox();
            this.inputPApellido = new System.Windows.Forms.TextBox();
            this.inputSNombre = new System.Windows.Forms.TextBox();
            this.inputPNombre = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.inputRol = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblNacionalidad = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblSApellido = new System.Windows.Forms.Label();
            this.lblSNombre = new System.Windows.Forms.Label();
            this.lblPNombre = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPApellido = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputCorreo
            // 
            this.inputCorreo.Location = new System.Drawing.Point(3, 20);
            this.inputCorreo.Name = "inputCorreo";
            this.inputCorreo.Size = new System.Drawing.Size(288, 20);
            this.inputCorreo.TabIndex = 22;
            // 
            // input_correo
            // 
            this.input_correo.AutoSize = true;
            this.input_correo.BackColor = System.Drawing.Color.Transparent;
            this.input_correo.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_correo.Location = new System.Drawing.Point(3, 3);
            this.input_correo.Name = "input_correo";
            this.input_correo.Size = new System.Drawing.Size(50, 22);
            this.input_correo.TabIndex = 23;
            this.input_correo.Text = "Correo";
            // 
            // inputContrasena
            // 
            this.inputContrasena.Location = new System.Drawing.Point(3, 66);
            this.inputContrasena.Name = "inputContrasena";
            this.inputContrasena.Size = new System.Drawing.Size(288, 20);
            this.inputContrasena.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 22);
            this.label1.TabIndex = 21;
            this.label1.Text = "Contraseña";
            // 
            // inputNacionalidad
            // 
            this.inputNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputNacionalidad.FormattingEnabled = true;
            this.inputNacionalidad.Items.AddRange(new object[] {
            "UYU",
            "ARG",
            "CHL",
            "BRA"});
            this.inputNacionalidad.Location = new System.Drawing.Point(6, 351);
            this.inputNacionalidad.Name = "inputNacionalidad";
            this.inputNacionalidad.Size = new System.Drawing.Size(285, 21);
            this.inputNacionalidad.TabIndex = 15;
            // 
            // inputDocumento
            // 
            this.inputDocumento.Location = new System.Drawing.Point(3, 304);
            this.inputDocumento.Name = "inputDocumento";
            this.inputDocumento.Size = new System.Drawing.Size(288, 20);
            this.inputDocumento.TabIndex = 9;
            // 
            // inputSApellido
            // 
            this.inputSApellido.Location = new System.Drawing.Point(3, 255);
            this.inputSApellido.Name = "inputSApellido";
            this.inputSApellido.Size = new System.Drawing.Size(288, 20);
            this.inputSApellido.TabIndex = 7;
            // 
            // inputPApellido
            // 
            this.inputPApellido.Location = new System.Drawing.Point(3, 206);
            this.inputPApellido.Name = "inputPApellido";
            this.inputPApellido.Size = new System.Drawing.Size(288, 20);
            this.inputPApellido.TabIndex = 5;
            // 
            // inputSNombre
            // 
            this.inputSNombre.Location = new System.Drawing.Point(3, 160);
            this.inputSNombre.Name = "inputSNombre";
            this.inputSNombre.Size = new System.Drawing.Size(288, 20);
            this.inputSNombre.TabIndex = 2;
            // 
            // inputPNombre
            // 
            this.inputPNombre.Location = new System.Drawing.Point(3, 111);
            this.inputPNombre.Name = "inputPNombre";
            this.inputPNombre.Size = new System.Drawing.Size(288, 20);
            this.inputPNombre.TabIndex = 0;
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
            this.btnSubmit.Location = new System.Drawing.Point(6, 442);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(285, 38);
            this.btnSubmit.TabIndex = 16;
            this.btnSubmit.Text = "Crear usuario";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // inputRol
            // 
            this.inputRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputRol.FormattingEnabled = true;
            this.inputRol.Items.AddRange(new object[] {
            "Almacenero",
            "Camionero",
            "Administrador"});
            this.inputRol.Location = new System.Drawing.Point(6, 399);
            this.inputRol.Name = "inputRol";
            this.inputRol.Size = new System.Drawing.Size(285, 21);
            this.inputRol.TabIndex = 14;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 65);
            this.panel1.TabIndex = 4;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.Location = new System.Drawing.Point(3, 380);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(28, 22);
            this.lblRol.TabIndex = 13;
            this.lblRol.Text = "Rol";
            // 
            // lblNacionalidad
            // 
            this.lblNacionalidad.AutoSize = true;
            this.lblNacionalidad.BackColor = System.Drawing.Color.Transparent;
            this.lblNacionalidad.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNacionalidad.Location = new System.Drawing.Point(3, 333);
            this.lblNacionalidad.Name = "lblNacionalidad";
            this.lblNacionalidad.Size = new System.Drawing.Size(90, 22);
            this.lblNacionalidad.TabIndex = 12;
            this.lblNacionalidad.Text = "Nacionalidad";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.BackColor = System.Drawing.Color.Transparent;
            this.lblDocumento.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.Location = new System.Drawing.Point(3, 285);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(96, 22);
            this.lblDocumento.TabIndex = 10;
            this.lblDocumento.Text = "Nº Documento";
            // 
            // lblSApellido
            // 
            this.lblSApellido.AutoSize = true;
            this.lblSApellido.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSApellido.Location = new System.Drawing.Point(3, 236);
            this.lblSApellido.Name = "lblSApellido";
            this.lblSApellido.Size = new System.Drawing.Size(115, 22);
            this.lblSApellido.TabIndex = 8;
            this.lblSApellido.Text = "Segundo apellido";
            // 
            // lblSNombre
            // 
            this.lblSNombre.AutoSize = true;
            this.lblSNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblSNombre.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSNombre.Location = new System.Drawing.Point(3, 141);
            this.lblSNombre.Name = "lblSNombre";
            this.lblSNombre.Size = new System.Drawing.Size(114, 22);
            this.lblSNombre.TabIndex = 3;
            this.lblSNombre.Text = "Segundo nombre";
            // 
            // lblPNombre
            // 
            this.lblPNombre.AutoSize = true;
            this.lblPNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblPNombre.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPNombre.Location = new System.Drawing.Point(3, 94);
            this.lblPNombre.Name = "lblPNombre";
            this.lblPNombre.Size = new System.Drawing.Size(97, 22);
            this.lblPNombre.TabIndex = 1;
            this.lblPNombre.Text = "Primer nombre";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.inputCorreo);
            this.panel3.Controls.Add(this.input_correo);
            this.panel3.Controls.Add(this.inputContrasena);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.inputNacionalidad);
            this.panel3.Controls.Add(this.inputDocumento);
            this.panel3.Controls.Add(this.inputSApellido);
            this.panel3.Controls.Add(this.inputPApellido);
            this.panel3.Controls.Add(this.inputSNombre);
            this.panel3.Controls.Add(this.inputPNombre);
            this.panel3.Controls.Add(this.btnSubmit);
            this.panel3.Controls.Add(this.inputRol);
            this.panel3.Controls.Add(this.lblRol);
            this.panel3.Controls.Add(this.lblNacionalidad);
            this.panel3.Controls.Add(this.lblDocumento);
            this.panel3.Controls.Add(this.lblSApellido);
            this.panel3.Controls.Add(this.lblPApellido);
            this.panel3.Controls.Add(this.lblSNombre);
            this.panel3.Controls.Add(this.lblPNombre);
            this.panel3.Location = new System.Drawing.Point(25, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 487);
            this.panel3.TabIndex = 1;
            // 
            // lblPApellido
            // 
            this.lblPApellido.AutoSize = true;
            this.lblPApellido.BackColor = System.Drawing.Color.Transparent;
            this.lblPApellido.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPApellido.Location = new System.Drawing.Point(3, 188);
            this.lblPApellido.Name = "lblPApellido";
            this.lblPApellido.Size = new System.Drawing.Size(98, 22);
            this.lblPApellido.TabIndex = 6;
            this.lblPApellido.Text = "Primer apellido";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 532);
            this.panel2.TabIndex = 5;
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 621);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximumSize = new System.Drawing.Size(385, 660);
            this.MinimumSize = new System.Drawing.Size(385, 660);
            this.Name = "CreateUser";
            this.Text = "Crear usuario";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox inputCorreo;
        private System.Windows.Forms.Label input_correo;
        private System.Windows.Forms.TextBox inputContrasena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox inputNacionalidad;
        private System.Windows.Forms.TextBox inputDocumento;
        private System.Windows.Forms.TextBox inputSApellido;
        private System.Windows.Forms.TextBox inputPApellido;
        private System.Windows.Forms.TextBox inputSNombre;
        private System.Windows.Forms.TextBox inputPNombre;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox inputRol;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblNacionalidad;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblSApellido;
        private System.Windows.Forms.Label lblSNombre;
        private System.Windows.Forms.Label lblPNombre;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPApellido;
        private System.Windows.Forms.Panel panel2;
    }
}