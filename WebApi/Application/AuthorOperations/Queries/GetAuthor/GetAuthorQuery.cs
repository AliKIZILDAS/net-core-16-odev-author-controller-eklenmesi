using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperatons.Queries.GetAuthor
{
    public class GetAuthorQuery
    {
        private readonly BookStoreDbContext _dbcontext;

        private readonly IMapper _mapper;

        public GetAuthorQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<GetAuthorModel> Handle()
        {
            var authors=_dbcontext.Authors.OrderBy(x=>x.Id).ToList<Author>();
            List<GetAuthorModel> vm=_mapper.Map<List<GetAuthorModel>>(authors);
            return vm;

        } 

    }

    public class GetAuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDay { get; set; }
        
    }
}