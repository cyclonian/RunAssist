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
    public partial class FrmKeyBinding : Form
    {
        public FrmKeyBinding()
        {
            InitializeComponent();

            checkStartTimer.Checked = true;
            checkStopTimer.Checked = true;
            checkNextGame.Checked = true;

            cbStartTimerKey.SelectedIndex = cbStartTimerKey.Items.IndexOf("0");
            cbStopTimerKey.SelectedIndex = cbStopTimerKey.Items.IndexOf("-");
            cbNextGameKey.SelectedIndex = cbNextGameKey.Items.IndexOf("=");

            checkStartTimerCtrl.Checked = true;
            checkStartTimerAlt.Checked = false;
            checkStopTimerCtrl.Checked = true;
            checkStopTimerAlt.Checked = false;
            checkNextGameCtrl.Checked = true;
            checkNextGameAlt.Checked = false;
        }

        public void CheckEnabled()
        {
            cbStartTimerKey.Enabled = checkStartTimerCtrl.Enabled = checkStartTimerAlt.Enabled = checkStartTimer.Checked;
            cbStopTimerKey.Enabled = checkStopTimerCtrl.Enabled = checkStopTimerAlt.Enabled = checkStopTimer.Checked;
            cbNextGameKey.Enabled = checkNextGameCtrl.Enabled = checkNextGameAlt.Enabled = checkNextGame.Checked;
        }

        public void SetState(RunAssistState state)
        {
            if (state.KeybindStart == null || state.KeybindStart.Key == Keys.None)
            {
                checkStartTimer.Checked = false;
                cbStartTimerKey.SelectedIndex = 0;
                checkStartTimerCtrl.Checked = false;
                checkStartTimerAlt.Checked = false;
            }
            else
            {
                checkStartTimer.Checked = true;
                cbStartTimerKey.SelectedIndex = cbStartTimerKey.Items.IndexOf(GetComboValue(state.KeybindStart.Key));
                checkStartTimerCtrl.Checked = (state.KeybindStart.Modifiers & RunAssist.ModifierKeys.Control) == RunAssist.ModifierKeys.Control;
                checkStartTimerAlt.Checked = (state.KeybindStart.Modifiers & RunAssist.ModifierKeys.Alt) == RunAssist.ModifierKeys.Alt;
            }

            if (state.KeybindStop == null || state.KeybindStop.Key == Keys.None)
            {
                checkStopTimer.Checked = false;
                cbStopTimerKey.SelectedIndex = 0;
                checkStopTimerCtrl.Checked = false;
                checkStopTimerAlt.Checked = false;
            }
            else
            {
                checkStopTimer.Checked = true;
                cbStopTimerKey.SelectedIndex = cbStopTimerKey.Items.IndexOf(GetComboValue(state.KeybindStop.Key));
                checkStopTimerCtrl.Checked = (state.KeybindStop.Modifiers & RunAssist.ModifierKeys.Control) == RunAssist.ModifierKeys.Control;
                checkStopTimerAlt.Checked = (state.KeybindStop.Modifiers & RunAssist.ModifierKeys.Alt) == RunAssist.ModifierKeys.Alt;
            }

            if (state.KeybindNextGame == null || state.KeybindNextGame.Key == Keys.None)
            {
                checkNextGame.Checked = false;
                cbNextGameKey.SelectedIndex = 0;
                checkNextGameCtrl.Checked = false;
                checkNextGameAlt.Checked = false;
            }
            else
            {
                checkNextGame.Checked = true;
                cbNextGameKey.SelectedIndex = cbNextGameKey.Items.IndexOf(GetComboValue(state.KeybindNextGame.Key));
                checkNextGameCtrl.Checked = (state.KeybindNextGame.Modifiers & RunAssist.ModifierKeys.Control) == RunAssist.ModifierKeys.Control;
                checkNextGameAlt.Checked = (state.KeybindNextGame.Modifiers & RunAssist.ModifierKeys.Alt) == RunAssist.ModifierKeys.Alt;
            }
        }

        protected string GetKey(ComboBox cb)
        {
            string szKey = string.Empty;
            try
            {
                if (cb != null)
                {
                    szKey = cb.Items[cb.SelectedIndex].ToString();
                    string szNumeric = "0123456789";
                    if (szNumeric.Contains(szKey))
                        szKey = "D" + szKey;
                    if(szKey == "-")
                    {
                        szKey = "OemMinus";
                    }
                    if(szKey == "=")
                    {
                        szKey = "Oemplus";
                    }
                }
            }
            catch
            {
                szKey = string.Empty;
            }

            if (szKey == null)
                szKey = string.Empty;
            return szKey;
        }

        protected string GetComboValue(Keys key)
        {
            string szValue = string.Empty;
            try
            {
                if (key != Keys.None)
                {
                    szValue = key.ToString();
                    List<string> numeric = new List<string>() { "D0", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9" };
                    if (numeric.Contains(szValue))
                        szValue = szValue.Substring(1);
                    if (szValue == "OemMinus")
                    {
                        szValue = "-";
                    }
                    if (szValue == "Oemplus")
                    {
                        szValue = "=";
                    }
                }
            }
            catch
            {
                szValue = string.Empty;
            }

            if (szValue == null)
                szValue = string.Empty;
            return szValue;
        }

        public KeyCombo GetSelection(RunAssistKey runAssistKey)
        {
            RunAssist.ModifierKeys modifiers = RunAssist.ModifierKeys.None;
            Keys key = Keys.None;
            KeyCombo keyCombo = new KeyCombo();

            switch (runAssistKey)
            {
                case RunAssistKey.Start:
                    if (checkStartTimer.Checked)
                    {
                        if (checkStartTimerCtrl.Checked)
                            modifiers |= RunAssist.ModifierKeys.Control;
                        if (checkStartTimerAlt.Checked)
                            modifiers |= RunAssist.ModifierKeys.Alt;
                        key = Enum.Parse<Keys>(GetKey(cbStartTimerKey));
                    }
                    keyCombo = new KeyCombo(modifiers, key);
                    break;
                case RunAssistKey.Stop:
                    if (checkStopTimer.Checked)
                    {
                        if (checkStopTimerCtrl.Checked)
                            modifiers |= RunAssist.ModifierKeys.Control;
                        if (checkStopTimerAlt.Checked)
                            modifiers |= RunAssist.ModifierKeys.Alt;
                        key = Enum.Parse<Keys>(GetKey(cbStopTimerKey));
                        keyCombo = new KeyCombo(modifiers, key);
                    }
                    break;
                case RunAssistKey.NextGame:
                    if (checkNextGame.Checked)
                    {
                        if (checkNextGameCtrl.Checked)
                            modifiers |= RunAssist.ModifierKeys.Control;
                        if (checkNextGameAlt.Checked)
                            modifiers |= RunAssist.ModifierKeys.Alt;
                        key = Enum.Parse<Keys>(GetKey(cbNextGameKey));
                        keyCombo = new KeyCombo(modifiers, key);
                    }
                    break;
                default: break;
            }

            return keyCombo;
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            CheckEnabled();
        }
    }
}
