namespace ProyectoAlmacenamiento
{
    partial class Anaquel
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
            this.TablaAnaquel = new System.Windows.Forms.DataGridView();
            this.botonClickModificar = new System.Windows.Forms.Button();
            this.botonClickEliminar = new System.Windows.Forms.Button();
            this.botonClickInsertar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textNivel = new System.Windows.Forms.TextBox();
            this.textFila = new System.Windows.Forms.TextBox();
            this.textColumna = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textCapacidad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaAnaquel)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaAnaquel
            // 
            this.TablaAnaquel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaAnaquel.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.TablaAnaquel.Location = new System.Drawing.Point(65, 384);
            this.TablaAnaquel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TablaAnaquel.Name = "TablaAnaquel";
            this.TablaAnaquel.RowHeadersWidth = 51;
            this.TablaAnaquel.RowTemplate.Height = 24;
            this.TablaAnaquel.Size = new System.Drawing.Size(694, 227);
            this.TablaAnaquel.TabIndex = 36;
            this.TablaAnaquel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaAnaquel_CellContentClick);
            // 
            // botonClickModificar
            // 
            this.botonClickModificar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickModificar.Location = new System.Drawing.Point(339, 322);
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
            this.botonClickEliminar.Location = new System.Drawing.Point(547, 322);
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
            this.botonClickInsertar.Location = new System.Drawing.Point(125, 322);
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
            this.label5.Location = new System.Drawing.Point(306, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 29);
            this.label5.TabIndex = 32;
            this.label5.Text = "ANAQUEL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(120, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 29);
            this.label3.TabIndex = 31;
            this.label3.Text = "Nivel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(123, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 29);
            this.label2.TabIndex = 30;
            this.label2.Text = "Fila";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 29);
            this.label1.TabIndex = 29;
            this.label1.Text = "Columna";
            // 
            // textNivel
            // 
            this.textNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNivel.Location = new System.Drawing.Point(311, 90);
            this.textNivel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textNivel.Name = "textNivel";
            this.textNivel.Size = new System.Drawing.Size(380, 35);
            this.textNivel.TabIndex = 28;
            // 
            // textFila
            // 
            this.textFila.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFila.Location = new System.Drawing.Point(311, 144);
            this.textFila.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textFila.Name = "textFila";
            this.textFila.Size = new System.Drawing.Size(380, 35);
            this.textFila.TabIndex = 27;
            // 
            // textColumna
            // 
            this.textColumna.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textColumna.Location = new System.Drawing.Point(311, 201);
            this.textColumna.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textColumna.Name = "textColumna";
            this.textColumna.Size = new System.Drawing.Size(380, 35);
            this.textColumna.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(123, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 29);
            this.label4.TabIndex = 38;
            this.label4.Text = "Capacidad";
            // 
            // textCapacidad
            // 
            this.textCapacidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCapacidad.Location = new System.Drawing.Point(311, 266);
            this.textCapacidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textCapacidad.Name = "textCapacidad";
            this.textCapacidad.Size = new System.Drawing.Size(380, 35);
            this.textCapacidad.TabIndex = 37;
            // 
            // Anaquel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 665);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textCapacidad);
            this.Controls.Add(this.TablaAnaquel);
            this.Controls.Add(this.botonClickModificar);
            this.Controls.Add(this.botonClickEliminar);
            this.Controls.Add(this.botonClickInsertar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textNivel);
            this.Controls.Add(this.textFila);
            this.Controls.Add(this.textColumna);
            this.Name = "Anaquel";
            this.Text = "Anaquel";
            ((System.ComponentModel.ISupportInitialize)(this.TablaAnaquel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaAnaquel;
        private System.Windows.Forms.Button botonClickModificar;
        private System.Windows.Forms.Button botonClickEliminar;
        private System.Windows.Forms.Button botonClickInsertar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNivel;
        private System.Windows.Forms.TextBox textFila;
        private System.Windows.Forms.TextBox textColumna;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCapacidad;
    }
}