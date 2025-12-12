namespace ProyectoFinalAgencia
{
    partial class FormMenuPrincipal
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
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            btnExportar = new Button();
            btnEliminarVehiculo = new Button();
            btnModificarVehiculo = new Button();
            btnAgregarVehiculo = new Button();
            dgvInventario = new DataGridView();
            tabPage3 = new TabPage();
            btnExportarTXT = new Button();
            btnModificarCliente = new Button();
            btnEliminarCliente = new Button();
            btnAgregarCliente = new Button();
            dgvClientes = new DataGridView();
            tabPage4 = new TabPage();
            btnExportarJSON = new Button();
            dgvEmpleados = new DataGridView();
            btnEliminarEmpleado = new Button();
            btnModificarEmpleado = new Button();
            btnAgregarEmpleado = new Button();
            dataGridView1 = new DataGridView();
            tabPage1 = new TabPage();
            btnEliminarVenta = new Button();
            label11 = new Label();
            label9 = new Label();
            label10 = new Label();
            cbxCredito = new ComboBox();
            label8 = new Label();
            cbxVehiculo = new ComboBox();
            label7 = new Label();
            btnRegistrarVenta = new Button();
            dgvVentas = new DataGridView();
            cbxPromocion = new ComboBox();
            cbxMetodoPago = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            cbxEmpleado = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            cbxCliente = new ComboBox();
            label2 = new Label();
            dtpFechaVenta = new DateTimePicker();
            label1 = new Label();
            cbxInventario = new ComboBox();
            lblTotal = new Label();
            btnImportarTicket = new Button();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(958, 490);
            tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Gainsboro;
            tabPage2.Controls.Add(btnExportar);
            tabPage2.Controls.Add(btnEliminarVehiculo);
            tabPage2.Controls.Add(btnModificarVehiculo);
            tabPage2.Controls.Add(btnAgregarVehiculo);
            tabPage2.Controls.Add(dgvInventario);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(950, 462);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "🚗 Inventario de Vehículos";
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.Thistle;
            btnExportar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportar.Location = new Point(771, 16);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(156, 33);
            btnExportar.TabIndex = 6;
            btnExportar.Text = "Exportar CSV";
            btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnEliminarVehiculo
            // 
            btnEliminarVehiculo.BackColor = Color.PapayaWhip;
            btnEliminarVehiculo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnEliminarVehiculo.Location = new Point(575, 278);
            btnEliminarVehiculo.Name = "btnEliminarVehiculo";
            btnEliminarVehiculo.Size = new Size(156, 35);
            btnEliminarVehiculo.TabIndex = 4;
            btnEliminarVehiculo.Text = "Eliminar";
            btnEliminarVehiculo.UseVisualStyleBackColor = false;
            btnEliminarVehiculo.Click += btnEliminarVehiculo_Click;
            // 
            // btnModificarVehiculo
            // 
            btnModificarVehiculo.BackColor = Color.PapayaWhip;
            btnModificarVehiculo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnModificarVehiculo.Location = new Point(574, 238);
            btnModificarVehiculo.Name = "btnModificarVehiculo";
            btnModificarVehiculo.Size = new Size(157, 34);
            btnModificarVehiculo.TabIndex = 3;
            btnModificarVehiculo.Text = "Modificar";
            btnModificarVehiculo.UseVisualStyleBackColor = false;
            btnModificarVehiculo.Click += btnModificarVehiculo_Click;
            // 
            // btnAgregarVehiculo
            // 
            btnAgregarVehiculo.BackColor = Color.PapayaWhip;
            btnAgregarVehiculo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAgregarVehiculo.Location = new Point(574, 198);
            btnAgregarVehiculo.Name = "btnAgregarVehiculo";
            btnAgregarVehiculo.Size = new Size(157, 34);
            btnAgregarVehiculo.TabIndex = 2;
            btnAgregarVehiculo.Text = "Agregar";
            btnAgregarVehiculo.UseVisualStyleBackColor = false;
            btnAgregarVehiculo.Click += btnAgregarVehiculo_Click;
            // 
            // dgvInventario
            // 
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(19, 16);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.Size = new Size(517, 430);
            dgvInventario.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.Gainsboro;
            tabPage3.Controls.Add(btnExportarTXT);
            tabPage3.Controls.Add(btnModificarCliente);
            tabPage3.Controls.Add(btnEliminarCliente);
            tabPage3.Controls.Add(btnAgregarCliente);
            tabPage3.Controls.Add(dgvClientes);
            tabPage3.ForeColor = SystemColors.ControlText;
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(950, 462);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "\U0001f9d1‍\U0001f91d‍\U0001f9d1 Clientes";
            // 
            // btnExportarTXT
            // 
            btnExportarTXT.BackColor = Color.MistyRose;
            btnExportarTXT.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportarTXT.Location = new Point(777, 18);
            btnExportarTXT.Name = "btnExportarTXT";
            btnExportarTXT.Size = new Size(151, 34);
            btnExportarTXT.TabIndex = 4;
            btnExportarTXT.Text = "Exportar TXT";
            btnExportarTXT.UseVisualStyleBackColor = false;
            btnExportarTXT.Click += btnExportarTXT_Click;
            // 
            // btnModificarCliente
            // 
            btnModificarCliente.BackColor = Color.Lavender;
            btnModificarCliente.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificarCliente.Location = new Point(552, 212);
            btnModificarCliente.Name = "btnModificarCliente";
            btnModificarCliente.Size = new Size(166, 31);
            btnModificarCliente.TabIndex = 3;
            btnModificarCliente.Text = "Modificar";
            btnModificarCliente.UseVisualStyleBackColor = false;
            btnModificarCliente.Click += btnModificarCliente_Click;
            // 
            // btnEliminarCliente
            // 
            btnEliminarCliente.BackColor = Color.Lavender;
            btnEliminarCliente.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarCliente.Location = new Point(552, 258);
            btnEliminarCliente.Name = "btnEliminarCliente";
            btnEliminarCliente.Size = new Size(166, 32);
            btnEliminarCliente.TabIndex = 2;
            btnEliminarCliente.Text = "Eliminar";
            btnEliminarCliente.UseVisualStyleBackColor = false;
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.BackColor = Color.Lavender;
            btnAgregarCliente.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarCliente.Location = new Point(552, 167);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(166, 29);
            btnAgregarCliente.TabIndex = 1;
            btnAgregarCliente.Text = "Agregar";
            btnAgregarCliente.UseVisualStyleBackColor = false;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(15, 18);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(514, 384);
            dgvClientes.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btnExportarJSON);
            tabPage4.Controls.Add(dgvEmpleados);
            tabPage4.Controls.Add(btnEliminarEmpleado);
            tabPage4.Controls.Add(btnModificarEmpleado);
            tabPage4.Controls.Add(btnAgregarEmpleado);
            tabPage4.Controls.Add(dataGridView1);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(950, 462);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "👨‍💼 Empleados";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnExportarJSON
            // 
            btnExportarJSON.BackColor = Color.PowderBlue;
            btnExportarJSON.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportarJSON.Location = new Point(785, 18);
            btnExportarJSON.Name = "btnExportarJSON";
            btnExportarJSON.Size = new Size(140, 30);
            btnExportarJSON.TabIndex = 4;
            btnExportarJSON.Text = "ExportarJSON";
            btnExportarJSON.UseVisualStyleBackColor = false;
            btnExportarJSON.Click += btnExportarJSON_Click;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Location = new Point(15, 18);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.Size = new Size(514, 384);
            dgvEmpleados.TabIndex = 0;
            // 
            // btnEliminarEmpleado
            // 
            btnEliminarEmpleado.BackColor = Color.Honeydew;
            btnEliminarEmpleado.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarEmpleado.Location = new Point(551, 241);
            btnEliminarEmpleado.Name = "btnEliminarEmpleado";
            btnEliminarEmpleado.Size = new Size(163, 36);
            btnEliminarEmpleado.TabIndex = 3;
            btnEliminarEmpleado.Text = "Eliminar";
            btnEliminarEmpleado.UseVisualStyleBackColor = false;
            // 
            // btnModificarEmpleado
            // 
            btnModificarEmpleado.BackColor = Color.Honeydew;
            btnModificarEmpleado.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificarEmpleado.Location = new Point(551, 193);
            btnModificarEmpleado.Name = "btnModificarEmpleado";
            btnModificarEmpleado.Size = new Size(163, 33);
            btnModificarEmpleado.TabIndex = 2;
            btnModificarEmpleado.Text = "Modificar";
            btnModificarEmpleado.UseVisualStyleBackColor = false;
            // 
            // btnAgregarEmpleado
            // 
            btnAgregarEmpleado.BackColor = Color.Honeydew;
            btnAgregarEmpleado.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarEmpleado.Location = new Point(551, 149);
            btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            btnAgregarEmpleado.Size = new Size(163, 29);
            btnAgregarEmpleado.TabIndex = 1;
            btnAgregarEmpleado.Text = "Agregar";
            btnAgregarEmpleado.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(502, 382);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Gainsboro;
            tabPage1.Controls.Add(btnImportarTicket);
            tabPage1.Controls.Add(btnEliminarVenta);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(cbxCredito);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(cbxVehiculo);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(btnRegistrarVenta);
            tabPage1.Controls.Add(dgvVentas);
            tabPage1.Controls.Add(cbxPromocion);
            tabPage1.Controls.Add(cbxMetodoPago);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(cbxEmpleado);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(cbxCliente);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(dtpFechaVenta);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(cbxInventario);
            tabPage1.Controls.Add(lblTotal);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(950, 462);
            tabPage1.TabIndex = 4;
            tabPage1.Text = "💰 Ventas y Reportes";
            // 
            // btnEliminarVenta
            // 
            btnEliminarVenta.BackColor = Color.PowderBlue;
            btnEliminarVenta.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarVenta.Location = new Point(289, 354);
            btnEliminarVenta.Name = "btnEliminarVenta";
            btnEliminarVenta.Size = new Size(121, 35);
            btnEliminarVenta.TabIndex = 18;
            btnEliminarVenta.Text = "Eliminar Venta";
            btnEliminarVenta.UseVisualStyleBackColor = false;
            btnEliminarVenta.Click += btnEliminarVenta_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.Location = new Point(289, 215);
            label11.Name = "label11";
            label11.Size = new Size(76, 20);
            label11.TabIndex = 17;
            label11.Text = "Inventario:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.Location = new Point(289, 153);
            label9.Name = "label9";
            label9.Size = new Size(59, 20);
            label9.TabIndex = 16;
            label9.Text = "Credito:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label10.Location = new Point(289, 82);
            label10.Name = "label10";
            label10.Size = new Size(67, 20);
            label10.TabIndex = 15;
            label10.Text = "Vehiculo:";
            // 
            // cbxCredito
            // 
            cbxCredito.Location = new Point(290, 178);
            cbxCredito.Name = "cbxCredito";
            cbxCredito.Size = new Size(200, 23);
            cbxCredito.TabIndex = 2;
            // 
            // label8
            // 
            label8.Location = new Point(310, 61);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 3;
            // 
            // cbxVehiculo
            // 
            cbxVehiculo.Location = new Point(289, 115);
            cbxVehiculo.Name = "cbxVehiculo";
            cbxVehiculo.Size = new Size(201, 23);
            cbxVehiculo.TabIndex = 4;
            // 
            // label7
            // 
            label7.Location = new Point(310, 61);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 5;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.BackColor = Color.PowderBlue;
            btnRegistrarVenta.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrarVenta.Location = new Point(289, 313);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(121, 35);
            btnRegistrarVenta.TabIndex = 13;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.UseVisualStyleBackColor = false;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click_1;
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(509, 18);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(435, 424);
            dgvVentas.TabIndex = 11;
            // 
            // cbxPromocion
            // 
            cbxPromocion.FormattingEnabled = true;
            cbxPromocion.Location = new Point(33, 379);
            cbxPromocion.Name = "cbxPromocion";
            cbxPromocion.Size = new Size(200, 23);
            cbxPromocion.TabIndex = 10;
            // 
            // cbxMetodoPago
            // 
            cbxMetodoPago.FormattingEnabled = true;
            cbxMetodoPago.Location = new Point(33, 313);
            cbxMetodoPago.Name = "cbxMetodoPago";
            cbxMetodoPago.Size = new Size(200, 23);
            cbxMetodoPago.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(33, 351);
            label6.Name = "label6";
            label6.Size = new Size(82, 20);
            label6.TabIndex = 8;
            label6.Text = "Promoción:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(33, 281);
            label5.Name = "label5";
            label5.Size = new Size(116, 20);
            label5.TabIndex = 7;
            label5.Text = "Metodo de Pago:";
            // 
            // cbxEmpleado
            // 
            cbxEmpleado.FormattingEnabled = true;
            cbxEmpleado.Location = new Point(33, 238);
            cbxEmpleado.Name = "cbxEmpleado";
            cbxEmpleado.Size = new Size(200, 23);
            cbxEmpleado.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(33, 215);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 5;
            label4.Text = "Empleado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(33, 153);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 4;
            label3.Text = "Cliente:";
            // 
            // cbxCliente
            // 
            cbxCliente.FormattingEnabled = true;
            cbxCliente.Location = new Point(33, 178);
            cbxCliente.Name = "cbxCliente";
            cbxCliente.Size = new Size(200, 23);
            cbxCliente.TabIndex = 3;
            cbxCliente.SelectedIndexChanged += cbxCliente_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(33, 82);
            label2.Name = "label2";
            label2.Size = new Size(122, 20);
            label2.TabIndex = 2;
            label2.Text = "Fecha de la Venta";
            // 
            // dtpFechaVenta
            // 
            dtpFechaVenta.Location = new Point(33, 115);
            dtpFechaVenta.Name = "dtpFechaVenta";
            dtpFechaVenta.Size = new Size(200, 23);
            dtpFechaVenta.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 34);
            label1.Name = "label1";
            label1.Size = new Size(173, 25);
            label1.TabIndex = 0;
            label1.Text = "Registro de Ventas";
            // 
            // cbxInventario
            // 
            cbxInventario.FormattingEnabled = true;
            cbxInventario.Location = new Point(290, 238);
            cbxInventario.Name = "cbxInventario";
            cbxInventario.Size = new Size(200, 23);
            cbxInventario.TabIndex = 10;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(289, 286);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(66, 15);
            lblTotal.TabIndex = 14;
            lblTotal.Text = "Total: $0.00";
            // 
            // btnImportarTicket
            // 
            btnImportarTicket.BackColor = Color.PaleTurquoise;
            btnImportarTicket.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImportarTicket.Location = new Point(289, 395);
            btnImportarTicket.Name = "btnImportarTicket";
            btnImportarTicket.Size = new Size(154, 31);
            btnImportarTicket.TabIndex = 19;
            btnImportarTicket.Text = "Importar Ticket";
            btnImportarTicket.UseVisualStyleBackColor = false;
            btnImportarTicket.Click += btnImportarTicket_Click;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 514);
            Controls.Add(tabControl1);
            Name = "FormMenuPrincipal";
            Text = "FormMenuPrincipal";
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dgvEmpleados;
        private DataGridView dgvInventario;
        private TabPage tabPage1;
        private Button btnAgregarVehiculo;
        private Button btnEliminarVehiculo;
        private Button btnModificarVehiculo;
        private DataGridView dgvClientes;
        private Button btnModificarCliente;
        private Button btnEliminarCliente;
        private Button btnAgregarCliente;
        private Button btnEliminarEmpleado;
        private Button btnModificarEmpleado;
        private Button btnAgregarEmpleado;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpFechaVenta;
        private ComboBox cbxCliente;
        private ComboBox cbxEmpleado;
        private Label label4;
        private Label label3;
        private Label label5;
        private ComboBox cbxMetodoPago;
        private Label label6;
        private ComboBox cbxPromocion;
        private DataGridView dgvVentas;
        private Button btnRegistrarVenta;
        private Label label9;
        private ComboBox cbxCredito;
        private Label label8;
        private ComboBox cbxVehiculo;
        private Label label7;
        private ComboBox cbxInventario;
        private Label lblTotal;
        private Label label10;
        private Label label11;
        private Button btnExportar;
        private Button btnEliminarVenta;
        private Button btnExportarTXT;
        private Button btnExportarJSON;
        private Button btnImportarTicket;
    }
}