using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperatons.Commands.DeleteAuthor

{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _dbcontext;
        public int Id{get;set;}
        public DeleteAuthorCommand(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var author=_dbcontext.Authors.SingleOrDefault(x=>x.Id==Id);
            if (author is null)
                throw new InvalidOperationException("Girdiğiniz numaralı yazar bulunamadı.");
            
            _dbcontext.Authors.Remove(author);
            _dbcontext.SaveChanges();

        }
    }
}