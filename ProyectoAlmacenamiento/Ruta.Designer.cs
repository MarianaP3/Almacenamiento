namespace ProyectoAlmacenamiento
{
    partial class Ruta
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
            this.TablaRuta = new System.Windows.Forms.DataGridView();
            this.botonClickModificar = new System.Windows.Forms.Button();
            this.botonClickEliminar = new System.Windows.Forms.Button();
            this.botonClickInsertar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TimeSalida = new System.Windows.Forms.DateTimePicker();
            this.TimeEntrada = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTrasportista = new System.Windows.Forms.ComboBox();
            this.comboBoxTransporte = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaRuta)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaRuta
            // 
            this.TablaRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaRuta.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.TablaRuta.Location = new System.Drawing.Point(67, 387);
            this.TablaRuta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TablaRuta.Name = "TablaRuta";
            this.TablaRuta.RowHeadersWidth = 51;
            this.TablaRuta.RowTemplate.Height = 24;
            this.TablaRuta.Size = new System.Drawing.Size(787, 227);
            this.TablaRuta.TabIndex = 36;
            this.TablaRuta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaRuta_CellContentClick);
            // 
            // botonClickModificar
            // 
            this.botonClickModificar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickModificar.Location = new System.Drawing.Point(389, 303);
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
            this.botonClickEliminar.Location = new System.Drawing.Point(597, 303);
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
            this.botonClickInsertar.Location = new System.Drawing.Point(175, 303);
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
            this.label5.Location = new System.Drawing.Point(374, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 29);
            this.label5.TabIndex = 32;
            this.label5.Text = "RUTA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 29);
            this.label3.TabIndex = 31;
            this.label3.Text = "Transporte";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 29);
            this.label1.TabIndex = 29;
            this.label1.Text = "Transportista";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "Hora de salida:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Hora de regreso";
            // 
            // TimeSalida
            // 
            this.TimeSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeSalida.Location = new System.Drawing.Point(198, 250);
            this.TimeSalida.Name = "TimeSalida";
            this.TimeSalida.Size = new System.Drawing.Size(200, 26);
            this.TimeSalida.TabIndex = 38;
            this.TimeSalida.ValueChanged += new System.EventHandler(this.TimeSalida_ValueChanged);
            // 
            // TimeEntrada
            // 
            this.TimeEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeEntrada.Location = new System.Drawing.Point(497, 250);
            this.TimeEntrada.Name = "TimeEntrada";
            this.TimeEntrada.Size = new System.Drawing.Size(200, 26);
            this.TimeEntrada.TabIndex = 37;
            // 
            // comboBoxTrasportista
            // 
            this.comboBoxTrasportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTrasportista.FormattingEnabled = true;
            this.comboBoxTrasportista.Location = new System.Drawing.Point(358, 93);
            this.comboBoxTrasportista.Name = "comboBoxTrasportista";
            this.comboBoxTrasportista.Size = new System.Drawing.Size(380, 34);
            this.comboBoxTrasportista.TabIndex = 45;
            // 
            // comboBoxTransporte
            // 
            this.comboBoxTransporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTransporte.FormattingEnabled = true;
            this.comboBoxTransporte.Location = new System.Drawing.Point(358, 157);
            this.comboBoxTransporte.Name = "comboBoxTransporte";
            this.comboBoxTransporte.Size = new System.Drawing.Size(380, 34);
            this.comboBoxTransporte.TabIndex = 46;
            // 
            // Ruta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 651);
            this.Controls.Add(this.comboBoxTransporte);
            this.Controls.Add(this.comboBoxTrasportista);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TimeSalida);
            this.Controls.Add(this.TimeEntrada);
            this.Controls.Add(this.TablaRuta);
            this.Controls.Add(this.botonClickModificar);
            this.Controls.Add(this.botonClickEliminar);
            this.Controls.Add(this.botonClickInsertar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Ruta";
            this.Text = "Ruta";
            this.Load += new System.EventHandler(this.Ruta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaRuta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaRuta;
        private System.Windows.Forms.Button botonClickModificar;
        private System.Windows.Forms.Button botonClickEliminar;
        private System.Windows.Forms.Button botonClickInsertar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker TimeSalida;
        private System.Windows.Forms.DateTimePicker TimeEntrada;
        private System.Windows.Forms.ComboBox comboBoxTrasportista;
        private System.Windows.Forms.ComboBox comboBoxTransporte;
    }
}