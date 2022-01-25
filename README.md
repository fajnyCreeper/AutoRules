# AutoRules
AutoRules is bot that allows you to automatically assign role to your members after successfully passing Discord's built-in member screening.

## Usage
Usage is really simple and straightforward so that once you set it up, you don't have to worry about it:
1. Invite the bot to your server using [this link](https://fjne.eu/autorules-bot)
1. Go to roles settings and put the "AutoRules" role above your target role
1. Assign role to bot by using slash command: `/addrole @RoleMention`

After this you are all set up and ready to go. New members will be automatically assigned this role after passing the Member Screening.

## Support
If you encounter any errors, please [open new issue](https://github.com/fajnyCreeper/AutoRules/issues/new?assignees=&labels=bug&template=bug_report.md&title=) or contact me on [Discord](https://fjne.eu/discord)

## Selfhosting
### Prerequisites
* .NET Core 3.1
* MySQL database
* Discord bot instance

### Database
You will need to create table for storing roles using this command
```SQL
CREATE TABLE `ar_rolelist` (
 `guildId` varchar(20) NOT NULL,
 `roleId` varchar(20) NOT NULL,
 PRIMARY KEY (`guildId`)
)
```

### Config
To function, the executable needs to have `config.json` file in same directory that should be structured accordingly:
```JSON
{
  "bot_token": "DiscordBotToken",
  "database": {
    "host": "127.0.0.1",
    "database": "autorules",
    "username": "user",
    "password": "Passw0rd",
    "table": "table_name"
  }
}
```

This bot is using nightly builds of DSharpPlus. [Tutorial, how to get nightly builds.](https://dsharpplus.github.io/articles/misc/nightly_builds.html)

#### Footnote
If you are missing some things you would like to see, feel free to [open new issue](https://github.com/fajnyCreeper/AutoRules/issues/new?assignees=&labels=&template=feature_request.md&title=) or contact me on [Discord](https://fjne.eu/discord)
