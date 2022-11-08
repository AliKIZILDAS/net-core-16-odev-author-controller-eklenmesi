using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperatons.Commands.CreateAuthor

{
    public class CreateAuthorCommand
    {
         public CreateAuthorModel Model{get;set;}
         private readonly BookStoreDbContext _dbcontext;
         private readonly IMapper _mapper;
        public CreateAuthorCommand(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author=_dbcontext.Authors.SingleOrDefault(x=>x.Name==Model.Name&&x.Surname==Model.Surname);
            if (author is not null)
                throw new InvalidOperationException("Girdiğiniz "+Model.Name+" "+Model.Surname+" sistemde mevcuttur.");
            
            author=_mapper.Map<Author>(Model);
            _dbcontext.Authors.Add(author);
            _dbcontext.SaveChanges();                       
        }
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
    }
    
}