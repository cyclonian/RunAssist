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
    public partial class FrmOptions : Form
    {
        public FrmOptions()
        {
            InitializeComponent();
        }
        public string GameRegion
        {
            get { return comboRegion.Text; }
        }
        public string GameRegionInclude
        {
            get { return checkIncludeRegion.Checked.ToString(); }
        }

        public string TimeZone
        {
            get { return tbTimezone.Text; }
        }

        public string NumPadding
        {
            get { return numPadding.Value.ToString(); }
        }

        public void ReadStateContent(RunAssistState state)
        {
            switch (state.Region)
            {
                case "Americas": comboRegion.SelectedIndex = 1; break;
                case "Europe": comboRegion.SelectedIndex = 2; break;
                case "Asia": comboRegion.SelectedIndex = 3; break;
                default: comboRegion.SelectedIndex = 0; break;
            }

            tbTimezone.Text = Helpers.GetSafeVal(ValType.TimeZone, state.TimeZone);
            numPadding.Value = state.NumPaddingVal;
            checkIncludeRegion.Checked = state.IncludeRegionVal;
        }
    }
}
