namespace WindowsFormsApp1.Forms
{
    partial class FormTruck
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTruck));
            this.dataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLot = new System.Windows.Forms.Button();
            this.btnDeleteTruck = new System.Windows.Forms.Button();
            this.btnEditTruck = new System.Windows.Forms.Button();
            this.btnCreateTruck = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.matricula,
            this.marca,
            this.modelo,
            this.capacidad});
            this.dataGridView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.HideOuterBorders = true;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(947, 520);
            this.dataGridView.StateCommon.Background.Color1 = System.Drawing.Color.Transparent;
            this.dataGridView.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dataGridView.StateCommon.DataCell.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom;
            this.dataGridView.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.StateCommon.DataCell.Content.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.dataGridView.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(-1, 9, -1, 9);
            this.dataGridView.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.dataGridView.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.dataGridView.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.Transparent;
            this.dataGridView.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Transparent;
            this.dataGridView.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dataGridView.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dataGridView.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.StatePressed.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(35)))));
            this.dataGridView.StatePressed.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(35)))));
            this.dataGridView.StatePressed.HeaderRow.Back.Color1 = System.Drawing.Color.Transparent;
            this.dataGridView.StatePressed.HeaderRow.Back.Color2 = System.Drawing.Color.Transparent;
            this.dataGridView.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.dataGridView.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.Gainsboro;
            this.dataGridView.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(35)))));
            this.dataGridView.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(35)))));
            this.dataGridView.StateTracking.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(35)))));
            this.dataGridView.StateTracking.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(35)))));
            this.dataGridView.TabIndex = 1;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // matricula
            // 
            this.matricula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.matricula.HeaderText = "Matricula";
            this.matricula.Name = "matricula";
            this.matricula.ReadOnly = true;
            // 
            // marca
            // 
            this.marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            // 
            // modelo
            // 
            this.modelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.modelo.HeaderText = "Modelo";
            this.modelo.Name = "modelo";
            this.modelo.ReadOnly = true;
            // 
            // capacidad
            // 
            this.capacidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.capacidad.HeaderText = "Capacidad(T)";
            this.capacidad.Name = "capacidad";
            this.capacidad.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Location = new System.Drawing.Point(12, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 520);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.btnLot);
            this.panel2.Controls.Add(this.btnDeleteTruck);
            this.panel2.Controls.Add(this.btnEditTruck);
            this.panel2.Controls.Add(this.btnCreateTruck);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.lblPage);
            this.panel2.Controls.Add(this.btnPrev);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 526);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(971, 60);
            this.panel2.TabIndex = 3;
            // 
            // btnLot
            // 
            this.btnLot.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLot.Enabled = false;
            this.btnLot.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLot.Location = new System.Drawing.Point(884, 15);
            this.btnLot.Name = "btnLot";
            this.btnLot.Size = new System.Drawing.Size(75, 33);
            this.btnLot.TabIndex = 6;
            this.btnLot.Text = "Ver lotes";
            this.btnLot.UseVisualStyleBackColor = true;
            this.btnLot.Click += new System.EventHandler(this.btnLot_Click);
            // 
            // btnDeleteTruck
            // 
            this.btnDeleteTruck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDeleteTruck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteTruck.BackgroundImage")));
            this.btnDeleteTruck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteTruck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteTruck.Enabled = false;
            this.btnDeleteTruck.ImageKey = "(none)";
            this.btnDeleteTruck.Location = new System.Drawing.Point(94, 13);
            this.btnDeleteTruck.Name = "btnDeleteTruck";
            this.btnDeleteTruck.Size = new System.Drawing.Size(35, 35);
            this.btnDeleteTruck.TabIndex = 5;
            this.btnDeleteTruck.Text = "\r\n";
            this.btnDeleteTruck.UseVisualStyleBackColor = true;
            this.btnDeleteTruck.Click += new System.EventHandler(this.btnDeleteTruck_Click);
            // 
            // btnEditTruck
            // 
            this.btnEditTruck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEditTruck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditTruck.BackgroundImage")));
            this.btnEditTruck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditTruck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditTruck.Enabled = false;
            this.btnEditTruck.Location = new System.Drawing.Point(53, 13);
            this.btnEditTruck.Name = "btnEditTruck";
            this.btnEditTruck.Size = new System.Drawing.Size(35, 35);
            this.btnEditTruck.TabIndex = 4;
            this.btnEditTruck.UseVisualStyleBackColor = true;
            this.btnEditTruck.Click += new System.EventHandler(this.btnEditTruck_Click);
            // 
            // btnCreateTruck
            // 
            this.btnCreateTruck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCreateTruck.BackColor = System.Drawing.SystemColors.Window;
            this.btnCreateTruck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreateTruck.BackgroundImage")));
            this.btnCreateTruck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCreateTruck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateTruck.Location = new System.Drawing.Point(12, 13);
            this.btnCreateTruck.Name = "btnCreateTruck";
            this.btnCreateTruck.Size = new System.Drawing.Size(35, 35);
            this.btnCreateTruck.TabIndex = 3;
            this.btnCreateTruck.UseVisualStyleBackColor = false;
            this.btnCreateTruck.Click += new System.EventHandler(this.btnCreateTruck_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(520, 15);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 33);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Siguiente";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblPage
            // 
            this.lblPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPage.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.Location = new System.Drawing.Point(464, 25);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(50, 13);
            this.lblPage.TabIndex = 1;
            this.lblPage.Text = "1/1";
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(392, 15);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(66, 33);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "Anterior";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // FormTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(971, 586);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(987, 625);
            this.Name = "FormTruck";
            this.Text = "Camiones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDeleteTruck;
        private System.Windows.Forms.Button btnEditTruck;
        private System.Windows.Forms.Button btnCreateTruck;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidad;
        private System.Windows.Forms.Button btnLot;
    }
}