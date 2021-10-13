using System;
using System.Collections.Generic;
using RBot;
using RBot.Plugins;
using RBot.Options;
using System.Windows.Forms;
using MaidRemake.LockedMapHandle;
using RBot.Flash;

namespace MaidRemake
{
    public class RLoader : RPlugin
    {
        public override string Name => "Maid Remake 5.1";
        public override string Author => "Afif_Sapi, Froztt13";
        public override string Description => "Battle maid to help your battle!\r\n" +
            "This plugin will auto follow 'Goto Username' then attack and kill any monster.";

        private ToolStripMenuItem menuItem;

        public override void Load()
        {
            // Called when the plugin is loaded.
            Bot.Log("Maid Remake plugin lodaed.");

            // Create a Menu Item  
            menuItem = (ToolStripMenuItem) Forms.Main.MainMenu.Items.Add("Maid(R)");
            menuItem.Click += MenuStripItem_Click;
        }

        public override void Unload()
        {
            // Called when the plugin is unloaded.
            Bot.Log("Maid Remake plugin unlodaed.");

            // Clean everything up
            FlashUtil.FlashCall -= MaidRemake.Instance.warningHandler.Handle;
            FlashUtil.FlashCall -= MaidRemake.Instance.jumpHandler.Handle;
            menuItem.Click -= MenuStripItem_Click;
            Forms.Main.MainMenu.Items.Remove(menuItem);
            LockedMapForm.Instance.Dispose();
            MaidRemake.Instance.Dispose();
        }

        private void MenuStripItem_Click(object sender, EventArgs e)
        {
            if (MaidRemake.Instance.Visible)
            {
                MaidRemake.Instance.Hide();
            }
            else
            {
                MaidRemake.Instance.Show();
                MaidRemake.Instance.BringToFront();
            }
        }

        // Misc
        //public static TestPlugin Instance => this.Bot;
        public override List<IOption> Options => new List<IOption>();

    }
}
