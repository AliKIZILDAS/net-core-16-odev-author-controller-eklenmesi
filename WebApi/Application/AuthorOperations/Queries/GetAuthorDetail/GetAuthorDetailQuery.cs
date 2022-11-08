using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperatons.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDbContext _dbcontext;

        public string Name{get;set;}
        public string Surname{get;set;}

        private readonly IMapper _mapper;

        public GetAuthorDetailQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public GetAuthorDetailModel Handle()
        {
            var author=_dbcontext.Authors.FirstOrDefault(x=>x.Name==Name&&x.Surname==Surname);
            if (author is null)
                throw new InvalidOperationException("Girdiğiniz yazar bulunamadı.");

            GetAuthorDetailModel yazar=_mapper.Map<GetAuthorDetailModel>(author);
            
            return yazar;

        }
    }

    public class GetAuthorDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDay { get; set; }
        
    }



}
