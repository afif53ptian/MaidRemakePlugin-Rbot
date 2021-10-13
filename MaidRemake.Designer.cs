namespace MaidRemake
{
    partial class MaidRemake
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaidRemake));
            this.trgtUsrnmLabel = new System.Windows.Forms.Label();
            this.cbEnablePlugin = new System.Windows.Forms.CheckBox();
            this.tbSkillList = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.numRelogDelay = new System.Windows.Forms.NumericUpDown();
            this.lblLockedMapSetting = new System.Windows.Forms.LinkLabel();
            this.cbHandleLockedMap = new System.Windows.Forms.CheckBox();
            this.cmbPreset = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStopIf = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUnfollow = new System.Windows.Forms.CheckBox();
            this.cbStopAttack = new System.Windows.Forms.CheckBox();
            this.cbEnableGlobalHotkey = new System.Windows.Forms.CheckBox();
            this.gbAdvancedOptions = new System.Windows.Forms.GroupBox();
            this.numHealthPercent = new System.Windows.Forms.NumericUpDown();
            this.lbUseHeal2 = new System.Windows.Forms.Label();
            this.tbHealSkill = new System.Windows.Forms.TextBox();
            this.cbUseHeal = new System.Windows.Forms.CheckBox();
            this.tbAttPriority = new System.Windows.Forms.TextBox();
            this.cbAttackPriority = new System.Windows.Forms.CheckBox();
            this.tbBuffSkill = new System.Windows.Forms.TextBox();
            this.cbBuffIfStop = new System.Windows.Forms.CheckBox();
            this.lbStopAttackBg = new System.Windows.Forms.Label();
            this.timerStopAttack = new System.Windows.Forms.Timer(this.components);
            this.cmbGotoUsername = new System.Windows.Forms.ComboBox();
            this.cbWaitSkill = new System.Windows.Forms.CheckBox();
            this.darkLabel1 = new System.Windows.Forms.Label();
            this.numSkillDelay = new System.Windows.Forms.NumericUpDown();
            this.gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRelogDelay)).BeginInit();
            this.gbAdvancedOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHealthPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkillDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // trgtUsrnmLabel
            // 
            this.trgtUsrnmLabel.AutoSize = true;
            this.trgtUsrnmLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.trgtUsrnmLabel.Location = new System.Drawing.Point(16, 12);
            this.trgtUsrnmLabel.Name = "trgtUsrnmLabel";
            this.trgtUsrnmLabel.Size = new System.Drawing.Size(84, 13);
            this.trgtUsrnmLabel.TabIndex = 4;
            this.trgtUsrnmLabel.Text = "Goto Username:";
            // 
            // cbEnablePlugin
            // 
            this.cbEnablePlugin.AutoSize = true;
            this.cbEnablePlugin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEnablePlugin.Location = new System.Drawing.Point(19, 94);
            this.cbEnablePlugin.Name = "cbEnablePlugin";
            this.cbEnablePlugin.Size = new System.Drawing.Size(65, 17);
            this.cbEnablePlugin.TabIndex = 7;
            this.cbEnablePlugin.Text = "Enable";
            this.cbEnablePlugin.CheckedChanged += new System.EventHandler(this.cbEnablePlugin_CheckedChanged);
            // 
            // tbSkillList
            // 
            this.tbSkillList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSkillList.Location = new System.Drawing.Point(19, 68);
            this.tbSkillList.Name = "tbSkillList";
            this.tbSkillList.Size = new System.Drawing.Size(135, 20);
            this.tbSkillList.TabIndex = 12;
            this.tbSkillList.Text = "1,2,3,4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(16, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Skill List:";
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.numRelogDelay);
            this.gbOptions.Controls.Add(this.lblLockedMapSetting);
            this.gbOptions.Controls.Add(this.cbHandleLockedMap);
            this.gbOptions.Controls.Add(this.cmbPreset);
            this.gbOptions.Controls.Add(this.label2);
            this.gbOptions.Controls.Add(this.cbStopIf);
            this.gbOptions.Controls.Add(this.label1);
            this.gbOptions.Location = new System.Drawing.Point(166, 12);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(164, 127);
            this.gbOptions.TabIndex = 15;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // numRelogDelay
            // 
            this.numRelogDelay.Location = new System.Drawing.Point(14, 92);
            this.numRelogDelay.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numRelogDelay.Name = "numRelogDelay";
            this.numRelogDelay.Size = new System.Drawing.Size(65, 20);
            this.numRelogDelay.TabIndex = 28;
            this.numRelogDelay.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // lblLockedMapSetting
            // 
            this.lblLockedMapSetting.AutoSize = true;
            this.lblLockedMapSetting.LinkColor = System.Drawing.Color.Blue;
            this.lblLockedMapSetting.Location = new System.Drawing.Point(30, 49);
            this.lblLockedMapSetting.Name = "lblLockedMapSetting";
            this.lblLockedMapSetting.Size = new System.Drawing.Size(111, 13);
            this.lblLockedMapSetting.TabIndex = 23;
            this.lblLockedMapSetting.TabStop = true;
            this.lblLockedMapSetting.Text = "Locked Zone Handler";
            this.lblLockedMapSetting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLockedMapSetting_LinkClicked);
            // 
            // cbHandleLockedMap
            // 
            this.cbHandleLockedMap.AutoSize = true;
            this.cbHandleLockedMap.Location = new System.Drawing.Point(14, 48);
            this.cbHandleLockedMap.Name = "cbHandleLockedMap";
            this.cbHandleLockedMap.Size = new System.Drawing.Size(15, 14);
            this.cbHandleLockedMap.TabIndex = 22;
            // 
            // cmbPreset
            // 
            this.cmbPreset.FormattingEnabled = true;
            this.cmbPreset.Items.AddRange(new object[] {
            "LR",
            "LC",
            "LOO",
            "SC",
            "AP",
            "CCMD",
            "SSOT",
            "NCM",
            "TK"});
            this.cmbPreset.Location = new System.Drawing.Point(86, 91);
            this.cmbPreset.Name = "cmbPreset";
            this.cmbPreset.Size = new System.Drawing.Size(68, 21);
            this.cmbPreset.TabIndex = 21;
            this.cmbPreset.SelectedIndexChanged += new System.EventHandler(this.cmbPreset_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(83, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Skill Preset:";
            // 
            // cbStopIf
            // 
            this.cbStopIf.AutoSize = true;
            this.cbStopIf.Location = new System.Drawing.Point(14, 24);
            this.cbStopIf.Name = "cbStopIf";
            this.cbStopIf.Size = new System.Drawing.Size(144, 17);
            this.cbStopIf.TabIndex = 19;
            this.cbStopIf.Text = "Stop if failed goto 5 times";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(11, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Relog Delay:";
            // 
            // cbUnfollow
            // 
            this.cbUnfollow.AutoSize = true;
            this.cbUnfollow.Location = new System.Drawing.Point(107, 19);
            this.cbUnfollow.Name = "cbUnfollow";
            this.cbUnfollow.Size = new System.Drawing.Size(84, 17);
            this.cbUnfollow.TabIndex = 16;
            this.cbUnfollow.Text = "Unfollow (R)";
            this.cbUnfollow.CheckedChanged += new System.EventHandler(this.cbLockCell_CheckedChanged);
            // 
            // cbStopAttack
            // 
            this.cbStopAttack.AutoSize = true;
            this.cbStopAttack.Location = new System.Drawing.Point(197, 19);
            this.cbStopAttack.Name = "cbStopAttack";
            this.cbStopAttack.Size = new System.Drawing.Size(95, 17);
            this.cbStopAttack.TabIndex = 17;
            this.cbStopAttack.Text = "StopAttack (T)";
            this.cbStopAttack.CheckedChanged += new System.EventHandler(this.cbStopAttack_CheckedChanged);
            // 
            // cbEnableGlobalHotkey
            // 
            this.cbEnableGlobalHotkey.AutoSize = true;
            this.cbEnableGlobalHotkey.Location = new System.Drawing.Point(7, 19);
            this.cbEnableGlobalHotkey.Name = "cbEnableGlobalHotkey";
            this.cbEnableGlobalHotkey.Size = new System.Drawing.Size(93, 17);
            this.cbEnableGlobalHotkey.TabIndex = 18;
            this.cbEnableGlobalHotkey.Text = "Global Hotkey";
            this.cbEnableGlobalHotkey.CheckedChanged += new System.EventHandler(this.cbEnableGlobalHotkey_CheckedChanged);
            // 
            // gbAdvancedOptions
            // 
            this.gbAdvancedOptions.Controls.Add(this.numHealthPercent);
            this.gbAdvancedOptions.Controls.Add(this.lbUseHeal2);
            this.gbAdvancedOptions.Controls.Add(this.tbHealSkill);
            this.gbAdvancedOptions.Controls.Add(this.cbUseHeal);
            this.gbAdvancedOptions.Controls.Add(this.tbAttPriority);
            this.gbAdvancedOptions.Controls.Add(this.cbAttackPriority);
            this.gbAdvancedOptions.Controls.Add(this.tbBuffSkill);
            this.gbAdvancedOptions.Controls.Add(this.cbBuffIfStop);
            this.gbAdvancedOptions.Controls.Add(this.cbEnableGlobalHotkey);
            this.gbAdvancedOptions.Controls.Add(this.cbStopAttack);
            this.gbAdvancedOptions.Controls.Add(this.cbUnfollow);
            this.gbAdvancedOptions.Controls.Add(this.lbStopAttackBg);
            this.gbAdvancedOptions.Location = new System.Drawing.Point(12, 153);
            this.gbAdvancedOptions.Name = "gbAdvancedOptions";
            this.gbAdvancedOptions.Size = new System.Drawing.Size(318, 92);
            this.gbAdvancedOptions.TabIndex = 19;
            this.gbAdvancedOptions.TabStop = false;
            this.gbAdvancedOptions.Text = "Advanced Options";
            // 
            // numHealthPercent
            // 
            this.numHealthPercent.Location = new System.Drawing.Point(123, 41);
            this.numHealthPercent.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numHealthPercent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHealthPercent.Name = "numHealthPercent";
            this.numHealthPercent.Size = new System.Drawing.Size(32, 20);
            this.numHealthPercent.TabIndex = 28;
            this.numHealthPercent.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // lbUseHeal2
            // 
            this.lbUseHeal2.AutoSize = true;
            this.lbUseHeal2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbUseHeal2.Location = new System.Drawing.Point(73, 43);
            this.lbUseHeal2.Name = "lbUseHeal2";
            this.lbUseHeal2.Size = new System.Drawing.Size(50, 13);
            this.lbUseHeal2.TabIndex = 26;
            this.lbUseHeal2.Text = "if health<";
            // 
            // tbHealSkill
            // 
            this.tbHealSkill.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHealSkill.Location = new System.Drawing.Point(47, 40);
            this.tbHealSkill.Name = "tbHealSkill";
            this.tbHealSkill.Size = new System.Drawing.Size(25, 20);
            this.tbHealSkill.TabIndex = 25;
            this.tbHealSkill.Text = "1,2";
            // 
            // cbUseHeal
            // 
            this.cbUseHeal.AutoSize = true;
            this.cbUseHeal.Location = new System.Drawing.Point(7, 42);
            this.cbUseHeal.Name = "cbUseHeal";
            this.cbUseHeal.Size = new System.Drawing.Size(45, 17);
            this.cbUseHeal.TabIndex = 24;
            this.cbUseHeal.Text = "Use";
            this.cbUseHeal.CheckedChanged += new System.EventHandler(this.cbUseHeal_CheckedChanged);
            // 
            // tbAttPriority
            // 
            this.tbAttPriority.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAttPriority.Location = new System.Drawing.Point(94, 64);
            this.tbAttPriority.Name = "tbAttPriority";
            this.tbAttPriority.Size = new System.Drawing.Size(214, 20);
            this.tbAttPriority.TabIndex = 23;
            this.tbAttPriority.Text = "Defense Drone,Attack Drone";
            // 
            // cbAttackPriority
            // 
            this.cbAttackPriority.AutoSize = true;
            this.cbAttackPriority.Location = new System.Drawing.Point(7, 66);
            this.cbAttackPriority.Name = "cbAttackPriority";
            this.cbAttackPriority.Size = new System.Drawing.Size(91, 17);
            this.cbAttackPriority.TabIndex = 22;
            this.cbAttackPriority.Text = "AttackPriority:";
            this.cbAttackPriority.CheckedChanged += new System.EventHandler(this.cbAttackPriority_CheckedChanged);
            // 
            // tbBuffSkill
            // 
            this.tbBuffSkill.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBuffSkill.Location = new System.Drawing.Point(268, 40);
            this.tbBuffSkill.Name = "tbBuffSkill";
            this.tbBuffSkill.Size = new System.Drawing.Size(40, 20);
            this.tbBuffSkill.TabIndex = 21;
            this.tbBuffSkill.Text = "2,3";
            // 
            // cbBuffIfStop
            // 
            this.cbBuffIfStop.AutoSize = true;
            this.cbBuffIfStop.Location = new System.Drawing.Point(161, 42);
            this.cbBuffIfStop.Name = "cbBuffIfStop";
            this.cbBuffIfStop.Size = new System.Drawing.Size(113, 17);
            this.cbBuffIfStop.TabIndex = 20;
            this.cbBuffIfStop.Text = "Buff If StopAttack:";
            this.cbBuffIfStop.CheckedChanged += new System.EventHandler(this.cbBuffIfStop_CheckedChanged);
            // 
            // lbStopAttackBg
            // 
            this.lbStopAttackBg.AutoSize = true;
            this.lbStopAttackBg.BackColor = System.Drawing.Color.Transparent;
            this.lbStopAttackBg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStopAttackBg.Location = new System.Drawing.Point(193, 16);
            this.lbStopAttackBg.Name = "lbStopAttackBg";
            this.lbStopAttackBg.Size = new System.Drawing.Size(105, 24);
            this.lbStopAttackBg.TabIndex = 21;
            this.lbStopAttackBg.Text = "                   ";
            // 
            // timerStopAttack
            // 
            this.timerStopAttack.Tick += new System.EventHandler(this.timerStopAttack_Tick);
            // 
            // cmbGotoUsername
            // 
            this.cmbGotoUsername.BackColor = this.tbSkillList.BackColor;
            this.cmbGotoUsername.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGotoUsername.ForeColor = this.tbSkillList.ForeColor;
            this.cmbGotoUsername.FormattingEnabled = true;
            this.cmbGotoUsername.Location = new System.Drawing.Point(19, 28);
            this.cmbGotoUsername.Name = "cmbGotoUsername";
            this.cmbGotoUsername.Size = new System.Drawing.Size(135, 21);
            this.cmbGotoUsername.TabIndex = 20;
            this.cmbGotoUsername.Text = "username";
            this.cmbGotoUsername.Click += new System.EventHandler(this.cmbGotoUsername_Clicked);
            // 
            // cbWaitSkill
            // 
            this.cbWaitSkill.AutoSize = true;
            this.cbWaitSkill.Location = new System.Drawing.Point(84, 94);
            this.cbWaitSkill.Name = "cbWaitSkill";
            this.cbWaitSkill.Size = new System.Drawing.Size(70, 17);
            this.cbWaitSkill.TabIndex = 21;
            this.cbWaitSkill.Text = "Wait Skill";
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.darkLabel1.Location = new System.Drawing.Point(16, 119);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(59, 13);
            this.darkLabel1.TabIndex = 23;
            this.darkLabel1.Text = "Skill Delay:";
            // 
            // numSkillDelay
            // 
            this.numSkillDelay.Location = new System.Drawing.Point(81, 117);
            this.numSkillDelay.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numSkillDelay.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numSkillDelay.Name = "numSkillDelay";
            this.numSkillDelay.Size = new System.Drawing.Size(73, 20);
            this.numSkillDelay.TabIndex = 24;
            this.numSkillDelay.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // MaidRemake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 257);
            this.Controls.Add(this.numSkillDelay);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.cbWaitSkill);
            this.Controls.Add(this.cmbGotoUsername);
            this.Controls.Add(this.gbAdvancedOptions);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSkillList);
            this.Controls.Add(this.cbEnablePlugin);
            this.Controls.Add(this.trgtUsrnmLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MaidRemake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maid Remake 5.1";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRelogDelay)).EndInit();
            this.gbAdvancedOptions.ResumeLayout(false);
            this.gbAdvancedOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHealthPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkillDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerStopAttack;
        internal System.Windows.Forms.ComboBox cmbGotoUsername;
        private System.Windows.Forms.Label trgtUsrnmLabel;
        private System.Windows.Forms.CheckBox cbEnablePlugin;
        internal System.Windows.Forms.TextBox tbSkillList;
        private System.Windows.Forms.CheckBox cbEnableGlobalHotkey;
        private System.Windows.Forms.Label lbUseHeal2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPreset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbStopAttackBg;
        internal System.Windows.Forms.CheckBox cbWaitSkill;
        internal System.Windows.Forms.CheckBox cbHandleLockedMap;
        private System.Windows.Forms.LinkLabel lblLockedMapSetting;
        private System.Windows.Forms.Label darkLabel1;
        private System.Windows.Forms.NumericUpDown numRelogDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.CheckBox cbStopIf;
        internal System.Windows.Forms.NumericUpDown numHealthPercent;
        private System.Windows.Forms.NumericUpDown numSkillDelay;
        private System.Windows.Forms.CheckBox cbUnfollow;
        private System.Windows.Forms.CheckBox cbStopAttack;
        private System.Windows.Forms.GroupBox gbAdvancedOptions;
        internal System.Windows.Forms.TextBox tbBuffSkill;
        internal System.Windows.Forms.CheckBox cbBuffIfStop;
        private System.Windows.Forms.TextBox tbAttPriority;
        private System.Windows.Forms.CheckBox cbAttackPriority;
        internal System.Windows.Forms.CheckBox cbUseHeal;
        internal System.Windows.Forms.TextBox tbHealSkill;
    }
}