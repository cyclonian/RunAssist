using System.Xml;
using System.Xml.Serialization;

namespace PositiveChaos.RunAssist
{
    public partial class FrmMain : Form
    {
        protected RunAssistState _state = new RunAssistState();
        CountdownTimer _timer = new CountdownTimer();

        public FrmMain()
        {
            FileInfo fiExe = new FileInfo(Application.ExecutablePath);
            if (fiExe.Directory != null && fiExe.Directory.Exists)
                _state.RootPath = fiExe.Directory.FullName;

            InitializeComponent();

            _state = DeserializeFromFile();

            ReadStateContent(_state);

            if(_state.Zones.Count == 0)
                _state.Zones.AddRange(new string[] { "Pits", "CS", "Chaos Sanctuary", "WSK", "Baal", "Pindle", "Shenk", "LK", "Cows", "Stony Tombs", "Trav" });
            if (_state.Notes.Count == 0)
                _state.Notes.Add("{0} minute timed runs");

            SetListSources();

            _timer.TimeChanged += () => lblTimer.Text = _timer.TimeLeftMsStr;
            _timer.CountdownFinished += () => HandleTimerFinished();
            _timer.CountdownWarning += () => HandleWarningEvent();
            _timer.CountdownWarning2 += () => HandleWarning2Event();
            _timer.StepMs = 77;
            ResetTimer();
        }

        protected void HandleTimerFinished()
        {
            SaveState();

            _timer.Reset();
            lblTimer.Text = _timer.TimeLeftMsStr;
            btnIncriment.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = true;
            btnIncriment.Enabled = true;

            using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"audio_finish.wav"))
            {
                player.Play();
            }

