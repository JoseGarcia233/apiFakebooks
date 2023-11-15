using FakeRestApiB.Entities;

namespace FakeRestApiB.DTOs
{
    public class PictureDTO
    {
        public int Id { get; set; }
        public string UrlPicture { get; set; }
        public Book Book { get; set; }
    }
}
