namespace ProyectoFinalAgencia
{
    partial class FormClienteDetalle
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
            txtNombreCliente = new TextBox();
            txtApellidoM = new TextBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtDireccion = new TextBox();
            btnGuardarCliente = new Button();
            btnCancelarCliente = new Button();
            txtRFC = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtApellidoP = new TextBox();
            SuspendLayout();
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(99, 52);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(192, 23);
            txtNombreCliente.TabIndex = 0;
            // 
            // txtApellidoM
            // 
            txtApellidoM.Location = new Point(99, 96);
            txtApellidoM.Name = "txtApellidoM";
            txtApellidoM.Size = new Size(82, 23);
            txtApellidoM.TabIndex = 1;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(99, 158);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(192, 23);
            txtTelefono.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(99, 205);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(192, 23);
            txtEmail.TabIndex = 3;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(99, 297);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(192, 23);
            txtDireccion.TabIndex = 4;
            // 
            // btnGuardarCliente
            // 
            btnGuardarCliente.Location = new Point(110, 346);
            btnGuardarCliente.Name = "btnGuardarCliente";
            btnGuardarCliente.Size = new Size(156, 23);
            btnGuardarCliente.TabIndex = 5;
            btnGuardarCliente.Text = "Guardar Cliente";
            btnGuardarCliente.UseVisualStyleBackColor = true;
            btnGuardarCliente.Click += btnGuardarCliente_Click;
            // 
            // btnCancelarCliente
            // 
            btnCancelarCliente.Location = new Point(110, 385);
            btnCancelarCliente.Name = "btnCancelarCliente";
            btnCancelarCliente.Size = new Size(156, 23);
            btnCancelarCliente.TabIndex = 6;
            btnCancelarCliente.Text = "Cancelar";
            btnCancelarCliente.UseVisualStyleBackColor = true;
            // 
            // txtRFC
            // 
            txtRFC.Location = new Point(99, 250);
            txtRFC.Name = "txtRFC";
            txtRFC.Size = new Size(192, 23);
            txtRFC.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 34);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 8;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 78);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 9;
            label2.Text = "Apellido M:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 140);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 10;
            label3.Text = "Telefono:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 187);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 11;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(99, 276);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 12;
            label5.Text = "Direccion:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(101, 232);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 13;
            label6.Text = "RFC:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(200, 78);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 14;
            label7.Text = "Apellido P:";
            // 
            // txtApellidoP
            // 
            txtApellidoP.Location = new Point(200, 96);
            txtApellidoP.Name = "txtApellidoP";
            txtApellidoP.Size = new Size(82, 23);
            txtApellidoP.TabIndex = 15;
            // 
            // FormClienteDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 450);
            Controls.Add(txtApellidoP);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtRFC);
            Controls.Add(btnCancelarCliente);
            Controls.Add(btnGuardarCliente);
            Controls.Add(txtDireccion);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellidoM);
            Controls.Add(txtNombreCliente);
            Name = "FormClienteDetalle";
            Text = "FormClienteDetalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreCliente;
        private TextBox txtApellidoM;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtDireccion;
        private Button btnGuardarCliente;
        private Button btnCancelarCliente;
        private TextBox txtRFC;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtApellidoP;
    }
}