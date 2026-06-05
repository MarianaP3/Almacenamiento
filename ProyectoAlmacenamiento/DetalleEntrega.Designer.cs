namespace ProyectoAlmacenamiento
{
    partial class DetalleEntrega
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
            this.comboBoxAlmacenamiento = new System.Windows.Forms.ComboBox();
            this.comboBoxEntrega = new System.Windows.Forms.ComboBox();
            this.TablaDetalleEntrega = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.botonClickModificar = new System.Windows.Forms.Button();
            this.botonClickEliminar = new System.Windows.Forms.Button();
            this.botonClickInsertar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TablaDetalleEntrega)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxAlmacenamiento
            // 
            this.comboBoxAlmacenamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAlmacenamiento.FormattingEnabled = true;
            this.comboBoxAlmacenamiento.Location = new System.Drawing.Point(327, 159);
            this.comboBoxAlmacenamiento.Name = "comboBoxAlmacenamiento";
            this.comboBoxAlmacenamiento.Size = new System.Drawing.Size(380, 34);
            this.comboBoxAlmacenamiento.TabIndex = 59;
            // 
            // comboBoxEntrega
            // 
            this.comboBoxEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEntrega.FormattingEnabled = true;
            this.comboBoxEntrega.Location = new System.Drawing.Point(327, 95);
            this.comboBoxEntrega.Name = "comboBoxEntrega";
            this.comboBoxEntrega.Size = new System.Drawing.Size(380, 34);
            this.comboBoxEntrega.TabIndex = 58;
            this.comboBoxEntrega.SelectedIndexChanged += new System.EventHandler(this.comboBoxEntrega_SelectedIndexChanged);
            // 
            // TablaDetalleEntrega
            // 
            this.TablaDetalleEntrega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaDetalleEntrega.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.TablaDetalleEntrega.Location = new System.Drawing.Point(42, 303);
            this.TablaDetalleEntrega.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TablaDetalleEntrega.Name = "TablaDetalleEntrega";
            this.TablaDetalleEntrega.RowHeadersWidth = 51;
            this.TablaDetalleEntrega.RowTemplate.Height = 24;
            this.TablaDetalleEntrega.Size = new System.Drawing.Size(787, 316);
            this.TablaDetalleEntrega.TabIndex = 53;
            this.TablaDetalleEntrega.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaDetalleEntrega_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(280, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(307, 29);
            this.label5.TabIndex = 49;
            this.label5.Text = "DETALLE DE ENTREGA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(100, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 29);
            this.label3.TabIndex = 48;
            this.label3.Text = "Almacenamiento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 29);
            this.label1.TabIndex = 47;
            this.label1.Text = "Entrega";
            // 
            // botonClickModificar
            // 
            this.botonClickModificar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickModificar.Location = new System.Drawing.Point(376, 244);
            this.botonClickModificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickModificar.Name = "botonClickModificar";
            this.botonClickModificar.Size = new System.Drawing.Size(130, 39);
            this.botonClickModificar.TabIndex = 62;
            this.botonClickModificar.Text = "Modificar";
            this.botonClickModificar.UseVisualStyleBackColor = true;
            this.botonClickModificar.Click += new System.EventHandler(this.botonClickModificar_Click);
            // 
            // botonClickEliminar
            // 
            this.botonClickEliminar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickEliminar.Location = new System.Drawing.Point(584, 244);
            this.botonClickEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickEliminar.Name = "botonClickEliminar";
            this.botonClickEliminar.Size = new System.Drawing.Size(130, 39);
            this.botonClickEliminar.TabIndex = 61;
            this.botonClickEliminar.Text = "Eliminar";
            this.botonClickEliminar.UseVisualStyleBackColor = true;
            this.botonClickEliminar.Click += new System.EventHandler(this.botonClickEliminar_Click);
            // 
            // botonClickInsertar
            // 
            this.botonClickInsertar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickInsertar.Location = new System.Drawing.Point(162, 244);
            this.botonClickInsertar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonClickInsertar.Name = "botonClickInsertar";
            this.botonClickInsertar.Size = new System.Drawing.Size(130, 39);
            this.botonClickInsertar.TabIndex = 60;
            this.botonClickInsertar.Text = "Insertar";
            this.botonClickInsertar.UseVisualStyleBackColor = true;
            this.botonClickInsertar.Click += new System.EventHandler(this.botonClickInsertar_Click);
            // 
            // DetalleEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 665);
            this.Controls.Add(this.botonClickModificar);
            this.Controls.Add(this.botonClickEliminar);
            this.Controls.Add(this.botonClickInsertar);
            this.Controls.Add(this.comboBoxAlmacenamiento);
            this.Controls.Add(this.comboBoxEntrega);
            this.Controls.Add(this.TablaDetalleEntrega);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "DetalleEntrega";
            this.Text = "Detalle de Entrega";
            this.Load += new System.EventHandler(this.DetalleEntrega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaDetalleEntrega)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAlmacenamiento;
        private System.Windows.Forms.ComboBox comboBoxEntrega;
        private System.Windows.Forms.DataGridView TablaDetalleEntrega;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonClickModificar;
        private System.Windows.Forms.Button botonClickEliminar;
        private System.Windows.Forms.Button botonClickInsertar;
    }
}