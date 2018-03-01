using System;

namespace DreamHome
{
    public class HomeAd
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Rent { get; set; }
        public string ZipCode { get; set; }
        public DateTime Posted { get; set; }
    }
}