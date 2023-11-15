namespace FakeRestApiB.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PubliserDATA { get; set; }
        public int Pages { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public  Picture Picture { get; set; }
    }
}
