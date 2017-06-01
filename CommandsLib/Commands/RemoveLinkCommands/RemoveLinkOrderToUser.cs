namespace CommandsLib
{
    public class RemoveLinkOrderToUserCommand : ICustomCommand
    {
        public int OrdId { get; set; }
        public int UserId { get; set; }
    }
}
