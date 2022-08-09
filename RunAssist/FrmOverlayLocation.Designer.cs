namespace PositiveChaos.RunAssist
{
    partial class FrmOverlayLocation
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
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnBackgroundColor = new System.Windows.Forms.Button();
            this.btnForegroundColor = new System.Windows.Forms.Button();
            this.checkShowPlayers = new System.Windows.Forms.CheckBox();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.lblAssignments = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.pnlPreview.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInstructions.Location = new System.Drawing.Point(0, 0);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(209, 26);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "Place and size the Overlay";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(41, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(122, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimer.ForeColor = System.Drawing.Color.Gray;
            this.lblTimer.Location = new System.Drawing.Point(12, 9);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(185, 44);
            this.lblTimer.TabIndex = 3;
            this.lblTimer.Text = "00:00.000";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBackgroundColor
            // 
            this.btnBackgroundColor.Location = new System.Drawing.Point(12, 59);
            this.btnBackgroundColor.Name = "btnBackgroundColor";
            this.btnBackgroundColor.Size = new System.Drawing.Size(156, 23);
            this.btnBackgroundColor.TabIndex = 2;
            this.btnBackgroundColor.Text = "Background Color...";
            this.btnBackgroundColor.UseVisualStyleBackColor = true;
            this.btnBackgroundColor.Click += new System.EventHandler(this.btnBackgroundColor_Click);
            // 
            // btnForegroundColor
            // 
            this.btnForegroundColor.Location = new System.Drawing.Point(12, 30);
            this.btnForegroundColor.Name = "btnForegroundColor";
            this.btnForegroundColor.Size = new System.Drawing.Size(156, 23);
            this.btnForegroundColor.TabIndex = 1;
            this.btnForegroundColor.Text = "Foreground Color...";
            this.btnForegroundColor.UseVisualStyleBackColor = true;
            this.btnForegroundColor.Click += new System.EventHandler(this.btnForegroundColor_Click);
            // 
            // checkShowPlayers
            // 
            this.checkShowPlayers.Checked = true;
            this.checkShowPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowPlayers.Location = new System.Drawing.Point(12, 3);
            this.checkShowPlayers.Name = "checkShowPlayers";
            this.checkShowPlayers.Size = new System.Drawing.Size(156, 24);
            this.checkShowPlayers.TabIndex = 5;
            this.checkShowPlayers.Text = "Show Players/Zones";
            this.checkShowPlayers.UseVisualStyleBackColor = true;
            this.checkShowPlayers.CheckedChanged += new System.EventHandler(this.checkShowPlayers_CheckedChanged);
            // 
            // pnlPreview
            // 
            this.pnlPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlPreview.Controls.Add(this.lblAssignments);
            this.pnlPreview.Controls.Add(this.lblTimer);
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPreview.Location = new System.Drawing.Point(0, 26);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(209, 257);
            this.pnlPreview.TabIndex = 6;
            // 
            // lblAssignments
            // 
            this.lblAssignments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAssignments.BackColor = System.Drawing.Color.Transparent;
            this.lblAssignments.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAssignments.ForeColor = System.Drawing.Color.Gray;
            this.lblAssignments.Location = new System.Drawing.Point(12, 53);
            this.lblAssignments.Name = "lblAssignments";
            this.lblAssignments.Size = new System.Drawing.Size(185, 193);
            this.lblAssignments.TabIndex = 4;
            this.lblAssignments.Text = "[Player 1 - Zone]";
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.checkShowPlayers);
            this.pnlSettings.Controls.Add(this.btnBackgroundColor);
            this.pnlSettings.Controls.Add(this.btnForegroundColor);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSettings.Location = new System.Drawing.Point(0, 283);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(209, 88);
            this.pnlSettings.TabIndex = 7;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnOk);
            this.pnlControl.Controls.Add(this.btnCancel);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 371);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(209, 41);
            this.pnlControl.TabIndex = 8;
            // 
            // FrmOverlayLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 412);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.lblInstructions);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(196, 255);
            this.Name = "FrmOverlayLocation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Overlay Size and Location";
            this.pnlPreview.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblInstructions;
        private Button btnOk;
        private Button btnCancel;
        private ColorDialog colorDialog;
        private Label lblTimer;
        private Button btnBackgroundColor;
        private Button btnForegroundColor;
        private CheckBox checkShowPlayers;
        private Panel pnlPreview;
        private Label lblAssignments;
        private Panel pnlSettings;
        private Panel pnlControl;
    }
}