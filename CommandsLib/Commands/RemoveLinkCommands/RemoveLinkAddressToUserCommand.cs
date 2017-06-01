namespace CommandsLib
{
    public class RemoveLinkAddressToUserCommand : ICustomCommand
    {
        public int AddrId { get; set; }
        public int UserId { get; set; }
    }
}
