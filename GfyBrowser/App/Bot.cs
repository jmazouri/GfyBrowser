using Discord;
using Discord.Addons.Paginator;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GfyBrowser
{
    public class Bot
    {
        public async Task Start(JsonConfiguration config, Gfycat.GfycatClientConfig gfyConfig)
        {
            DiscordSocketClient discordClient = new DiscordSocketClient();

            CommandHandler handler = new CommandHandler();

            DependencyMap map = new DependencyMap();
            map.Add(gfyConfig);
            map.Add(discordClient);
            discordClient.UsePaginator(map);

            await handler.Install(map);

            await discordClient.LoginAsync(TokenType.Bot, config.BotToken);
            await discordClient.StartAsync();

            Console.WriteLine("Bot Initialized");

            await Task.Delay(-1);
        }
    }
}
