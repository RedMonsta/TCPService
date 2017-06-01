namespace CommandsLib
{
    public class AddLinkOrderToAddressCommand : ICustomCommand
    {
        public int AddrId { get; set; }
        public int OrdId { get; set; }
    }
}