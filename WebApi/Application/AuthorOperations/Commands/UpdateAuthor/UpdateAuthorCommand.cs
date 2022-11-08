using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperatons.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int Id{get;set;}
        public UpdateAuthorModel Model{get;set;}
         
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;


        public UpdateAuthorCommand(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author=_dbcontext.Authors.SingleOrDefault(x=>x.Id==Id);
            if (author is null)
                throw new InvalidOperationException("id bulunamadı.");
            
            //_mapper.Map<Author>(Model);
            author.Name=Model.Name!= default? Model.Name:author.Name;
            author.Surname=Model.Surname!= default? Model.Surname:author.Surname;
            
            _dbcontext.SaveChanges();

            
            
        }
    }

    public class UpdateAuthorModel
    {
         public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        
    }


}