namespace ProyectoFinalAgencia
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnIniciarSesion = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Captura_de_pantalla_2025_12_05_180436;
            pictureBox1.Location = new Point(-29, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(385, 289);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(204, 169);
            label1.Name = "label1";
            label1.Size = new Size(66, 30);
            label1.TabIndex = 1;
            label1.Text = "USER";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(204, 217);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(199, 23);
            txtUsuario.TabIndex = 3;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(204, 307);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(199, 23);
            txtContrasena.TabIndex = 4;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.Gainsboro;
            btnIniciarSesion.Font = new Font("Franklin Gothic Medium", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarSesion.ForeColor = SystemColors.AppWorkspace;
            btnIniciarSesion.Location = new Point(204, 378);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(199, 42);
            btnIniciarSesion.TabIndex = 5;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonFace;
            label2.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(204, 259);
            label2.Name = "label2";
            label2.Size = new Size(134, 30);
            label2.TabIndex = 6;
            label2.Text = "PASSWORD";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(598, 457);
            Controls.Add(label2);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnIniciarSesion;
        private Label label2;
    }
}
