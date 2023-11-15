using AutoMapper;
using FakeRestApiB.DTOs;
using FakeRestApiB.Entities;

namespace FakeRestApiB.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<AddAuthorDTO, Author>();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<AddBookDTO, Book>();
            CreateMap<Picture, PictureDTO>().ReverseMap();
            CreateMap<AddPictureDTO, Picture>();
        }
    }
}
