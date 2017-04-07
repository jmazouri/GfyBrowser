using Discord;
using Discord.Addons.Paginator;
using Discord.Commands;
using Gfycat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GfyBrowser.App
{
    public class GfyModule : ModuleBase
    {
        private readonly PaginationService paginator;
        private GfycatClient gfyClient;

        public GfyModule(PaginationService paginationService, GfycatClientConfig configService)
        {
            paginator = paginationService;
            gfyClient = new GfycatClient(configService);
        }

        [Command("browse")]
        [RequireBotPermission(ChannelPermission.ManageMessages | ChannelPermission.AddReactions)]
        public async Task BrowseGfys([Remainder]string query)
        {
            var searchResult = await gfyClient.SearchAsync(query);

            var gfys = searchResult.ToEnumerable().Take(10);
            await SendGfys("Results for " + query, gfys);            
        }

        [Command("trending")]
        public async Task TrendingGfys()
        {
            var searchResult = await gfyClient.GetTrendingGfysAsync();

            var gfys = searchResult.ToEnumerable().Take(25);
            await SendGfys("Trending Gfys", gfys);
        }

        private async Task SendGfys(string title, IEnumerable<Gfy> gfys)
        {
            var gfyUrls = gfys.Select(d => "https://gfycat.com/" + d.Name).ToList().AsReadOnly();

            var message = new PaginatedMessage(gfyUrls, title, Context.User);

            await paginator.SendPaginatedMessageAsync(Context.Channel, message);
        }
    }
}
