using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using AutoRules.Objects;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;

namespace AutoRules
{
    internal class SlashCommands : ApplicationCommandModule
    {
        public static Config _config = new Config(@"config.json");
        public static Database _database = new Database(_config.Database);

        [SlashCommand("addrole", "Add role to auto-assign after passing member screening")]
        public async Task AddRole(InteractionContext ctx, [Option("role", "Role to assign")] DiscordRole role)
        {
            try
            {
                await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);
                JoinRole joinRole = null;
                foreach (var option in ctx.Interaction.Data.Options)
                {
                    if (option.Name == "role")
                        joinRole = new JoinRole(ctx.Guild.Id, ulong.Parse(option.Value.ToString()));
                }
                _database.InsertRole(joinRole);

                await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"Successfully added role!"));
            }
            catch (Exception)
            {
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"There was an error adding a role!"));
            }
            
        }

    }
}
