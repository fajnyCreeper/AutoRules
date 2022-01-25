using System.IO;
using Newtonsoft.Json.Linq;

namespace AutoRules.Objects
{
    internal class Config
    {
        public string BotToken { get; }
        public DatabaseConfig Database { get; }

        public Config(string configPath)
        {
            //load config, parse json to objects
            var configFile = JObject.Parse(File.ReadAllText(configPath));
            BotToken = configFile["bot_token"].ToString();

            var dbConfig = configFile["database"];
            Database = new DatabaseConfig(dbConfig["host"].ToString(), dbConfig["database"].ToString(), dbConfig["username"].ToString(), dbConfig["password"].ToString(), dbConfig["table"].ToString());
        }
    }
}
