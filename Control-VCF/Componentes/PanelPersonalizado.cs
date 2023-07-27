using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Prueba_lista
{
  class PanelPersonalizado : Panel
  {
    // Atributos
    private int borderRadius = 20;
    private Color borderColor = Color.White;
    private bool topLeft = true, topRight = true, bottomRight = true, bottomLeft = true;

    // Constructor
    public PanelPersonalizado()
    {
      this.Size = new Size(150, 40);
      this.BackColor = Color.FromArgb(0, 80, 73);
      this.ForeColor = Color.White;
      this.Resize += new EventHandler(Panel_Resize);
    }

    // Propiedades
    public int BorderRadius
    {
      get { return borderRadius; }
      set
      {
        borderRadius = value;
        this.Invalidate();
      }
    }

    public Color BorderColor
    {
      get { return borderColor; }
      set
      {
        borderColor = value;
        this.Invalidate();
      }
    }
    public bool TopLeft
    {
      get { return topLeft; }
      set
      {
        topLeft = value;
        this.Invalidate();
      }
    }
    public bool TopRight
    {
      get { return topRight; }
      set
      {
        topRight = value;
        this.Invalidate();
      }
    }
    public bool BottomRight
    {
      get { return bottomRight; }
      set
      {
        bottomRight = value;
        this.Invalidate();
      }
    }
    public bool BottomLeft
    {
      get { return bottomLeft; }
      set
      {
        bottomLeft = value;
        this.Invalidate();
      }
    }

    // Eventos
    private void Panel_Resize(object sender, EventArgs e)
    {
      if (borderRadius > this.Height)
        borderRadius = this.Height;
    }
    protected override void OnPaint(PaintEventArgs pevent)
    {
      base.OnPaint(pevent);
      Rectangle rectSurface = this.ClientRectangle;
      int smoothSize = 2;
      if (borderRadius > 2)
      {
        using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
        using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
        using (Pen penBorder = new Pen(borderColor))
        {
          pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
          this.Region = new Region(pathSurface);
          pevent.Graphics.DrawPath(penSurface, pathSurface);                  
          if (borderRadius > 4)
          {
            pevent.Graphics.SmoothingMode = SmoothingMode.None;
            pevent.Graphics.DrawPath(penBorder, pathSurface);
          }
        }
      }
      else 
      {
        pevent.Graphics.SmoothingMode = SmoothingMode.None;
        this.Region = new Region(rectSurface);
        using (Pen penBorder = new Pen(borderColor))
        {
          pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
        }
      }
    }

    // Metodos
    private GraphicsPath GetFigurePath(Rectangle rect, int radius)
    {
      GraphicsPath path = new GraphicsPath();
      int diameter = radius * 4;
      path.StartFigure();

      if (topLeft)
      {
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
      }
      else
      {
        path.AddLine(rect.X, rect.Y, rect.X + diameter, rect.Y);
      }

      if (topRight)
      {
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
      }
      else
      {
        path.AddLine(rect.Right - diameter, rect.Y, rect.Right, rect.Y);
      }

      if (bottomRight)
      {
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
      }
      else
      {
        path.AddLine(rect.Right, rect.Bottom - diameter, rect.Right, rect.Bottom);
      }

      if (bottomLeft)
      {
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
      }
      else
      {
        path.AddLine(rect.X + diameter, rect.Bottom, rect.X, rect.Bottom);
      }
      path.CloseFigure();
      return path;
    }
  }
}
