namespace ProyectoFinalAgencia;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

public partial class Form1 : Form
{
    private const string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=AGENCIA;Integrated Security=True;TrustServerCertificate=True;";

    public Form1()
    {
        InitializeComponent();
    }

    private void FormMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
    {
        Application.Exit(); 
    }

    private void btnIniciarSesion_Click(object sender, EventArgs e)
    {
        string usuarioIngresado = txtUsuario.Text.Trim();
        string contrasenaIngresada = txtContrasena.Text;


        byte[] hashGuardadoBytes = null;

        string sql = "SELECT PasswordHash FROM Usuario WHERE Username = @User";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@User", usuarioIngresado);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        hashGuardadoBytes = (byte[])result;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la BD: " + ex.Message, "Error");
                    return;
                }
            }
        }

        if (hashGuardadoBytes != null) 
        {
            byte[] hashGeneradoBytes = HashUtility.GenerarHashBytes(contrasenaIngresada);

            if (hashGeneradoBytes.SequenceEqual(hashGuardadoBytes))
            {
                MessageBox.Show("¡Acceso Concedido!", "Bienvenido");

                FormMenuPrincipal menuPrincipal = new FormMenuPrincipal();

                menuPrincipal.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso Denegado");
            }
        }
        else 
        {
            MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso Denegado");
        }


    }

}