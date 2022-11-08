using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Quries.GetGenres
{
    public class GetGenreQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper  _mapper;
        public GetGenreQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres=_context.Genres.Where(queries=>queries.IsActive==true).OrderBy(x=>x.Id);//==true silinecek
            List<GenresViewModel> returnobj=_mapper.Map<List<GenresViewModel>>(genres);
            return returnobj;
        }



    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}