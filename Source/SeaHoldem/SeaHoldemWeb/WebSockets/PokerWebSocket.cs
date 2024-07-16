using Microsoft.AspNetCore.Mvc;
using SeaHoldemApi;
using SeaHoldemApi.Enums;
using SeaHoldemApi.Responses;
using SeaHoldemLogic;
using SeaHoldemLogic.Abstraction;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json.Serialization;

namespace SeaHoldemWeb.WebSockets
{
    // ref https://learn.microsoft.com/en-us/aspnet/core/fundamentals/websockets?view=aspnetcore-8.0
    /// <summary>Feeds generic Poker game data</summary>
    [ApiController]
    public class PokerWebSocket : ControllerBase
    {
        private readonly ISeaLogger _logger;
        private readonly Game _game;

        public PokerWebSocket(ISeaLogger logger, Game game)
        {
            _logger = logger;
            _game = game;
        }

        [Route("/game")]
        public async Task Connect()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                var socketFinishedTcs = new TaskCompletionSource<object>();

                var handler = new PokerHandler(_logger, _game, webSocket);
                handler.BindWebSocket(webSocket);

                await socketFinishedTcs.Task;
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}
