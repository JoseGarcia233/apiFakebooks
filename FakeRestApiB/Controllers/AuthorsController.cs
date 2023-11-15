using AutoMapper;
using FakeRestApiB.DTOs;
using FakeRestApiB.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FakeRestApiB.Controllers
{
    [ApiController]
    [Route("api/authors")]
    [EnableCors("MyPolicy")]
    public class AuthorsController : ControllerBase
    {
         private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AuthorsController(ApplicationDbContext context,
         IMapper mapper  )
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("listAuthors")]
        public  async Task<ActionResult<List<AuthorDTO>>> author()
        {
            var entities = await context.Authors.ToListAsync();
             
            var AuthorsDto =  mapper.Map<List<AuthorDTO>>(entities);
            return Ok(AuthorsDto);
        }

        [HttpGet("{id}", Name = "getAuhtorId")]
        public async Task<ActionResult<List<AuthorDTO>>> authorByid( int id)
        {
            var entities = await context.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if(entities == null)
            {
                return NotFound();
            }

            var AuthorsDto = mapper.Map<AuthorDTO>(entities);
            return Ok(AuthorsDto);
        }


        [HttpPost]
        public async Task<ActionResult> AddAuthor([FromBody] AddAuthorDTO addAuthor)
        {
            var entities = mapper.Map<Author>(addAuthor);
            context.Add(entities);
            await context.SaveChangesAsync();
            var addAuthorDto = mapper.Map<AuthorDTO>(entities);

            return new CreatedAtRouteResult("getAuhtorId", new { id = addAuthorDto.Id }, addAuthorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] AddAuthorDTO addAuthor)
        {
            var entities = mapper.Map<Author>(addAuthor);

            entities.Id = id;
            context.Entry(entities).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return Ok();



        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor( int id)
        {
            var exists = await context.Authors.AnyAsync(x => x.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            context.Remove(new Author() { Id = id });
            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
