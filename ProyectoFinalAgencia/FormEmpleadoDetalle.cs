using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Windows.Forms;

namespace ProyectoFinalAgencia
{
    public partial class FormEmpleadoDetalle : Form
    {
        private const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=AGENCIA;Integrated Security=True;TrustServerCertificate=True;";
        private bool isInsert = true;
        private int idEmpleado = 0;

        public FormEmpleadoDetalle()
        {
            InitializeComponent();
            this.Text = "Agregar Nuevo Empleado";
            isInsert = true;
        }

        public FormEmpleadoDetalle(int id)
        {
            InitializeComponent();
            idEmpleado = id;
            isInsert = false;
            this.Text = "Modificar Empleado";
            CargarDatosEmpleado();
        }
        private void CargarDatosRolUsuario()
        {
            // Aquí puedes cargar los roles desde la base de datos si es necesario
            // Por simplicidad, agregaremos algunos roles estáticos
            cbxRolUsuario.Items.Clear();
            string query = "SELECT NombreRol, IDRol FROM RolUsuario WHERE Puesto IS NOT NULL";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    DataSet set = new DataSet();
                    DataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(set);
                    cbxRolUsuario.DataSource = set.Tables[0];
                    cbxRolUsuario.ValueMember = "IDRol";

                    cbxRolUsuario.DisplayMember = "NombreRol";

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar roles de usuario: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CargarDatosEmpleado()
        {
            string query = "SELECT Nombre, ApellidoP, ApellidoM, Telefono, Email, Puesto, FechaContratacion, Salario, Activo FROM Empleado WHERE IDEmpleado = @ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", idEmpleado);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNombreEmpleado.Text = reader["Nombre"].ToString();
                            txtApellidoP.Text = reader["ApellidoP"].ToString();
                            txtApellidoM.Text = reader["ApellidoM"].ToString();
                            txtTelefonoEmpleado.Text = reader["Telefono"].ToString();
                            txtEmailEmpleado.Text = reader["Email"].ToString();

                            string puesto = reader["Puesto"] == DBNull.Value ? string.Empty : reader["Puesto"].ToString();
                            if (!string.IsNullOrEmpty(puesto))
                            {
                                // seleccionar si existe en la lista
                                int idx = cbxRolUsuario.Items.IndexOf(puesto);
                                if (idx >= 0) cbxRolUsuario.SelectedIndex = idx;
                                else cbxRolUsuario.Text = puesto;
                            }

                            if (reader["FechaContratacion"] != DBNull.Value)
                            {
                                dtpFechaContratacion.Value = Convert.ToDateTime(reader["FechaContratacion"]);
                            }

                            txtSalario.Text = reader["Salario"] == DBNull.Value ? string.Empty : reader["Salario"].ToString();
                            chbActivo.Checked = reader["Activo"] != DBNull.Value && Convert.ToBoolean(reader["Activo"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos del empleado: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            // Validaciones mínimas
            if (string.IsNullOrWhiteSpace(txtNombreEmpleado.Text))
            {
                MessageBox.Show("Ingrese el nombre del empleado.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEmpleado.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellidoP.Text))
            {
                MessageBox.Show("Ingrese el apellido paterno del empleado.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidoP.Focus();
                return;
            }

            // Salario (opcional pero validar formato si se ingresó)
            decimal salario = 0;
            if (!string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                if (!decimal.TryParse(txtSalario.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out salario))
                {
                    MessageBox.Show("El salario debe ser un número válido (ej: 15000.50).", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalario.Focus();
                    txtSalario.SelectAll();
                    return;
                }
            }

            // string puesto = string.IsNullOrWhiteSpace(cbxRolPuesto.Text) ? (object)DBNull.Value.ToString() : cbxRolPuesto.Text;
            string puestoText = string.IsNullOrWhiteSpace(cbxRolUsuario.Text) ? string.Empty : cbxRolUsuario.Text.Trim();

            if (isInsert)
            {
                string query = @"INSERT INTO Empleado (Nombre, ApellidoP, ApellidoM, Telefono, Email, Puesto, FechaContratacion, Salario, Activo)
                                 VALUES (@Nombre, @ApellidoP, @ApellidoM, @Telefono, @Email, @Puesto, @FechaContratacion, @Salario, @Activo)";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", txtNombreEmpleado.Text.Trim());
                    command.Parameters.AddWithValue("@ApellidoP", txtApellidoP.Text.Trim());
                    command.Parameters.AddWithValue("@ApellidoM", txtApellidoM.Text.Trim());
                    command.Parameters.AddWithValue("@Telefono", txtTelefonoEmpleado.Text.Trim());
                    command.Parameters.AddWithValue("@Email", txtEmailEmpleado.Text.Trim());
                    command.Parameters.AddWithValue("@Puesto", string.IsNullOrWhiteSpace(puestoText) ? (object)DBNull.Value : puestoText);
                    command.Parameters.AddWithValue("@FechaContratacion", dtpFechaContratacion.Value.Date);
                    command.Parameters.AddWithValue("@Salario", string.IsNullOrWhiteSpace(txtSalario.Text) ? (object)DBNull.Value : salario);
                    command.Parameters.AddWithValue("@Activo", chbActivo.Checked);

                    try
                    {
                        connection.Open();
                        int rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Empleado agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                string query = @"UPDATE Empleado SET Nombre=@Nombre, ApellidoP=@ApellidoP, ApellidoM=@ApellidoM, Telefono=@Telefono, Email=@Email, Puesto=@Puesto, FechaContratacion=@FechaContratacion, Salario=@Salario, Activo=@Activo
                                 WHERE IDEmpleado = @ID";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", txtNombreEmpleado.Text.Trim());
                    command.Parameters.AddWithValue("@ApellidoP", txtApellidoP.Text.Trim());
                    command.Parameters.AddWithValue("@ApellidoM", txtApellidoM.Text.Trim());
                    command.Parameters.AddWithValue("@Telefono", txtTelefonoEmpleado.Text.Trim());
                    command.Parameters.AddWithValue("@Email", txtEmailEmpleado.Text.Trim());
                    command.Parameters.AddWithValue("@Puesto", string.IsNullOrWhiteSpace(puestoText) ? (object)DBNull.Value : puestoText);
                    command.Parameters.AddWithValue("@FechaContratacion", dtpFechaContratacion.Value.Date);
                    command.Parameters.AddWithValue("@Salario", string.IsNullOrWhiteSpace(txtSalario.Text) ? (object)DBNull.Value : salario);
                    command.Parameters.AddWithValue("@Activo", chbActivo.Checked);
                    command.Parameters.AddWithValue("@ID", idEmpleado);

                    try
                    {
                        connection.Open();
                        int rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el empleado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void label2_Click(object sender, EventArgs e)
        {
            // event handler required by designer; no action needed
        }

        private void cbxRolPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
