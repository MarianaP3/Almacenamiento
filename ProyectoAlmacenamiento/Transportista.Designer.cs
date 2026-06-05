namespace ProyectoAlmacenamiento
{
    partial class Transportista
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
            this.TablaTransportista = new System.Windows.Forms.DataGridView();
            this.botonClickModificar = new System.Windows.Forms.Button();
            this.botonClickEliminar = new System.Windows.Forms.Button();
            this.botonClickInsertar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textTelefono_Transportista = new System.Windows.Forms.TextBox();
            this.textCorreo_Transportista = new System.Windows.Forms.TextBox();
            this.textNombre_Transportista = new System.Windows.Forms.TextBox();
            this.TimeEntrada = new System.Windows.Forms.DateTimePicker();
            this.TimeSalida = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TablaTransportista)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaTransportista
            // 
            this.TablaTransportista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaTransportista.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.TablaTransportista.Location = new System.Drawing.Point(65, 428);
            this.TablaTransportista.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TablaTransportista.Name = "TablaTransportista";
            this.TablaTransportista.RowHeadersWidth = 51;
            this.TablaTransportista.RowTemplate.Height = 24;
            this.TablaTransportista.Size = new System.Drawing.Size(694, 209);
            this.TablaTransportista.TabIndex = 25;
            this.TablaTransportista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaTransportista_CellContentClick);
            // 
            // botonClickModificar
            // 
            this.botonClickModificar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickModificar.Location = new System.Drawing.Point(334, 351);
            this.botonClickModificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickModificar.Name = "botonClickModificar";
            this.botonClickModificar.Size = new System.Drawing.Size(130, 39);
            this.botonClickModificar.TabIndex = 24;
            this.botonClickModificar.Text = "Modificar";
            this.botonClickModificar.UseVisualStyleBackColor = true;
            this.botonClickModificar.Click += new System.EventHandler(this.botonClickModificar_Click);
            // 
            // botonClickEliminar
            // 
            this.botonClickEliminar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickEliminar.Location = new System.Drawing.Point(542, 351);
            this.botonClickEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickEliminar.Name = "botonClickEliminar";
            this.botonClickEliminar.Size = new System.Drawing.Size(130, 39);
            this.botonClickEliminar.TabIndex = 23;
            this.botonClickEliminar.Text = "Eliminar";
            this.botonClickEliminar.UseVisualStyleBackColor = true;
            this.botonClickEliminar.Click += new System.EventHandler(this.botonClickEliminar_Click);
            // 
            // botonClickInsertar
            // 
            this.botonClickInsertar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickInsertar.Location = new System.Drawing.Point(120, 351);
            this.botonClickInsertar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickInsertar.Name = "botonClickInsertar";
            this.botonClickInsertar.Size = new System.Drawing.Size(130, 39);
            this.botonClickInsertar.TabIndex = 22;
            this.botonClickInsertar.Text = "Insertar";
            this.botonClickInsertar.UseVisualStyleBackColor = true;
            this.botonClickInsertar.Click += new System.EventHandler(this.botonClickInsertar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(268, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 29);
            this.label5.TabIndex = 21;
            this.label5.Text = "TRANSPORTISTA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(114, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 29);
            this.label3.TabIndex = 18;
            this.label3.Text = "Correo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(114, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "Teléfono";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre";
            // 
            // textTelefono_Transportista
            // 
            this.textTelefono_Transportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTelefono_Transportista.Location = new System.Drawing.Point(311, 220);
            this.textTelefono_Transportista.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textTelefono_Transportista.Name = "textTelefono_Transportista";
            this.textTelefono_Transportista.Size = new System.Drawing.Size(380, 35);
            this.textTelefono_Transportista.TabIndex = 15;
            // 
            // textCorreo_Transportista
            // 
            this.textCorreo_Transportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCorreo_Transportista.Location = new System.Drawing.Point(311, 154);
            this.textCorreo_Transportista.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textCorreo_Transportista.Name = "textCorreo_Transportista";
            this.textCorreo_Transportista.Size = new System.Drawing.Size(380, 35);
            this.textCorreo_Transportista.TabIndex = 14;
            // 
            // textNombre_Transportista
            // 
            this.textNombre_Transportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombre_Transportista.Location = new System.Drawing.Point(311, 91);
            this.textNombre_Transportista.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textNombre_Transportista.Name = "textNombre_Transportista";
            this.textNombre_Transportista.Size = new System.Drawing.Size(380, 35);
            this.textNombre_Transportista.TabIndex = 13;
            // 
            // TimeEntrada
            // 
            this.TimeEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeEntrada.Location = new System.Drawing.Point(164, 309);
            this.TimeEntrada.Name = "TimeEntrada";
            this.TimeEntrada.Size = new System.Drawing.Size(200, 26);
            this.TimeEntrada.TabIndex = 26;
            // 
            // TimeSalida
            // 
            this.TimeSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeSalida.Location = new System.Drawing.Point(448, 309);
            this.TimeSalida.Name = "TimeSalida";
            this.TimeSalida.Size = new System.Drawing.Size(200, 26);
            this.TimeSalida.TabIndex = 27;
            this.TimeSalida.ValueChanged += new System.EventHandler(this.TimeSalida_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Hora de entrada:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(485, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Hora de salida:";
            // 
            // Transportista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 844);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TimeSalida);
            this.Controls.Add(this.TimeEntrada);
            this.Controls.Add(this.TablaTransportista);
            this.Controls.Add(this.botonClickModificar);
            this.Controls.Add(this.botonClickEliminar);
            this.Controls.Add(this.botonClickInsertar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textTelefono_Transportista);
            this.Controls.Add(this.textCorreo_Transportista);
            this.Controls.Add(this.textNombre_Transportista);
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.Name = "Transportista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transportista";
            this.Load += new System.EventHandler(this.Transportista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaTransportista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaTransportista;
        private System.Windows.Forms.Button botonClickModificar;
        private System.Windows.Forms.Button botonClickEliminar;
        private System.Windows.Forms.Button botonClickInsertar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTelefono_Transportista;
        private System.Windows.Forms.TextBox textCorreo_Transportista;
        private System.Windows.Forms.TextBox textNombre_Transportista;
        private System.Windows.Forms.DateTimePicker TimeEntrada;
        private System.Windows.Forms.DateTimePicker TimeSalida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}