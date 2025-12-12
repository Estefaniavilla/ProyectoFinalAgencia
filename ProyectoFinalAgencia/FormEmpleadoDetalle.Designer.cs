namespace ProyectoFinalAgencia
{
    partial class FormEmpleadoDetalle
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
            txtNombreEmpleado = new TextBox();
            txtApellidoP = new TextBox();
            txtTelefonoEmpleado = new TextBox();
            txtEmailEmpleado = new TextBox();
            cbxRolUsuario = new ComboBox();
            dtpFechaContratacion = new DateTimePicker();
            txtSalario = new TextBox();
            chbActivo = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            txtApellidoM = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnGuardarEmpleado = new Button();
            SuspendLayout();
            // 
            // txtNombreEmpleado
            // 
            txtNombreEmpleado.Location = new Point(32, 42);
            txtNombreEmpleado.Name = "txtNombreEmpleado";
            txtNombreEmpleado.Size = new Size(212, 23);
            txtNombreEmpleado.TabIndex = 0;
            // 
            // txtApellidoP
            // 
            txtApellidoP.Location = new Point(32, 102);
            txtApellidoP.Name = "txtApellidoP";
            txtApellidoP.Size = new Size(97, 23);
            txtApellidoP.TabIndex = 1;
            // 
            // txtTelefonoEmpleado
            // 
            txtTelefonoEmpleado.Location = new Point(32, 167);
            txtTelefonoEmpleado.Name = "txtTelefonoEmpleado";
            txtTelefonoEmpleado.Size = new Size(212, 23);
            txtTelefonoEmpleado.TabIndex = 2;
            // 
            // txtEmailEmpleado
            // 
            txtEmailEmpleado.Location = new Point(32, 235);
            txtEmailEmpleado.Name = "txtEmailEmpleado";
            txtEmailEmpleado.Size = new Size(212, 23);
            txtEmailEmpleado.TabIndex = 3;
            // 
            // cbxRolUsuario
            // 
            cbxRolUsuario.FormattingEnabled = true;
            cbxRolUsuario.Location = new Point(32, 331);
            cbxRolUsuario.Name = "cbxRolUsuario";
            cbxRolUsuario.Size = new Size(212, 23);
            cbxRolUsuario.TabIndex = 4;
            cbxRolUsuario.SelectedIndexChanged += cbxRolPuesto_SelectedIndexChanged;
            // 
            // dtpFechaContratacion
            // 
            dtpFechaContratacion.Location = new Point(353, 42);
            dtpFechaContratacion.Name = "dtpFechaContratacion";
            dtpFechaContratacion.Size = new Size(200, 23);
            dtpFechaContratacion.TabIndex = 5;
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(353, 113);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(200, 23);
            txtSalario.TabIndex = 6;
            // 
            // chbActivo
            // 
            chbActivo.AutoSize = true;
            chbActivo.Location = new Point(353, 203);
            chbActivo.Name = "chbActivo";
            chbActivo.Size = new Size(60, 19);
            chbActivo.TabIndex = 7;
            chbActivo.Text = "Activo";
            chbActivo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 19);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 8;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 79);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 9;
            label2.Text = "Apellido P:";
            label2.Click += label2_Click;
            // 
            // txtApellidoM
            // 
            txtApellidoM.Location = new Point(147, 102);
            txtApellidoM.Name = "txtApellidoM";
            txtApellidoM.Size = new Size(97, 23);
            txtApellidoM.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(147, 79);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 11;
            label3.Text = "Apellido M:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(32, 144);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 12;
            label4.Text = "Telefono:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(32, 212);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 13;
            label5.Text = "Email:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(32, 308);
            label6.Name = "label6";
            label6.Size = new Size(87, 20);
            label6.TabIndex = 14;
            label6.Text = "Rol/Puesto:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(353, 19);
            label7.Name = "label7";
            label7.Size = new Size(145, 20);
            label7.TabIndex = 15;
            label7.Text = "Fecha Contratación:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(353, 90);
            label8.Name = "label8";
            label8.Size = new Size(60, 20);
            label8.TabIndex = 16;
            label8.Text = "Salario:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(353, 170);
            label9.Name = "label9";
            label9.Size = new Size(101, 20);
            label9.TabIndex = 17;
            label9.Text = "Status Activo:";
            // 
            // btnGuardarEmpleado
            // 
            btnGuardarEmpleado.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarEmpleado.Location = new Point(353, 273);
            btnGuardarEmpleado.Name = "btnGuardarEmpleado";
            btnGuardarEmpleado.Size = new Size(200, 30);
            btnGuardarEmpleado.TabIndex = 18;
            btnGuardarEmpleado.Text = "Guardar";
            btnGuardarEmpleado.UseVisualStyleBackColor = true;
            btnGuardarEmpleado.Click += btnGuardarEmpleado_Click;
            // 
            // FormEmpleadoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 450);
            Controls.Add(btnGuardarEmpleado);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtApellidoM);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chbActivo);
            Controls.Add(txtSalario);
            Controls.Add(dtpFechaContratacion);
            Controls.Add(cbxRolUsuario);
            Controls.Add(txtEmailEmpleado);
            Controls.Add(txtTelefonoEmpleado);
            Controls.Add(txtApellidoP);
            Controls.Add(txtNombreEmpleado);
            Name = "FormEmpleadoDetalle";
            Text = "FormEmpleadoDetalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreEmpleado;
        private TextBox txtApellidoP;
        private TextBox txtTelefonoEmpleado;
        private TextBox txtEmailEmpleado;
        private ComboBox cbxRolUsuario;
        private DateTimePicker dtpFechaContratacion;
        private TextBox txtSalario;
        private CheckBox chbActivo;
        private Label label1;
        private Label label2;
        private TextBox txtApellidoM;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button btnGuardarEmpleado;
    }
}