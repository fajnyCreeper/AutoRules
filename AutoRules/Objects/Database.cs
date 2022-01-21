using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;

namespace AutoRules.Objects
{
    internal class Database
    {
        private DatabaseConfig Config;
        private readonly MySqlConnection Connection;

        public Database(DatabaseConfig config)
        {
            Config = config;
            Connection = new MySqlConnection($"server={Config.Host};database={Config.Database};userid={Config.Username};password={Config.Password}");
        }

        public void InsertRole(JoinRole joinRole)
        {
            try
            {
                Connection.Open();

                string sqlQuery = @"INSERT INTO `ar_roleList` (`guildId`, `roleId`) VALUES (@guildId, @roleId) ON DUPLICATE KEY UPDATE `roleId`=@roleId";
                var command = new MySqlCommand(sqlQuery, Connection);

                command.Parameters.AddWithValue("@guildId", joinRole.GuildId.ToString());
                command.Parameters.AddWithValue("@roleId", joinRole.RoleId.ToString());
                command.Prepare();

                command.ExecuteNonQuery();
            }
            finally
            {
                Connection.Close();
            }
        }

#nullable enable
        public JoinRole? GetRole(ulong guildId)
        {
            try
            {
                Connection.Open();

                string sqlQuery = @"SELECT `roleId` FROM `ar_roleList` WHERE `guildId`=@guildId";
                var command = new MySqlCommand(sqlQuery, Connection);

                command.Parameters.AddWithValue("@guildId", guildId.ToString());
                command.Prepare();

                var reader = command.ExecuteReader();
                if (!reader.HasRows)
                    return null;

                reader.Read();
                var roleId = ulong.Parse(reader.GetString(0));
                var role = new JoinRole(guildId, roleId);


                return role;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
#nullable disable
        
    }
}
