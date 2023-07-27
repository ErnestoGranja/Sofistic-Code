using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_VCF.UserControls
{
  public partial class UC_MenuPrincipal : UserControl
  {
    public UC_MenuPrincipal()
    {
      InitializeComponent();
    }

    private void panelVender_Click(object sender, EventArgs e)
    {
      Form1.userControls[1].BringToFront();
    }

    private void panelComprar_Click(object sender, EventArgs e)
    {
      Form1.userControls[1].BringToFront();
    }

    private void panelPagos_Click(object sender, EventArgs e)
    {
      Form1.userControls[1].BringToFront();
    }

    private void panelFinanzas_Click(object sender, EventArgs e)
    {
      Form1.userControls[1].BringToFront();
    }

    private void panelRegistrar_Click(object sender, EventArgs e)
    {
      Form1.userControls[1].BringToFront();
    }

    private void pbContraseña_Click(object sender, EventArgs e)
    {
      pbContraseña.Image = Image.FromFile($"..\\..\\Diseños del programa\\Imágenes\\Componentes\\{(txtContraseña.UseSystemPasswordChar ? "Ver-Contraseña.png" : "Ocultar-contraseña.png")}"); 
      txtContraseña.UseSystemPasswordChar = !txtContraseña.UseSystemPasswordChar;
    }

    private void btnIniciarSesion_Click(object sender, EventArgs e)
    {
      if (btnIniciarSesion.Text.Equals("Cerrar sesión"))
      {
        cambiarPanelAdministrador(false);
        return;
      }

      string connectionString = "server=localhost;database=controlvcf;user=root;password=123456789;";
      MySqlConnection connection = new MySqlConnection(connectionString);

      try
      {
        connection.Open();

        string query = "SELECT contraseña FROM usuarios;";
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
          if (txtContraseña.Text.Equals(reader.GetString(0)))
          {
            MessageBox.Show("Contraseña correcta");
            cambiarPanelAdministrador(true);
          }
          else
          {
            MessageBox.Show("Contraseña ultra mal, la verdad me desepcionaste");
          }
        }

        reader.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
      }
      finally
      {
        connection.Close();
      }
    }

    public void cambiarPanelAdministrador(bool sesionIniciada)
    {
      pbUsuario.Image = Image.FromFile($"..\\..\\Diseños del programa\\Imágenes\\Apartados\\Apartados principales\\{(sesionIniciada ? "imgAdministrador.png" : "imgUsuario.png")}");
      btnIniciarSesion.Text = sesionIniciada ? "Cerrar sesión" : "Iniciar sesión";
      panelContraseña.Visible = !sesionIniciada;
      txtContraseña.Text = "";
      lblSesionIniciada.Location = new Point(27, 371);
      lblSesionIniciada.Visible = sesionIniciada;
    }
  }
}
