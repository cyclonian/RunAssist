using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PositiveChaos.RunAssist
{
    public partial class FrmOverlayLocation : Form
    {
        public FrmOverlayLocation()
        {
            InitializeComponent();
        }

        public Color OverlayForeColor
        {
            get { return lblColorPreview.ForeColor; }
        }
        public Color OverlayBackColor
        {
            get { return lblColorPreview.BackColor; }
        }

        public void SetColors(Color foreColor, Color backColor)
        {
            lblColorPreview.ForeColor = foreColor;
            lblColorPreview.BackColor = backColor;
        }

        private void btnForegroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = lblColorPreview.ForeColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                lblColorPreview.ForeColor = colorDialog.Color;
            }
        }

        private void btnBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = lblColorPreview.BackColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                lblColorPreview.BackColor = colorDialog.Color;
            }
        }
    }
}
