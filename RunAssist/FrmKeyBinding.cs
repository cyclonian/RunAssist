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

            cbToggleTimerKey.Items.AddRange(arrKeys);
            cbNextGameKey.Items.AddRange(arrKeys);
            cbCopyRolesKey.Items.AddRange(arrKeys);
            cbOverlayKey.Items.AddRange(arrKeys);
            cbAdvertKey.Items.AddRange(arrKeys);

            checkToggleTimer.Checked = true;
            checkNextGame.Checked = true;
            checkCopyRoles.Checked = true;
            checkOverlay.Checked = true;
            checkAdvert.Checked = true;

            cbToggleTimerKey.SelectedIndex = cbToggleTimerKey.Items.IndexOf("0");
            cbNextGameKey.SelectedIndex = cbNextGameKey.Items.IndexOf("=");
            cbCopyRolesKey.SelectedIndex = cbCopyRolesKey.Items.IndexOf("]");
            cbOverlayKey.SelectedIndex = cbOverlayKey.Items.IndexOf("/");
            cbAdvertKey.SelectedIndex = cbAdvertKey.Items.IndexOf("[");

            checkToggleTimerCtrl.Checked = true;
            checkToggleTimerAlt.Checked = false;
            checkNextGameCtrl.Checked = true;
            checkNextGameAlt.Checked = false;
            checkCopyRolesCtrl.Checked = true;
            checkCopyRolesAlt.Checked = false;
            checkOverlayCtrl.Checked = true;
            checkOverlayAlt.Checked = false;
            checkAdvertCtrl.Checked = true;
            checkAdvertAlt.Checked = false;
        }

        public void CheckEnabled()
        {
            cbToggleTimerKey.Enabled = checkToggleTimerCtrl.Enabled = checkToggleTimerAlt.Enabled = checkToggleTimer.Checked;
            cbNextGameKey.Enabled = checkNextGameCtrl.Enabled = checkNextGameAlt.Enabled = checkNextGame.Checked;
            cbCopyRolesKey.Enabled = checkCopyRolesCtrl.Enabled = checkCopyRolesAlt.Enabled = checkCopyRoles.Checked;
            cbOverlayKey.Enabled = checkOverlayCtrl.Enabled = checkOverlayAlt.Enabled = checkOverlay.Checked;
            cbAdvertKey.Enabled = checkAdvertCtrl.Enabled = checkAdvertAlt.Enabled = checkAdvert.Checked;
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
            SetState(state.KeybindToggle, checkToggleTimer, cbToggleTimerKey, checkToggleTimerCtrl, checkToggleTimerAlt);
            SetState(state.KeybindNextGame, checkNextGame, cbNextGameKey, checkNextGameCtrl, checkNextGameAlt);
            SetState(state.KeybindCopyRoles, checkCopyRoles, cbCopyRolesKey, checkCopyRolesCtrl, checkCopyRolesAlt);
            SetState(state.KeybindOverlay, checkOverlay, cbOverlayKey, checkOverlayCtrl, checkOverlayAlt);
            SetState(state.KeybindAdvert, checkAdvert, cbAdvertKey, checkAdvertCtrl, checkAdvertAlt);
        }

        protected string GetKey(ComboBox cb)
        {
            string szKey = string.Empty;
            try
            {
                if (cb != null && cb.SelectedIndex >= 0)
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
                case RunAssistKey.Toggle:
                    GetSelection(checkToggleTimer, checkToggleTimerCtrl, checkToggleTimerAlt, cbToggleTimerKey, ref modifiers, ref key, ref keyCombo);
                    break;
                case RunAssistKey.NextGame:
                    GetSelection(checkNextGame, checkNextGameCtrl, checkNextGameAlt, cbNextGameKey, ref modifiers, ref key, ref keyCombo);
                    break;
                case RunAssistKey.CopyRoles:
                    GetSelection(checkCopyRoles, checkCopyRolesCtrl, checkCopyRolesAlt, cbCopyRolesKey, ref modifiers, ref key, ref keyCombo);
                    break;
                case RunAssistKey.Overlay:
                    GetSelection(checkOverlay, checkOverlayCtrl, checkOverlayAlt, cbOverlayKey, ref modifiers, ref key, ref keyCombo);
                    break;
                case RunAssistKey.Advert:
                    GetSelection(checkAdvert, checkAdvertCtrl, checkAdvertAlt, cbAdvertKey, ref modifiers, ref key, ref keyCombo);
                    break;
                default: break;
            }

            return keyCombo;
        }

        private void GetSelection(CheckBox check, CheckBox checkCtrl, CheckBox checkAlt, ComboBox cbKey, ref RunAssist.ModifierKeys modifiers, ref Keys key, ref KeyCombo keyCombo)
        {
            if (check.Checked)
            {
                if (checkCtrl.Checked)
                    modifiers |= RunAssist.ModifierKeys.Control;
                if (checkAlt.Checked)
                    modifiers |= RunAssist.ModifierKeys.Alt;
                key = Enum.Parse<Keys>(GetKey(cbKey));
                keyCombo = new KeyCombo(modifiers, key);
            }
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            CheckEnabled();
        }
    }
}
