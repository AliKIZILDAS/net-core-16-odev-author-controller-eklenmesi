using AutoMapper;
using WebApi.Application.AuthorOperatons.Commands.CreateAuthor;
using WebApi.Application.AuthorOperatons.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperatons.Queries.GetAuthor;
using WebApi.Application.AuthorOperatons.Queries.GetAuthorDetail;
using WebApi.Application.BookOperations.Command.CreateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Quries.GetGenreDetail;
using WebApi.Application.GenreOperations.Quries.GetGenres;
using WebApi.Entities;


namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<CreateAuthorModel,Author>();
            CreateMap<Author,GetAuthorModel>();
            CreateMap<Author,GetAuthorDetailModel>();
            CreateMap<UpdateAuthorModel,Author>();
        }
        
    }
}