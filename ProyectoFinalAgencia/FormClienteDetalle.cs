using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ProyectoFinalAgencia
{
    public partial class FormClienteDetalle : Form
    {
        bool isInsert = false;
        int idCliente;
        private const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=AGENCIA;Integrated Security=True;TrustServerCertificate=True;";
        public FormClienteDetalle()
        {
            InitializeComponent();
            this.Text = "Agregar Nuevo Cliente";
            this.isInsert = true;
        }
        public FormClienteDetalle(int id)
        {
            InitializeComponent();
            this.idCliente = id;
            this.Text = "Modificar Cliente";
            this.isInsert = false;
            CargarDatosCliente();
        }



        private void CargarDatosCliente()
        {
            // Consulta para obtener todos los datos del cliente por su ID
            string query = "SELECT Nombre, ApellidoP, ApellidoM, Telefono, Email, RFC, Direccion FROM Cliente WHERE IDCliente = @ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", idCliente);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Llenar los TextBoxes con los datos de la base de datos
                            txtNombreCliente.Text = reader["Nombre"].ToString();
                            txtApellidoP.Text = reader["ApellidoP"].ToString();
                            txtApellidoM.Text = reader["ApellidoM"].ToString();
                            txtTelefono.Text = reader["Telefono"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtRFC.Text = reader["RFC"].ToString();
                            txtDireccion.Text = reader["Direccion"].ToString();
                            // ... Llenar otros campos
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos del cliente: {ex.Message}", "Error de BD");
                }
            }
        }


        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (isInsert)
            {
                string query = @"INSERT INTO Cliente (Nombre, ApellidoP, ApellidoM, Telefono, Email, RFC, Direccion) 
                         VALUES (@Nombre, @ApellidoP, @ApellidoM, @Telefono, @Email, @RFC, @Direccion)";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", txtNombreCliente.Text);
                    command.Parameters.AddWithValue("@ApellidoP", txtApellidoP.Text);
                    command.Parameters.AddWithValue("@ApellidoM", txtApellidoM.Text);
                    command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@RFC", txtRFC.Text);
                    command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar el cliente: {ex.Message}", "Error de Base de Datos");
                    }
                }
            }
            else
            {
                // UPDATE
                string query = @"UPDATE Cliente SET Nombre = @Nombre, ApellidoP = @ApellidoP, ApellidoM = @ApellidoM, Telefono = @Telefono, Email = @Email, RFC = @RFC, Direccion = @Direccion
                                 WHERE IDCliente = @ID";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", txtNombreCliente.Text);
                    command.Parameters.AddWithValue("@ApellidoP", txtApellidoP.Text);
                    command.Parameters.AddWithValue("@ApellidoM", txtApellidoM.Text);
                    command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@RFC", txtRFC.Text);
                    command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    command.Parameters.AddWithValue("@ID", idCliente);

                    try
                    {
                        connection.Open();
                        int rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el cliente o no se actualizaron los datos.", "Aviso");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar el cliente: {ex.Message}", "Error de Base de Datos");
                    }
                }
            }
        }


       
    }
}
