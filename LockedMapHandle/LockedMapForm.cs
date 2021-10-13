using RBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaidRemake.LockedMapHandle
{
    public partial class LockedMapForm : Form
    {
        public static LockedMapForm Instance { get; } = new LockedMapForm();

        private ScriptInterface bot = ScriptInterface.Instance;

        public List<string> getAlternativeMap => getMaps();

        private Random rand = new Random();

        public LockedMapForm()
        {
            InitializeComponent();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void btnGrabMap_Click(object sender, EventArgs e)
        {
            if (bot.Player.LoggedIn && bot.Map.Loaded)
            {
                Task.Run(() =>
                {
                    string getMapInfo = $"{bot.Map.Name}-{rand.Next(1000, 99999)}";
                    tbGrabMapResult.Text = $"{getMapInfo};{bot.Player.Cell};{bot.Player.Pad}";
                });
            }
            else
            {
                tbGrabMapResult.Text = String.Empty;
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (tbGrabMapResult.Text != String.Empty)
            {
                tbLockedMapAlternative.Text += tbLockedMapAlternative.Text == String.Empty ? String.Empty : "\r\n";
                tbLockedMapAlternative.Text += tbGrabMapResult.Text;
            }
        }

        private List<string> getMaps()
        {
            Regex rgx = new Regex("[^a-zA-Z0-9\\-\\;\\r\\n]");
            string clearText = rgx.Replace(tbLockedMapAlternative.Text, String.Empty);
            string[] lines = clearText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            List<string> maps = new List<string>();
            foreach (string line in lines)
            {
                string mapName;
                string cellName = "Enter";
                string padName = "Spawn";

                string[] mapInfo = line.Split(';');
                if (mapInfo[0].Contains('-'))
                {
                    string[] tempMap = mapInfo[0].Split('-');
                    if (tempMap[1].Contains('e'))
                        tempMap[1] = new Random().Next(9999, 99999).ToString();
                    else if (tempMap[1] == "0" || tempMap[1] == String.Empty)
                        tempMap[1] = "1";
                    mapName = $"{tempMap[0]}-{tempMap[1]}";
                }
                else
                {
                    mapName = mapInfo[0];
                }
                try { cellName = mapInfo[1] == String.Empty ? "Enter" : mapInfo[1]; }
                catch { }
                try { padName = mapInfo[2] == String.Empty ? "Spawn" : mapInfo[2]; }
                catch { }
                maps.Add($"{mapName};{cellName};{padName}");
            }
            return maps;
        }

        private void tbLockedMapAlternative_TextChanged(object sender, EventArgs e)
        {
            lbCounter.Text = "Number of map(s): " + getMaps().Count.ToString();
        }

        private void lblCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (getMaps().Count <= 0)
                return;

            List<string> maps = getMaps();
            string formattedMap =
                "Unspecified cell/pad will set to Spawn/Enter,\r\n" +
                "The empty line & space will be ignored, etc.\r\n" +
                "(It will goto target when you're in the same map)\r\n\r\n";
            int counter = 1;
            foreach (string map in maps)
            {
                string[] mapInfo = map.Split(';');
                formattedMap += $"({counter}) map:{mapInfo[0]}, cell:{mapInfo[1]}, pad:{mapInfo[2]}\r\n";
                counter++;
            }
            MessageBoxEx.Show(this, formattedMap, "Parsing Result");
        }

        private void lblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbLockedMapAlternative.Text = String.Empty;
        }
    }
}
