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
            get { return pnlPreview.ForeColor; }
        }
        public Color OverlayBackColor
        {
            get { return pnlPreview.BackColor; }
        }
        public bool OverlayShowPlayersZones
        {
            get { return checkShowPlayers.Checked; }
        }
        public Point OverlayLocation
        {
            get { return pnlPreview.PointToScreen(Location); }
        }
        public Size OverlaySize
        {
            get { return pnlPreview.Size; }
        }
        public void SetValues(Color foreColor, Color backColor, bool bOverlayShowPlayersZones, Point overlayLocation, Size overlaySize)
        {
            pnlPreview.ForeColor = foreColor;
            lblAssignments.ForeColor = foreColor;
            lblTimer.ForeColor = foreColor;

            pnlPreview.BackColor = backColor;
            checkShowPlayers.Checked = bOverlayShowPlayersZones;

            Location = new Point(
                overlayLocation.X - (SystemInformation.FrameBorderSize.Width * 2) - pnlPreview.Location.X,
                overlayLocation.Y - 4 - pnlPreview.Location.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height);
            Size = new Size(
                overlaySize.Width + 8 + (SystemInformation.FrameBorderSize.Width * 2),
                overlaySize.Height + 8 + pnlControl.Height + pnlSettings.Height + lblInstructions.Height + SystemInformation.CaptionHeight + (SystemInformation.FrameBorderSize.Height * 2));
            UpdatePreview();
        }
        protected void UpdatePreview()
        {
            lblTimer.Text = "00:00.000";
            lblAssignments.Visible = checkShowPlayers.Checked;
            if(checkShowPlayers.Checked)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("[Player 1 - Zone A]");
                sb.AppendLine("[Player 2 - Zone B]");
                sb.AppendLine("[Player 3 - Zone C]");
                sb.AppendLine("[Player 4 - Zone D]");
                sb.AppendLine("[Player 5 - Zone E]");
                sb.AppendLine("[Player 6 - Zone F]");
                sb.AppendLine("[Player 7 - Zone G]");
                sb.AppendLine("[Player 8 - Zone H]");
                lblAssignments.Text = sb.ToString();
            }
        }
        private void btnForegroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = pnlPreview.ForeColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                pnlPreview.ForeColor = colorDialog.Color;
            }
        }
        private void btnBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = pnlPreview.BackColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                pnlPreview.BackColor = colorDialog.Color;
            }
        }
        private void checkShowPlayers_CheckedChanged(object sender, EventArgs e)
        {
            lblAssignments.Visible = checkShowPlayers.Checked;
        }
    }
}
