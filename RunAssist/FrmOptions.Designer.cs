namespace PositiveChaos.RunAssist
{
    partial class FrmOptions
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
            this.lblNumPadding = new System.Windows.Forms.Label();
            this.numPadding = new System.Windows.Forms.NumericUpDown();
            this.lblNumPaddingDesc = new System.Windows.Forms.Label();
            this.tbTimezone = new System.Windows.Forms.TextBox();
            this.lblTimezone = new System.Windows.Forms.Label();
            this.lblTimezoneDesc = new System.Windows.Forms.Label();
            this.comboRegion = new System.Windows.Forms.ComboBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblRegionDesc = new System.Windows.Forms.Label();
            this.checkIncludeRegion = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPadding)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumPadding
            // 
            this.lblNumPadding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumPadding.Location = new System.Drawing.Point(12, 9);
            this.lblNumPadding.Name = "lblNumPadding";
            this.lblNumPadding.Size = new System.Drawing.Size(81, 23);
            this.lblNumPadding.TabIndex = 41;
            this.lblNumPadding.Text = "Num Padding";
            this.lblNumPadding.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numPadding
            // 
            this.numPadding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numPadding.Location = new System.Drawing.Point(99, 9);
            this.numPadding.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numPadding.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPadding.Name = "numPadding";
            this.numPadding.Size = new System.Drawing.Size(46, 23);
            this.numPadding.TabIndex = 40;
            this.numPadding.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblNumPaddingDesc
            // 
            this.lblNumPaddingDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumPaddingDesc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumPaddingDesc.Location = new System.Drawing.Point(12, 35);
            this.lblNumPaddingDesc.Name = "lblNumPaddingDesc";
            this.lblNumPaddingDesc.Size = new System.Drawing.Size(402, 50);
            this.lblNumPaddingDesc.TabIndex = 42;
            this.lblNumPaddingDesc.Text = "How many digits the Game Number for the game name should be.  Example: GameName-0" +
    "2 would have padding of 2 where as GameName-001 would have padding of 3";
            // 
            // tbTimezone
            // 
            this.tbTimezone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbTimezone.Location = new System.Drawing.Point(99, 107);
            this.tbTimezone.Name = "tbTimezone";
            this.tbTimezone.Size = new System.Drawing.Size(45, 23);
            this.tbTimezone.TabIndex = 64;
            this.tbTimezone.Text = "EST";
            // 
            // lblTimezone
            // 
            this.lblTimezone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimezone.Location = new System.Drawing.Point(12, 106);
            this.lblTimezone.Name = "lblTimezone";
            this.lblTimezone.Size = new System.Drawing.Size(81, 23);
            this.lblTimezone.TabIndex = 65;
            this.lblTimezone.Text = "Timezone";
            this.lblTimezone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimezoneDesc
            // 
            this.lblTimezoneDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimezoneDesc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTimezoneDesc.Location = new System.Drawing.Point(12, 133);
            this.lblTimezoneDesc.Name = "lblTimezoneDesc";
            this.lblTimezoneDesc.Size = new System.Drawing.Size(402, 36);
            this.lblTimezoneDesc.TabIndex = 66;
            this.lblTimezoneDesc.Text = "What should display for the timestamps that appear when using Copy to Clipboard";
            // 
            // comboRegion
            // 
            this.comboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRegion.FormattingEnabled = true;
            this.comboRegion.Items.AddRange(new object[] {
            "",
            "Americas",
            "Europe",
            "Asia"});
            this.comboRegion.Location = new System.Drawing.Point(99, 196);
            this.comboRegion.Name = "comboRegion";
            this.comboRegion.Size = new System.Drawing.Size(123, 23);
            this.comboRegion.TabIndex = 67;
            // 
            // lblRegion
            // 
            this.lblRegion.Location = new System.Drawing.Point(12, 195);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(81, 23);
            this.lblRegion.TabIndex = 68;
            this.lblRegion.Text = "Region";
            this.lblRegion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegionDesc
            // 
            this.lblRegionDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegionDesc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRegionDesc.Location = new System.Drawing.Point(12, 222);
            this.lblRegionDesc.Name = "lblRegionDesc";
            this.lblRegionDesc.Size = new System.Drawing.Size(402, 36);
            this.lblRegionDesc.TabIndex = 69;
            this.lblRegionDesc.Text = "What region to display for the text that is copied to the clipboard when using Co" +
    "py to Clipboard.  And whether to include Region as well.";
            // 
            // checkIncludeRegion
            // 
            this.checkIncludeRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkIncludeRegion.Checked = true;
            this.checkIncludeRegion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkIncludeRegion.Location = new System.Drawing.Point(228, 196);
            this.checkIncludeRegion.Name = "checkIncludeRegion";
            this.checkIncludeRegion.Size = new System.Drawing.Size(186, 22);
            this.checkIncludeRegion.TabIndex = 70;
            this.checkIncludeRegion.Text = "Include Region";
            this.checkIncludeRegion.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(258, 461);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 71;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(339, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 72;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmOptions
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(426, 496);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.checkIncludeRegion);
            this.Controls.Add(this.lblRegionDesc);
            this.Controls.Add(this.comboRegion);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.lblTimezoneDesc);
            this.Controls.Add(this.tbTimezone);
            this.Controls.Add(this.lblTimezone);
            this.Controls.Add(this.lblNumPaddingDesc);
            this.Controls.Add(this.lblNumPadding);
            this.Controls.Add(this.numPadding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.numPadding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblNumPadding;
        private NumericUpDown numPadding;
        private Label lblNumPaddingDesc;
        private TextBox tbTimezone;
        private Label lblTimezone;
        private Label lblTimezoneDesc;
        private ComboBox comboRegion;
        private Label lblRegion;
        private Label lblRegionDesc;
        private CheckBox checkIncludeRegion;
        private Button btnOk;
        private Button btnCancel;
    }
}