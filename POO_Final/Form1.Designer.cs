namespace POO_Final
{
    partial class Form1
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
            this.AlumnosGroupBox = new System.Windows.Forms.GroupBox();
            this.AlumnosDGV = new System.Windows.Forms.DataGridView();
            this.AlumnosExtranjerosGroupBox = new System.Windows.Forms.GroupBox();
            this.AlumnosExtranjerosDGV = new System.Windows.Forms.DataGridView();
            this.TelefonosGroupBox = new System.Windows.Forms.GroupBox();
            this.TelefonosDGV = new System.Windows.Forms.DataGridView();
            this.AgregarAlumnoButton = new System.Windows.Forms.Button();
            this.ModificarAlumnoButton = new System.Windows.Forms.Button();
            this.EliminarAlumnoButton = new System.Windows.Forms.Button();
            this.AgregarTelefonoButton = new System.Windows.Forms.Button();
            this.ModificarTelefonoButton = new System.Windows.Forms.Button();
            this.EliminarTelefonoButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.AntiguedadGroupBox = new System.Windows.Forms.GroupBox();
            this.DiasRadioButton = new System.Windows.Forms.RadioButton();
            this.MesesRadioButton = new System.Windows.Forms.RadioButton();
            this.AniosRadioButton = new System.Windows.Forms.RadioButton();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.OrdenarGroupBox = new System.Windows.Forms.GroupBox();
            this.AscRadioButton = new System.Windows.Forms.RadioButton();
            this.DescRadioButton = new System.Windows.Forms.RadioButton();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.TipoGroupBox = new System.Windows.Forms.GroupBox();
            this.ExtranjeroRadioButton = new System.Windows.Forms.RadioButton();
            this.LocalRadioButton = new System.Windows.Forms.RadioButton();
            this.AlumnosGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlumnosDGV)).BeginInit();
            this.AlumnosExtranjerosGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlumnosExtranjerosDGV)).BeginInit();
            this.TelefonosGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TelefonosDGV)).BeginInit();
            this.AntiguedadGroupBox.SuspendLayout();
            this.OrdenarGroupBox.SuspendLayout();
            this.TipoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AlumnosGroupBox
            // 
            this.AlumnosGroupBox.Controls.Add(this.AlumnosDGV);
            this.AlumnosGroupBox.Location = new System.Drawing.Point(12, 21);
            this.AlumnosGroupBox.Name = "AlumnosGroupBox";
            this.AlumnosGroupBox.Size = new System.Drawing.Size(553, 232);
            this.AlumnosGroupBox.TabIndex = 0;
            this.AlumnosGroupBox.TabStop = false;
            this.AlumnosGroupBox.Text = "Alumnos";
            // 
            // AlumnosDGV
            // 
            this.AlumnosDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlumnosDGV.Location = new System.Drawing.Point(9, 20);
            this.AlumnosDGV.Name = "AlumnosDGV";
            this.AlumnosDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AlumnosDGV.Size = new System.Drawing.Size(538, 192);
            this.AlumnosDGV.TabIndex = 0;
            this.AlumnosDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AlumnosDGV_CellClick);
            // 
            // AlumnosExtranjerosGroupBox
            // 
            this.AlumnosExtranjerosGroupBox.Controls.Add(this.AlumnosExtranjerosDGV);
            this.AlumnosExtranjerosGroupBox.Location = new System.Drawing.Point(12, 412);
            this.AlumnosExtranjerosGroupBox.Name = "AlumnosExtranjerosGroupBox";
            this.AlumnosExtranjerosGroupBox.Size = new System.Drawing.Size(547, 256);
            this.AlumnosExtranjerosGroupBox.TabIndex = 0;
            this.AlumnosExtranjerosGroupBox.TabStop = false;
            this.AlumnosExtranjerosGroupBox.Text = "AlumnosExtranjeros";
            // 
            // AlumnosExtranjerosDGV
            // 
            this.AlumnosExtranjerosDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlumnosExtranjerosDGV.Location = new System.Drawing.Point(6, 28);
            this.AlumnosExtranjerosDGV.Name = "AlumnosExtranjerosDGV";
            this.AlumnosExtranjerosDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AlumnosExtranjerosDGV.Size = new System.Drawing.Size(535, 192);
            this.AlumnosExtranjerosDGV.TabIndex = 0;
            // 
            // TelefonosGroupBox
            // 
            this.TelefonosGroupBox.Controls.Add(this.TelefonosDGV);
            this.TelefonosGroupBox.Location = new System.Drawing.Point(571, 21);
            this.TelefonosGroupBox.Name = "TelefonosGroupBox";
            this.TelefonosGroupBox.Size = new System.Drawing.Size(343, 507);
            this.TelefonosGroupBox.TabIndex = 1;
            this.TelefonosGroupBox.TabStop = false;
            this.TelefonosGroupBox.Text = "Telefonos";
            // 
            // TelefonosDGV
            // 
            this.TelefonosDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TelefonosDGV.Location = new System.Drawing.Point(22, 20);
            this.TelefonosDGV.Name = "TelefonosDGV";
            this.TelefonosDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TelefonosDGV.Size = new System.Drawing.Size(302, 452);
            this.TelefonosDGV.TabIndex = 0;
            // 
            // AgregarAlumnoButton
            // 
            this.AgregarAlumnoButton.Location = new System.Drawing.Point(12, 269);
            this.AgregarAlumnoButton.Name = "AgregarAlumnoButton";
            this.AgregarAlumnoButton.Size = new System.Drawing.Size(75, 23);
            this.AgregarAlumnoButton.TabIndex = 2;
            this.AgregarAlumnoButton.Text = "Agregar";
            this.AgregarAlumnoButton.UseVisualStyleBackColor = true;
            this.AgregarAlumnoButton.Click += new System.EventHandler(this.AgregarAlumnoButton_Click);
            // 
            // ModificarAlumnoButton
            // 
            this.ModificarAlumnoButton.Location = new System.Drawing.Point(117, 269);
            this.ModificarAlumnoButton.Name = "ModificarAlumnoButton";
            this.ModificarAlumnoButton.Size = new System.Drawing.Size(75, 23);
            this.ModificarAlumnoButton.TabIndex = 2;
            this.ModificarAlumnoButton.Text = "Modificar";
            this.ModificarAlumnoButton.UseVisualStyleBackColor = true;
            this.ModificarAlumnoButton.Click += new System.EventHandler(this.ModificarAlumnoButton_Click);
            // 
            // EliminarAlumnoButton
            // 
            this.EliminarAlumnoButton.Location = new System.Drawing.Point(218, 269);
            this.EliminarAlumnoButton.Name = "EliminarAlumnoButton";
            this.EliminarAlumnoButton.Size = new System.Drawing.Size(75, 23);
            this.EliminarAlumnoButton.TabIndex = 2;
            this.EliminarAlumnoButton.Text = "Eliminar";
            this.EliminarAlumnoButton.UseVisualStyleBackColor = true;
            this.EliminarAlumnoButton.Click += new System.EventHandler(this.EliminarAlumnoButton_Click);
            // 
            // AgregarTelefonoButton
            // 
            this.AgregarTelefonoButton.Location = new System.Drawing.Point(593, 548);
            this.AgregarTelefonoButton.Name = "AgregarTelefonoButton";
            this.AgregarTelefonoButton.Size = new System.Drawing.Size(75, 23);
            this.AgregarTelefonoButton.TabIndex = 2;
            this.AgregarTelefonoButton.Text = "Agregar";
            this.AgregarTelefonoButton.UseVisualStyleBackColor = true;
            // 
            // ModificarTelefonoButton
            // 
            this.ModificarTelefonoButton.Location = new System.Drawing.Point(698, 548);
            this.ModificarTelefonoButton.Name = "ModificarTelefonoButton";
            this.ModificarTelefonoButton.Size = new System.Drawing.Size(75, 23);
            this.ModificarTelefonoButton.TabIndex = 2;
            this.ModificarTelefonoButton.Text = "Modificar";
            this.ModificarTelefonoButton.UseVisualStyleBackColor = true;
            // 
            // EliminarTelefonoButton
            // 
            this.EliminarTelefonoButton.Location = new System.Drawing.Point(799, 548);
            this.EliminarTelefonoButton.Name = "EliminarTelefonoButton";
            this.EliminarTelefonoButton.Size = new System.Drawing.Size(75, 23);
            this.EliminarTelefonoButton.TabIndex = 2;
            this.EliminarTelefonoButton.Text = "Eliminar";
            this.EliminarTelefonoButton.UseVisualStyleBackColor = true;
            // 
            // AntiguedadGroupBox
            // 
            this.AntiguedadGroupBox.Controls.Add(this.DiasRadioButton);
            this.AntiguedadGroupBox.Controls.Add(this.MesesRadioButton);
            this.AntiguedadGroupBox.Controls.Add(this.AniosRadioButton);
            this.AntiguedadGroupBox.Location = new System.Drawing.Point(325, 269);
            this.AntiguedadGroupBox.Name = "AntiguedadGroupBox";
            this.AntiguedadGroupBox.Size = new System.Drawing.Size(154, 124);
            this.AntiguedadGroupBox.TabIndex = 3;
            this.AntiguedadGroupBox.TabStop = false;
            this.AntiguedadGroupBox.Text = "Antiguedad";
            // 
            // DiasRadioButton
            // 
            this.DiasRadioButton.AutoSize = true;
            this.DiasRadioButton.Location = new System.Drawing.Point(7, 101);
            this.DiasRadioButton.Name = "DiasRadioButton";
            this.DiasRadioButton.Size = new System.Drawing.Size(46, 17);
            this.DiasRadioButton.TabIndex = 0;
            this.DiasRadioButton.TabStop = true;
            this.DiasRadioButton.Text = "Dias";
            this.DiasRadioButton.UseVisualStyleBackColor = true;
            this.DiasRadioButton.CheckedChanged += new System.EventHandler(this.DiasRadioButton_CheckedChanged);
            // 
            // MesesRadioButton
            // 
            this.MesesRadioButton.AutoSize = true;
            this.MesesRadioButton.Location = new System.Drawing.Point(6, 63);
            this.MesesRadioButton.Name = "MesesRadioButton";
            this.MesesRadioButton.Size = new System.Drawing.Size(56, 17);
            this.MesesRadioButton.TabIndex = 0;
            this.MesesRadioButton.TabStop = true;
            this.MesesRadioButton.Text = "Meses";
            this.MesesRadioButton.UseVisualStyleBackColor = true;
            this.MesesRadioButton.CheckedChanged += new System.EventHandler(this.MesesRadioButton_CheckedChanged);
            // 
            // AniosRadioButton
            // 
            this.AniosRadioButton.AutoSize = true;
            this.AniosRadioButton.Location = new System.Drawing.Point(7, 30);
            this.AniosRadioButton.Name = "AniosRadioButton";
            this.AniosRadioButton.Size = new System.Drawing.Size(49, 17);
            this.AniosRadioButton.TabIndex = 0;
            this.AniosRadioButton.TabStop = true;
            this.AniosRadioButton.Text = "Años";
            this.AniosRadioButton.UseVisualStyleBackColor = true;
            this.AniosRadioButton.CheckedChanged += new System.EventHandler(this.AniosRadioButton_CheckedChanged);
            // 
            // OrdenarGroupBox
            // 
            this.OrdenarGroupBox.Controls.Add(this.AscRadioButton);
            this.OrdenarGroupBox.Controls.Add(this.DescRadioButton);
            this.OrdenarGroupBox.Location = new System.Drawing.Point(21, 332);
            this.OrdenarGroupBox.Name = "OrdenarGroupBox";
            this.OrdenarGroupBox.Size = new System.Drawing.Size(236, 55);
            this.OrdenarGroupBox.TabIndex = 4;
            this.OrdenarGroupBox.TabStop = false;
            this.OrdenarGroupBox.Text = "Ordenar:";
            // 
            // AscRadioButton
            // 
            this.AscRadioButton.AutoSize = true;
            this.AscRadioButton.Location = new System.Drawing.Point(16, 19);
            this.AscRadioButton.Name = "AscRadioButton";
            this.AscRadioButton.Size = new System.Drawing.Size(82, 17);
            this.AscRadioButton.TabIndex = 0;
            this.AscRadioButton.TabStop = true;
            this.AscRadioButton.Text = "Ascendente";
            this.AscRadioButton.UseVisualStyleBackColor = true;
            this.AscRadioButton.CheckedChanged += new System.EventHandler(this.AscRadioButton_CheckedChanged);
            // 
            // DescRadioButton
            // 
            this.DescRadioButton.AutoSize = true;
            this.DescRadioButton.Location = new System.Drawing.Point(130, 19);
            this.DescRadioButton.Name = "DescRadioButton";
            this.DescRadioButton.Size = new System.Drawing.Size(89, 17);
            this.DescRadioButton.TabIndex = 0;
            this.DescRadioButton.TabStop = true;
            this.DescRadioButton.Text = "Descendente";
            this.DescRadioButton.UseVisualStyleBackColor = true;
            // 
            // TipoGroupBox
            // 
            this.TipoGroupBox.Controls.Add(this.ExtranjeroRadioButton);
            this.TipoGroupBox.Controls.Add(this.LocalRadioButton);
            this.TipoGroupBox.Location = new System.Drawing.Point(485, 268);
            this.TipoGroupBox.Name = "TipoGroupBox";
            this.TipoGroupBox.Size = new System.Drawing.Size(80, 125);
            this.TipoGroupBox.TabIndex = 5;
            this.TipoGroupBox.TabStop = false;
            this.TipoGroupBox.Text = "Tipo:";
            // 
            // ExtranjeroRadioButton
            // 
            this.ExtranjeroRadioButton.AutoSize = true;
            this.ExtranjeroRadioButton.Location = new System.Drawing.Point(6, 64);
            this.ExtranjeroRadioButton.Name = "ExtranjeroRadioButton";
            this.ExtranjeroRadioButton.Size = new System.Drawing.Size(72, 17);
            this.ExtranjeroRadioButton.TabIndex = 0;
            this.ExtranjeroRadioButton.TabStop = true;
            this.ExtranjeroRadioButton.Text = "Extranjero";
            this.ExtranjeroRadioButton.UseVisualStyleBackColor = true;
            this.ExtranjeroRadioButton.CheckedChanged += new System.EventHandler(this.AniosRadioButton_CheckedChanged);
            // 
            // LocalRadioButton
            // 
            this.LocalRadioButton.AutoSize = true;
            this.LocalRadioButton.Location = new System.Drawing.Point(6, 31);
            this.LocalRadioButton.Name = "LocalRadioButton";
            this.LocalRadioButton.Size = new System.Drawing.Size(51, 17);
            this.LocalRadioButton.TabIndex = 0;
            this.LocalRadioButton.TabStop = true;
            this.LocalRadioButton.Text = "Local";
            this.LocalRadioButton.UseVisualStyleBackColor = true;
            this.LocalRadioButton.CheckedChanged += new System.EventHandler(this.AniosRadioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 706);
            this.Controls.Add(this.TipoGroupBox);
            this.Controls.Add(this.OrdenarGroupBox);
            this.Controls.Add(this.AntiguedadGroupBox);
            this.Controls.Add(this.EliminarTelefonoButton);
            this.Controls.Add(this.EliminarAlumnoButton);
            this.Controls.Add(this.ModificarTelefonoButton);
            this.Controls.Add(this.ModificarAlumnoButton);
            this.Controls.Add(this.AgregarTelefonoButton);
            this.Controls.Add(this.AgregarAlumnoButton);
            this.Controls.Add(this.AlumnosExtranjerosGroupBox);
            this.Controls.Add(this.TelefonosGroupBox);
            this.Controls.Add(this.AlumnosGroupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AlumnosGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlumnosDGV)).EndInit();
            this.AlumnosExtranjerosGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlumnosExtranjerosDGV)).EndInit();
            this.TelefonosGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TelefonosDGV)).EndInit();
            this.AntiguedadGroupBox.ResumeLayout(false);
            this.AntiguedadGroupBox.PerformLayout();
            this.OrdenarGroupBox.ResumeLayout(false);
            this.OrdenarGroupBox.PerformLayout();
            this.TipoGroupBox.ResumeLayout(false);
            this.TipoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AlumnosGroupBox;
        private System.Windows.Forms.DataGridView AlumnosDGV;
        private System.Windows.Forms.GroupBox AlumnosExtranjerosGroupBox;
        private System.Windows.Forms.DataGridView AlumnosExtranjerosDGV;
        private System.Windows.Forms.GroupBox TelefonosGroupBox;
        private System.Windows.Forms.DataGridView TelefonosDGV;
        private System.Windows.Forms.Button AgregarAlumnoButton;
        private System.Windows.Forms.Button ModificarAlumnoButton;
        private System.Windows.Forms.Button EliminarAlumnoButton;
        private System.Windows.Forms.Button AgregarTelefonoButton;
        private System.Windows.Forms.Button ModificarTelefonoButton;
        private System.Windows.Forms.Button EliminarTelefonoButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox AntiguedadGroupBox;
        private System.Windows.Forms.RadioButton DiasRadioButton;
        private System.Windows.Forms.RadioButton MesesRadioButton;
        private System.Windows.Forms.RadioButton AniosRadioButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox OrdenarGroupBox;
        private System.Windows.Forms.RadioButton AscRadioButton;
        private System.Windows.Forms.RadioButton DescRadioButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.GroupBox TipoGroupBox;
        private System.Windows.Forms.RadioButton ExtranjeroRadioButton;
        private System.Windows.Forms.RadioButton LocalRadioButton;
    }
}

