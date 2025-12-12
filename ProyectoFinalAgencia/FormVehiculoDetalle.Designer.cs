namespace ProyectoFinalAgencia
{
    partial class FormVehiculoDetalle
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
            cbxMarca = new ComboBox();
            cbxModelo = new ComboBox();
            cbxVersion = new ComboBox();
            cbxColor = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtAnio = new TextBox();
            label6 = new Label();
            txtPrecio = new TextBox();
            label7 = new Label();
            txtVIN = new TextBox();
            label8 = new Label();
            chbDisponible = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // cbxMarca
            // 
            cbxMarca.FormattingEnabled = true;
            cbxMarca.Items.AddRange(new object[] { "Toyota", "Nissan", "Honda", "Ford", "Chevrolet", "Mazda", "Kia", "Hyundai", "Volkswagen", "BMW" });
            cbxMarca.Location = new Point(34, 39);
            cbxMarca.Name = "cbxMarca";
            cbxMarca.Size = new Size(215, 23);
            cbxMarca.TabIndex = 0;
            // 
            // cbxModelo
            // 
            cbxModelo.FormattingEnabled = true;
            cbxModelo.Items.AddRange(new object[] { "Corolla", "Camry", "Hilux", "Sentra", "Versa", "Altima", "Civic", "CR-V", "Accord", "F-150", "Mustang", "Explorer", "Spark", "Aveo", "Onix", "Mazda", "CX", "Sorento", "Rio", "Elantra", "Tucson", "Jetta", "Golf", "X5", "Serie 3" });
            cbxModelo.Location = new Point(34, 107);
            cbxModelo.Name = "cbxModelo";
            cbxModelo.Size = new Size(215, 23);
            cbxModelo.TabIndex = 1;
            // 
            // cbxVersion
            // 
            cbxVersion.FormattingEnabled = true;
            cbxVersion.Items.AddRange(new object[] { "Base", "Sport", "Premium", "Limited", "XL", "XLE", "Platinum" });
            cbxVersion.Location = new Point(34, 181);
            cbxVersion.Name = "cbxVersion";
            cbxVersion.Size = new Size(215, 23);
            cbxVersion.TabIndex = 2;
            // 
            // cbxColor
            // 
            cbxColor.FormattingEnabled = true;
            cbxColor.Items.AddRange(new object[] { "Rojo", "Azul", "Negro", "Blanco", "Gris", "Plata", "Verde", "Amarillo", "Naranja", "Beige" });
            cbxColor.Location = new Point(34, 248);
            cbxColor.Name = "cbxColor";
            cbxColor.Size = new Size(215, 23);
            cbxColor.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientActiveCaption;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 15);
            label1.Name = "label1";
            label1.Size = new Size(59, 21);
            label1.TabIndex = 4;
            label1.Text = "Marca:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 83);
            label2.Name = "label2";
            label2.Size = new Size(72, 21);
            label2.TabIndex = 5;
            label2.Text = "Modelo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(34, 158);
            label3.Name = "label3";
            label3.Size = new Size(68, 21);
            label3.TabIndex = 6;
            label3.Text = "Version:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(34, 224);
            label4.Name = "label4";
            label4.Size = new Size(55, 21);
            label4.TabIndex = 7;
            label4.Text = "Color:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(34, 291);
            label5.Name = "label5";
            label5.Size = new Size(44, 21);
            label5.TabIndex = 8;
            label5.Text = "Año:";
            // 
            // txtAnio
            // 
            txtAnio.Location = new Point(34, 315);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(100, 23);
            txtAnio.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(297, 15);
            label6.Name = "label6";
            label6.Size = new Size(60, 21);
            label6.TabIndex = 10;
            label6.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(297, 39);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(297, 83);
            label7.Name = "label7";
            label7.Size = new Size(41, 21);
            label7.TabIndex = 12;
            label7.Text = "VIN:";
            // 
            // txtVIN
            // 
            txtVIN.Location = new Point(297, 107);
            txtVIN.Name = "txtVIN";
            txtVIN.Size = new Size(100, 23);
            txtVIN.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(297, 158);
            label8.Name = "label8";
            label8.Size = new Size(173, 21);
            label8.TabIndex = 14;
            label8.Text = "Disponible para Venta:";
            // 
            // chbDisponible
            // 
            chbDisponible.AutoSize = true;
            chbDisponible.Location = new Point(297, 194);
            chbDisponible.Name = "chbDisponible";
            chbDisponible.Size = new Size(82, 19);
            chbDisponible.TabIndex = 15;
            chbDisponible.Text = "Disponible";
            chbDisponible.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(297, 247);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(124, 36);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(297, 289);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(124, 33);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormVehiculoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(486, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chbDisponible);
            Controls.Add(label8);
            Controls.Add(txtVIN);
            Controls.Add(label7);
            Controls.Add(txtPrecio);
            Controls.Add(label6);
            Controls.Add(txtAnio);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbxColor);
            Controls.Add(cbxVersion);
            Controls.Add(cbxModelo);
            Controls.Add(cbxMarca);
            Name = "FormVehiculoDetalle";
            Text = "FormVehiculoDetalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxMarca;
        private ComboBox cbxModelo;
        private ComboBox cbxVersion;
        private ComboBox cbxColor;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtAnio;
        private Label label6;
        private TextBox txtPrecio;
        private Label label7;
        private TextBox txtVIN;
        private Label label8;
        private CheckBox chbDisponible;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}