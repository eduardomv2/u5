namespace u5
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.txtRutaCarpeta = new System.Windows.Forms.TextBox();
            this.lblTamanoTotal = new System.Windows.Forms.Label();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(704, 329);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(413, 13);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(298, 28);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "Analizar tamaños de los archivos en la Ruta Seleccionada";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // txtRutaCarpeta
            // 
            this.txtRutaCarpeta.Location = new System.Drawing.Point(92, 17);
            this.txtRutaCarpeta.Name = "txtRutaCarpeta";
            this.txtRutaCarpeta.Size = new System.Drawing.Size(315, 20);
            this.txtRutaCarpeta.TabIndex = 2;
            // 
            // lblTamanoTotal
            // 
            this.lblTamanoTotal.AutoSize = true;
            this.lblTamanoTotal.Location = new System.Drawing.Point(30, 21);
            this.lblTamanoTotal.Name = "lblTamanoTotal";
            this.lblTamanoTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTamanoTotal.TabIndex = 3;
            this.lblTamanoTotal.Text = "label1";
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Location = new System.Drawing.Point(92, 54);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(315, 20);
            this.txtRutaArchivo.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(413, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Leer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(472, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 28);
            this.button2.TabIndex = 9;
            this.button2.Text = "Poner Indices";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(563, 51);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 28);
            this.button3.TabIndex = 10;
            this.button3.Text = "Leer el Indice Seleccionado";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRutaArchivo);
            this.Controls.Add(this.lblTamanoTotal);
            this.Controls.Add(this.txtRutaCarpeta);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.TextBox txtRutaCarpeta;
        private System.Windows.Forms.Label lblTamanoTotal;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

