using SeaHoldemApi.Enums;
using SeaHoldemApi.Responses;
using SeaHoldemApi;
using SeaHoldemLogic.Abstraction;
using SeaHoldemLogic;
using System.Net.WebSockets;
using System.Text.Json;
using System.Text;

namespace SeaHoldemWeb
{
    public class PokerHandler : IPokerHandler
    {
        private readonly Game _game;
        private readonly ISeaLogger _logger;
        private WebSocket _socket;
        private Player _player;
        Thread _receiveThread;

        public PokerHandler(ISeaLogger logger, Game game, WebSocket socket)
        {
            _game = game;
            _logger = logger;
            _socket = socket;

            _game.GameState.EventHub.OnPlayerCardsDealt += HandlePlayerCardsDealt;
            _game.GameState.EventHub.OnCommunityCardsDealt += HandleCommunityCardsDealt;
            _game.GameState.EventHub.OnPlayerJoined += HandlePlayerJoined;
            _game.GameState.EventHub.OnPlayerLeft += HandlePlayerLeft;
            _game.GameState.EventHub.OnWinnerDeclared += HandleWinnerDeclared;
            _game.GameState.EventHub.OnPlayerPlacedBet += HandlePlayerPlacedBet;
            _game.GameState.EventHub.OnPlayerFolded += HandlePlayerFolded;
        }

        public void BindWebSocket(WebSocket socket)
        {
            _socket = socket;
            _player = new Player()
            {
                Id = 1,
                Active = false,
                Chips = 1_000_000,
                Username = "Test"
            };

            _receiveThread = new Thread(HandleMessage);
            _receiveThread.Start();

            Join(_player);
        }

        public void Join(Player player)
        {
            _game.PlayerJoined(_player);
        }

        public void Leave(Player player)
        {
            _game.PlayerLeft(_player);
        }

        public void PlaceBet(Player player, ulong chips)
        {
            _game.PlaceBet(_player, chips);
        }

        public void Fold(Player player)
        {
            _game.Fold(_player);
        }

        public async Task HandlePlayerJoined(Player player)
        {
            var playerActivity = new PlayerActivity()
            {
                Id = player.Id,
                Chips = player.Chips,
                State = PlayerState.Inactive,
                Action = PlayerAction.Join,
                Username = player.Username
            };
            await Write(MessageType.PlayerActivity, playerActivity);
        }

        public async Task HandlePlayerLeft(Player player)
        {
            var playerActivity = new PlayerActivity()
            {
                Id = player.Id,
                Chips = player.Chips,
                State = PlayerState.Inactive,
                Action = PlayerAction.Leave,
                Username = player.Username
            };
            await Write(MessageType.PlayerActivity, playerActivity);
        }

        public async Task HandlePlayerCardsDealt(ushort[] cards)
        {
            var list = cards.Select(c => new Card() { Id = c, Show = true });
            var cardSet = new CardSet()
            {
                Cards = list.ToArray(),
                CardType = CardType.Player
            };
            await Write(MessageType.CardsDealt, cards);
        }

        public async Task HandleCommunityCardsDealt(ushort[] cards)
        {
            var list = cards.Select(c => new Card() { Id = c, Show = true });
            var cardSet = new CardSet()
            {
                Cards = list.ToArray(),
                CardType = CardType.Community
            };
            await Write(MessageType.CardsDealt, cards);
        }

        public async Task HandleWinnerDeclared(Player player)
        {
            var playerActivity = new PlayerActivity()
            {
                Id = player.Id,
                Chips = player.Chips,
                State = PlayerState.Active,
                Action = PlayerAction.Winner,
                Username = player.Username
            };
            await Write(MessageType.PlayerActivity, playerActivity);
        }

        public async Task HandlePlayerPlacedBet(Player player, ulong chips)
        {
            var playerActivity = new PlayerActivity()
            {
                Id = player.Id,
                Chips = player.Chips,
                State = PlayerState.Active,
                Username = player.Username,
                Action = PlayerAction.Bet
            };

            await Write(MessageType.PlayerActivity, playerActivity);
        }

        public async Task HandlePlayerFolded(Player player)
        {
            var playerActivity = new PlayerActivity()
            {
                Id = player.Id,
                Chips = player.Chips,
                State = PlayerState.Inactive,
                Username = player.Username,
                Action = PlayerAction.Bet
            };
            await Write(MessageType.PlayerActivity, playerActivity);
        }

        private async void HandleMessage()
        {
            var buffer = new byte[1024 * 4];
            var receiveResult = await _socket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!receiveResult.CloseStatus.HasValue)
            {
                receiveResult = await _socket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await _socket.CloseAsync(
                receiveResult.CloseStatus.Value,
                receiveResult.CloseStatusDescription,
                CancellationToken.None);
        }

        private async Task Write<T>(MessageType type, T message)
        {
            var apiMessage = new SeaHoldemResponse<T>(type, message);
            var jsonString = JsonSerializer.Serialize(apiMessage);
            var buffer = Encoding.ASCII.GetBytes(jsonString);

            await _socket.SendAsync(
                new ArraySegment<byte>(buffer),
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
        }
    }
}
