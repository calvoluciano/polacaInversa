namespace PagoAgilFrba.ListadoEstadistico
{
    partial class ListadoEstadisticoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownCantidadElementos = new System.Windows.Forms.NumericUpDown();
            this.comboBoxTrimestre = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerAnio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxInforme = new System.Windows.Forms.ComboBox();
            this.buttonCargarFacturasPagas = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTablaInformes = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidadElementos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTablaInformes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownCantidadElementos);
            this.groupBox1.Controls.Add(this.comboBoxTrimestre);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateTimePickerAnio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 101);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar datos de busqueda";
            // 
            // numericUpDownCantidadElementos
            // 
            this.numericUpDownCantidadElementos.Location = new System.Drawing.Point(345, 64);
            this.numericUpDownCantidadElementos.Name = "numericUpDownCantidadElementos";
            this.numericUpDownCantidadElementos.Size = new System.Drawing.Size(120, 27);
            this.numericUpDownCantidadElementos.TabIndex = 73;
            // 
            // comboBoxTrimestre
            // 
            this.comboBoxTrimestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboBoxTrimestre.FormattingEnabled = true;
            this.comboBoxTrimestre.Location = new System.Drawing.Point(348, 24);
            this.comboBoxTrimestre.Name = "comboBoxTrimestre";
            this.comboBoxTrimestre.Size = new System.Drawing.Size(117, 26);
            this.comboBoxTrimestre.TabIndex = 72;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(268, 20);
            this.label7.TabIndex = 71;
            this.label7.Text = "Cantidad de elementos a mostrar*:";
            // 
            // dateTimePickerAnio
            // 
            this.dateTimePickerAnio.Checked = false;
            this.dateTimePickerAnio.CustomFormat = "yyyy";
            this.dateTimePickerAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAnio.Location = new System.Drawing.Point(76, 26);
            this.dateTimePickerAnio.MaxDate = new System.DateTime(2017, 11, 28, 0, 16, 34, 0);
            this.dateTimePickerAnio.Name = "dateTimePickerAnio";
            this.dateTimePickerAnio.Size = new System.Drawing.Size(119, 27);
            this.dateTimePickerAnio.TabIndex = 8;
            this.dateTimePickerAnio.Value = new System.DateTime(2017, 11, 28, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Trimestre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Año:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 74;
            this.label3.Text = "Seleccione Informe:";
            // 
            // comboBoxInforme
            // 
            this.comboBoxInforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboBoxInforme.FormattingEnabled = true;
            this.comboBoxInforme.Location = new System.Drawing.Point(222, 125);
            this.comboBoxInforme.Name = "comboBoxInforme";
            this.comboBoxInforme.Size = new System.Drawing.Size(474, 26);
            this.comboBoxInforme.TabIndex = 75;
            this.comboBoxInforme.SelectedIndexChanged += new System.EventHandler(this.comboBoxInforme_SelectionChangeCommitted);
            // 
            // buttonCargarFacturasPagas
            // 
            this.buttonCargarFacturasPagas.Location = new System.Drawing.Point(531, 32);
            this.buttonCargarFacturasPagas.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCargarFacturasPagas.Name = "buttonCargarFacturasPagas";
            this.buttonCargarFacturasPagas.Size = new System.Drawing.Size(182, 28);
            this.buttonCargarFacturasPagas.TabIndex = 76;
            this.buttonCargarFacturasPagas.Text = "Buscar";
            this.buttonCargarFacturasPagas.UseVisualStyleBackColor = true;
            this.buttonCargarFacturasPagas.Click += new System.EventHandler(this.buttonCargarFacturasPagas_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 70);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 28);
            this.button1.TabIndex = 77;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewTablaInformes
            // 
            this.dataGridViewTablaInformes.AllowUserToAddRows = false;
            this.dataGridViewTablaInformes.AllowUserToDeleteRows = false;
            this.dataGridViewTablaInformes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTablaInformes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTablaInformes.Location = new System.Drawing.Point(12, 171);
            this.dataGridViewTablaInformes.Name = "dataGridViewTablaInformes";
            this.dataGridViewTablaInformes.ReadOnly = true;
            this.dataGridViewTablaInformes.RowTemplate.Height = 24;
            this.dataGridViewTablaInformes.Size = new System.Drawing.Size(701, 247);
            this.dataGridViewTablaInformes.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(391, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(323, 20);
            this.label4.TabIndex = 79;
            this.label4.Text = "(*)Por defecto se muestran las primeros 5";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(34, 425);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 28);
            this.button2.TabIndex = 80;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ListadoEstadisticoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 463);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewTablaInformes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCargarFacturasPagas);
            this.Controls.Add(this.comboBoxInforme);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoEstadisticoForm";
            this.Text = "Listados Estdisticos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidadElementos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTablaInformes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownCantidadElementos;
        private System.Windows.Forms.ComboBox comboBoxTrimestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxInforme;
        private System.Windows.Forms.Button buttonCargarFacturasPagas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewTablaInformes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}