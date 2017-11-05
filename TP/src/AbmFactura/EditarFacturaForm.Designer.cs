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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNumeroFactura = new System.Windows.Forms.TextBox();
            this.buttonSeleccionarEmpresa = new System.Windows.Forms.Button();
            this.textBoxDNICliente = new System.Windows.Forms.TextBox();
            this.textBoxNombreEmpresa = new System.Windows.Forms.TextBox();
            this.dateTimePickerFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 18);
            this.label10.TabIndex = 40;
            this.label10.Text = "Fecha Vencimiento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(36, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 18);
            this.label9.TabIndex = 39;
            this.label9.Text = "Fecha Alta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 38;
            this.label8.Text = "Numero Factura";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 18);
            this.label7.TabIndex = 37;
            this.label7.Text = "Empresa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 18);
            this.label6.TabIndex = 36;
            this.label6.Text = "DNI Cliente";
            // 
            // textBoxNumeroFactura
            // 
            this.textBoxNumeroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumeroFactura.Location = new System.Drawing.Point(188, 110);
            this.textBoxNumeroFactura.Name = "textBoxNumeroFactura";
            this.textBoxNumeroFactura.Size = new System.Drawing.Size(266, 24);
            this.textBoxNumeroFactura.TabIndex = 35;
            // 
            // buttonSeleccionarEmpresa
            // 
            this.buttonSeleccionarEmpresa.Location = new System.Drawing.Point(386, 62);
            this.buttonSeleccionarEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSeleccionarEmpresa.Name = "buttonSeleccionarEmpresa";
            this.buttonSeleccionarEmpresa.Size = new System.Drawing.Size(67, 28);
            this.buttonSeleccionarEmpresa.TabIndex = 34;
            this.buttonSeleccionarEmpresa.Text = "...";
            this.buttonSeleccionarEmpresa.UseVisualStyleBackColor = true;
            this.buttonSeleccionarEmpresa.Click += new System.EventHandler(this.buttonSeleccionarEmpresa_Click);
            // 
            // textBoxDNICliente
            // 
            this.textBoxDNICliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDNICliente.Location = new System.Drawing.Point(187, 17);
            this.textBoxDNICliente.Name = "textBoxDNICliente";
            this.textBoxDNICliente.Size = new System.Drawing.Size(266, 24);
            this.textBoxDNICliente.TabIndex = 28;
            // 
            // textBoxNombreEmpresa
            // 
            this.textBoxNombreEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNombreEmpresa.Location = new System.Drawing.Point(187, 62);
            this.textBoxNombreEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNombreEmpresa.Name = "textBoxNombreEmpresa";
            this.textBoxNombreEmpresa.ReadOnly = true;
            this.textBoxNombreEmpresa.Size = new System.Drawing.Size(191, 24);
            this.textBoxNombreEmpresa.TabIndex = 31;
            // 
            // dateTimePickerFechaAlta
            // 
            this.dateTimePickerFechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFechaAlta.Location = new System.Drawing.Point(188, 156);
            this.dateTimePickerFechaAlta.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFechaAlta.Name = "dateTimePickerFechaAlta";
            this.dateTimePickerFechaAlta.Size = new System.Drawing.Size(266, 24);
            this.dateTimePickerFechaAlta.TabIndex = 29;
            // 
            // dateTimePickerFechaVencimiento
            // 
            this.dateTimePickerFechaVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFechaVencimiento.Location = new System.Drawing.Point(188, 202);
            this.dateTimePickerFechaVencimiento.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFechaVencimiento.Name = "dateTimePickerFechaVencimiento";
            this.dateTimePickerFechaVencimiento.Size = new System.Drawing.Size(265, 24);
            this.dateTimePickerFechaVencimiento.TabIndex = 30;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(278, 254);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(100, 28);
            this.buttonCancelar.TabIndex = 17;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(98, 254);
            this.buttonAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(100, 28);
            this.buttonAceptar.TabIndex = 16;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // EditarFacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 295);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxNumeroFactura);
            this.Controls.Add(this.buttonSeleccionarEmpresa);
            this.Controls.Add(this.textBoxDNICliente);
            this.Controls.Add(this.textBoxNombreEmpresa);
            this.Controls.Add(this.dateTimePickerFechaAlta);
            this.Controls.Add(this.dateTimePickerFechaVencimiento);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "EditarFacturaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Factura";
            this.Load += new System.EventHandler(this.EditarFacturaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNumeroFactura;
        private System.Windows.Forms.Button buttonSeleccionarEmpresa;
        private System.Windows.Forms.TextBox textBoxDNICliente;
        private System.Windows.Forms.TextBox textBoxNombreEmpresa;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaAlta;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaVencimiento;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion
    }
}