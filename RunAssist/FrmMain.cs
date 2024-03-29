using System.Media;
using System.Resources;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace PositiveChaos.RunAssist
{
    public partial class FrmMain : Form
    {
        protected RunAssistState _state = new RunAssistState();
        protected CountdownTimer _timer = new CountdownTimer();
        protected KeyboardHook _hook = new KeyboardHook();
        protected FrmOverlay _frmOverlay = new FrmOverlay();
        protected Point _overlayLocation = new Point();
        protected Size _overlaySize = new Size();
        protected Color _overlayForeColor = ColorTranslator.FromHtml("#FF808080");
        protected Color _overlayBackColor = ColorTranslator.FromHtml("#222222");
        protected bool _bOverlayShowPlayersZones = true;
        protected FrmOverlayLocation _frmOverlayLocation = new FrmOverlayLocation();
        protected SoundPlayer _playerStart = new SoundPlayer();
        protected SoundPlayer _playerFinish = new SoundPlayer();
        protected SoundPlayer _playerWarning = new SoundPlayer();
        protected SoundPlayer _playerTick = new SoundPlayer();

        public FrmMain()
        {
            FileInfo fiExe = new FileInfo(AppDomain.CurrentDomain.BaseDirectory);
            if (fiExe.Directory != null && fiExe.Directory.Exists)
                _state.RootPath = fiExe.Directory.FullName;

            InitializeComponent();

            PreloadSound(_playerStart, Properties.Resource.audio_start);
            PreloadSound(_playerFinish, Properties.Resource.audio_finish);
            PreloadSound(_playerWarning, Properties.Resource.audio_warning);
            PreloadSound(_playerTick, Properties.Resource.audio_tick);

            _state = DeserializeFromFile();

            ReadStateContent(_state);

            if(_state.Zones.Count == 0)
                _state.Zones.AddRange(new string[] { "Baal", "Chaos Sanctuary", "CS", "Countess", "Cows", "Eldritch", "LK", "Lower Kurast", "Pindle", "Pits", "Shenk", "Stony Tombs", "Tal Tombs", "Travincal", "WSK" });
            if (_state.Notes.Count == 0)
                _state.Notes.Add("{0} minute timed runs");

            SetListSources();

            lblTimer.ForeColor = ColorTranslator.FromHtml(_state.OverlayForeColor);
            lblTimer.BackColor = ColorTranslator.FromHtml(_state.OverlayBackColor);

            _timer.TimeChanged += () => HandleTimerChanged();
            _timer.CountdownFinished += () => HandleTimerFinished();
            _timer.CountdownWarning += () => HandleWarningEvent();
            _timer.CountdownWarning2 += () => HandleWarning2Event();
            _timer.StepMs = 77;
            ResetTimer();

            _frmOverlay.Show(this);
            _frmOverlay.Hide();
            _frmOverlayLocation.Show(this);
            _frmOverlayLocation.Hide();
        }

        protected void HandleTimerChanged()
        {
            lblTimer.Text = _timer.TimeLeftMsStr;
            _frmOverlay.SetContent(lblTimer.Text);
        }

        protected void PerformOverlay()
        {
            if (_frmOverlay.Visible)
            {
                _frmOverlay.Hide();
            }
            else
            {
                _frmOverlay.Location = _overlayLocation;
                _frmOverlay.Size = _overlaySize;
                _frmOverlay.SetValues(_overlayForeColor, _overlayBackColor, _bOverlayShowPlayersZones);
                _frmOverlay.SetContent(lblTimer.Text, _state.ToStringOverlayAssignments());
                _frmOverlay.Show(this);
            }

            tssMainLabel.Text = "Toggle Overlay performed";
        }

        protected void HandleTimerFinished()
        {
            SaveState(false, true);

            _timer.Reset();
            lblTimer.Text = _timer.TimeLeftMsStr;
            _frmOverlay.SetContent(lblTimer.Text);
            btnIncriment.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = true;
            btnIncriment.Enabled = true;

            PlaySoundFinish();
            tssMainLabel.Text = "Run finished";
        }

        protected void HandleWarningEvent()
        {
            PlaySoundWarning();
            string szClip = string.Empty;
            Helpers.TryFormat(tbWarningMsg.Text, out szClip, tbWarningTime.Text);
            Clipboard.SetText(szClip);
        }

        protected void HandleWarning2Event()
        {
            PlaySoundWarning();
            string szClip = string.Empty;
            Helpers.TryFormat(tbWarningMsg.Text, out szClip, tbWarningTime2.Text);
            Clipboard.SetText(szClip);
        }

        protected void PlaySoundStart()
        {
            _playerStart.Play();
        }

        protected void PlaySoundFinish()
        {
            _playerFinish.Play();
        }

        protected void PlaySoundWarning()
        {
            _playerWarning.Play();
        }

        protected void PlaySoundTick()
        {
            _playerTick.Play();
        }

        protected void PreloadSound(SoundPlayer player, UnmanagedMemoryStream stream)
        {
            try
            {
                
                player.Stream = stream;
                player.LoadAsync();
            }
            catch (Exception ex)
            {
                tssMainLabel.Text = ex.Message;
            }
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

            comboGameName.Text = state.GameName;
            int nGameNumber = 0;
            if(int.TryParse(state.GameNumber, out nGameNumber))
                numGameNumber.Value = nGameNumber;
            tbPassword.Text = Helpers.GetSafeVal(ValType.Password, state.Password);
            comboNote.Text = Helpers.GetSafeVal(ValType.Note, state.Note);
            tbRunTime.Text = Helpers.GetSafeVal(ValType.RunTime, state.RunTime);
            tbWarningTime.Text = Helpers.GetSafeVal(ValType.WarningTime, state.WarningTime);
            tbWarningTime2.Text = Helpers.GetSafeVal(ValType.WarningTime2, state.WarningTime2);
            tbWarningMsg.Text = Helpers.GetSafeVal(ValType.WarningMessage, state.WarningMessage);
            tbAdvert.Text = Helpers.GetSafeVal(ValType.Advert, state.Advert);
            checkAutoTimer.Checked = state.AutoTimerVal;
            numAutoTimerDelay.Value = state.AutoTimerDelayVal;
            checkIncludeTimestamp.Checked = state.IncludeTimestampVal;

            int nOverlayX = Location.X + Width;
            if (!string.IsNullOrWhiteSpace(state.OverlayLocationX))
                int.TryParse(state.OverlayLocationX, out nOverlayX);
            int nOverlayY = Location.Y;
            if (!string.IsNullOrWhiteSpace(state.OverlayLocationY))
                int.TryParse(state.OverlayLocationY, out nOverlayY);
            _overlayLocation = new Point(nOverlayX, nOverlayY);

            int nOverlayWidth = 300;
            if (!string.IsNullOrWhiteSpace(state.OverlayWidth))
                int.TryParse(state.OverlayWidth, out nOverlayWidth);
            int nOverlayHeight = 450;
            if (!string.IsNullOrWhiteSpace(state.OverlayHeight))
                int.TryParse(state.OverlayHeight, out nOverlayHeight);
            _overlaySize = new Size(nOverlayWidth, nOverlayHeight);

            _overlayForeColor = ColorTranslator.FromHtml(state.OverlayForeColor);
            _overlayBackColor = ColorTranslator.FromHtml(state.OverlayBackColor);
            _bOverlayShowPlayersZones = state.OverlayShowPlayersZonesVal;

            BindKeysFromState(state);
        }

        protected void PerformCurrentToClipboard()
        {
            Clipboard.SetText(_state.ToString());
        }

        protected void SaveState(bool bUpdateLists, bool bSaveToFile)
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

            _state.RunTime = tbRunTime.Text;
            _state.WarningTime = tbWarningTime.Text;
            _state.WarningTime2 = tbWarningTime2.Text;
            _state.WarningMessage = tbWarningMsg.Text;
            _state.Advert = tbAdvert.Text;
            _state.AutoTimer = checkAutoTimer.Checked.ToString();
            _state.AutoTimerDelay = numAutoTimerDelay.Value.ToString();
            _state.IncludeTimestamp = checkIncludeTimestamp.Checked.ToString();

            if (bSaveToFile)
            {
                string szXml = SerializeToXml<RunAssistState>(_state);

                File.WriteAllText(Path.Combine(_state.RootPath, _state.StateFileName), szXml);
            }

            if (bUpdateLists)
                SetListSources();

            _frmOverlay.SetContent(lblTimer.Text, _state.ToStringOverlayAssignments());
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
                _frmOverlay.SetContent(lblTimer.Text);
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

        protected void BindKeysFromState(RunAssistState state)
        {
            // reset the hooks
            if (_hook != null)
                _hook.Dispose();
            _hook = new KeyboardHook();
            _hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            if(state.KeybindToggle.Key != Keys.None)
                _hook.RegisterHotKey(state.KeybindToggle.Modifiers, state.KeybindToggle.Key);
            if (state.KeybindNextGame.Key != Keys.None)
                _hook.RegisterHotKey(state.KeybindNextGame.Modifiers, state.KeybindNextGame.Key);
            if (state.KeybindCopyRoles.Key != Keys.None)
                _hook.RegisterHotKey(state.KeybindCopyRoles.Modifiers, state.KeybindCopyRoles.Key);
            if (state.KeybindOverlay.Key != Keys.None)
                _hook.RegisterHotKey(state.KeybindOverlay.Modifiers, state.KeybindOverlay.Key);
            if (state.KeybindAdvert.Key != Keys.None)
                _hook.RegisterHotKey(state.KeybindAdvert.Modifiers, state.KeybindAdvert.Key);
        }

        protected void BindsKeys(KeyCombo kcToggle, KeyCombo kcNextGame, KeyCombo kcCopyRoles, KeyCombo kcOverlay, KeyCombo kcAdvert)
        {
            // update the keybinds mapping
            _state.KeybindToggle = kcToggle;
            _state.KeybindNextGame = kcNextGame;
            _state.KeybindCopyRoles = kcCopyRoles;
            _state.KeybindOverlay = kcOverlay;
            _state.KeybindAdvert = kcAdvert;
            BindKeysFromState(_state);
        }

        protected void PerformStart()
        {
            if (!_timer.IsRunning)
            {
                SaveState(false, true);

                Clipboard.SetText(_state.ToStringRoles(_timer.TimeLeftMsStr));

                PlaySoundStart();
                tssMainLabel.Text = "Timer running";
                _timer.Start();

                SetEnabled(false);

                btnStop.Focus();
            }
        }

        protected void PerformStop()
        {
            if (_timer.IsRunning)
            {
                tssMainLabel.Text = "Timer stopped";
                _timer.Pause();
                SetEnabled(true);
                btnStart.Focus();
            }
        }

        protected void PerformNextGame(bool bIncrement, bool bAutoNextGame)
        {
            if (_timer.IsRunning)
                _timer.Stop();

            tssMainLabel.Text = "Timer reset";
            _timer.Reset();
            lblTimer.Text = _timer.TimeLeftMsStr;

            if (bIncrement)
                numGameNumber.Value++;

            btnIncriment.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = true;
            btnIncriment.Enabled = true;

            SaveState(false, true);

            if (bIncrement)
            {
                PerformCurrentToClipboard();
                PlaySoundTick();
            }

            _frmOverlay.SetContent(lblTimer.Text, _state.ToStringOverlayAssignments());

            btnStart.Focus();

            if(bAutoNextGame && _state.AutoTimerVal)
            {
                if (bgWorker.IsBusy)
                {
                    bgWorker.CancelAsync();
                    while (bgWorker.IsBusy)
                        Application.DoEvents();
                }

                KeyValuePair<WorkerKey, int> arg = new KeyValuePair<WorkerKey, int>(WorkerKey.AutoStart, _state.AutoTimerDelayVal);
                bgWorker.RunWorkerAsync(arg);
            }
        }

        protected void PerformCopyRoles()
        {
            SaveState(false, false);
            Clipboard.SetText(_state.ToStringRoles(_timer.TimeLeftMsStr));
            tssMainLabel.Text = "Copy Roles performed";
        }

        protected void PerformAdvert()
        {
            Clipboard.SetText(_state.Advert);
            tssMainLabel.Text = "Advert performed";
        }

        #region Event Handlers

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveState(true, true);
            //MessageBox.Show(this, "Saved to file.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tssMainLabel.Text = "Saved to file";
        }

        private void btnToClipboard_Click(object sender, EventArgs e)
        {
            SaveState(true, true);
            PerformCurrentToClipboard();
        }

        private void btnIncriment_Click(object sender, EventArgs e)
        {
            PerformNextGame(true, true);
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
            PerformStart();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            PerformStop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            PerformNextGame(false, false);
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
            PerformCopyRoles();
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            KeyCombo keyCombo = new KeyCombo(e.Modifier, e.Key);
            RunAssistKey key = RunAssistKey.None;
            if (_state.KeybindToggle.Modifiers == keyCombo.Modifiers && _state.KeybindToggle.Key == keyCombo.Key)
                key = RunAssistKey.Toggle;
            else if (_state.KeybindNextGame.Modifiers == keyCombo.Modifiers && _state.KeybindNextGame.Key == keyCombo.Key)
                key = RunAssistKey.NextGame;
            else if (_state.KeybindCopyRoles.Modifiers == keyCombo.Modifiers && _state.KeybindCopyRoles.Key == keyCombo.Key)
                key = RunAssistKey.CopyRoles;
            else if (_state.KeybindOverlay.Modifiers == keyCombo.Modifiers && _state.KeybindOverlay.Key == keyCombo.Key)
                key = RunAssistKey.Overlay;
            else if (_state.KeybindAdvert.Modifiers == keyCombo.Modifiers && _state.KeybindAdvert.Key == keyCombo.Key)
                key = RunAssistKey.Advert;

            switch (key)
            {
                case RunAssistKey.Toggle:
                    if (_timer.IsRunning)
                        PerformStop();
                    else
                        PerformStart();
                    break;
                case RunAssistKey.NextGame:
                    PerformNextGame(true, true);
                    break;
                case RunAssistKey.CopyRoles:
                    PerformCopyRoles();
                    break;
                case RunAssistKey.Overlay:
                    PerformOverlay();
                    break;
                case RunAssistKey.Advert:
                    PerformAdvert();
                    break;
                default: break;
            }
        }

        private void btnKeyBinding_Click(object sender, EventArgs e)
        {
            FrmKeyBinding frm = new FrmKeyBinding();
            frm.SetState(_state);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                // update the keybinds mapping
                KeyCombo kcToggle = frm.GetSelection(RunAssistKey.Toggle);
                KeyCombo kcNextGame = frm.GetSelection(RunAssistKey.NextGame);
                KeyCombo kcCopyRoles = frm.GetSelection(RunAssistKey.CopyRoles);
                KeyCombo kcOverlay = frm.GetSelection(RunAssistKey.Overlay);
                KeyCombo kcAdvert = frm.GetSelection(RunAssistKey.Advert);

                BindsKeys(kcToggle, kcNextGame, kcCopyRoles, kcOverlay, kcAdvert);

                SaveState(false, false);
            }
        }

        private void btnAdjustOverlay_Click(object sender, EventArgs e)
        {
            _frmOverlayLocation.SetValues(_overlayForeColor, _overlayBackColor, _bOverlayShowPlayersZones, _overlayLocation, _overlaySize);

            bool bIsOverlayVisible = _frmOverlay.Visible;

            if (bIsOverlayVisible)
                _frmOverlay.Hide();

            if (_frmOverlayLocation.ShowDialog(this) == DialogResult.OK)
            {
                _overlayLocation = _frmOverlayLocation.OverlayLocation;
                _overlaySize = _frmOverlayLocation.OverlaySize;
                _overlayForeColor = _frmOverlayLocation.OverlayForeColor;
                _overlayBackColor = _frmOverlayLocation.OverlayBackColor;
                _bOverlayShowPlayersZones = _frmOverlayLocation.OverlayShowPlayersZones;

                _state.OverlayLocationX = _overlayLocation.X.ToString();
                _state.OverlayLocationY = _overlayLocation.Y.ToString();
                _state.OverlayWidth = _overlaySize.Width.ToString();
                _state.OverlayHeight = _overlaySize.Height.ToString();

                _state.OverlayForeColor = ColorTranslator.ToHtml(_overlayForeColor);
                _state.OverlayBackColor = ColorTranslator.ToHtml(_overlayBackColor);
                _state.OverlayShowPlayersZones = _bOverlayShowPlayersZones.ToString();

                SaveState(false, true);

                lblTimer.ForeColor = _frmOverlayLocation.OverlayForeColor;
                lblTimer.BackColor = _frmOverlayLocation.OverlayBackColor;
            }

            if (bIsOverlayVisible)
                PerformOverlay();
        }

        private void FrmMain_LocationChanged(object sender, EventArgs e)
        {
            int nOverlayX = Location.X + Width;
            int nOverlayY = Location.Y;
            if (string.IsNullOrWhiteSpace(_state.OverlayLocationX) && string.IsNullOrWhiteSpace(_state.OverlayLocationY))
                _overlayLocation = new Point(nOverlayX, nOverlayY);
        }

        private void checkAutoTimer_CheckedChanged(object sender, EventArgs e)
        {
            numAutoTimerDelay.Enabled = checkAutoTimer.Checked;
        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (bgWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            KeyValuePair<WorkerKey, int> kvp = new KeyValuePair<WorkerKey, int>();
            if (e.Argument is KeyValuePair<WorkerKey, int>)
                kvp = (KeyValuePair<WorkerKey, int>)e.Argument;
            else
                return;

            switch(kvp.Key)
            {
                case WorkerKey.AutoStart:
                    Thread.Sleep(kvp.Value * 1000);
                    e.Result = new KeyValuePair<WorkerKey, int>(kvp.Key, kvp.Value);
                    break;
                default: break;
            }
        }

        private void bgWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            KeyValuePair<WorkerKey, int> kvp = new KeyValuePair<WorkerKey, int>();
            if (e.Result is KeyValuePair<WorkerKey, int>)
                kvp = (KeyValuePair<WorkerKey, int>)e.Result;
            else
                return;

            switch (kvp.Key)
            {
                case WorkerKey.AutoStart:
                    PerformStart();
                    break;
                default: break;
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            FrmOptions frmOptions = new FrmOptions();
            frmOptions.ReadStateContent(_state);
            if(frmOptions.ShowDialog(this) == DialogResult.OK)
            {
                _state.Region = frmOptions.GameRegion;
                _state.IncludeRegion = frmOptions.GameRegionInclude;
                _state.TimeZone = frmOptions.TimeZone;
                _state.NumPadding = frmOptions.NumPadding;
                SaveState(false, true);
            }
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            comboPlayerName2.Text = string.Empty;
            comboPlayerZones2.Text = string.Empty;
            comboPlayerName3.Text = string.Empty;
            comboPlayerZones3.Text = string.Empty;
            comboPlayerName4.Text = string.Empty;
            comboPlayerZones4.Text = string.Empty;
            comboPlayerName5.Text = string.Empty;
            comboPlayerZones5.Text = string.Empty;
            comboPlayerName6.Text = string.Empty;
            comboPlayerZones6.Text = string.Empty;
            comboPlayerName7.Text = string.Empty;
            comboPlayerZones7.Text = string.Empty;
            comboPlayerName8.Text = string.Empty;
            comboPlayerZones8.Text = string.Empty;
        }

        #endregion Event Handlers
    }
}