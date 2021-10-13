using AxShockwaveFlashObjects;
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
    public class JumpHandler
    {
        private string targetUsername => MaidRemake.Instance.cmbGotoUsername.Text.ToLower();

        private ScriptInterface bot = ScriptInterface.Instance;

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

                if (command == "uotls")
                {
                    // current Username
                    string currUsername = dataObj[2]?.Value<string>();
                    string currPosition = dataObj[3]?.Value<string>();

                    if (currPosition.StartsWith("strPad:") && (currUsername == targetUsername) && bot.Map.Loaded)
                    {
                        // strPad:Spawn (0), tx:0 (1), strFrame:Enter (2), ty:0 (3)
                        string targetPad = currPosition.Split(',')[0].Split(':')[1];

                        // strPad:Spawn (0), tx:0 (1), strFrame:Enter (2), ty:0 (3)
                        string targetFrame = currPosition.Split(',')[2].Split(':')[1];

                        bot.Player.Jump(targetFrame, targetPad);
                    }
                }
            }
            catch { }
        }
    }
}
