using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PositiveChaos.RunAssist
{
    public partial class FrmOverlay : Form
    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public FrmOverlay()
        {
            InitializeComponent();
        }

        private void FrmOverlay_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        public void SetValues(Color foreColor, Color backColor, bool bOverlayShowPlayersZones)
        {
            lblTimer.ForeColor = foreColor;
            lblAssignments.ForeColor = foreColor;
            BackColor = backColor;
            lblAssignments.Visible = bOverlayShowPlayersZones;
        }

        public void SetContent(string szTimer, string szAssignments)
        {
            lblTimer.Text = szTimer;
            lblAssignments.Text = szAssignments;
        }
        public void SetContent(string szTimer)
        {
            lblTimer.Text = szTimer;
        }
    }
}
