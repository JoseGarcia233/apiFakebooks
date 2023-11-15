namespace FakeRestApiB.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public string UrlPicture { get; set; }
        public int ?BookId { get; set; }
        public Book Book { get; set; }
        
    }
}
