namespace PagoAgilFrba.Rendicion
{
    partial class RendicionForm
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
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonRendirFacturas = new System.Windows.Forms.Button();
            this.textBoxImporteComision = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownPorcentajeComision = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCargarFacturasPagas = new System.Windows.Forms.Button();
            this.dateTimePickerFechaRendicion = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCantidadFacturas = new System.Windows.Forms.TextBox();
            this.labelEmpresa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPorcentajeComision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(475, 528);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(223, 28);
            this.buttonCancelar.TabIndex = 59;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonRendirFacturas
            // 
            this.buttonRendirFacturas.Location = new System.Drawing.Point(166, 528);
            this.buttonRendirFacturas.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRendirFacturas.Name = "buttonRendirFacturas";
            this.buttonRendirFacturas.Size = new System.Drawing.Size(223, 28);
            this.buttonRendirFacturas.TabIndex = 58;
            this.buttonRendirFacturas.Text = "Rendir Facturas";
            this.buttonRendirFacturas.UseVisualStyleBackColor = true;
            this.buttonRendirFacturas.Click += new System.EventHandler(this.buttonRendirFacturas_Click);
            // 
            // textBoxImporteComision
            // 
            this.textBoxImporteComision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImporteComision.Location = new System.Drawing.Point(636, 483);
            this.textBoxImporteComision.Name = "textBoxImporteComision";
            this.textBoxImporteComision.ReadOnly = true;
            this.textBoxImporteComision.Size = new System.Drawing.Size(183, 24);
            this.textBoxImporteComision.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(458, 485);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 56;
            this.label5.Text = "Importe Comision:";
            // 
            // numericUpDownPorcentajeComision
            // 
            this.numericUpDownPorcentajeComision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPorcentajeComision.Location = new System.Drawing.Point(240, 482);
            this.numericUpDownPorcentajeComision.Name = "numericUpDownPorcentajeComision";
            this.numericUpDownPorcentajeComision.Size = new System.Drawing.Size(183, 24);
            this.numericUpDownPorcentajeComision.TabIndex = 55;
            this.numericUpDownPorcentajeComision.ValueChanged += new System.EventHandler(this.numericUpDownPorcentajeComision_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 483);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 20);
            this.label4.TabIndex = 54;
            this.label4.Text = "Porcentaje Comision:";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotal.Location = new System.Drawing.Point(636, 443);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(183, 24);
            this.textBoxTotal.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(552, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 52;
            this.label3.Text = "Total:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(826, 287);
            this.dataGridView1.TabIndex = 51;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.buttonCargarFacturasPagas);
            this.groupBox1.Controls.Add(this.dateTimePickerFechaRendicion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxEmpresa);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 101);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Rendicion";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 65);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 28);
            this.button1.TabIndex = 58;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCargarFacturasPagas
            // 
            this.buttonCargarFacturasPagas.Location = new System.Drawing.Point(531, 28);
            this.buttonCargarFacturasPagas.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCargarFacturasPagas.Name = "buttonCargarFacturasPagas";
            this.buttonCargarFacturasPagas.Size = new System.Drawing.Size(223, 28);
            this.buttonCargarFacturasPagas.TabIndex = 52;
            this.buttonCargarFacturasPagas.Text = "Cargar Facturas Pagas";
            this.buttonCargarFacturasPagas.UseVisualStyleBackColor = true;
            this.buttonCargarFacturasPagas.Click += new System.EventHandler(this.buttonCargarFacturasPagas_Click);
            // 
            // dateTimePickerFechaRendicion
            // 
            this.dateTimePickerFechaRendicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaRendicion.Location = new System.Drawing.Point(277, 60);
            this.dateTimePickerFechaRendicion.Name = "dateTimePickerFechaRendicion";
            this.dateTimePickerFechaRendicion.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerFechaRendicion.TabIndex = 8;
            this.dateTimePickerFechaRendicion.Value = new System.DateTime(2017, 11, 28, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha de Rendicion";
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(236, 26);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(241, 26);
            this.comboBoxEmpresa.TabIndex = 6;
            this.comboBoxEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmpresa_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Empresa";
            // 
            // textBoxCantidadFacturas
            // 
            this.textBoxCantidadFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCantidadFacturas.Location = new System.Drawing.Point(240, 443);
            this.textBoxCantidadFacturas.Name = "textBoxCantidadFacturas";
            this.textBoxCantidadFacturas.ReadOnly = true;
            this.textBoxCantidadFacturas.Size = new System.Drawing.Size(183, 24);
            this.textBoxCantidadFacturas.TabIndex = 49;
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.AutoSize = true;
            this.labelEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmpresa.Location = new System.Drawing.Point(44, 443);
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Size = new System.Drawing.Size(174, 20);
            this.labelEmpresa.TabIndex = 48;
            this.labelEmpresa.Text = "Nro Facturas a rendir:";
            // 
            // RendicionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 569);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonRendirFacturas);
            this.Controls.Add(this.textBoxImporteComision);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownPorcentajeComision);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxCantidadFacturas);
            this.Controls.Add(this.labelEmpresa);
            this.Name = "RendicionForm";
            this.Text = "Rendicion";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPorcentajeComision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEmpresa;
        private System.Windows.Forms.TextBox textBoxCantidadFacturas;
        private System.Windows.Forms.Button buttonCargarFacturasPagas;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaRendicion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownPorcentajeComision;
        private System.Windows.Forms.TextBox textBoxImporteComision;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonRendirFacturas;
        private System.Windows.Forms.Button buttonCancelar;
    }
}