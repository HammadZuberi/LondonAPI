namespace LondonAPI.Models
{
    public class HotelInfo : Resource
    {
        public string Title { get; set; } = string.Empty;
        public string TagLine { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public Address Location { get; set; }

    }

    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

    }
}