            tssMainLabel.Text = "Run finished";
        }

        protected void HandleWarningEvent()
        {
            using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"audio_warning.wav"))
            {
                player.Play();
            }
            Clipboard.SetText(string.Format(tbWarningMsg.Text, tbWarningTime.Text));
        }

        protected void HandleWarning2Event()
        {
            using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"audio_warning.wav"))
            {
                player.Play();
            }
            Clipboard.SetText(string.Format(tbWarningMsg2.Text, tbWarningTime2.Text));
        }

        protected string SerializeToXml<T>(T source)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                using (XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented })
                {
                    serializer.Serialize(xmlWriter, source);
                    return stringWriter.ToString();
                }
            }
        }

        protected void SetListSources()
        {
            AutoCompleteStringCollection playerNames = new AutoCompleteStringCollection();
            playerNames.AddRange(_state.PlayerNames.ToArray());

            comboPlayerName1.Items.Clear();
            comboPlayerName1.Items.AddRange(_state.PlayerNames.ToArray());
            comboPlayerName1.AutoCompleteCustomSource = playerNames;

            comboPlayerName2.Items.Clear();
            comboPlayerName2.Items.AddRange(_state.PlayerNames.ToArray());
            comboPlayerName2.AutoCompleteCustomSource = playerNames;

            comboPlayerName3.Items.Clear();
            comboPlayerName3.Items.AddRange(_state.PlayerNames.ToArray());
            comboPlayerName3.AutoCompleteCustomSource = playerNames;

            comboPlayerName4.Items.Clear();
            comboPlayerName4.Items.AddRange(_state.PlayerNames.ToArray());
            comboPlayerName4.AutoCompleteCustomSource = playerNames;

            comboPlayerName5.Items.Clear();
            comboPlayerName5.Items.AddRange(_state.PlayerNames.ToArray());
            comboPlayerName5.AutoCompleteCustomSource = playerNames;

            comboPlayerName6.Items.Clear();
            comboPlayerName6.Items.AddRange(_state.PlayerNames.ToArray());
            comboPlayerName6.AutoCompleteCustomSource = playerNames;

            comboPlayerName7.Items.Clear();
            comboPlayerName7.Items.AddRange(_state.PlayerNames.ToArray());
            comboPlayerName7.AutoCompleteCustomSource = playerNames;

            comboPlayerName8.Items.Clear();
            comboPlayerName8.Items.AddRange(_state.PlayerNames.ToArray());
            comboPlayerName8.AutoCompleteCustomSource = playerNames;

            AutoCompleteStringCollection zones = new AutoCompleteStringCollection();
            zones.AddRange(_state.Zones.ToArray());
            comboPlayerZones1.Items.Clear();
            comboPlayerZones1.Items.AddRange(_state.Zones.ToArray());
            comboPlayerZones1.AutoCompleteCustomSource = zones;

            comboPlayerZones2.Items.Clear();
            comboPlayerZones2.Items.AddRange(_state.Zones.ToArray());
            comboPlayerZones2.AutoCompleteCustomSource = zones;

            comboPlayerZones3.Items.Clear();
            comboPlayerZones3.Items.AddRange(_state.Zones.ToArray());
            comboPlayerZones3.AutoCompleteCustomSource = zones;

            comboPlayerZones4.Items.Clear();
            comboPlayerZones4.Items.AddRange(_state.Zones.ToArray());
            comboPlayerZones4.AutoCompleteCustomSource = zones;

            comboPlayerZones5.Items.Clear();
            comboPlayerZones5.Items.AddRange(_state.Zones.ToArray());
            comboPlayerZones5.AutoCompleteCustomSource = zones;

            comboPlayerZones6.Items.Clear();
            comboPlayerZones6.Items.AddRange(_state.Zones.ToArray());
            comboPlayerZones6.AutoCompleteCustomSource = zones;

            comboPlayerZones7.Items.Clear();
            comboPlayerZones7.Items.AddRange(_state.Zones.ToArray());
            comboPlayerZones7.AutoCompleteCustomSource = zones;

            comboPlayerZones8.Items.Clear();
            comboPlayerZones8.Items.AddRange(_state.Zones.ToArray());
            comboPlayerZones8.AutoCompleteCustomSource = zones;

            AutoCompleteStringCollection gameNames = new AutoCompleteStringCollection();
            comboGameName.Items.Clear();
            comboGameName.Items.AddRange(_state.GameNames.ToArray());
            gameNames.AddRange(_state.GameNames.ToArray());
            comboGameName.AutoCompleteCustomSource = gameNames;

            AutoCompleteStringCollection notes = new AutoCompleteStringCollection();
            comboNote.Items.Clear();
            comboNote.Items.AddRange(_state.Notes.ToArray());
            notes.AddRange(_state.Notes.ToArray());
            comboNote.AutoCompleteCustomSource = notes;
        }

        protected RunAssistState DeserializeFromFile()
        {
            string szRootPath = _state.RootPath;
            string szStateFileName = _state.StateFileName;
            FileInfo fiXml = new FileInfo(Path.Combine(szRootPath, szStateFileName));
            RunAssistState state = _state;

            if (fiXml.Exists)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(fiXml.FullName))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(RunAssistState));
                        state = serializer.Deserialize(reader) as RunAssistState;
                        reader.Close();
                    }

                    if (state != null)
                    {
                        state.RootPath = szRootPath;
                        state.StateFileName = szStateFileName;
                    }
                }
                catch
                {
                    state = _state;
                }
            }

            return state;
        }

        protected void ReadPlayerInfo(RunAssistState state, ComboBox comboName, ComboBox comboZones, int nIndex)
        {
            if (state == null || nIndex > state.Limit)
                return;

            if (state.Players[nIndex] != null)
            {
                comboName.Text = state.Players[nIndex].Name;
                comboZones.Text = state.Players[nIndex].Zones;
            }
        }


        protected void SetPlayerInfo(RunAssistState state, ComboBox comboName, ComboBox comboZones, int nIndex)
        {
            if(state == null || nIndex > state.Limit)
                return;

            if (state.Players[nIndex] == null)
                state.Players[nIndex] = new PlayerInfo();

            state.Players[nIndex].Name = comboName.Text;
            state.Players[nIndex].Zones = comboZones.Text;
        }

        protected void ResetValues()
        {
            comboPlayerName1.Text = comboPlayerName2.Text = comboPlayerName3.Text = comboPlayerName4.Text = comboPlayerName5.Text = comboPlayerName6.Text = comboPlayerName7.Text = comboPlayerName8.Text = string.Empty;
            comboPlayerZones1.Text = comboPlayerZones2.Text = comboPlayerZones3.Text = comboPlayerZones4.Text = comboPlayerZones5.Text = comboPlayerZones6.Text = comboPlayerZones7.Text = comboPlayerZones8.Text = string.Empty;
            comboGameName.Text = string.Empty;
            tbPassword.Text = string.Empty;
            numGameNumber.Value = 1;
        }

        protected void ReadStateContent(RunAssistState state)
        {
            ReadPlayerInfo(state, comboPlayerName1, comboPlayerZones1, 0);
            ReadPlayerInfo(state, comboPlayerName2, comboPlayerZones2, 1);
            ReadPlayerInfo(state, comboPlayerName3, comboPlayerZones3, 2);
            ReadPlayerInfo(state, comboPlayerName4, comboPlayerZones4, 3);
            ReadPlayerInfo(state, comboPlayerName5, comboPlayerZones5, 4);
            ReadPlayerInfo(state, comboPlayerName6, comboPlayerZones6, 5);
            ReadPlayerInfo(state, comboPlayerName7, comboPlayerZones7, 6);
            ReadPlayerInfo(state, comboPlayerName8, comboPlayerZones8, 7);

            switch(state.Region)
            {
                case "Americas": comboRegion.SelectedIndex = 1; break;
                case "Europe": comboRegion.SelectedIndex = 2; break;
                case "Asia": comboRegion.SelectedIndex = 3; break;
                default: comboRegion.SelectedIndex = 0; break;
            }

            comboGameName.Text = state.GameName;
            int nGameNumber = 0;
            if(int.TryParse(state.GameNumber, out nGameNumber))
                numGameNumber.Value = nGameNumber;
            tbPassword.Text = state.Password;
            comboNote.Text = state.Note;
            tbRunTime.Text = state.RunTime;
            tbWarningTime.Text = state.WarningTime;
            tbWarningTime2.Text = state.WarningTime2;
            tbWarningMsg.Text = state.WarningMessage;
            tbWarningMsg2.Text = state.WarningMessage2;
            tbTimezone.Text = state.TimeZone;
            decimal dNumPadding = 0;
            if(!decimal.TryParse(state.NumPadding, out dNumPadding))
                dNumPadding = 2;
            numPadding.Value = dNumPadding;
        }

        protected void PerformCurrentToClipboard()
        {
            Clipboard.SetText(_state.ToString());
        }

        protected void SaveState()
        {
            SetPlayerInfo(_state, comboPlayerName1, comboPlayerZones1, 0);
            SetPlayerInfo(_state, comboPlayerName2, comboPlayerZones2, 1);
            SetPlayerInfo(_state, comboPlayerName3, comboPlayerZones3, 2);
            SetPlayerInfo(_state, comboPlayerName4, comboPlayerZones4, 3);
            SetPlayerInfo(_state, comboPlayerName5, comboPlayerZones5, 4);
            SetPlayerInfo(_state, comboPlayerName6, comboPlayerZones6, 5);
            SetPlayerInfo(_state, comboPlayerName7, comboPlayerZones7, 6);
            SetPlayerInfo(_state, comboPlayerName8, comboPlayerZones8, 7);

            AddPlayerName(comboPlayerName1);
            AddPlayerName(comboPlayerName2);
            AddPlayerName(comboPlayerName3);
            AddPlayerName(comboPlayerName4);
            AddPlayerName(comboPlayerName5);
            AddPlayerName(comboPlayerName6);
            AddPlayerName(comboPlayerName7);
            AddPlayerName(comboPlayerName8);

            AddZone(comboPlayerZones1);
            AddZone(comboPlayerZones2);
            AddZone(comboPlayerZones3);
            AddZone(comboPlayerZones4);
            AddZone(comboPlayerZones5);
            AddZone(comboPlayerZones6);
            AddZone(comboPlayerZones7);
            AddZone(comboPlayerZones8);

            _state.GameName = comboGameName.Text;
            AddGameName(comboGameName);
            _state.GameNumber = numGameNumber.Value.ToString();
            _state.Password = tbPassword.Text;
            _state.Note = comboNote.Text;
            AddNote(comboNote);
            _state.Region = comboRegion.Text;

            _state.RunTime = tbRunTime.Text;
            _state.WarningTime = tbWarningTime.Text;
            _state.WarningTime2 = tbWarningTime2.Text;
            _state.WarningMessage = tbWarningMsg.Text;
            _state.WarningMessage2 = tbWarningMsg2.Text;
            _state.TimeZone = tbTimezone.Text;
            _state.NumPadding = numPadding.Value.ToString();

            string szXml = SerializeToXml<RunAssistState>(_state);

            File.WriteAllText(Path.Combine(_state.RootPath, _state.StateFileName), szXml);

            SetListSources();
        }

        protected void AddPlayerName(ComboBox combo)
        {
            if (!string.IsNullOrWhiteSpace(combo.Text) && !_state.PlayerNames.Contains(combo.Text))
                _state.PlayerNames.Add(combo.Text);
        }

        protected void AddZone(ComboBox combo)
        {
            if (!string.IsNullOrWhiteSpace(combo.Text) && !_state.Zones.Contains(combo.Text))
                _state.Zones.Add(combo.Text);
        }

        protected void AddGameName(ComboBox combo)
        {
            if (!string.IsNullOrWhiteSpace(combo.Text) && !_state.GameNames.Contains(combo.Text))
                _state.GameNames.Add(combo.Text);
        }

        protected void AddNote(ComboBox combo)
        {
            if (!string.IsNullOrWhiteSpace(combo.Text) && !_state.Notes.Contains(combo.Text))
                _state.Notes.Add(combo.Text);
        }

        protected void ResetTimer()
        {
            if (!_timer.IsRunning)
            {
                lblTimer.Text = tbRunTime.Text;
                int nRunMinutes = 0;
                int nRunSeconds = 0;
                string szRunTime = tbRunTime.Text;

                string[] splitRun = szRunTime.Split(':');
                if (!int.TryParse(splitRun[0], out nRunMinutes))
                    nRunMinutes = 6;
                if (splitRun.Length > 1 && !int.TryParse(splitRun[1], out nRunSeconds))
                    nRunSeconds = 0;

                _timer.SetTime(nRunMinutes, nRunSeconds);


                int nWarningMinutes = 0;
                int nWarningSeconds = 0;
                string szWarningTime = tbWarningTime.Text;

                string[] splitWarning = szWarningTime.Split(':');
                if (!int.TryParse(splitWarning[0], out nWarningMinutes))
                    nWarningMinutes = 2;
                if (splitWarning.Length > 1 && !int.TryParse(splitWarning[1], out nWarningSeconds))
                    nWarningSeconds = 0;

                _timer.SetWarning(nWarningMinutes, nWarningSeconds);


                int nWarning2Minutes = 0;
                int nWarning2Seconds = 0;
                string szWarningTime2 = tbWarningTime2.Text;

                string[] splitWarning2 = szWarningTime2.Split(':');
                if (!int.TryParse(splitWarning2[0], out nWarning2Minutes))
                    nWarning2Minutes = 0;
                if (splitWarning2.Length > 1 && !int.TryParse(splitWarning2[1], out nWarning2Seconds))
                    nWarning2Seconds = 30;

                _timer.SetWarning2(nWarning2Minutes, nWarning2Seconds);
            }
        }

        protected void SetEnabled(bool bVal)
        {
            btnStart.Enabled = bVal;
            btnStop.Enabled = !bVal;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveState();
            //MessageBox.Show(this, "Saved to file.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tssMainLabel.Text = "Saved to file";
        }

        private void btnToClipboard_Click(object sender, EventArgs e)
        {
            SaveState();
            PerformCurrentToClipboard();
        }

        private void btnIncriment_Click(object sender, EventArgs e)
        {
            tssMainLabel.Text = "Timer reset";
            _timer.Reset();
            lblTimer.Text = _timer.TimeLeftMsStr;

            numGameNumber.Value++;

            btnIncriment.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = true;
            btnIncriment.Enabled = true;

            SaveState();
            PerformCurrentToClipboard();

            btnStart.Focus();
        }

        private void tbRunTime_Leave(object sender, EventArgs e)
        {
            TimeSpan ts = TimeSpan.Zero;
            bool bSuccess = TimeSpan.TryParse(tbRunTime.Text, out ts);
            if (bSuccess)
            {
                errorProvider.Clear();
                ResetTimer();
            }
            else
            {
                errorProvider.SetError(tbRunTime, "Invalid time span");
                tbRunTime.Focus();
            }
        }

        private void tbWarningTime_Leave(object sender, EventArgs e)
        {
            TimeSpan ts = TimeSpan.Zero;
            bool bSuccess = TimeSpan.TryParse(tbWarningTime.Text, out ts);
            if (bSuccess)
            {
                errorProvider.Clear();
                ResetTimer();
            }
            else
            {
                errorProvider.SetError(tbWarningTime, "Invalid time span");
                tbWarningTime.Focus();
            }
        }

        private void tbWarningTime2_Leave(object sender, EventArgs e)
        {
            TimeSpan ts = TimeSpan.Zero;
            bool bSuccess = TimeSpan.TryParse(tbWarningTime2.Text, out ts);
            if (bSuccess)
            {
                errorProvider.Clear();
                ResetTimer();
            }
            else
            {
                errorProvider.SetError(tbWarningTime2, "Invalid time span");
                tbWarningTime2.Focus();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SaveState();

            Clipboard.SetText(_state.ToStringRoles(_timer.TimeLeftMsStr));

            tssMainLabel.Text = "Timer running";
            _timer.Start();

            SetEnabled(false);

            btnStop.Focus();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tssMainLabel.Text = "Timer stopped";
            _timer.Pause();
            SetEnabled(true);
            btnStart.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tssMainLabel.Text = "Timer reset";
            _timer.Reset();
            lblTimer.Text = _timer.TimeLeftMsStr;
            btnIncriment.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = true;
            btnIncriment.Enabled = true;
            btnStart.Focus();
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            string szName = (sender as Button).Name;
            string szIndex = szName.Substring(szName.Length - 1);
            Control[] cPlayer = Controls.Find("comboPlayerName" + szIndex, true);
            Control[] cZone = Controls.Find("comboPlayerZones" + szIndex, true);

            if (cPlayer.Length > 0)
                (cPlayer[0] as ComboBox).Text = string.Empty;
            if (cZone.Length > 0)
                (cZone[0] as ComboBox).Text = string.Empty;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog(this);
        }

        private void btnRolesToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_state.ToStringRoles(_timer.TimeLeftMsStr));
        }
    }
}