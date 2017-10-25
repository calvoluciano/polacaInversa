namespace PagoAgilFrba.AbmFactura
{
    partial class TablaFacturaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numeroFactura = new System.Windows.Forms.TextBox();
            this.cuit = new System.Windows.Forms.TextBox();
            this.dniCliente = new System.Windows.Forms.TextBox();
            this.total = new System.Windows.Forms.TextBox();
            this.buttonFiltrar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero Factura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "DNI Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "CUIT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cuit);
            this.groupBox1.Controls.Add(this.dniCliente);
            this.groupBox1.Controls.Add(this.total);
            this.groupBox1.Controls.Add(this.numeroFactura);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 170);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de busqueda";
            // 
            // numeroFactura
            // 
            this.numeroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroFactura.Location = new System.Drawing.Point(151, 33);
            this.numeroFactura.MaxLength = 20;
            this.numeroFactura.Name = "numeroFactura";
            this.numeroFactura.Size = new System.Drawing.Size(228, 24);
            this.numeroFactura.TabIndex = 4;
            // 
            // cuit
            // 
            this.cuit.Location = new System.Drawing.Point(151, 127);
            this.cuit.Name = "cuit";
            this.cuit.Size = new System.Drawing.Size(228, 27);
            this.cuit.TabIndex = 5;
            // 
            // dniCliente
            // 
            this.dniCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dniCliente.Location = new System.Drawing.Point(151, 63);
            this.dniCliente.MaxLength = 20;
            this.dniCliente.Name = "dniCliente";
            this.dniCliente.Size = new System.Drawing.Size(228, 24);
            this.dniCliente.TabIndex = 4;
            // 
            // total
            // 
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.Location = new System.Drawing.Point(151, 93);
            this.total.MaxLength = 20;
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(228, 24);
            this.total.TabIndex = 4;
            // 
            // buttonFiltrar
            // 
            this.buttonFiltrar.Location = new System.Drawing.Point(651, 38);
            this.buttonFiltrar.Name = "buttonFiltrar";
            this.buttonFiltrar.Size = new System.Drawing.Size(87, 31);
            this.buttonFiltrar.TabIndex = 4;
            this.buttonFiltrar.Text = "Filtrar";
            this.buttonFiltrar.UseVisualStyleBackColor = true;
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(651, 88);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(87, 31);
            this.buttonLimpiar.TabIndex = 5;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 188);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(746, 296);
            this.dataGridView1.TabIndex = 6;
            // 
            // TablaFacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 510);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonFiltrar);
            this.Controls.Add(this.groupBox1);
            this.Name = "TablaFacturaForm";
            this.Text = "Tabla Sucursal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox numeroFactura;
        private System.Windows.Forms.TextBox cuit;
        private System.Windows.Forms.TextBox dniCliente;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.Button buttonFiltrar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.DataGridView dataGridView1;

        #endregion
    }
}