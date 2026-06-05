namespace ProyectoAlmacenamiento
{
    partial class Entrega
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
            this.comboBoxRuta = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TimeSalida = new System.Windows.Forms.DateTimePicker();
            this.TablaEntrega = new System.Windows.Forms.DataGridView();
            this.botonClickModificar = new System.Windows.Forms.Button();
            this.botonClickEliminar = new System.Windows.Forms.Button();
            this.botonClickInsertar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TablaEntrega)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxRuta
            // 
            this.comboBoxRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRuta.FormattingEnabled = true;
            this.comboBoxRuta.Location = new System.Drawing.Point(249, 144);
            this.comboBoxRuta.Name = "comboBoxRuta";
            this.comboBoxRuta.Size = new System.Drawing.Size(380, 34);
            this.comboBoxRuta.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 57;
            this.label6.Text = "Fecha de entrega";
            // 
            // TimeSalida
            // 
            this.TimeSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeSalida.Location = new System.Drawing.Point(340, 210);
            this.TimeSalida.Name = "TimeSalida";
            this.TimeSalida.Size = new System.Drawing.Size(200, 26);
            this.TimeSalida.TabIndex = 55;
            // 
            // TablaEntrega
            // 
            this.TablaEntrega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaEntrega.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.TablaEntrega.Location = new System.Drawing.Point(51, 346);
            this.TablaEntrega.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TablaEntrega.Name = "TablaEntrega";
            this.TablaEntrega.RowHeadersWidth = 51;
            this.TablaEntrega.RowTemplate.Height = 24;
            this.TablaEntrega.Size = new System.Drawing.Size(787, 282);
            this.TablaEntrega.TabIndex = 53;
            this.TablaEntrega.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaEntrega_CellContentClick);
            // 
            // botonClickModificar
            // 
            this.botonClickModificar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickModificar.Location = new System.Drawing.Point(373, 278);
            this.botonClickModificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickModificar.Name = "botonClickModificar";
            this.botonClickModificar.Size = new System.Drawing.Size(130, 39);
            this.botonClickModificar.TabIndex = 52;
            this.botonClickModificar.Text = "Modificar";
            this.botonClickModificar.UseVisualStyleBackColor = true;
            this.botonClickModificar.Click += new System.EventHandler(this.botonClickModificar_Click);
            // 
            // botonClickEliminar
            // 
            this.botonClickEliminar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickEliminar.Location = new System.Drawing.Point(581, 278);
            this.botonClickEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickEliminar.Name = "botonClickEliminar";
            this.botonClickEliminar.Size = new System.Drawing.Size(130, 39);
            this.botonClickEliminar.TabIndex = 51;
            this.botonClickEliminar.Text = "Eliminar";
            this.botonClickEliminar.UseVisualStyleBackColor = true;
            this.botonClickEliminar.Click += new System.EventHandler(this.botonClickEliminar_Click);
            // 
            // botonClickInsertar
            // 
            this.botonClickInsertar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickInsertar.Location = new System.Drawing.Point(159, 278);
            this.botonClickInsertar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickInsertar.Name = "botonClickInsertar";
            this.botonClickInsertar.Size = new System.Drawing.Size(130, 39);
            this.botonClickInsertar.TabIndex = 50;
            this.botonClickInsertar.Text = "Insertar";
            this.botonClickInsertar.UseVisualStyleBackColor = true;
            this.botonClickInsertar.Click += new System.EventHandler(this.botonClickInsertar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(335, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 29);
            this.label5.TabIndex = 49;
            this.label5.Text = "ENTREGA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 29);
            this.label1.TabIndex = 47;
            this.label1.Text = "Ruta";
            // 
            // comboEstado
            // 
            this.comboEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEstado.FormattingEnabled = true;
            this.comboEstado.Location = new System.Drawing.Point(340, 62);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(380, 34);
            this.comboEstado.TabIndex = 60;
            this.comboEstado.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 29);
            this.label2.TabIndex = 59;
            this.label2.Text = "Estado de Entrega";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Entrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 670);
            this.Controls.Add(this.comboEstado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxRuta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TimeSalida);
            this.Controls.Add(this.TablaEntrega);
            this.Controls.Add(this.botonClickModificar);
            this.Controls.Add(this.botonClickEliminar);
            this.Controls.Add(this.botonClickInsertar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "Entrega";
            this.Text = "Entrega";
            ((System.ComponentModel.ISupportInitialize)(this.TablaEntrega)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxRuta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker TimeSalida;
        private System.Windows.Forms.DataGridView TablaEntrega;
        private System.Windows.Forms.Button botonClickModificar;
        private System.Windows.Forms.Button botonClickEliminar;
        private System.Windows.Forms.Button botonClickInsertar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.Label label2;
    }
}