using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace ProyectoFinalAgencia
{

    public partial class FormMenuPrincipal : Form
    {
        private const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=AGENCIA;Integrated Security=True;TrustServerCertificate=True;";

        private decimal precioVehiculoBase = 0.00m;
        private int idVehiculoSeleccionado = 0;
        private DataTable dtPromociones;
        private DataTable dtCreditos;

        private int idClienteSeleccionado = 0;
        private int idEmpleadoSeleccionado = 0;
        private int idInventarioSeleccionado = 0;
        private int idMetodoPagoSeleccionado = 0;
        private int idPromocionSeleccionada = 0;
        private int idCreditoSeleccionado = 0;
        private decimal totalVenta = 0.00m;


        public FormMenuPrincipal()
        {
            InitializeComponent();
            CargarInventario();
            CargarListasAuxiliares();

            // Inicializa el Label Total
            lblTotal.Text = "Total: $0.00";
            // Suscribir al evento para detectar cambio de pestañas
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // Suscribir al evento del botón Modificar Cliente
            btnModificarCliente.Click += btnModificarCliente_Click;
            // Suscribir al evento del botón Eliminar Cliente
            btnEliminarCliente.Click += btnEliminarCliente_Click;
            // Suscribir al evento del botón Agregar Empleado
            btnAgregarEmpleado.Click += btnAgregarEmpleado_Click;
            // Suscribir al evento del botón Modificar Empleado
            btnModificarEmpleado.Click += btnModificarEmpleado_Click;
            // Suscribir al evento del botón Eliminar Empleado
            btnEliminarEmpleado.Click += btnEliminarEmpleado_Click;
            if (btnRegistrarVenta != null)
                if (btnExportar != null)
                    btnExportar.Click += btnExportar_Click;
            cbxVehiculo.SelectedIndexChanged += cbxVehiculo_SelectedIndexChanged;

        }

        private void cbxVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            // 1. Conversión Segura del ID
            if (cbxVehiculo.SelectedValue != null && int.TryParse(cbxVehiculo.SelectedValue.ToString(), out id))
            {
                idVehiculoSeleccionado = id;
            }
            else
            {
                idVehiculoSeleccionado = 0;
            }

            // 2. Llamada a ObtenerPrecioVehiculo
            if (idVehiculoSeleccionado > 0)
            {
                ObtenerPrecioVehiculo(idVehiculoSeleccionado);
            }
            else
            {
                precioVehiculoBase = 0.00m; // Reiniciar si no hay selección
            }

            // 3. Actualizar el Total
            CalcularTotal();
        }


        private void cbxPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }
        private void cbxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Verificar si hay un valor seleccionado
            if (cbxCliente.SelectedValue != null && cbxCliente.SelectedValue != DBNull.Value)
            {
                int idCliente = 0;

                // 2. CONVERSIÓN SEGURA: Intentamos convertir el SelectedValue a entero.
                try
                {
                    idCliente = Convert.ToInt32(cbxCliente.SelectedValue);
                }
                catch (Exception)
                {
                    // Si falla la conversión (ej. DataRowView -> int), idCliente será 0.
                    idCliente = 0;
                }

                // 3. Si el ID es válido (> 0), cargamos sus créditos.
                if (idCliente > 0)
                {
                    CargarCreditosDisponibles(idCliente);
                }
                else
                {
                    // 4. Si el ID es 0 (el "-- Seleccione --" inicial)
                    CargarCreditosDisponibles(0);
                }
            }
            else
            {
                // 5. TU BLOQUE EXTRA: Si SelectedValue es nulo.
                CargarCreditosDisponibles(0);
            }
        }


        private void ObtenerPrecioVehiculo(int idVehiculo)
        {
            // Si el ID es 0 o menor, establece el precio en 0 y termina.
            if (idVehiculo <= 0)
            {
                precioVehiculoBase = 0.00m;
                return;
            }

            // Consulta el precio de la tabla VEHICULO
            // La columna Precio es DECIMAL(15, 2)
            string query = "SELECT Precio FROM Vehiculo WHERE IDVehiculo = @IDVehiculo;";

            // Por defecto, asumimos que falló o el precio es 0
            precioVehiculoBase = 0.00m;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDVehiculo", idVehiculo);
                    connection.Open();

                    // ExecuteScalar devuelve el primer valor de la primera fila
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        // Convierte el resultado a decimal y asigna a la variable de CLASE
                        precioVehiculoBase = Convert.ToDecimal(result);
                    }
                    // Si result es NULL, ya asignamos 0.00m al inicio.
                }
            }
            catch (Exception ex)
            {
                // Si hay error (ej. conexión o SQL), se mantendrá en 0.00m y se notificará.
                MessageBox.Show($"Error al obtener el precio: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // NOTA: EL MÉTODO cbxVehiculo_SelectedIndexChanged DEBE LLAMAR A CalcularTotal()
            // JUSTO DESPUÉS DE ESTE MÉTODO.
        }


        private void CalcularTotal()
        {
            decimal total = precioVehiculoBase;
            decimal descuento = 0.00m;


            lblTotal.Text = $"Total: {total:C}";

            // Opcional: Actualizar etiquetas de subtotal/descuento si existen.
            // lblSubtotal.Text = $"{precioVehiculoBase:C}";
            // lblDescuento.Text = $"{descuento:C}";
        }


        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            // 1. Validaciones
            if (cbxCliente.SelectedValue == null || (cbxCliente.SelectedValue is int && (int)cbxCliente.SelectedValue == 0) ||
                cbxEmpleado.SelectedValue == null || (cbxEmpleado.SelectedValue is int && (int)cbxEmpleado.SelectedValue == 0) ||
                cbxMetodoPago.SelectedValue == null || (cbxMetodoPago.SelectedValue is int && (int)cbxMetodoPago.SelectedValue == 0) ||
                idVehiculoSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar Cliente, Empleado, Método de Pago y Vehículo.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (precioVehiculoBase == 0)
            {
                MessageBox.Show("El vehículo seleccionado no tiene precio de venta.", "Error de Precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Obtener IDs y valores finales
            int idCliente = (int)cbxCliente.SelectedValue;
            int idEmpleado = (int)cbxEmpleado.SelectedValue;
            int idMetodoPago = (int)cbxMetodoPago.SelectedValue;

            // Promoción (Puede ser DBNull.Value)
            object idPromocion = (cbxPromocion.SelectedValue != null && cbxPromocion.SelectedValue != DBNull.Value && (int)cbxPromocion.SelectedValue != 0) ? cbxPromocion.SelectedValue : (object)DBNull.Value;

            // Crédito (Puede ser DBNull.Value)
            object idCredito = (cbxCredito.SelectedValue != null && cbxCredito.SelectedValue != DBNull.Value && !(cbxCredito.SelectedValue is int && (int)cbxCredito.SelectedValue == 0)) ? cbxCredito.SelectedValue : (object)DBNull.Value;

            DateTime fechaVenta = dtpFechaVenta.Value.Date;

            // Parsear el total del Label (eliminando formato de moneda y coma decimal si aplica)
            decimal montoTotal = 0;
            if (!decimal.TryParse(lblTotal.Text.Replace("Total:", "").Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out montoTotal))
            {
                MessageBox.Show("Error al obtener el monto total del cálculo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // 3. Query de Transacción (Asegura la venta y la actualización del stock)
            string queryInsertVenta = @"
                INSERT INTO Venta (id_cliente, id_empleado, id_vehiculo, id_metodo_pago, id_promocion, id_credito, fecha_venta, total)
                VALUES (@ClienteID, @EmpleadoID, @VehiculoID, @MetodoPagoID, @PromocionID, @CreditoID, @FechaVenta, @MontoTotal);
                SELECT SCOPE_IDENTITY();";

            string queryUpdateStock = "UPDATE Vehiculo SET Stock = Stock - 1 WHERE IDVehiculo = @VehiculoID;";


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Ejecutar INSERT Venta
                    using (SqlCommand commandVenta = new SqlCommand(queryInsertVenta, connection, transaction))
                    {
                        // Usando los nombres de columna de tu tabla Venta (image_ca787e.png)
                        commandVenta.Parameters.AddWithValue("@ClienteID", idCliente);
                        commandVenta.Parameters.AddWithValue("@EmpleadoID", idEmpleado);
                        commandVenta.Parameters.AddWithValue("@VehiculoID", idVehiculoSeleccionado);
                        commandVenta.Parameters.AddWithValue("@MetodoPagoID", idMetodoPago);
                        commandVenta.Parameters.AddWithValue("@PromocionID", idPromocion);
                        commandVenta.Parameters.AddWithValue("@CreditoID", idCredito);
                        commandVenta.Parameters.AddWithValue("@FechaVenta", fechaVenta);
                        commandVenta.Parameters.AddWithValue("@MontoTotal", montoTotal);

                        object result = commandVenta.ExecuteScalar();
                        int idVenta = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;

                        // Ejecutar UPDATE Stock
                        using (SqlCommand commandStock = new SqlCommand(queryUpdateStock, connection, transaction))
                        {
                            commandStock.Parameters.AddWithValue("@VehiculoID", idVehiculoSeleccionado);
                            int rowsAffected = commandStock.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                throw new Exception("Error al actualizar el stock del vehículo. Venta cancelada (Vehículo no disponible).");
                            }
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show($"Venta registrada correctamente. Total: {montoTotal.ToString("C")}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Opcional: Recargar el DataGridView y limpiar el formulario
                    // ActualizarVentasGridView(); 
                    LimpiarFormulario();
                    CargarListasAuxiliares();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error al registrar la venta: {ex.Message}", "Error de Transacción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void LimpiarFormulario()
        {
            // Volver a seleccionar la opción "-- Seleccione --" o "-- Sin Promoción --"
            cbxCliente.SelectedIndex = 0;
            cbxEmpleado.SelectedIndex = 0;
            cbxMetodoPago.SelectedIndex = 0;
            cbxPromocion.SelectedIndex = 1; // Sin Promoción
            cbxVehiculo.SelectedIndex = 0;
            if (cbxCredito.Items.Count > 0) cbxCredito.SelectedIndex = 1; // Pagar Sin Crédito

            lblTotal.Text = "Total: $0.00";
            precioVehiculoBase = 0.00m;
            idVehiculoSeleccionado = 0;
        }

        // 2. MÉTODOS DE CARGA
        private void CargarListasAuxiliares()
        {
            // 1. Cargar Empleados (Vendedor)
            string queryEmpleados = "SELECT IDEmpleado, CONCAT(Nombre, ' ', ApellidoP) AS NombreCompleto FROM Empleado ORDER BY NombreCompleto;";
            CargarComboBox(cbxEmpleado, queryEmpleados, "NombreCompleto", "IDEmpleado");

            // 2. Cargar Clientes
            string queryClientes = "SELECT IDCliente, CONCAT(Nombre, ' ', ISNULL(ApellidoP,''), ' ', ISNULL(ApellidoM,'')) AS NombreCompleto FROM Cliente ORDER BY NombreCompleto;";
            CargarComboBox(cbxCliente, queryClientes, "NombreCompleto", "IDCliente");

            // 3. Cargar Vehículos Disponibles
            string queryVehiculos = "SELECT IDVehiculo, " +
                        "CONCAT(Marca, ' - ', Modelo, ' (Precio: ', FORMAT(Precio, 'C', 'es-MX'), ')') AS Descripcion " +
                        "FROM V_InventarioVehiculos ORDER BY Marca, Modelo;";
            CargarComboBox(cbxVehiculo, queryVehiculos, "Descripcion", "IDVehiculo");

            // 4. Cargar Métodos de Pago
            string queryPagos = "SELECT IDMetodoPago, Nombre FROM MetodoPago ORDER BY IDMetodoPago;";
            CargarComboBox(cbxMetodoPago, queryPagos, "Nombre", "IDMetodoPago");

            // 5. Cargar Promociones
            string queryPromociones = "SELECT IDPromocion, Nombre, DescuentoPorcentaje FROM Promocion WHERE VigenciaFin >= GETDATE() OR VigenciaFin IS NULL ORDER BY Nombre;";
            dtPromociones = CargarComboBox(cbxPromocion, queryPromociones, "Nombre", "IDPromocion");

            cbxCredito.DataSource = null;
            cbxCredito.Items.Clear();
            cbxCredito.Items.Add("-- Seleccione un Cliente --");
            cbxCredito.SelectedIndex = 0;
            cbxCredito.Enabled = false;

            // 6. Inicializar Créditos (se deshabilitan hasta seleccionar cliente)
            cbxCredito.DataSource = null;
            cbxCredito.Items.Clear();
            cbxCredito.Items.Add("-- Plazo a Meses --");
            cbxCredito.SelectedIndex = 0;
            cbxCredito.Enabled = true;

            // 7. Cargar Inventario (Unidades Disponibles)
            // Muestra el ID de Inventario, el Estado y la Ubicación de la unidad
            string queryInventario = "SELECT IDInventario, CONCAT('ID: ', IDInventario, ' - Estado: ', Estado, ' - Ubicación: ', Ubicacion) AS Descripcion FROM Inventario WHERE Estado = 'Disponible' ORDER BY IDInventario;";
            CargarComboBox(cbxInventario, queryInventario, "Descripcion", "IDInventario");

            CargarVentasDataGridView();
        }

        private void LimpiarCampos()
        {
            // 1. Resetear los ComboBoxes (seleccionar el índice inicial 0, que es "-- Seleccione --")
            cbxCliente.SelectedIndex = 0;
            cbxEmpleado.SelectedIndex = 0;
            cbxVehiculo.SelectedIndex = 0;
            cbxMetodoPago.SelectedIndex = 0;
            cbxPromocion.SelectedIndex = 0;
            cbxInventario.SelectedIndex = 0;

            // El ComboBox de Crédito se maneja automáticamente por el evento del cliente,
            // pero lo reiniciamos si está cargado:
            cbxCredito.DataSource = null;
            cbxCredito.Items.Clear();
            cbxCredito.Items.Add("-- Plazo a Meses --");
            cbxCredito.SelectedIndex = 0;
            cbxCredito.Enabled = false;

            // 2. Resetear las variables de cálculo
            precioVehiculoBase = 0.00m;

            // 3. Recalcular y actualizar etiquetas (debería mostrar Total: $0.00)
            CalcularTotal();

            // Opcional: Limpiar cualquier TextBox o control extra que uses
            // txtPromocionAplicada.Text = string.Empty; 
        }



        private DataTable CargarComboBox(ComboBox cbx, string query, string displayMember, string valueMember)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dt);

                    DataRow initialRow = dt.NewRow();

                    if (dt.Columns.Contains(valueMember))
                    {

                        initialRow[valueMember] = Convert.ChangeType(0, dt.Columns[valueMember].DataType);
                    }

                    if (dt.Columns.Contains(displayMember))
                    {
                        initialRow[displayMember] = "-- Seleccione --";
                    }


                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName != valueMember && col.ColumnName != displayMember && !col.AllowDBNull)
                        {

                            if (col.DataType == typeof(int) || col.DataType == typeof(decimal))
                            {
                                initialRow[col.ColumnName] = 0;
                            }
                            else
                            {
                                initialRow[col.ColumnName] = DBNull.Value;
                            }
                        }
                    }

                    dt.Rows.InsertAt(initialRow, 0);

                    cbx.DataSource = dt;
                    cbx.DisplayMember = displayMember;
                    cbx.ValueMember = valueMember;
                    cbx.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el ComboBox {cbx.Name}: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        private void AgregarOpcionNula(ComboBox cbx, DataTable dt, string valueMember, string displayMember, string text)
        {
            DataRow nullRow = dt.NewRow();
            nullRow[valueMember] = DBNull.Value; // Usar DBNull para la base de datos
            nullRow[displayMember] = text;
            dt.Rows.InsertAt(nullRow, 1); // Insertar después de "-- Seleccione --"
            cbx.SelectedIndex = 1;
        }



        private void CargarCreditosDisponibles(int idCliente)
        {
            if (cbxCredito == null) return;

            if (idCliente > 0)
            {
                string query = "SELECT IDCredito, " +
                               "CONCAT(PlazoMeses, ' meses - Monto: ', FORMAT(MontoFinanciado, 'C', 'es-MX')) AS Descripcion " +
                               "FROM Credito WHERE ClienteID = @IDCliente ORDER BY PlazoMeses ASC;";

                DataTable dt = new DataTable();

                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        command.Parameters.AddWithValue("@IDCliente", idCliente);
                        adapter.Fill(dt);

                        // 2. Agrega la opción nula
                        DataRow initialRow = dt.NewRow();
                        initialRow["IDCredito"] = 0;
                        initialRow["Descripcion"] = "-- Ningún Crédito Aplicado --";

                        if (dt.Columns.Contains("PlazoMeses"))
                        {
                            initialRow["PlazoMeses"] = 0;
                        }

                        dt.Rows.InsertAt(initialRow, 0);

                        // 3. Asigna la lista y HABILITA el ComboBox
                        cbxCredito.DataSource = dt;
                        cbxCredito.DisplayMember = "Descripcion";
                        cbxCredito.ValueMember = "IDCredito";
                        cbxCredito.SelectedIndex = 0;
                        cbxCredito.Enabled = true; // ¡Se habilita aquí!
                    }
                }
                catch (Exception ex)
                {
                    // Si falla, muestra el error, pero el ComboBox quedará deshabilitado
                    MessageBox.Show($"Error al cargar créditos: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxCredito.Enabled = false;
                }
            }
            else // Si no hay cliente seleccionado (ID=0)
            {
                cbxCredito.DataSource = null;
                cbxCredito.Items.Clear();
                cbxCredito.Items.Add("-- Plazo a Meses --");
                cbxCredito.SelectedIndex = 0;
                cbxCredito.Enabled = false;
            }
        }



        private void CargarInventario()
        {
            string query = "SELECT * FROM dbo.V_InventarioVehiculos ORDER BY IDVehiculo DESC;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        dgvInventario.DataSource = dataTable;
                        dgvInventario.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error de Base de Datos");
                }
            }
        }


        private void CargarClientes()
        {
            // Usaremos la tabla Cliente directamente por ahora, sin vista.
            // La tabla tiene columnas "ApellidoP" y "ApellidoM" — combinamos ambas como "Apellido" para la cuadrícula.
            string query = "SELECT IDCliente, Nombre, CONCAT(ApellidoP, ' ', ApellidoM) AS Apellido, Telefono, Email FROM Cliente ORDER BY IDCliente DESC;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Asegúrate de que este control esté dentro de la pestaña Clientes
                    dgvClientes.DataSource = dataTable;
                    dgvClientes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la lista de clientes: {ex.Message}", "Error de Base de Datos");
                }
            }
        }

        private void CargarEmpleados()
        {
            string query = "SELECT * FROM Empleado ORDER BY IDEmpleado DESC;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dgvEmpleados.DataSource = dataTable;
                    dgvEmpleados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la lista de empleados: {ex.Message}", "Error de Base de Datos");
                }
            }
        }

        // Carga los nombres de los clientes en el ComboBox de la pestaña Ventas
        private void CargarClientesCombo()
        {
            if (cbxCliente == null)
                return;

            string query = "SELECT IDCliente, CONCAT(Nombre, ' ', ISNULL(ApellidoP,''), ' ', ISNULL(ApellidoM,'')) AS NombreCompleto FROM Cliente ORDER BY NombreCompleto;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                try
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbxCliente.DisplayMember = "NombreCompleto";
                    cbxCliente.ValueMember = "IDCliente";
                    cbxCliente.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar clientes para el combo: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cargar la pestaña Clientes cuando se seleccione
            if (tabControl1.SelectedTab == tabPage3)
            {
                CargarClientes();
            }
            // Cargar la pestaña Empleados
            if (tabControl1.SelectedTab == tabPage4)
            {
                CargarEmpleados();
            }
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                // 🚨 INTENTA crear e inicializar el formulario modal
                using (FormVehiculoDetalle frmDetalle = new FormVehiculoDetalle())
                {
                    // Si llega hasta aquí, la inicialización fue EXITOSA.

                    if (frmDetalle.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Vehículo agregado exitosamente. Refrescando inventario.");
                        CargarInventario();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"¡ERROR CRÍTICO AL ABRIR EL FORMULARIO! El botón funciona, pero el formulario falló al inicializarse.\n\nDetalle del Error:\n{ex.Message}\n\nFuente: {ex.Source}",
                                "ERROR FATAL DE INICIALIZACIÓN",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormEmpleadoDetalle frm = new FormEmpleadoDetalle())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Empleado agregado exitosamente.");
                        CargarEmpleados();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Dentro de la clase FormMenuPrincipal
        private int ObtenerIDVehiculoSeleccionado()
        {
            // Verifica si el DataGridView tiene filas o si hay una fila actualmente seleccionada
            if (dgvInventario.Rows.Count == 0 || dgvInventario.CurrentRow == null)
            {
                throw new InvalidOperationException("Debe seleccionar un vehículo de la lista.");
            }

            // El nombre de la columna debe ser IDVehiculo, según tu vista SQL
            object idValue = dgvInventario.CurrentRow.Cells["IDVehiculo"].Value;

            if (idValue == DBNull.Value || idValue == null)
            {
                throw new InvalidOperationException("La fila seleccionada no contiene un ID de vehículo válido.");
            }

            // Devuelve el ID como entero
            return Convert.ToInt32(idValue);
        }

        // Nuevo: Obtener ID de cliente seleccionado
        private int ObtenerIDClienteSeleccionado()
        {
            if (dgvClientes.Rows.Count == 0 || dgvClientes.CurrentRow == null)
            {
                throw new InvalidOperationException("Debe seleccionar un cliente de la lista.");
            }

            object idValue;
            // Intentar obtener por nombre de columna, si no existe usar la primera celda
            if (dgvClientes.Columns.Contains("IDCliente"))
            {
                idValue = dgvClientes.CurrentRow.Cells["IDCliente"].Value;
            }
            else
            {
                idValue = dgvClientes.CurrentRow.Cells[0].Value;
            }

            if (idValue == DBNull.Value || idValue == null)
            {
                throw new InvalidOperationException("La fila seleccionada no contiene un ID de cliente válido.");
            }

            return Convert.ToInt32(idValue);
        }

        // Obtener ID de empleado seleccionado en dgvEmpleados
        private int ObtenerIDEmpleadoSeleccionado()
        {
            if (dgvEmpleados.Rows.Count == 0 || dgvEmpleados.CurrentRow == null)
            {
                throw new InvalidOperationException("Debe seleccionar un empleado de la lista.");
            }

            object idValue;
            if (dgvEmpleados.Columns.Contains("IDEmpleado"))
            {
                idValue = dgvEmpleados.CurrentRow.Cells["IDEmpleado"].Value;
            }
            else
            {
                idValue = dgvEmpleados.CurrentRow.Cells[0].Value;
            }

            if (idValue == null || idValue == DBNull.Value)
            {
                throw new InvalidOperationException("La fila seleccionada no contiene un ID de empleado válido.");
            }

            return Convert.ToInt32(idValue);
        }

        private void EliminarVehiculo(int idVehiculo)
        {
            string query = "DELETE FROM Vehiculo WHERE IDVehiculo = @ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", idVehiculo);

                try
                {
                    connection.Open();
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Vehículo eliminado exitosamente.", "Éxito");
                        CargarInventario(); // Recarga tu DataGridView para reflejar el cambio
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error de Base de Datos");
                }
            }
        }

        private void btnModificarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtiene el ID del vehículo seleccionado
                int idVehiculo = ObtenerIDVehiculoSeleccionado();

                // 2. Abre el formulario modal, pasándole el ID
                using (FormVehiculoDetalle frmDetalle = new FormVehiculoDetalle(idVehiculo))
                {
                    if (frmDetalle.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Vehículo modificado exitosamente.");
                        CargarInventario(); // Recarga la lista para ver los cambios
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar abrir el formulario para modificar: {ex.Message}");
            }
        }

        private void btnEliminarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtiene el ID del vehículo seleccionado
                int idVehiculo = ObtenerIDVehiculoSeleccionado();

                // 2. Pide confirmación al usuario
                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro de eliminar el vehículo con ID {idVehiculo}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    EliminarVehiculo(idVehiculo); // Llama a la función de eliminación
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia"); // Muestra el mensaje de 'debe seleccionar un vehículo'
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}");
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            using (FormClienteDetalle frmDetalle = new FormClienteDetalle())
            {
                if (frmDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Cliente agregado exitosamente.");
                    CargarClientes(); // Recargar la lista de clientes
                }
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = ObtenerIDClienteSeleccionado();

                using (FormClienteDetalle frmDetalle = new FormClienteDetalle(idCliente))
                {
                    if (frmDetalle.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Cliente modificado exitosamente.");
                        CargarClientes();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar modificar el cliente: {ex.Message}");
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = ObtenerIDClienteSeleccionado();

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro de eliminar el cliente con ID {idCliente}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion != DialogResult.Yes)
                    return;

                string query = "DELETE FROM Cliente WHERE IDCliente = @ID";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", idCliente);

                    try
                    {
                        connection.Open();
                        int filas = command.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarClientes();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el cliente o no fue posible eliminarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el cliente: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosRolUsuario()
        {
            // Si el control no existe en el formulario, no hacemos nada
            if (cbxMetodoPago == null)
                return;

            // Aquí puedes cargar los roles desde la base de datos si es necesario
            // Por simplicidad, agregaremos algunos roles estáticos
            cbxMetodoPago.Items.Clear();
            string query = "SELECT IDMetodoPago, Nombre FROM RolUsuario WHERE Puesto IS NOT NULL";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    DataSet set = new DataSet();
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(set);
                    }

                    cbxMetodoPago.DataSource = set.Tables[0];
                    cbxMetodoPago.ValueMember = "IDMetodoPago";
                    cbxMetodoPago.DisplayMember = "Nombre";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar roles de usuario: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void CargarDatosPromocion()
        {
            // Si el control de promociones no existe (usamos comboBox2 en el diseñador), salir
            if (cbxPromocion == null)
                return;

            cbxPromocion.Items.Clear();
            string query = "SELECT IDPromocion, Nombre, DescuentoPorcentaje FROM Promocion";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    DataSet set = new DataSet();
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(set);
                    }

                    cbxPromocion.DataSource = set.Tables[0];
                    cbxPromocion.ValueMember = "IDPromocion";
                    cbxPromocion.DisplayMember = "Nombre";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar promociones: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                int idEmpleado = ObtenerIDEmpleadoSeleccionado();

                using (FormEmpleadoDetalle frm = new FormEmpleadoDetalle(idEmpleado))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Empleado modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEmpleados();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar modificar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                int idEmpleado = ObtenerIDEmpleadoSeleccionado();

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro de eliminar el empleado con ID {idEmpleado}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion != DialogResult.Yes)
                    return;

                string query = "DELETE FROM Empleado WHERE IDEmpleado = @ID";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", idEmpleado);

                    try
                    {
                        connection.Open();
                        int filas = command.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            MessageBox.Show("Empleado eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarEmpleados();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el empleado o no fue posible eliminarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el empleado: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventario == null || dgvInventario.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Exportar CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = "inventario.csv";
                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        // Header
                        var headers = dgvInventario.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).Select(c => EscapeCsv(c.HeaderText));
                        sw.WriteLine(string.Join(",", headers));

                        // Rows
                        foreach (DataGridViewRow row in dgvInventario.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var cells = dgvInventario.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).Select(c =>
                            {
                                var v = row.Cells[c.Index].Value;
                                return EscapeCsv(v?.ToString() ?? string.Empty);
                            });
                            sw.WriteLine(string.Join(",", cells));
                        }
                    }

                    MessageBox.Show("Exportación completada.", "Exportar CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string EscapeCsv(string s)
        {
            if (s == null)
                return "";
            bool mustQuote = s.Contains(',') || s.Contains('"') || s.Contains('\n') || s.Contains('\r');
            if (s.Contains('"'))
                s = s.Replace("\"", "\"\"");
            return mustQuote ? "\"" + s + "\"" : s;
        }

        private void btnRegistrarVenta_Click_1(object sender, EventArgs e)
        {
            // 1. Recolectar IDs
            RecolectarIDs();

            // 2. Ejecutar Cálculo Final
            CalcularTotal();

            // Asignar el total calculado a una variable local para la inserción
            totalVenta = decimal.Parse(lblTotal.Text.Replace("Total: ", "").Replace("$", "").Replace(",", ""));

            // 3. Validaciones Mínimas
            if (idClienteSeleccionado == 0 || idVehiculoSeleccionado == 0 || idEmpleadoSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un Cliente, un Empleado y un Vehículo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (totalVenta <= 0)
            {
                MessageBox.Show("El total de la venta debe ser mayor a cero. Verifique el precio del vehículo.", "Error de Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Ejecutar Inserción en la Base de Datos
            if (InsertarVenta())
            {
                MessageBox.Show("¡Venta registrada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarVentasDataGridView();
                LimpiarCampos(); // Crea este método para limpiar los controles
            }
            else
            {
                MessageBox.Show("Error al registrar la venta. Verifique la conexión o los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecolectarIDs()
        {
            // Revisa si el ComboBox tiene un valor seleccionado y lo convierte a entero de forma segura

            // Cliente
            int.TryParse(cbxCliente.SelectedValue?.ToString() ?? "0", out idClienteSeleccionado);

            // Vehículo
            int.TryParse(cbxVehiculo.SelectedValue?.ToString() ?? "0", out idVehiculoSeleccionado);

            // Empleado
            int.TryParse(cbxEmpleado.SelectedValue?.ToString() ?? "0", out idEmpleadoSeleccionado);

            // Método de Pago
            int.TryParse(cbxMetodoPago.SelectedValue?.ToString() ?? "0", out idMetodoPagoSeleccionado);

            // Inventario (asume que si seleccionas Vehículo, también debes seleccionar Inventario)
            int.TryParse(cbxInventario.SelectedValue?.ToString() ?? "0", out idInventarioSeleccionado);

            // Promoción (Puede ser 0 si no se seleccionó)
            int.TryParse(cbxPromocion.SelectedValue?.ToString() ?? "0", out idPromocionSeleccionada);

            // Crédito (Puede ser 0 si no se seleccionó)
            int.TryParse(cbxCredito.SelectedValue?.ToString() ?? "0", out idCreditoSeleccionado);

        }

        private bool InsertarVenta()
        {
            string query = "INSERT INTO Venta (" +
                           "fecha_venta, total, id_cliente, id_empleado, id_inventario, id_metodo_pago, id_promocion, id_credito, id_vehiculo) " +
                           "VALUES (@FechaVenta, @Total, @ClienteID, @EmpleadoID, @InventarioID, @MetodoPagoID, @PromocionID, @CreditoID, @VehiculoID);";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parámetros de la venta
                    command.Parameters.AddWithValue("@FechaVenta", DateTime.Now);
                    command.Parameters.AddWithValue("@Total", totalVenta);
                    command.Parameters.AddWithValue("@ClienteID", idClienteSeleccionado);
                    command.Parameters.AddWithValue("@EmpleadoID", idEmpleadoSeleccionado);
                    command.Parameters.AddWithValue("@InventarioID", idInventarioSeleccionado);
                    command.Parameters.AddWithValue("@MetodoPagoID", idMetodoPagoSeleccionado);
                    command.Parameters.AddWithValue("@VehiculoID", idVehiculoSeleccionado);

                    // Parámetros que pueden ser NULL (Promoción y Crédito)
                    // Usamos SqlDbType.Int para evitar problemas al enviar NULL
                    command.Parameters.Add("@PromocionID", SqlDbType.Int).Value = (idPromocionSeleccionada > 0) ? (object)idPromocionSeleccionada : DBNull.Value;
                    command.Parameters.Add("@CreditoID", SqlDbType.Int).Value = (idCreditoSeleccionado > 0) ? (object)idCreditoSeleccionado : DBNull.Value;

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de BD al insertar venta: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private bool EliminarVenta(int idVenta)
        {
            // Consulta SQL para eliminar el registro usando el ID de la venta
            string query = "DELETE FROM Venta WHERE id_venta = @IdVenta";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdVenta", idVenta);
                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    // Retorna verdadero si se eliminó al menos una fila
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la venta: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CargarVentasDataGridView()
        {
            // Consulta los datos relevantes, haciendo JOIN para obtener los NOMBRES de Marca y Modelo.
            string query = "SELECT V.id_venta, V.fecha_venta, V.total, " +
                           "C.Nombre AS Cliente, E.Nombre AS Empleado, " +
                           "M.Nombre AS Marca, MD.Nombre AS Modelo, " + // 🚨 CORRECCIÓN: Usamos las tablas de Marca y Modelo
                           "VH.VIN " + // Usamos el VIN como identificador único del vehículo
                           "FROM Venta V " +
                           "INNER JOIN Cliente C ON V.id_cliente = C.IDCliente " +
                           "INNER JOIN Empleado E ON V.id_empleado = E.IDEmpleado " +
                           "INNER JOIN Vehiculo VH ON V.id_vehiculo = VH.IDVehiculo " +
                           "INNER JOIN Marca M ON VH.MarcaID = M.IDMarca " +    // 🚨 NUEVA UNIÓN: Tabla Marca
                           "INNER JOIN Modelo MD ON VH.ModeloID = MD.IDModelo " + // 🚨 NUEVA UNIÓN: Tabla Modelo
                           "ORDER BY V.fecha_venta DESC;";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvVentas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el listado de ventas: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            // 1. Verificar si hay alguna fila seleccionada en el DataGridView
            if (dgvVentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una venta de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener el ID de la venta de la fila seleccionada
            // Se asume que la columna del ID se llama "id_venta" (como en la BD)
            int idVentaAEliminar = Convert.ToInt32(dgvVentas.SelectedRows[0].Cells["id_venta"].Value);

            // 3. Confirmación del usuario
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar la venta ID {idVentaAEliminar}? Esta acción es irreversible.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // 4. Ejecutar la eliminación
                if (EliminarVenta(idVentaAEliminar))
                {
                    MessageBox.Show("Venta eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Actualizar el DataGridView para que el cambio se refleje
                    CargarVentasDataGridView();
                }
                // Si hay error, el mensaje ya lo mostró la función EliminarVenta
            }
        }

        private void btnExportarTXT_Click(object sender, EventArgs e)
        {
            // 1. Verificar si hay datos en el DataGridView de Clientes
            if (dgvClientes.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos de clientes para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Configurar el diálogo para guardar archivo
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos de texto (*.txt)|*.txt";
                sfd.FileName = "Reporte_Clientes_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
                sfd.Title = "Guardar Reporte de Clientes";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // 3. Llamar a la función de exportación con la ruta seleccionada
                    if (ExportarClientesATXT(sfd.FileName))
                    {
                        MessageBox.Show("Datos de clientes exportados con éxito a:\n" + sfd.FileName, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private bool ExportarClientesATXT(string rutaArchivo)
        {
            try
            {
                // Usamos StreamWriter para escribir texto en el archivo
                using (StreamWriter sw = new StreamWriter(rutaArchivo, false, System.Text.Encoding.UTF8))
                {
                    // 1. Escribir encabezados de columna
                    string header = "";
                    for (int i = 0; i < dgvClientes.Columns.Count; i++)
                    {
                        header += dgvClientes.Columns[i].HeaderText + "\t"; // Usa tabulador como separador
                    }
                    sw.WriteLine(header.TrimEnd('\t')); // Escribe encabezado y elimina el tabulador final

                    // 2. Escribir datos de cada fila
                    foreach (DataGridViewRow row in dgvClientes.Rows)
                    {
                        if (!row.IsNewRow) // Evitar la fila de inserción nueva si existe
                        {
                            string line = "";
                            for (int i = 0; i < dgvClientes.Columns.Count; i++)
                            {
                                // Obtiene el valor de la celda, si es nulo, usa una cadena vacía
                                object cellValue = row.Cells[i].Value;
                                line += (cellValue == null ? "" : cellValue.ToString()) + "\t";
                            }
                            sw.WriteLine(line.TrimEnd('\t'));
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar los datos: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnExportarJSON_Click(object sender, EventArgs e)
        {
            // 1. Verificar si hay datos
            if (dgvEmpleados.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos de empleados para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Configurar el diálogo para guardar archivo JSON
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos JSON (*.json)|*.json";
                sfd.FileName = "Reporte_Empleados_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json";
                sfd.Title = "Guardar Reporte de Empleados";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // 3. Llamar a la función de exportación con la ruta seleccionada
                    if (ExportarEmpleadosAJSON(sfd.FileName))
                    {
                        MessageBox.Show("Datos de empleados exportados con éxito a:\n" + sfd.FileName, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private bool ExportarEmpleadosAJSON(string rutaArchivo)
        {
            try
            {
                // 1. Crear una lista genérica para almacenar los datos
                var listaEmpleados = new List<Dictionary<string, object>>();

                // 2. Recorrer las filas del DataGridView
                foreach (DataGridViewRow row in dgvEmpleados.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Crear un diccionario para representar el objeto JSON de un solo empleado
                        var empleado = new Dictionary<string, object>();

                        // 3. Recorrer las columnas y asignar el nombre de la columna como clave (key)
                        for (int i = 0; i < dgvEmpleados.Columns.Count; i++)
                        {
                            string columnName = dgvEmpleados.Columns[i].HeaderText;
                            object cellValue = row.Cells[i].Value;

                            // Se agrega la clave (nombre de columna) y el valor de la celda
                            empleado.Add(columnName, cellValue);
                        }

                        listaEmpleados.Add(empleado);
                    }
                }

                // 4. Serializar la lista de diccionarios a una cadena JSON formateada
                // El ajuste Formatting.Indented hace que el JSON sea más fácil de leer
                string jsonOutput = JsonConvert.SerializeObject(listaEmpleados, Newtonsoft.Json.Formatting.Indented);

                // 5. Escribir la cadena JSON en el archivo
                File.WriteAllText(rutaArchivo, jsonOutput);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar los datos JSON: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnImportarTicket_Click(object sender, EventArgs e)
        {
            // 1. Verificar si hay alguna fila seleccionada
            if (dgvVentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una venta de la lista para generar el ticket.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener el ID de la venta y la fecha (para el nombre del archivo)
            int idVenta = Convert.ToInt32(dgvVentas.SelectedRows[0].Cells["id_venta"].Value);
            DateTime fechaVenta = Convert.ToDateTime(dgvVentas.SelectedRows[0].Cells["fecha_venta"].Value);

            // 3. Configurar el diálogo para guardar el archivo
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos de texto (*.txt)|*.txt";
                sfd.FileName = $"Ticket_Venta_{idVenta}_{fechaVenta:yyyyMMdd}.txt";
                sfd.Title = "Guardar Ticket de Venta";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // 4. Llamar a la función de generación de ticket
                    if (GenerarTicketTXT(idVenta, sfd.FileName))
                    {
                        MessageBox.Show("Ticket generado con éxito en:\n" + sfd.FileName, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private bool GenerarTicketTXT(int idVenta, string rutaArchivo)
        {
            string query = @"
        SELECT 
            V.id_venta, 
            V.fecha_venta, 
            V.total,
            C.Nombre AS Cliente, 
            E.Nombre AS Empleado,
            M.Nombre AS Marca, 
            MD.Nombre AS Modelo, 
            MP.Nombre AS MetodoPago  -- Utilizamos la columna Nombre
        FROM 
            Venta V
        INNER JOIN Cliente C ON V.id_cliente = C.IDCliente 
        INNER JOIN Empleado E ON V.id_empleado = E.IDEmpleado 
        INNER JOIN Vehiculo VH ON V.id_vehiculo = VH.IDVehiculo 
        INNER JOIN Marca M ON VH.MarcaID = M.IDMarca    
        INNER JOIN Modelo MD ON VH.ModeloID = MD.IDModelo 
        INNER JOIN MetodoPago MP ON V.id_metodo_pago = MP.IDMetodoPago 
        WHERE 
            V.id_venta = @IdVenta;
    ";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdVenta", idVenta);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 1. Obtener los valores de la venta
                            string ticketId = reader["id_venta"].ToString();
                            string fecha = Convert.ToDateTime(reader["fecha_venta"]).ToString("dd/MM/yyyy HH:mm");
                            string cliente = reader["Cliente"].ToString();
                            string empleado = reader["Empleado"].ToString();
                            string vehiculo = reader["Marca"].ToString() + " " + reader["Modelo"].ToString();
                            string metodoPago = reader["MetodoPago"] != DBNull.Value ? reader["MetodoPago"].ToString() : "Error en BD";
                            decimal total = Convert.ToDecimal(reader["total"]);

                            // 2. Formatear el ticket (usando espacios para alineación simple)
                            string ticketContent = "";
                            ticketContent += "=========================================\n";
                            ticketContent += "        AGENCIA DE VENTAS DE AUTOS       \n";
                            ticketContent += "=========================================\n";
                            ticketContent += $"Ticket No: {ticketId}\n";
                            ticketContent += $"Fecha:     {fecha}\n";
                            ticketContent += "-----------------------------------------\n";
                            ticketContent += $"Vendedor:  {empleado}\n";
                            ticketContent += $"Cliente:   {cliente}\n";
                            ticketContent += "-----------------------------------------\n";
                            ticketContent += $"Vehículo:  {vehiculo}\n";
                            ticketContent += $"Método de Pago: {metodoPago}\n";
                            ticketContent += "-----------------------------------------\n";
                            ticketContent += $"TOTAL PAGADO: {total:C}\n"; // Formato de moneda
                            ticketContent += "=========================================\n";
                            ticketContent += "         ¡GRACIAS POR SU COMPRA!         \n";

                            // 3. Escribir el contenido al archivo
                            File.WriteAllText(rutaArchivo, ticketContent);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron detalles para la venta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el ticket: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}