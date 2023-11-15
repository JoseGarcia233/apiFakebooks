namespace FakeRestApiB.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public int? IdBook { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; }
    }
}
