namespace WindowsFormsApp1.Forms.Warehouse
{
    partial class EditWarehouse
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.inputCapacity = new System.Windows.Forms.TextBox();
            this.labelPostalCode = new System.Windows.Forms.Label();
            this.inputPostalCode = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.inputNumber = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.inputAddress = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.inputDepartamento = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 338);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.inputDepartamento);
            this.panel3.Controls.Add(this.lblDepartamento);
            this.panel3.Controls.Add(this.labelCapacity);
            this.panel3.Controls.Add(this.inputCapacity);
            this.panel3.Controls.Add(this.labelPostalCode);
            this.panel3.Controls.Add(this.inputPostalCode);
            this.panel3.Controls.Add(this.btnSubmit);
            this.panel3.Controls.Add(this.lblNumber);
            this.panel3.Controls.Add(this.inputNumber);
            this.panel3.Controls.Add(this.lblName);
            this.panel3.Controls.Add(this.inputAddress);
            this.panel3.Location = new System.Drawing.Point(25, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 294);
            this.panel3.TabIndex = 0;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Location = new System.Drawing.Point(3, 194);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(74, 13);
            this.lblDepartamento.TabIndex = 10;
            this.lblDepartamento.Text = "Departamento";
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Location = new System.Drawing.Point(3, 146);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(58, 13);
            this.labelCapacity.TabIndex = 8;
            this.labelCapacity.Text = "Capacidad";
            // 
            // inputCapacity
            // 
            this.inputCapacity.Location = new System.Drawing.Point(3, 162);
            this.inputCapacity.Name = "inputCapacity";
            this.inputCapacity.Size = new System.Drawing.Size(288, 20);
            this.inputCapacity.TabIndex = 7;
            // 
            // labelPostalCode
            // 
            this.labelPostalCode.AutoSize = true;
            this.labelPostalCode.Location = new System.Drawing.Point(3, 96);
            this.labelPostalCode.Name = "labelPostalCode";
            this.labelPostalCode.Size = new System.Drawing.Size(71, 13);
            this.labelPostalCode.TabIndex = 6;
            this.labelPostalCode.Text = "Código postal";
            // 
            // inputPostalCode
            // 
            this.inputPostalCode.Location = new System.Drawing.Point(3, 112);
            this.inputPostalCode.Name = "inputPostalCode";
            this.inputPostalCode.Size = new System.Drawing.Size(288, 20);
            this.inputPostalCode.TabIndex = 5;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(3, 253);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(288, 38);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Editar almacen";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(3, 48);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(92, 13);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "Número de puerta";
            // 
            // inputNumber
            // 
            this.inputNumber.Location = new System.Drawing.Point(3, 64);
            this.inputNumber.Name = "inputNumber";
            this.inputNumber.Size = new System.Drawing.Size(288, 20);
            this.inputNumber.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(30, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Calle";
            // 
            // inputAddress
            // 
            this.inputAddress.Location = new System.Drawing.Point(3, 16);
            this.inputAddress.Name = "inputAddress";
            this.inputAddress.Size = new System.Drawing.Size(288, 20);
            this.inputAddress.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 65);
            this.panel1.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(369, 65);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Editar almacen";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputDepartamento
            // 
            this.inputDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputDepartamento.FormattingEnabled = true;
            this.inputDepartamento.Location = new System.Drawing.Point(3, 210);
            this.inputDepartamento.Name = "inputDepartamento";
            this.inputDepartamento.Size = new System.Drawing.Size(288, 21);
            this.inputDepartamento.TabIndex = 11;
            // 
            // EditWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 421);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(385, 460);
            this.MinimumSize = new System.Drawing.Size(385, 460);
            this.Name = "EditWarehouse";
            this.Text = "EditWarehouse";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox inputNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox inputAddress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label labelPostalCode;
        private System.Windows.Forms.TextBox inputPostalCode;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.TextBox inputCapacity;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox inputDepartamento;
    }
}