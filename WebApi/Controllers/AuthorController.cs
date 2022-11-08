using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperatons.Commands.CreateAuthor;
using WebApi.Application.AuthorOperatons.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperatons.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperatons.Queries.GetAuthor;
using WebApi.Application.AuthorOperatons.Queries.GetAuthorDetail;
using WebApi.DBOperations;

namespace WebApi.Controlers
{
    [ApiController]
    [Route("[controller]s")]

    public class AuthorController:ControllerBase
    {        
        private readonly BookStoreDbContext _dbcontext;

        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetAuthor()
        {
            GetAuthorQuery query=new GetAuthorQuery(_dbcontext,_mapper);
            var liste=query.Handle();

            return Ok(liste);
        }

        [HttpGet("Name, Surname")]
        public IActionResult GetAuthorDetail(string name, string surname)
        {
            GetAuthorDetailQuery query=new GetAuthorDetailQuery(_dbcontext,_mapper);
            query.Name=name;
            query.Surname=surname;
            GetAuthorDetailQueryValidator validator=new GetAuthorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var yazar=query.Handle();
            return Ok(yazar);

        }

        [HttpPost]

        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command=new CreateAuthorCommand(_dbcontext,_mapper);
            command.Model=newAuthor;
            
            CreateAuthorCommandValidator validator=new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();          
        }

        [HttpPut("id")]
        public IActionResult UpdateAuthor(int id ,[FromBody] UpdateAuthorModel newAuthor)
        {
            UpdateAuthorCommand command=new UpdateAuthorCommand(_dbcontext,_mapper);
            command.Id=id;
            command.Model=newAuthor;

            UpdateAuthorCommandValidator validator=new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();


        }

        [HttpDelete("id")]

        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command=new DeleteAuthorCommand(_dbcontext);
            command.Id=id;

            DeleteAuthorCommandValidator validator=new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}