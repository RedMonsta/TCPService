namespace CommandsLib
{
    public class RemoveLinkOrderToAddressCommand : ICustomCommand
    {
        public int AddrId { get; set; }
        public int OrdId { get; set; }
    }
}
