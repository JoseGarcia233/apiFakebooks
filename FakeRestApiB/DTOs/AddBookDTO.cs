namespace FakeRestApiB.DTOs
{
    public class AddBookDTO
    {
        public string Title { get; set; }
        public DateTime PubliserDATA { get; set; }
        public int Pages { get; set; }
        public int AuthorId { get; set; }
    }
}
