namespace ProyectoAlmacenamiento
{
    partial class DomicilioCliente
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
            this.TablaDomCliente = new System.Windows.Forms.DataGridView();
            this.botonClickModificar = new System.Windows.Forms.Button();
            this.botonClickEliminar = new System.Windows.Forms.Button();
            this.botonClickInsertar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textCalle_Cliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_codigoPostal = new System.Windows.Forms.TextBox();
            this.text_coloniaCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxClientes = new System.Windows.Forms.ComboBox();
            this.textExt = new System.Windows.Forms.TextBox();
            this.textInt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaDomCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaDomCliente
            // 
            this.TablaDomCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaDomCliente.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.TablaDomCliente.Location = new System.Drawing.Point(74, 318);
            this.TablaDomCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TablaDomCliente.Name = "TablaDomCliente";
            this.TablaDomCliente.RowHeadersWidth = 51;
            this.TablaDomCliente.RowTemplate.Height = 24;
            this.TablaDomCliente.Size = new System.Drawing.Size(1116, 325);
            this.TablaDomCliente.TabIndex = 36;
            this.TablaDomCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaDomCliente_CellContentClick);
            // 
            // botonClickModificar
            // 
            this.botonClickModificar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickModificar.Location = new System.Drawing.Point(551, 255);
            this.botonClickModificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickModificar.Name = "botonClickModificar";
            this.botonClickModificar.Size = new System.Drawing.Size(130, 39);
            this.botonClickModificar.TabIndex = 35;
            this.botonClickModificar.Text = "Modificar";
            this.botonClickModificar.UseVisualStyleBackColor = true;
            this.botonClickModificar.Click += new System.EventHandler(this.botonClickModificar_Click);
            // 
            // botonClickEliminar
            // 
            this.botonClickEliminar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickEliminar.Location = new System.Drawing.Point(759, 255);
            this.botonClickEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickEliminar.Name = "botonClickEliminar";
            this.botonClickEliminar.Size = new System.Drawing.Size(130, 39);
            this.botonClickEliminar.TabIndex = 34;
            this.botonClickEliminar.Text = "Eliminar";
            this.botonClickEliminar.UseVisualStyleBackColor = true;
            this.botonClickEliminar.Click += new System.EventHandler(this.botonClickEliminar_Click);
            // 
            // botonClickInsertar
            // 
            this.botonClickInsertar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickInsertar.Location = new System.Drawing.Point(337, 255);
            this.botonClickInsertar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickInsertar.Name = "botonClickInsertar";
            this.botonClickInsertar.Size = new System.Drawing.Size(130, 39);
            this.botonClickInsertar.TabIndex = 33;
            this.botonClickInsertar.Text = "Insertar";
            this.botonClickInsertar.UseVisualStyleBackColor = true;
            this.botonClickInsertar.Click += new System.EventHandler(this.botonClickInsertar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(432, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(347, 29);
            this.label5.TabIndex = 32;
            this.label5.Text = "DOMICILIO DEL CLIENTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 29);
            this.label3.TabIndex = 31;
            this.label3.Text = "Número Ext.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(617, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 29);
            this.label2.TabIndex = 30;
            this.label2.Text = "Número Int";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 29);
            this.label1.TabIndex = 29;
            this.label1.Text = "Calle";
            // 
            // textCalle_Cliente
            // 
            this.textCalle_Cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCalle_Cliente.Location = new System.Drawing.Point(188, 150);
            this.textCalle_Cliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textCalle_Cliente.Name = "textCalle_Cliente";
            this.textCalle_Cliente.Size = new System.Drawing.Size(380, 35);
            this.textCalle_Cliente.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(617, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 29);
            this.label4.TabIndex = 40;
            this.label4.Text = "Colonia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(617, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 29);
            this.label6.TabIndex = 39;
            this.label6.Text = "Código Postal";
            // 
            // text_codigoPostal
            // 
            this.text_codigoPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_codigoPostal.Location = new System.Drawing.Point(810, 152);
            this.text_codigoPostal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.text_codigoPostal.Name = "text_codigoPostal";
            this.text_codigoPostal.Size = new System.Drawing.Size(380, 35);
            this.text_codigoPostal.TabIndex = 38;
            // 
            // text_coloniaCliente
            // 
            this.text_coloniaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_coloniaCliente.Location = new System.Drawing.Point(810, 103);
            this.text_coloniaCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.text_coloniaCliente.Name = "text_coloniaCliente";
            this.text_coloniaCliente.Size = new System.Drawing.Size(380, 35);
            this.text_coloniaCliente.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(67, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 29);
            this.label7.TabIndex = 43;
            this.label7.Text = "Cliente";
            // 
            // comboBoxClientes
            // 
            this.comboBoxClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxClientes.FormattingEnabled = true;
            this.comboBoxClientes.Location = new System.Drawing.Point(188, 104);
            this.comboBoxClientes.Name = "comboBoxClientes";
            this.comboBoxClientes.Size = new System.Drawing.Size(380, 34);
            this.comboBoxClientes.TabIndex = 44;
            // 
            // textExt
            // 
            this.textExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textExt.Location = new System.Drawing.Point(236, 195);
            this.textExt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textExt.Name = "textExt";
            this.textExt.Size = new System.Drawing.Size(152, 35);
            this.textExt.TabIndex = 47;
            // 
            // textInt
            // 
            this.textInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInt.Location = new System.Drawing.Point(810, 195);
            this.textInt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textInt.Name = "textInt";
            this.textInt.Size = new System.Drawing.Size(152, 35);
            this.textInt.TabIndex = 48;
            // 
            // DomicilioCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 730);
            this.Controls.Add(this.textInt);
            this.Controls.Add(this.textExt);
            this.Controls.Add(this.comboBoxClientes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.text_codigoPostal);
            this.Controls.Add(this.text_coloniaCliente);
            this.Controls.Add(this.TablaDomCliente);
            this.Controls.Add(this.botonClickModificar);
            this.Controls.Add(this.botonClickEliminar);
            this.Controls.Add(this.botonClickInsertar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textCalle_Cliente);
            this.Name = "DomicilioCliente";
            this.Text = "Domicilio del Cliente";
            this.Load += new System.EventHandler(this.DomicilioCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaDomCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaDomCliente;
        private System.Windows.Forms.Button botonClickModificar;
        private System.Windows.Forms.Button botonClickEliminar;
        private System.Windows.Forms.Button botonClickInsertar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCalle_Cliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_codigoPostal;
        private System.Windows.Forms.TextBox text_coloniaCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.TextBox textExt;
        private System.Windows.Forms.TextBox textInt;
    }
}