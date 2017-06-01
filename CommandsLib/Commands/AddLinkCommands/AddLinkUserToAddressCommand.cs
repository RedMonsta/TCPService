namespace CommandsLib
{
    public class AddLinkUserToAddressCommand : ICustomCommand
    {
        public int AddrId { get; set; }
        public int UserId { get; set; }
    }
}
