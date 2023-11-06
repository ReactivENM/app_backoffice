namespace WindowsFormsApp1.Forms.Warehouse
{
    partial class CreateWarehouse
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
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.inputDeparamento = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.inputCapacity = new System.Windows.Forms.TextBox();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.inputPostalCode = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.inputNumber = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.inputAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputDescripcion = new System.Windows.Forms.TextBox();
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
            this.lblTitle.Text = "Crear almacen";
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
            this.panel2.Size = new System.Drawing.Size(345, 408);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.inputDeparamento);
            this.panel3.Controls.Add(this.inputCapacity);
            this.panel3.Controls.Add(this.inputPostalCode);
            this.panel3.Controls.Add(this.inputNumber);
            this.panel3.Controls.Add(this.inputAddress);
            this.panel3.Controls.Add(this.inputDescripcion);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnSubmit);
            this.panel3.Controls.Add(this.lblDepartamento);
            this.panel3.Controls.Add(this.lblCapacity);
            this.panel3.Controls.Add(this.lblPostalCode);
            this.panel3.Controls.Add(this.lblNumber);
            this.panel3.Controls.Add(this.lblName);
            this.panel3.Location = new System.Drawing.Point(26, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 357);
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
            this.btnSubmit.Location = new System.Drawing.Point(6, 313);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(285, 38);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Crear almacen";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartamento.Location = new System.Drawing.Point(5, 245);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(96, 22);
            this.lblDepartamento.TabIndex = 10;
            this.lblDepartamento.Text = "Departamento";
            // 
            // inputDeparamento
            // 
            this.inputDeparamento.Location = new System.Drawing.Point(3, 265);
            this.inputDeparamento.Name = "inputDeparamento";
            this.inputDeparamento.Size = new System.Drawing.Size(288, 20);
            this.inputDeparamento.TabIndex = 9;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.Location = new System.Drawing.Point(5, 197);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(77, 22);
            this.lblCapacity.TabIndex = 8;
            this.lblCapacity.Text = "Capacidad";
            // 
            // inputCapacity
            // 
            this.inputCapacity.Location = new System.Drawing.Point(3, 216);
            this.inputCapacity.Name = "inputCapacity";
            this.inputCapacity.Size = new System.Drawing.Size(288, 20);
            this.inputCapacity.TabIndex = 7;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostalCode.Location = new System.Drawing.Point(3, 148);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(94, 22);
            this.lblPostalCode.TabIndex = 6;
            this.lblPostalCode.Text = "Código postal";
            // 
            // inputPostalCode
            // 
            this.inputPostalCode.Location = new System.Drawing.Point(3, 168);
            this.inputPostalCode.Name = "inputPostalCode";
            this.inputPostalCode.Size = new System.Drawing.Size(288, 20);
            this.inputPostalCode.TabIndex = 5;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(3, 100);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(117, 22);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "Número de puerta";
            // 
            // inputNumber
            // 
            this.inputNumber.Location = new System.Drawing.Point(3, 120);
            this.inputNumber.Name = "inputNumber";
            this.inputNumber.Size = new System.Drawing.Size(288, 20);
            this.inputNumber.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 52);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 22);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Calle";
            // 
            // inputAddress
            // 
            this.inputAddress.Location = new System.Drawing.Point(3, 71);
            this.inputAddress.Name = "inputAddress";
            this.inputAddress.Size = new System.Drawing.Size(288, 20);
            this.inputAddress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Descripción";
            // 
            // inputDescripcion
            // 
            this.inputDescripcion.Location = new System.Drawing.Point(3, 22);
            this.inputDescripcion.Name = "inputDescripcion";
            this.inputDescripcion.Size = new System.Drawing.Size(288, 20);
            this.inputDescripcion.TabIndex = 11;
            // 
            // CreateWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 491);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(385, 530);
            this.MinimumSize = new System.Drawing.Size(385, 530);
            this.Name = "CreateWarehouse";
            this.Text = "Crear almacen";
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
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox inputNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox inputAddress;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox inputCapacity;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.TextBox inputPostalCode;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.TextBox inputDeparamento;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputDescripcion;
    }
}