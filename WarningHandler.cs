using AxShockwaveFlashObjects;
using MaidRemake.LockedMapHandle;
using Newtonsoft.Json.Linq;
using RBot;
using RBot.GameProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaidRemake
{
    public class WarningHandler
    {
        private ScriptInterface bot = ScriptInterface.Instance;
        private string targetUsername => MaidRemake.Instance.cmbGotoUsername.Text.ToLower();
        private bool isLockedMapHandlerEnabled => MaidRemake.Instance.cbHandleLockedMap.Checked;

        public void Handle(AxShockwaveFlash flash, string function, object[] args)
        {
            /*  function: "pext", "packet"
             *      "packet" = xt packet
             *      "pext" = hardcore js packet (contains type: json / str)
             *  args: one element of object (only save the packet at args[0])
             *  raw: args[0].ToString();
             */
            try
            {
                // pext or packet
                string raw = args[0].ToString();
                if (function != "pext" || !raw.StartsWith("{"))
                    return;

                // pext: str or json
                JToken obj = JObject.Parse(raw);
                string type = obj?["params"]?["type"]?.Value<string>();
                if (type != "str")
                    return;

                // str pext: get command
                JArray dataObj = (JArray)obj?["params"]?["dataObj"];
                string command = dataObj[0].Value<string>();

                if (command == "warning")
                {
                    string warningMsg = dataObj[2].Value<string>();
                    bot.Log("Warning: " + warningMsg);

                    if (isLockedMapHandlerEnabled && warningMsg.Contains("Cannot goto to player in a Locked zone.") && bot.Player.LoggedIn)
                    {
                        JoinAltMap();
                    }
                    else if (bot.Player.LoggedIn && bot.Map.Name != "whitemap")
                    {
                        if (warningMsg.Contains("Cannot goto to player in a Locked zone.") && bot.Player.LoggedIn)
                        {
                            GotoSafeMap();
                        }
                        else if (warningMsg.Contains("Room join failed, destination room is full.") && bot.Player.LoggedIn)
                        {
                            GotoSafeMap();
                        }
                        else if (warningMsg.Contains($"Player '{targetUsername}' could not be found.") && bot.Player.LoggedIn)
                        {
                            GotoSafeMap();
                        }
                    }
                }
            }
            catch { }
        }

        private async void JoinAltMap()
        {
            await Task.Delay(new Random().Next(250, 750));
            string[] mapInfo = AlternativeMap.GetNext().Split(';');
            Task.Run(() => bot.Player.Join(mapInfo[0], mapInfo[1], mapInfo[2], true));
        }

        private async void GotoSafeMap()
        {
            await Task.Delay(new Random().Next(250, 750));
            Task.Run(() => bot.Player.Join($"whitemap-{new Random().Next(9999, 99999)}", "Enter", "Spawn", true));
        }
    }
}
