namespace CommandsLib
{
    public class AddLinkAddressToUserCommand : ICustomCommand
    {
        public int AddrId { get; set; }
        public int UserId { get; set; }
    }
}

