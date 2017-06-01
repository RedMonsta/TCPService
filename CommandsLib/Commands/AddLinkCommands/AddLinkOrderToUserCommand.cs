namespace CommandsLib
{
    public class AddLinkOrderToUserCommand : ICustomCommand
    {
        public int OrdId { get; set; }
        public int UserId { get; set; }
    }
}