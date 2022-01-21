using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AutoRules
{
    internal class Config
    {
        public string BotToken { get; }

        public ulong RoleId { get; }

        public Config(string configPath)
        {
            //load config, parse json to objects
            var configFile = JObject.Parse(File.ReadAllText(configPath));
            BotToken = configFile["bot_token"].ToString();
            RoleId = ulong.Parse(configFile["role_id"].ToString());
        }
    }
}
