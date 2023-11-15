using FakeRestApiB.Entities;

namespace FakeRestApiB.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PubliserDATA { get; set; }
        public int Pages { get; set; }
        public Author Author { get; set; }
    }
}
