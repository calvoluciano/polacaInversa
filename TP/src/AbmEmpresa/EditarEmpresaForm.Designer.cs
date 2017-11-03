namespace PagoAgilFrba.AbmEmpresa
{
    partial class EditarEmpresaForm
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
            this.dateTimePickerFechaNac = new System.Windows.Forms.DateTimePicker();
            this.comboBoxRubro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCuit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.checkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePickerFechaNac
            // 
            this.dateTimePickerFechaNac.Enabled = false;
            this.dateTimePickerFechaNac.Location = new System.Drawing.Point(17, 290);
            this.dateTimePickerFechaNac.Name = "dateTimePickerFechaNac";
            this.dateTimePickerFechaNac.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFechaNac.TabIndex = 0;
            // 
            // comboBoxRubro
            // 
            this.comboBoxRubro.FormattingEnabled = true;
            this.comboBoxRubro.Location = new System.Drawing.Point(109, 157);
            this.comboBoxRubro.Name = "comboBoxRubro";
            this.comboBoxRubro.Size = new System.Drawing.Size(265, 24);
            this.comboBoxRubro.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Rubro";
            // 
            // textBoxCuit
            // 
            this.textBoxCuit.Location = new System.Drawing.Point(109, 67);
            this.textBoxCuit.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCuit.Name = "textBoxCuit";
            this.textBoxCuit.Size = new System.Drawing.Size(265, 22);
            this.textBoxCuit.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cuit";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(219, 235);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(100, 28);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(66, 235);
            this.buttonAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(100, 28);
            this.buttonAceptar.TabIndex = 9;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // checkBoxHabilitado
            // 
            this.checkBoxHabilitado.AutoSize = true;
            this.checkBoxHabilitado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxHabilitado.Checked = true;
            this.checkBoxHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHabilitado.Location = new System.Drawing.Point(140, 197);
            this.checkBoxHabilitado.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxHabilitado.Name = "checkBoxHabilitado";
            this.checkBoxHabilitado.Size = new System.Drawing.Size(93, 21);
            this.checkBoxHabilitado.TabIndex = 7;
            this.checkBoxHabilitado.Text = "Habilitado";
            this.checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(109, 112);
            this.textBoxDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(265, 22);
            this.textBoxDireccion.TabIndex = 5;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(109, 25);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(265, 22);
            this.textBoxNombre.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Direccion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // NuevaEmpresaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 273);
            this.Controls.Add(this.comboBoxRubro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCuit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.checkBoxHabilitado);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "NuevaEmpresaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Empresa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerFechaNac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.CheckBox checkBoxHabilitado;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.TextBox textBoxCuit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxRubro;
    }
}