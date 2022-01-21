using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoRules.Objects;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;

namespace AutoRules
{
    class Program
    {
        static void Main(string[] args)
            => MainAsync().GetAwaiter().GetResult();

        static async Task MainAsync()
        {
            var config = new Config(@"config.json");

            /*
             * Pre-release build only:
             * Role ID is stored in config, in future, database will be utilized for storing multiple guilds and roles
             * No command is registered at the moment, but slash commands will be used to register role to be granted
             * If role is registered and command is fired again, it will overwrite currently registered role
             */

            var discord = new DiscordClient(new DiscordConfiguration() 
            {
                Token = config.BotToken,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.GuildMembers,

#if DEBUG
                MinimumLogLevel = LogLevel.Debug
#endif
            });

            discord.GuildMemberUpdated += (sender, e) =>
            {
                _ = Task.Run(async () =>
                {
                    if (e.PendingBefore.HasValue && e.PendingAfter.HasValue && e.PendingBefore.Value && !e.PendingAfter.Value)
                    {
                        var database = new Database(config.Database);
                        var resultRole = database.GetRole(e.Guild.Id);
                        if (resultRole != null)
                        {
                            var role = e.Guild.GetRole(resultRole.RoleId);
                            await e.Member.GrantRoleAsync(role);
                        }
                    }
                });

                return Task.CompletedTask;
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
