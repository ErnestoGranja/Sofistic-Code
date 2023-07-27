using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Control_VCF.UserControls;

namespace Control_VCF
{
  public partial class Form1 : Form
  {
    public static UserControl[] userControls = {
      new UC_MenuPrincipal(),
      new UC_Apartados()
    };
    public Form1()
    {
      InitializeComponent();

      foreach (UserControl uc in userControls)
      {
        panelContenedor.Controls.Add(uc);
      }
    }
  }
}
