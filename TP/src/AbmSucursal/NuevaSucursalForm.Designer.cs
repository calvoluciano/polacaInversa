namespace PagoAgilFrba.AbmSucursal
{
    partial class NuevaSucursalForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();        
            this.checkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonSeleccionarUsuario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePickerFechaNac
            // 
            this.dateTimePickerFechaNac.Enabled = false;
            this.dateTimePickerFechaNac.Location = new System.Drawing.Point(17, 290);
            this.dateTimePickerFechaNac.Name = "dateTimePickerFechaNac";
            this.dateTimePickerFechaNac.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFechaNac.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
       
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Direccion";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(17, 56);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.ReadOnly = true;
            this.textBoxNombre.Size = new System.Drawing.Size(200, 20);
            this.textBoxNombre.TabIndex = 9;        
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(17, 173);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.ReadOnly = true;
            this.textBoxDireccion.Size = new System.Drawing.Size(200, 20);
            this.textBoxDireccion.TabIndex = 13;          
            // 
            // checkBoxHabilitado
            // 
            this.checkBoxHabilitado.AutoSize = true;
            this.checkBoxHabilitado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxHabilitado.Checked = true;
            this.checkBoxHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHabilitado.Location = new System.Drawing.Point(79, 316);
            this.checkBoxHabilitado.Name = "checkBoxHabilitado";
            this.checkBoxHabilitado.Size = new System.Drawing.Size(73, 17);
            this.checkBoxHabilitado.TabIndex = 15;
            this.checkBoxHabilitado.Text = "Habilitado";
            this.checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(125, 339);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 17;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(26, 339);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 16;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonSeleccionarUsuario
            // 
            this.buttonSeleccionarUsuario.Location = new System.Drawing.Point(54, 12);
            this.buttonSeleccionarUsuario.Name = "buttonSeleccionarUsuario";
            this.buttonSeleccionarUsuario.Size = new System.Drawing.Size(122, 23);
            this.buttonSeleccionarUsuario.TabIndex = 18;
            this.buttonSeleccionarUsuario.Text = "Seleccionar Usuario";
            this.buttonSeleccionarUsuario.UseVisualStyleBackColor = true;
            this.buttonSeleccionarUsuario.Click += new System.EventHandler(this.buttonSeleccionarUsuario_Click);
            // 
            // NuevaSucursalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 379);
            this.Controls.Add(this.buttonSeleccionarUsuario);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.checkBoxHabilitado);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "NuevoChoferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Chofer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerFechaNac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.CheckBox checkBoxHabilitado;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonSeleccionarUsuario;
    }
}