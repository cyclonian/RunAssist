namespace PositiveChaos.RunAssist
{
    partial class FrmKeyBinding
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbStartTimerKey = new System.Windows.Forms.ComboBox();
            this.checkStartTimerAlt = new System.Windows.Forms.CheckBox();
            this.checkStartTimerCtrl = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkStartTimer = new System.Windows.Forms.CheckBox();
            this.checkStopTimer = new System.Windows.Forms.CheckBox();
            this.cbStopTimerKey = new System.Windows.Forms.ComboBox();
            this.checkStopTimerAlt = new System.Windows.Forms.CheckBox();
            this.checkStopTimerCtrl = new System.Windows.Forms.CheckBox();
            this.checkNextGame = new System.Windows.Forms.CheckBox();
            this.cbNextGameKey = new System.Windows.Forms.ComboBox();
            this.checkNextGameAlt = new System.Windows.Forms.CheckBox();
            this.checkNextGameCtrl = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbStartTimerKey
            // 
            this.cbStartTimerKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartTimerKey.FormattingEnabled = true;
            this.cbStartTimerKey.Items.AddRange(new object[] {
            "",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "-",
            "=",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.cbStartTimerKey.Location = new System.Drawing.Point(103, 15);
            this.cbStartTimerKey.Name = "cbStartTimerKey";
            this.cbStartTimerKey.Size = new System.Drawing.Size(75, 23);
            this.cbStartTimerKey.TabIndex = 74;
            // 
            // checkStartTimerAlt
            // 
            this.checkStartTimerAlt.AutoSize = true;
            this.checkStartTimerAlt.Location = new System.Drawing.Point(184, 27);
            this.checkStartTimerAlt.Name = "checkStartTimerAlt";
            this.checkStartTimerAlt.Size = new System.Drawing.Size(45, 19);
            this.checkStartTimerAlt.TabIndex = 73;
            this.checkStartTimerAlt.Text = "ALT";
            this.checkStartTimerAlt.UseVisualStyleBackColor = true;
            // 
            // checkStartTimerCtrl
            // 
            this.checkStartTimerCtrl.AutoSize = true;
            this.checkStartTimerCtrl.Location = new System.Drawing.Point(184, 11);
            this.checkStartTimerCtrl.Name = "checkStartTimerCtrl";
            this.checkStartTimerCtrl.Size = new System.Drawing.Size(53, 19);
            this.checkStartTimerCtrl.TabIndex = 72;
            this.checkStartTimerCtrl.Text = "CTRL";
            this.checkStartTimerCtrl.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(103, 193);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 75;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(184, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 76;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkStartTimer
            // 
            this.checkStartTimer.AutoSize = true;
            this.checkStartTimer.Location = new System.Drawing.Point(12, 17);
            this.checkStartTimer.Name = "checkStartTimer";
            this.checkStartTimer.Size = new System.Drawing.Size(83, 19);
            this.checkStartTimer.TabIndex = 77;
            this.checkStartTimer.Text = "Start Timer";
            this.checkStartTimer.UseVisualStyleBackColor = true;
            this.checkStartTimer.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // checkStopTimer
            // 
            this.checkStopTimer.AutoSize = true;
            this.checkStopTimer.Location = new System.Drawing.Point(12, 68);
            this.checkStopTimer.Name = "checkStopTimer";
            this.checkStopTimer.Size = new System.Drawing.Size(83, 19);
            this.checkStopTimer.TabIndex = 81;
            this.checkStopTimer.Text = "Stop Timer";
            this.checkStopTimer.UseVisualStyleBackColor = true;
            this.checkStopTimer.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // cbStopTimerKey
            // 
            this.cbStopTimerKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopTimerKey.FormattingEnabled = true;
            this.cbStopTimerKey.Items.AddRange(new object[] {
            "",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "-",
            "=",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.cbStopTimerKey.Location = new System.Drawing.Point(103, 66);
            this.cbStopTimerKey.Name = "cbStopTimerKey";
            this.cbStopTimerKey.Size = new System.Drawing.Size(75, 23);
            this.cbStopTimerKey.TabIndex = 80;
            // 
            // checkStopTimerAlt
            // 
            this.checkStopTimerAlt.AutoSize = true;
            this.checkStopTimerAlt.Location = new System.Drawing.Point(184, 78);
            this.checkStopTimerAlt.Name = "checkStopTimerAlt";
            this.checkStopTimerAlt.Size = new System.Drawing.Size(45, 19);
            this.checkStopTimerAlt.TabIndex = 79;
            this.checkStopTimerAlt.Text = "ALT";
            this.checkStopTimerAlt.UseVisualStyleBackColor = true;
            // 
            // checkStopTimerCtrl
            // 
            this.checkStopTimerCtrl.AutoSize = true;
            this.checkStopTimerCtrl.Location = new System.Drawing.Point(184, 62);
            this.checkStopTimerCtrl.Name = "checkStopTimerCtrl";
            this.checkStopTimerCtrl.Size = new System.Drawing.Size(53, 19);
            this.checkStopTimerCtrl.TabIndex = 78;
            this.checkStopTimerCtrl.Text = "CTRL";
            this.checkStopTimerCtrl.UseVisualStyleBackColor = true;
            // 
            // checkNextGame
            // 
            this.checkNextGame.AutoSize = true;
            this.checkNextGame.Location = new System.Drawing.Point(12, 120);
            this.checkNextGame.Name = "checkNextGame";
            this.checkNextGame.Size = new System.Drawing.Size(85, 19);
            this.checkNextGame.TabIndex = 85;
            this.checkNextGame.Text = "Next Game";
            this.checkNextGame.UseVisualStyleBackColor = true;
            this.checkNextGame.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // cbNextGameKey
            // 
            this.cbNextGameKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNextGameKey.FormattingEnabled = true;
            this.cbNextGameKey.Items.AddRange(new object[] {
            "",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "-",
            "=",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.cbNextGameKey.Location = new System.Drawing.Point(103, 118);
            this.cbNextGameKey.Name = "cbNextGameKey";
            this.cbNextGameKey.Size = new System.Drawing.Size(75, 23);
            this.cbNextGameKey.TabIndex = 84;
            // 
            // checkNextGameAlt
            // 
            this.checkNextGameAlt.AutoSize = true;
            this.checkNextGameAlt.Location = new System.Drawing.Point(184, 130);
            this.checkNextGameAlt.Name = "checkNextGameAlt";
            this.checkNextGameAlt.Size = new System.Drawing.Size(45, 19);
            this.checkNextGameAlt.TabIndex = 83;
            this.checkNextGameAlt.Text = "ALT";
            this.checkNextGameAlt.UseVisualStyleBackColor = true;
            // 
            // checkNextGameCtrl
            // 
            this.checkNextGameCtrl.AutoSize = true;
            this.checkNextGameCtrl.Location = new System.Drawing.Point(184, 114);
            this.checkNextGameCtrl.Name = "checkNextGameCtrl";
            this.checkNextGameCtrl.Size = new System.Drawing.Size(53, 19);
            this.checkNextGameCtrl.TabIndex = 82;
            this.checkNextGameCtrl.Text = "CTRL";
            this.checkNextGameCtrl.UseVisualStyleBackColor = true;
            // 
            // FrmKeyBinding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 228);
            this.Controls.Add(this.checkNextGame);
            this.Controls.Add(this.cbNextGameKey);
            this.Controls.Add(this.checkNextGameAlt);
            this.Controls.Add(this.checkNextGameCtrl);
            this.Controls.Add(this.checkStopTimer);
            this.Controls.Add(this.cbStopTimerKey);
            this.Controls.Add(this.checkStopTimerAlt);
            this.Controls.Add(this.checkStopTimerCtrl);
            this.Controls.Add(this.checkStartTimer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbStartTimerKey);
            this.Controls.Add(this.checkStartTimerAlt);
            this.Controls.Add(this.checkStartTimerCtrl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKeyBinding";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Global Key Bindings...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbStartTimerKey;
        private CheckBox checkStartTimerAlt;
        private CheckBox checkStartTimerCtrl;
        private Button btnOk;
        private Button button1;
        private CheckBox checkStartTimer;
        private CheckBox checkStopTimer;
        private ComboBox cbStopTimerKey;
        private CheckBox checkStopTimerAlt;
        private CheckBox checkStopTimerCtrl;
        private CheckBox checkNextGame;
        private ComboBox cbNextGameKey;
        private CheckBox checkNextGameAlt;
        private CheckBox checkNextGameCtrl;
    }
}