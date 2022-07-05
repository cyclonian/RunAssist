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
            string[] arrKeys = new string[] { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=", "[", "]", "/", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12" };

            cbStartTimerKey.Items.AddRange(arrKeys);
            cbStopTimerKey.Items.AddRange(arrKeys);
            cbNextGameKey.Items.AddRange(arrKeys);
            cbCopyRolesKey.Items.AddRange(arrKeys);
            cbOverlayKey.Items.AddRange(arrKeys);

            checkStartTimer.Checked = true;
            checkStopTimer.Checked = true;
            checkNextGame.Checked = true;
            checkCopyRoles.Checked = true;
            checkOverlay.Checked = true;

            cbStartTimerKey.SelectedIndex = cbStartTimerKey.Items.IndexOf("0");
            cbStopTimerKey.SelectedIndex = cbStopTimerKey.Items.IndexOf("-");
            cbNextGameKey.SelectedIndex = cbNextGameKey.Items.IndexOf("=");
            cbCopyRolesKey.SelectedIndex = cbCopyRolesKey.Items.IndexOf("]");
            cbOverlayKey.SelectedIndex = cbOverlayKey.Items.IndexOf("/");

            checkStartTimerCtrl.Checked = true;
            checkStartTimerAlt.Checked = false;
            checkStopTimerCtrl.Checked = true;
            checkStopTimerAlt.Checked = false;
            checkNextGameCtrl.Checked = true;
            checkNextGameAlt.Checked = false;
            checkCopyRolesCtrl.Checked = true;
            checkCopyRolesAlt.Checked = false;
            checkOverlayCtrl.Checked = true;
            checkOverlayAlt.Checked = false;
        }

        public void CheckEnabled()
        {
            cbStartTimerKey.Enabled = checkStartTimerCtrl.Enabled = checkStartTimerAlt.Enabled = checkStartTimer.Checked;
            cbStopTimerKey.Enabled = checkStopTimerCtrl.Enabled = checkStopTimerAlt.Enabled = checkStopTimer.Checked;
            cbNextGameKey.Enabled = checkNextGameCtrl.Enabled = checkNextGameAlt.Enabled = checkNextGame.Checked;
            cbCopyRolesKey.Enabled = checkCopyRolesCtrl.Enabled = checkCopyRolesAlt.Enabled = checkCopyRoles.Checked;
            cbOverlayKey.Enabled = checkOverlayCtrl.Enabled = checkOverlayAlt.Enabled = checkOverlay.Checked;
        }

        protected void SetState(KeyCombo kc, CheckBox check, ComboBox cbKey, CheckBox checkCtrl, CheckBox checkAlt)
        {
            if (kc == null || kc.Key == Keys.None)
            {
                check.Checked = false;
                cbKey.SelectedIndex = 0;
                checkCtrl.Checked = false;
                checkAlt.Checked = false;
            }
            else
            {
                check.Checked = true;
                cbKey.SelectedIndex = cbKey.Items.IndexOf(GetComboValue(kc.Key));
                checkCtrl.Checked = (kc.Modifiers & RunAssist.ModifierKeys.Control) == RunAssist.ModifierKeys.Control;
                checkAlt.Checked = (kc.Modifiers & RunAssist.ModifierKeys.Alt) == RunAssist.ModifierKeys.Alt;
            }
        }

        public void SetState(RunAssistState state)
        {
            SetState(state.KeybindStart, checkStartTimer, cbStartTimerKey, checkStartTimerCtrl, checkStartTimerAlt);
            SetState(state.KeybindStop, checkStopTimer, cbStopTimerKey, checkStopTimerCtrl, checkStopTimerAlt);
            SetState(state.KeybindNextGame, checkNextGame, cbNextGameKey, checkNextGameCtrl, checkNextGameAlt);
            SetState(state.KeybindCopyRoles, checkCopyRoles, cbCopyRolesKey, checkCopyRolesCtrl, checkCopyRolesAlt);
            SetState(state.KeybindOverlay, checkOverlay, cbOverlayKey, checkOverlayCtrl, checkOverlayAlt);
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
                    else if(szKey == "-")
                    {
                        szKey = "OemMinus";
                    }
                    else if(szKey == "=")
                    {
                        szKey = "Oemplus";
                    }
                    else if (szKey == "[")
                    {
                        szKey = "Oem4";
                    }
                    else if (szKey == "]")
                    {
                        szKey = "Oem6";
                    }
                    else if (szKey == "/")
                    {
                        szKey = "OemQuestion";
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
                    else if (szValue == "OemMinus")
                    {
                        szValue = "-";
                    }
                    else if (szValue == "Oemplus")
                    {
                        szValue = "=";
                    }
                    else if (szValue == "Oem4" || szValue == "OemOpenBrackets")
                    {
                        szValue = "[";
                    }
                    else if (szValue == "Oem6" || szValue == "OemCloseBrackets")
                    {
                        szValue = "]";
                    }
                    else if (szValue == "OemQuestion")
                    {
                        szValue = "/";
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
                case RunAssistKey.CopyRoles:
                    if (checkCopyRoles.Checked)
                    {
                        if (checkCopyRolesCtrl.Checked)
                            modifiers |= RunAssist.ModifierKeys.Control;
                        if (checkCopyRolesAlt.Checked)
                            modifiers |= RunAssist.ModifierKeys.Alt;
                        key = Enum.Parse<Keys>(GetKey(cbCopyRolesKey));
                        keyCombo = new KeyCombo(modifiers, key);
                    }
                    break;
                case RunAssistKey.Overlay:
                    if (checkOverlay.Checked)
                    {
                        if (checkOverlayCtrl.Checked)
                            modifiers |= RunAssist.ModifierKeys.Control;
                        if (checkOverlayAlt.Checked)
                            modifiers |= RunAssist.ModifierKeys.Alt;
                        key = Enum.Parse<Keys>(GetKey(cbOverlayKey));
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
