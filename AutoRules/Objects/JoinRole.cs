using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRules.Objects
{
    internal class JoinRole
    {
        public ulong GuildId { get; }

        public ulong RoleId { get; }

        public JoinRole(ulong guildId, ulong roleId)
        {
            GuildId = guildId;
            RoleId = roleId;
        }
    }
}
