using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaidRemake.LockedMapHandle;
using RBot;
using RBot.Factions;
using RBot.Flash;
using RBot.Items;
using RBot.Monsters;
using RBot.Options;
using RBot.PatchProxy;
using RBot.Players;
using RBot.Plugins;
using RBot.Quests;
using RBot.Servers;
using RBot.Skills;
using RBot.Utils;

namespace MaidRemake
{
    public partial class MaidRemake : Form
    {
        public static MaidRemake Instance { get; } = new MaidRemake();

        private ScriptInterface bot = ScriptInterface.Instance;

        public string targetUsername => MaidRemake.Instance.cmbGotoUsername.Text.ToLower();

        public bool isPlayerInMyRoom => IsPlayerInMap(targetUsername);

        public int skillDelay => (int)MaidRemake.Instance.numSkillDelay.Value;

        LowLevelKeyboardHook kbh = new LowLevelKeyboardHook();

        public JumpHandler jumpHandler = new JumpHandler();

        public WarningHandler warningHandler = new WarningHandler();

        private int healthPercent => (int)MaidRemake.Instance.numHealthPercent.Value;

        int[] buffSkill = null;
        int buffIndex = 0;

        int[] healSkill = null;
        int healIndex = 0;

        string[] monsterList = null;

        Stopwatch stopwatch = new Stopwatch();

