using AutoMapper;
using FakeRestApiB.DTOs;
using FakeRestApiB.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FakeRestApiB.Controllers
{
    [ApiController]
    [Route("Api/Pictues")]
    [EnableCors("MyPolicy")]
    public class PictureController: ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public PictureController(ApplicationDbContext context,
          IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("ListPicture")]
        public async Task<ActionResult<List<PictureDTO>>> ListPicture()
        {
            var Picturelist = await context.Pictures.Include(x => x.Book).ToListAsync();
            var pictureDto = mapper.Map<List<PictureDTO>>(Picturelist);

            return Ok(pictureDto);

        }

        [HttpGet("{id}", Name = "getPicture")]
        public async Task<ActionResult<List<PictureDTO>>> GetPictureById(int id)
        {
            var picturesById = await context.Pictures.Include(x => x.Book).FirstOrDefaultAsync(x => x.Id == id);
            if (picturesById == null)
            {
                return NotFound();
            }

            var pictureDTO = mapper.Map<PictureDTO>(picturesById);

            return Ok(pictureDTO);
        }

        [HttpPost]
        public async Task<ActionResult<PictureDTO>> AddPicture([FromBody] AddPictureDTO addpicture)
        {
            var AddPicture = mapper.Map<Picture>(addpicture);
            context.Add(AddPicture);
            var AddpicDto = mapper.Map<PictureDTO>(AddPicture);
            await context.SaveChangesAsync();

            return new CreatedAtRouteResult("getPicture", new { id = AddpicDto.Id }, AddpicDto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePictures(int id, [FromBody] AddPictureDTO AddPicture)
        {
            var AddPictureU = mapper.Map<Picture>(AddPicture);

            AddPictureU.Id = id;

            context.Entry(AddPictureU).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePicture(int id)
        {
            var Pexists = await context.Pictures.AnyAsync(x => x.Id == id);

            if (!Pexists)
            {
                return NotFound();
            }

            context.Remove(new Picture() { Id = id });
            await context.SaveChangesAsync();

            return Ok();

        }

    }
}
