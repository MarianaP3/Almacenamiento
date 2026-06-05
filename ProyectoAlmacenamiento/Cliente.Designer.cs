namespace ProyectoAlmacenamiento
{
    partial class Cliente
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
            this.TablaCliente = new System.Windows.Forms.DataGridView();
            this.botonClickModificar = new System.Windows.Forms.Button();
            this.botonClickEliminar = new System.Windows.Forms.Button();
            this.botonClickInsertar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textTelefono_Cliente = new System.Windows.Forms.TextBox();
            this.textCorreo_Cliente = new System.Windows.Forms.TextBox();
            this.textNombre_Cliente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaCliente
            // 
            this.TablaCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaCliente.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.TablaCliente.Location = new System.Drawing.Point(58, 393);
            this.TablaCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TablaCliente.Name = "TablaCliente";
            this.TablaCliente.RowHeadersWidth = 51;
            this.TablaCliente.RowTemplate.Height = 24;
            this.TablaCliente.Size = new System.Drawing.Size(694, 227);
            this.TablaCliente.TabIndex = 25;
            this.TablaCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaCliente_CellContentClick_1);
            // 
            // botonClickModificar
            // 
            this.botonClickModificar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClickModificar.Location = new System.Drawing.Point(335, 308);
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
            this.botonClickEliminar.Location = new System.Drawing.Point(543, 308);
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
            this.botonClickInsertar.Location = new System.Drawing.Point(121, 308);
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
            this.label5.Location = new System.Drawing.Point(299, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 29);
            this.label5.TabIndex = 21;
            this.label5.Text = "CLIENTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 29);
            this.label3.TabIndex = 18;
            this.label3.Text = "Correo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "Teléfono";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre";
            // 
            // textTelefono_Cliente
            // 
            this.textTelefono_Cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTelefono_Cliente.Location = new System.Drawing.Point(304, 226);
            this.textTelefono_Cliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textTelefono_Cliente.Name = "textTelefono_Cliente";
            this.textTelefono_Cliente.Size = new System.Drawing.Size(380, 35);
            this.textTelefono_Cliente.TabIndex = 15;
            // 
            // textCorreo_Cliente
            // 
            this.textCorreo_Cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCorreo_Cliente.Location = new System.Drawing.Point(304, 160);
            this.textCorreo_Cliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textCorreo_Cliente.Name = "textCorreo_Cliente";
            this.textCorreo_Cliente.Size = new System.Drawing.Size(380, 35);
            this.textCorreo_Cliente.TabIndex = 14;
            // 
            // textNombre_Cliente
            // 
            this.textNombre_Cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombre_Cliente.Location = new System.Drawing.Point(304, 97);
            this.textNombre_Cliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textNombre_Cliente.Name = "textNombre_Cliente";
            this.textNombre_Cliente.Size = new System.Drawing.Size(380, 35);
            this.textNombre_Cliente.TabIndex = 13;
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 655);
            this.Controls.Add(this.TablaCliente);
            this.Controls.Add(this.botonClickModificar);
            this.Controls.Add(this.botonClickEliminar);
            this.Controls.Add(this.botonClickInsertar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textTelefono_Cliente);
            this.Controls.Add(this.textCorreo_Cliente);
            this.Controls.Add(this.textNombre_Cliente);
            this.Name = "Cliente";
            this.Text = "Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.TablaCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaCliente;
        private System.Windows.Forms.Button botonClickModificar;
        private System.Windows.Forms.Button botonClickEliminar;
        private System.Windows.Forms.Button botonClickInsertar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTelefono_Cliente;
        private System.Windows.Forms.TextBox textCorreo_Cliente;
        private System.Windows.Forms.TextBox textNombre_Cliente;
    }
}