        public MaidRemake()
        {
            InitializeComponent();

            KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.hotkey);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private async void cbEnablePlugin_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnablePlugin.Checked)
            {
                startUI();
                Task.Run(() => doMaid());
            }
            else
            {
                stopMaid();
            }
        }

        private async void doMaid()
        {
            bot.Options.SafeTimings = false;
            bot.Options.InfiniteRange = true;
            bot.Options.SkipCutscenes = true;
            bot.Options.LagKiller = true;
            bot.Options.DisableFX = true;

            int gotoTry = 0;

            int[] skillList = tbSkillList.Text.Split(',').Select(int.Parse).ToArray();
            int skillIndex = 0;

            if (cbHandleLockedMap.Checked && AlternativeMap.Count() > 0)
                AlternativeMap.Init();
            else if (cbHandleLockedMap.Checked)
                cbHandleLockedMap.Checked = false;

            FlashUtil.FlashCall += warningHandler.Handle;

            if (!cbUnfollow.Checked)
                FlashUtil.FlashCall += jumpHandler.Handle;

            if (!cbUnfollow.Checked && bot.Player.LoggedIn && bot.Map.Loaded && isPlayerInMyRoom)
                bot.Player.Goto(targetUsername);

            while (cbEnablePlugin.Checked)
            {
                try
                {
                    // while player is logout -> do delay (2s), wait first join, do first join delay
                    if (cbEnablePlugin.Checked && !bot.Player.LoggedIn)
                        await waitForFirstJoin();

                    // plugin disabled
                    if (!cbEnablePlugin.Checked)
                        return;

                    // starting the plugin
                    if ((isPlayerInMyRoom || cbUnfollow.Checked) && bot.Player.LoggedIn && bot.Map.Loaded)
                    {
                        gotoTry = 0;

                        if (!bot.Player.Alive)
                        {
                            skillIndex = 0;
                            bot.Player.SetSpawnPoint(bot.Player.Cell, bot.Player.Pad);
                            await Task.Delay(500);
                            continue;
                        }

                        if (cbUseHeal.Checked && tbHealSkill.Text != String.Empty && isHealthUnder(healthPercent))
                        {
                            bot.Player.UseSkill(healSkill[healIndex]);
                            healIndex++;

                            if (healIndex >= healSkill.Length)
                                healIndex = 0;

                            await Task.Delay(skillDelay);
                            continue;
                        }

                        if (cbStopAttack.Checked)
                        {
                            if (bot.Player.HasTarget)
                                bot.Player.CancelTarget();

                            if (cbBuffIfStop.Checked && tbBuffSkill.Text != String.Empty && isPlayerInCombat())
                            {
                                bot.Player.UseSkill(buffSkill[buffIndex]);
                                buffIndex++;

                                if (buffIndex >= buffSkill.Length)
                                    buffIndex = 0;
                            }

                            await Task.Delay(skillDelay);
                            continue;
                        }

                        if (cbAttackPriority.Checked)
                            doPriorityAttack();

                        if (isAnyMonsterExists() && !bot.Player.HasTarget)
                            bot.Player.Attack("*");

                        if (cbWaitSkill.Checked && (!bot.Player.CanUseSkill(skillList[skillIndex]) || !bot.Player.HasTarget))
                        {
                            await Task.Delay(150);
                            continue;
                        }

                        //if (bot.Player.CanUseSkill(skillList[skillIndex]))
                            bot.Player.UseSkill(skillList[skillIndex]);

                        skillIndex++;

                        if (skillIndex >= skillList.Length)
                            skillIndex = 0;
                    }
                    else if (bot.Player.LoggedIn && bot.Map.Loaded)
                    {
                        gotoTarget(targetUsername);
                        if (cbStopIf.Checked)
                        {
                            gotoTry++;
                            if (gotoTry >= 5)
                            {
                                gotoTry = 0;
                                stopMaid();
                            }
                        }

                        // wait loading screen before try to goto again (max: 5100 ms)
                        for (int i = 0; i < 36 && cbEnablePlugin.Checked && bot.Player.LoggedIn && bot.Map.Loaded; i++)
                            await Task.Delay(150);

                        // wait map loading end
                        while (cbEnablePlugin.Checked && bot.Player.LoggedIn && !bot.Map.Loaded)
                            await Task.Delay(500);

                        // wait 2 second before try to goto or join to different map (when locked map handler is enabled)
                        for (int i = 0; i < 8 && cbEnablePlugin.Checked && cbHandleLockedMap.Checked && bot.Player.LoggedIn && bot.Map.Loaded; i++)
                            await Task.Delay(250);

                        // goto target current cell when in the same room
                        //while (cbEnablePlugin.Checked && bot.Player.LoggedIn && isPlayerInMyRoom && !isPlayerInMyCell)
                        //{
                        //    bot.Player.Goto(targetUsername);
                        //    if (cbEnablePlugin.Checked && bot.Player.LoggedIn && isPlayerInMyRoom && !isPlayerInMyCell)
                        //        await Task.Delay(1000);
                        //    else break;
                        //}
                        bot.Player.Goto(targetUsername);
                    }

                    await Task.Delay(skillDelay);
                }
                catch { }
            }
        }

        private bool isAnyMonsterExists()
        {
            if (bot.Monsters.CurrentMonsters.Count <= 0) return false;
            foreach(Monster m in bot.Monsters.CurrentMonsters)
            {
                if (bot.Monsters.Exists(m.Name))
                    return true;
            }
            return false;
        }

        private async Task waitForFirstJoin()
        {
            // wait player to join the map
            while (cbEnablePlugin.Checked && !bot.Player.LoggedIn && !bot.Map.Loaded)
                await Task.Delay(2000);

            // do first join delay
            if (cbEnablePlugin.Checked)
                await Task.Delay((int)numRelogDelay.Value);
        }

        private void doPriorityAttack()
        {
            for(int i = 0; i < monsterList.Length; i++)
            {
                if(bot.Monsters.Exists(monsterList[i]))
                {
                    bot.Player.Attack(monsterList[i]);
                    return;
                }
            }
        }

        private bool isPlayerInCombat()
        {
            return (bot.Player.State == 2 ? true : false);
        }

        private bool IsPlayerInMap (string targetUsername)
        {
            foreach (string player in bot.Map.PlayerNames)
            {
                if (player.ToLower() == targetUsername)
                    return true;
            }
            return false;
        }

        private bool isHealthUnder(int percentage)
        {
            int healthBoundary = bot.Player.MaxHealth * percentage / 100;
            return bot.Player.Health <= healthBoundary ? true : false;
        }

        private void gotoTarget(string targetUsername)
        {
            if (bot.Player.State != 1) // if state isnt idle
                bot.Player.Jump("Blank", "Spawn");
            bot.Player.Goto(targetUsername);
        }

        /* UI state */

        public void startUI()
        {
            cmbGotoUsername.Enabled = false;
            tbSkillList.Enabled = false;
            gbOptions.Enabled = false;
            if (LockedMapForm.Instance.Visible)
            {
                if (LockedMapForm.Instance.WindowState == FormWindowState.Minimized)
                    LockedMapForm.Instance.WindowState = FormWindowState.Normal;
                LockedMapForm.Instance.Hide();
            }
        }

        public void stopMaid()
        {
            FlashUtil.FlashCall -= warningHandler.Handle;
            FlashUtil.FlashCall -= jumpHandler.Handle;
            cmbGotoUsername.Enabled = true;
            tbSkillList.Enabled = true;
            gbOptions.Enabled = true;
            cbEnablePlugin.Checked = false;
        }

        /* Hotkey */

        private void cbEnableGlobalHotkey_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableGlobalHotkey.Checked)
            {
                kbh.OnKeyPressed += globalHotkey;
                kbh.OnKeyUnpressed += (s, ek) => { };
                this.KeyDown -= hotkey;

                kbh.HookKeyboard();
            }
            else
            {
                kbh.OnKeyPressed -= globalHotkey;
                kbh.OnKeyUnpressed -= (s, ek) => { };
                this.KeyDown += new KeyEventHandler(this.hotkey);

                kbh.UnHookKeyboard();
            }
        }

        private void hotkey(object sender, KeyEventArgs e)
        {
            if (cmbGotoUsername.Focused || tbAttPriority.Focused)
                return;

            if (e.KeyCode == Keys.R)
            {
                // LockCell: R
                e.SuppressKeyPress = true;
                cbUnfollow.Checked = cbUnfollow.Checked ? false : true;
            }
            else if (e.KeyCode == Keys.T)
            {
                // StopAttack: T
                e.SuppressKeyPress = true;
                cbStopAttack.Checked = cbStopAttack.Checked ? false : true;
            }
        }
        private void globalHotkey(object sender, Keys e)
        {
            if (cmbGotoUsername.Focused || tbAttPriority.Focused)
                return;

            if (e == Keys.R)
            {
                // LockCell: R
                cbUnfollow.Checked = cbUnfollow.Checked ? false : true;
            }
            else if (e == Keys.T)
            {
                // StopAttack: T
                cbStopAttack.Checked = cbStopAttack.Checked ? false : true;
            }
        }

        /* Other Control */

        private void cbLockCell_CheckedChanged(object sender, EventArgs e)
        {
            if(cbUnfollow.Checked)
                FlashUtil.FlashCall -= jumpHandler.Handle;
            else
                FlashUtil.FlashCall += jumpHandler.Handle;
        }

        private void cbStopAttack_CheckedChanged(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (cbStopAttack.Checked)
                {
                    lbStopAttackBg.BackColor = System.Drawing.Color.DeepPink;
                    stopwatch.Reset();
                    stopwatch.Start();
                    timerStopAttack.Enabled = true;
                    cbStopAttack.BackColor = System.Drawing.Color.Magenta;
                    if (bot.Player.HasTarget)
                        bot.Player.CancelTarget();
                    bot.Player.Rest();
                }
                else
                {
                    lbStopAttackBg.BackColor = System.Drawing.Color.Transparent;
                    stopwatch.Stop();
                    this.Text = "Maid Remake";
                    timerStopAttack.Enabled = false;
                    cbStopAttack.BackColor = System.Drawing.SystemColors.Control;
                }
            });
        }

        private void cbUseHeal_CheckedChanged(object sender, EventArgs e)
        {
            if (tbHealSkill.Text == String.Empty)
            {
                cbUseHeal.Checked = false;
                return;
            }

            if (cbUseHeal.Checked)
            {
                tbHealSkill.Enabled = false;
                numHealthPercent.Enabled = false;
                healSkill = tbHealSkill.Text.Split(',').Select(int.Parse).ToArray();
            }
            else
            {
                tbHealSkill.Enabled = true;
                numHealthPercent.Enabled = true;
            }
        }

        private void cbBuffIfStop_CheckedChanged(object sender, EventArgs e)
        {
            if (tbBuffSkill.Text == String.Empty)
            {
                cbBuffIfStop.Checked = false;
                return;
            }

            if (cbBuffIfStop.Checked)
            {
                tbBuffSkill.Enabled = false;
                buffSkill = MaidRemake.Instance.tbBuffSkill.Text.Split(',').Select(int.Parse).ToArray();
                buffIndex = 0;
            }
            else
            {
                tbBuffSkill.Enabled = true;
            }
        }

        private void cbAttackPriority_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAttackPriority.Checked)
            {
                monsterList = MaidRemake.Instance.tbAttPriority.Text.Split(',');
                tbAttPriority.Enabled = false;
            }
            else
            {
                tbAttPriority.Enabled = true;
            }
        }

        private void timerStopAttack_Tick(object sender, EventArgs e)
        {
            this.Text = $"Maid Remake ({string.Format("{0:hh\\:mm\\:ss}", stopwatch.Elapsed)})";
        }

        private void cmbPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassPreset.cbClear();
            switch (cmbPreset.SelectedItem.ToString())
            {
                case "LR":
                    ClassPreset.LR();
                    break;
                case "LC":
                    ClassPreset.LC();
                    break;
                case "LOO":
                    ClassPreset.LOO();
                    break;
                case "SC":
                    ClassPreset.SC();
                    break;
                case "AP":
                    ClassPreset.AP();
                    break;
                case "CCMD":
                    ClassPreset.CCMD();
                    break;
                case "SSOT":
                    ClassPreset.SSOT();
                    break;
                case "NCM":
                    ClassPreset.NCM();
                    break;
                case "TK":
                    ClassPreset.TK();
                    break;
            }
            ClassPreset.cbSet();
        }

        // get username in cell
        private void cmbGotoUsername_Clicked(object sender, EventArgs e)
        {
            if (!bot.Map.Loaded)
                return;
            cmbGotoUsername.Items.Clear();
            foreach(string player in bot.Map.PlayerNames)
                cmbGotoUsername.Items.Add(player);
        }

        private void lblLockedMapSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LockedMapForm.Instance.Visible || LockedMapForm.Instance.WindowState == FormWindowState.Minimized)
            {
                LockedMapForm.Instance.WindowState = FormWindowState.Normal;
                LockedMapForm.Instance.Hide();
            }
            else if (!LockedMapForm.Instance.Visible)
            {
                LockedMapForm.Instance.StartPosition = FormStartPosition.CenterParent;
                LockedMapForm.Instance.ShowDialog(this);
            }
        }
    }
}
