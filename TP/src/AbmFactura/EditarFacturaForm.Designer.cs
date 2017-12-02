namespace PagoAgilFrba.AbmFactura
{
    partial class EditarFacturaForm
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
            this.checkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.buttonSeleccionarEmpresa = new System.Windows.Forms.Button();
            this.dateTimePickerFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.textBoxNumeroFactura = new System.Windows.Forms.TextBox();
            this.textBoxNombreEmpresa = new System.Windows.Forms.TextBox();
            this.textBoxDNICliente = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.dataGridViewDetalleFactura = new System.Windows.Forms.DataGridView();
            this.labelFechaVencimiento = new System.Windows.Forms.Label();
            this.labelFechaAlta = new System.Windows.Forms.Label();
            this.labelIdFactura = new System.Windows.Forms.Label();
            this.labelEmpresa = new System.Windows.Forms.Label();
            this.labelDniCliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxHabilitado
            // 
            this.checkBoxHabilitado.AutoSize = true;
            this.checkBoxHabilitado.Checked = true;
            this.checkBoxHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHabilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHabilitado.Location = new System.Drawing.Point(155, 442);
            this.checkBoxHabilitado.Name = "checkBoxHabilitado";
            this.checkBoxHabilitado.Size = new System.Drawing.Size(92, 22);
            this.checkBoxHabilitado.TabIndex = 48;
            this.checkBoxHabilitado.Text = "Hablitado";
            this.checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // buttonSeleccionarEmpresa
            // 
            this.buttonSeleccionarEmpresa.Location = new System.Drawing.Point(345, 55);
            this.buttonSeleccionarEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSeleccionarEmpresa.Name = "buttonSeleccionarEmpresa";
            this.buttonSeleccionarEmpresa.Size = new System.Drawing.Size(31, 28);
            this.buttonSeleccionarEmpresa.TabIndex = 47;
            this.buttonSeleccionarEmpresa.Text = "...";
            this.buttonSeleccionarEmpresa.UseVisualStyleBackColor = true;
            this.buttonSeleccionarEmpresa.Click += new System.EventHandler(this.buttonSeleccionarEmpresa_Click);
            // 
            // dateTimePickerFechaVencimiento
            // 
            this.dateTimePickerFechaVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaVencimiento.Location = new System.Drawing.Point(155, 401);
            this.dateTimePickerFechaVencimiento.Name = "dateTimePickerFechaVencimiento";
            this.dateTimePickerFechaVencimiento.Size = new System.Drawing.Size(221, 24);
            this.dateTimePickerFechaVencimiento.TabIndex = 46;
            // 
            // dateTimePickerFechaAlta
            // 
            this.dateTimePickerFechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaAlta.Location = new System.Drawing.Point(155, 137);
            this.dateTimePickerFechaAlta.Name = "dateTimePickerFechaAlta";
            this.dateTimePickerFechaAlta.Size = new System.Drawing.Size(221, 24);
            this.dateTimePickerFechaAlta.TabIndex = 44;
            // 
            // textBoxNumeroFactura
            // 
            this.textBoxNumeroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumeroFactura.Location = new System.Drawing.Point(155, 97);
            this.textBoxNumeroFactura.Name = "textBoxNumeroFactura";
            this.textBoxNumeroFactura.Size = new System.Drawing.Size(221, 24);
            this.textBoxNumeroFactura.TabIndex = 43;
            // 
            // textBoxNombreEmpresa
            // 
            this.textBoxNombreEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNombreEmpresa.Location = new System.Drawing.Point(155, 55);
            this.textBoxNombreEmpresa.Name = "textBoxNombreEmpresa";
            this.textBoxNombreEmpresa.ReadOnly = true;
            this.textBoxNombreEmpresa.Size = new System.Drawing.Size(183, 24);
            this.textBoxNombreEmpresa.TabIndex = 42;
            // 
            // textBoxDNICliente
            // 
            this.textBoxDNICliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDNICliente.Location = new System.Drawing.Point(155, 20);
            this.textBoxDNICliente.Name = "textBoxDNICliente";
            this.textBoxDNICliente.Size = new System.Drawing.Size(221, 24);
            this.textBoxDNICliente.TabIndex = 41;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(276, 282);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 40;
            this.button3.Text = "Borrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(276, 227);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 38;
            this.button2.Text = "Agregar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(233, 480);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(100, 28);
            this.buttonCancelar.TabIndex = 37;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(70, 480);
            this.buttonAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(100, 28);
            this.buttonAceptar.TabIndex = 36;
            this.buttonAceptar.Text = "Guardar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(26, 373);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(49, 18);
            this.labelTotal.TabIndex = 34;
            this.labelTotal.Text = "Total: ";
            // 
            // dataGridViewDetalleFactura
            // 
            this.dataGridViewDetalleFactura.AllowUserToAddRows = false;
            this.dataGridViewDetalleFactura.AllowUserToDeleteRows = false;
            this.dataGridViewDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetalleFactura.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewDetalleFactura.Location = new System.Drawing.Point(28, 183);
            this.dataGridViewDetalleFactura.Name = "dataGridViewDetalleFactura";
            this.dataGridViewDetalleFactura.ReadOnly = true;
            this.dataGridViewDetalleFactura.RowTemplate.Height = 24;
            this.dataGridViewDetalleFactura.Size = new System.Drawing.Size(245, 171);
            this.dataGridViewDetalleFactura.TabIndex = 33;
            // 
            // labelFechaVencimiento
            // 
            this.labelFechaVencimiento.AutoSize = true;
            this.labelFechaVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaVencimiento.Location = new System.Drawing.Point(26, 407);
            this.labelFechaVencimiento.Name = "labelFechaVencimiento";
            this.labelFechaVencimiento.Size = new System.Drawing.Size(86, 18);
            this.labelFechaVencimiento.TabIndex = 32;
            this.labelFechaVencimiento.Text = "Fecha Ven: ";
            // 
            // labelFechaAlta
            // 
            this.labelFechaAlta.AutoSize = true;
            this.labelFechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaAlta.Location = new System.Drawing.Point(26, 142);
            this.labelFechaAlta.Name = "labelFechaAlta";
            this.labelFechaAlta.Size = new System.Drawing.Size(85, 18);
            this.labelFechaAlta.TabIndex = 31;
            this.labelFechaAlta.Text = "Fecha Alta: ";
            // 
            // labelIdFactura
            // 
            this.labelIdFactura.AutoSize = true;
            this.labelIdFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdFactura.Location = new System.Drawing.Point(25, 100);
            this.labelIdFactura.Name = "labelIdFactura";
            this.labelIdFactura.Size = new System.Drawing.Size(124, 18);
            this.labelIdFactura.TabIndex = 30;
            this.labelIdFactura.Text = "Numero Factura: ";
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.AutoSize = true;
            this.labelEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmpresa.Location = new System.Drawing.Point(26, 61);
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Size = new System.Drawing.Size(76, 18);
            this.labelEmpresa.TabIndex = 29;
            this.labelEmpresa.Text = "Empresa: ";
            // 
            // labelDniCliente
            // 
            this.labelDniCliente.AutoSize = true;
            this.labelDniCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDniCliente.Location = new System.Drawing.Point(26, 23);
            this.labelDniCliente.Name = "labelDniCliente";
            this.labelDniCliente.Size = new System.Drawing.Size(90, 18);
            this.labelDniCliente.TabIndex = 28;
            this.labelDniCliente.Text = "DNI Cliente: ";
            // 
            // EditarFacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 521);
            this.Controls.Add(this.checkBoxHabilitado);
            this.Controls.Add(this.buttonSeleccionarEmpresa);
            this.Controls.Add(this.dateTimePickerFechaVencimiento);
            this.Controls.Add(this.dateTimePickerFechaAlta);
            this.Controls.Add(this.textBoxNumeroFactura);
            this.Controls.Add(this.textBoxNombreEmpresa);
            this.Controls.Add(this.textBoxDNICliente);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.dataGridViewDetalleFactura);
            this.Controls.Add(this.labelFechaVencimiento);
            this.Controls.Add(this.labelFechaAlta);
            this.Controls.Add(this.labelIdFactura);
            this.Controls.Add(this.labelEmpresa);
            this.Controls.Add(this.labelDniCliente);
            this.Name = "EditarFacturaForm";
            this.Text = "Cargar Factura";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFechaVencimiento;
        private System.Windows.Forms.Label labelFechaAlta;
        private System.Windows.Forms.Label labelIdFactura;
        private System.Windows.Forms.Label labelEmpresa;
        private System.Windows.Forms.Label labelDniCliente;
        private System.Windows.Forms.DataGridView dataGridViewDetalleFactura;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxDNICliente;
        private System.Windows.Forms.TextBox textBoxNombreEmpresa;
        private System.Windows.Forms.TextBox textBoxNumeroFactura;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaAlta;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaVencimiento;
        private System.Windows.Forms.Button buttonSeleccionarEmpresa;
        private System.Windows.Forms.CheckBox checkBoxHabilitado;
    }
}