using SeaHoldemApi.Enums;

namespace SeaHoldemApi
{
    [Serializable]
    public class SeaHoldemResponse<TMessage>
    {
        public MessageType MessageType { get; set; }
        public TMessage Message { get; set; }

        public SeaHoldemResponse(MessageType type, TMessage message)
        {
            MessageType = type;
            Message = message;
        }
    }
}
