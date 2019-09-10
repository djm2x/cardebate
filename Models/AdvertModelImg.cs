namespace mvc
{
    public class AdvertModelImg
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int IdAdvert { get; set; }
        public Advert Advert { get; set; }
    }
}