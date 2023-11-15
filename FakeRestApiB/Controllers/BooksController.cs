using AutoMapper;
using FakeRestApiB.DTOs;
using FakeRestApiB.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FakeRestApiB.Controllers
{
    [ApiController]
    [Route("Api/Books")]
    [EnableCors("MyPolicy")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BooksController(ApplicationDbContext context,
          IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("ListBooks")]
        public async Task<ActionResult<List<BookDTO>>> ListBooks()
        {
            var booklist = await context.Books.Include(x => x.Author).Include(x => x.Picture).ToListAsync();
            var booksDto = mapper.Map<List<BookDTO>>(booklist);

            return Ok(booksDto);

        }

        [HttpGet("{id}", Name = "getBookId")]
        public async Task<ActionResult<List<BookDTO>>> GetBooksById(int id)
        {
            var bookById = await context.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == id);
            if (bookById == null)
            {
                return NotFound();
            }

            var bookDTO = mapper.Map<BookDTO>(bookById);

            return Ok(bookDTO);
        }

        [HttpPost]

        public async Task<ActionResult<BookDTO>> AddBook([FromBody] AddBookDTO addBook)
        {
            var AddBook = mapper.Map<Book>(addBook);
            context.Add(AddBook);
            var AddBookDto = mapper.Map<BookDTO>(AddBook);
            await context.SaveChangesAsync();

            return new CreatedAtRouteResult("getBookId", new { id = AddBookDto.Id }, AddBookDto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id,[FromBody] AddBookDTO addbook)
        {
            var AddBookU = mapper.Map<Book>(addbook);

            AddBookU.Id = id;

            context.Entry(AddBookU).State = EntityState.Modified;
            await context.SaveChangesAsync();
            
            return Ok();    
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var Bexists = await context.Books.AnyAsync(x => x.Id == id);

            if (!Bexists)
            {
                return NotFound();
            }

            context.Remove(new Book() { Id = id });
            await context.SaveChangesAsync();

            return Ok();

        }


    }
}
