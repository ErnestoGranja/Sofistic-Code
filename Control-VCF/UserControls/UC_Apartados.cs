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
  public partial class UC_Apartados : UserControl
  {
    public UC_Apartados()
    {
      InitializeComponent();
    }

    private void btnVolver_Click(object sender, EventArgs e)
    {
      Form1.userControls[0].BringToFront();
    }
  }
}
