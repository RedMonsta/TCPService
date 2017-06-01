namespace CommandsLib
{
    public class AddAddressCommand : ICustomCommand
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Build { get; set; }
        public int Flat { get; set; }
    }
}
