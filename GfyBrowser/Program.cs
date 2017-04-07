using Discord;
using Discord.WebSocket;
using Gfycat;
using System;
using System.Threading.Tasks;

namespace GfyBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Bot...");

            var config = new JsonConfiguration("config.json");
            config.Load();

            var gfyConfig = new GfycatClientConfig(config.GfyClientId, config.GfySecret);

            new Bot().Start(config, gfyConfig).GetAwaiter().GetResult();
        }
    }
}