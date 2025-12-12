using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAgencia
{
    public partial class FormVehiculoDetalle : Form
    {
        private const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=AGENCIA;Integrated Security=True;TrustServerCertificate=True;";

        private int _idVehiculoEditando = 0;


        public FormVehiculoDetalle()
        {
            InitializeComponent();
            CargarListasAuxiliares();
            cbxMarca.SelectedIndexChanged += cbxMarca_SelectedIndexChanged;
            cbxModelo.SelectedIndexChanged += cbxModelo_SelectedIndexChanged;
            this.Text = "Agregar Nuevo Vehículo";
        }


        /// <summary>
        /// Carga un ComboBox simple con dos columnas (sin filtro)
        /// </summary>
        private void CargarComboBoxSimple(
            ComboBox cmb,
            string query,
            string valueMember,
            string displayMember)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }

                    // Primero configuramos los miembros y después asignamos el DataSource
                    // para evitar que SelectedValue sea un DataRowView cuando el evento se dispare.
                    cmb.ValueMember = valueMember;
                    cmb.DisplayMember = displayMember;
                    cmb.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar ComboBox {cmb.Name}: {ex.Message}", "Error de BD");
                }
            }
        }

        /// <summary>
        /// Carga un ComboBox con opción "Seleccione..." inicial
        /// </summary>
        private void CargarComboBoxConOpcionInicial(
            ComboBox cbx,
            string query,
            string displayMember,
            string valueMember)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);

                    // Añadir la opción inicial "Seleccione..."
                    DataRow row = dt.NewRow();
                    row[valueMember] = DBNull.Value;
                    row[displayMember] = "--- Seleccione ---";
                    dt.Rows.InsertAt(row, 0);

                    cbx.DisplayMember = displayMember;
                    cbx.ValueMember = valueMember;
                    cbx.DataSource = dt;
                    cbx.SelectedIndex = 0; // Selecciona la opción "Seleccione..."
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar listas: {ex.Message}", "Error de BD");
                }
            }
        }

        /// <summary>
        /// Carga un ComboBox con filtro (cascada)
        /// </summary>
        private void CargarComboBoxConFiltro(
            ComboBox cmb,
            string query,
            string valueMember,
            string displayMember,
            int idFiltro,
            string nombreParametro)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(nombreParametro, idFiltro);

                try
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }

                    // Configurar Value/Display antes de asignar DataSource para evitar el DataRowView
                    cmb.ValueMember = valueMember;
                    cmb.DisplayMember = displayMember;
                    cmb.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar ComboBox {cmb.Name}: {ex.Message}", "Error de BD");
                }
            }
        }

        public FormVehiculoDetalle(int idVehiculo) : this()
        {
            _idVehiculoEditando = idVehiculo;
            this.Text = $"Modificar Vehículo (ID: {idVehiculo})";
            CargarDatosVehiculo(idVehiculo);
        }


        private void CargarDatosVehiculo(int idVehiculo)
        {
            string query = @"
        SELECT V.MarcaID, V.ModeloID, V.VersionID, V.ColorID, V.Anio, V.Precio, V.VIN, V.Disponible
        FROM Vehiculo V
        WHERE V.IDVehiculo = @ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", idVehiculo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // 1. Carga de los ComboBox (debe ocurrir antes de configurar la lista)
                        int marcaId = Convert.ToInt32(reader["MarcaID"]);
                        cbxMarca.SelectedValue = marcaId;

                        // Esperar brevemente para que se carguen los modelos
                        System.Threading.Thread.Sleep(100);

                        // Estos deben cargarse después de que la Marca haya cargado los Modelos
                        int modeloId = Convert.ToInt32(reader["ModeloID"]);
                        cbxModelo.SelectedValue = modeloId;

                        // Esperar brevemente para que se carguen las versiones
                        System.Threading.Thread.Sleep(100);

                        if (reader["VersionID"] != DBNull.Value)
                        {
                            cbxVersion.SelectedValue = Convert.ToInt32(reader["VersionID"]);
                        }

                        if (reader["ColorID"] != DBNull.Value)
                        {
                            cbxColor.SelectedValue = Convert.ToInt32(reader["ColorID"]);
                        }

                        // 2. Carga de los TextBox y CheckBox
                        txtAnio.Text = reader["Anio"].ToString();
                        txtPrecio.Text = reader["Precio"].ToString();
                        txtVIN.Text = reader["VIN"].ToString();
                        chbDisponible.Checked = Convert.ToBoolean(reader["Disponible"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos del vehículo: {ex.Message}", "Error de BD");
                }
            }
        }

        private void CargarListasAuxiliares()
        {
            // Carga las listas estáticas (Marca y Color)
            CargarComboBoxConOpcionInicial(cbxMarca, "SELECT IDMarca, Nombre FROM Marca ORDER BY Nombre", "Nombre", "IDMarca");
            CargarComboBoxConOpcionInicial(cbxColor, "SELECT IDColor, Nombre FROM Color ORDER BY Nombre", "Nombre", "IDColor");

            // Las listas Modelo y Versión se llenarán con el filtrado
        }

        private void cbxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpiar ComboBoxes en cascada
            cbxModelo.DataSource = null;
            cbxVersion.DataSource = null;

            if (cbxMarca.SelectedValue != null && cbxMarca.SelectedValue != DBNull.Value)
            {
                int marcaId = Convert.ToInt32(cbxMarca.SelectedValue);
                string query = "SELECT IDModelo, Nombre FROM Modelo WHERE IDMarca = @IDMarca ORDER BY Nombre";
                CargarComboBoxConFiltro(cbxModelo, query, "IDModelo", "Nombre", marcaId, "@IDMarca");
            }
        }

        private void cbxModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxVersion.DataSource = null; // Limpiar Versiones

            var sel = cbxModelo.SelectedValue;

            // Protección: si viene un DataRowView (o nulo), no intentamos convertir.
            if (sel == null || sel == DBNull.Value || sel is DataRowView)
            {
                return;
            }

            int modeloId = Convert.ToInt32(sel);
            string query = "SELECT IDVersion, Nombre FROM Version ORDER BY Nombre";
            CargarComboBoxSimple(cbxVersion, query, "IDVersion", "Nombre");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. VALIDACIONES PREVIAS
            if (!ValidarCamposRequeridos())
            {
                return;
            }

            // 2. VALIDAR CONVERSIÓN DE DATOS NUMÉRICOS
            if (!ValidarDatosNumericos(out int ano, out decimal precio))
            {
                return;
            }

            // 3. CONSTRUIR Y EJECUTAR CONSULTA
            GuardarVehiculo(ano, precio);
        }

        /// <summary>
        /// Valida que los campos requeridos estén completos
        /// </summary>
        private bool ValidarCamposRequeridos()
        {
            // Marca
            if (cbxMarca.SelectedValue == null || cbxMarca.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Por favor, seleccione una Marca.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxMarca.Focus();
                return false;
            }

            // Modelo
            if (cbxModelo.SelectedValue == null || cbxModelo.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Por favor, seleccione un Modelo.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxModelo.Focus();
                return false;
            }

            // Versión
            if (cbxVersion.SelectedValue == null || cbxVersion.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Por favor, seleccione una Versión.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxVersion.Focus();
                return false;
            }

            // VIN
            if (string.IsNullOrWhiteSpace(txtVIN.Text))
            {
                MessageBox.Show("Por favor, ingrese el VIN del vehículo.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVIN.Focus();
                return false;
            }

            // Año
            if (string.IsNullOrWhiteSpace(txtAnio.Text))
            {
                MessageBox.Show("Por favor, ingrese el año del vehículo.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnio.Focus();
                return false;
            }

            // Precio
            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, ingrese el precio del vehículo.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida y convierte los datos numéricos (Año y Precio)
        /// </summary>
        private bool ValidarDatosNumericos(out int ano, out decimal precio)
        {
            ano = 0;
            precio = 0;

            // Validar Año
            if (!int.TryParse(txtAnio.Text, out ano))
            {
                MessageBox.Show("El año debe ser un número entero válido (ej: 2024).", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnio.Focus();
                txtAnio.SelectAll();
                return false;
            }

            // Validar rango de año (ej: entre 1900 y el año actual + 1)
            int anoActual = DateTime.Now.Year;
            if (ano < 1900 || ano > anoActual + 1)
            {
                MessageBox.Show($"El año debe estar entre 1900 y {anoActual + 1}.", "Año Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnio.Focus();
                txtAnio.SelectAll();
                return false;
            }

            // Validar Precio
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio debe ser un número válido (ej: 25000.50).", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                txtPrecio.SelectAll();
                return false;
            }

            // Validar que el precio sea positivo
            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0.", "Precio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                txtPrecio.SelectAll();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Guarda el vehículo en la base de datos (INSERT o UPDATE)
        /// </summary>
        private void GuardarVehiculo(int ano, decimal precio)
        {
            string query = "";

            if (_idVehiculoEditando == 0)
            {
                // INSERT
                query = @"INSERT INTO Vehiculo (MarcaID, ModeloID, VersionID, ColorID, Anio, Precio, VIN, Disponible) 
                          VALUES (@MarcaID, @ModeloID, @VersionID, @ColorID, @Anio, @Precio, @VIN, @Disponible)";
            }
            else
            {
                // UPDATE
                query = @"UPDATE Vehiculo SET 
                          MarcaID = @MarcaID, 
                          ModeloID = @ModeloID, 
                          VersionID = @VersionID, 
                          ColorID = @ColorID, 
                          Anio = @Anio, 
                          Precio = @Precio, 
                          VIN = @VIN, 
                          Disponible = @Disponible 
                          WHERE IDVehiculo = @ID";
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@MarcaID", Convert.ToInt32(cbxMarca.SelectedValue));
                    command.Parameters.AddWithValue("@ModeloID", Convert.ToInt32(cbxModelo.SelectedValue));
                    command.Parameters.AddWithValue("@VersionID", Convert.ToInt32(cbxVersion.SelectedValue));
                    command.Parameters.AddWithValue("@ColorID", cbxColor.SelectedValue ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Anio", ano);
                    command.Parameters.AddWithValue("@Precio", precio);
                    command.Parameters.AddWithValue("@VIN", txtVIN.Text.Trim());
                    command.Parameters.AddWithValue("@Disponible", chbDisponible.Checked);

                    if (_idVehiculoEditando != 0)
                    {
                        command.Parameters.AddWithValue("@ID", _idVehiculoEditando);
                    }

                    // Ejecutar comando
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        string accion = (_idVehiculoEditando == 0) ? "agregado" : "modificado";
                        MessageBox.Show($"Vehículo {accion} exitosamente. ¡Inventario actualizado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el vehículo. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Error de base de datos: {sqlEx.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
