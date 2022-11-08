
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.Command.CreateBook;
using WebApi.Application.BookOperations.Command.DeleteBook;
using WebApi.Application.BookOperations.Command.UpdateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.DBOperations;


namespace WebApi.Controlers
{
    [ApiController]
    [Route("[controller]s")]

    public class BookController:ControllerBase
    {        
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query=new GetBooksQuery(_context,_mapper);
            var result=query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            GetBookDetailQuery query=new GetBookDetailQuery(_context,_mapper);
            
            query.BookId=id;
            GetBookDetailQueryValidator validator=new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result =query.Handle();
                     
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command=new CreateBookCommand(_context,_mapper);
            //try
            //{                
            command.Model=newBook;
            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle(); 
            //ValidationResult result=validator.Validate(command);
            //if (result.IsValid)
            //    foreach (var item in result.Errors)            
            //        Console.WriteLine("Özellik"+item.PropertyName+"-error message"+item.ErrorMessage);            
            //else
            //{
            //    command.Handle(); 
            //}                         
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}            
            return Ok();
        }
         [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command=new UpdateBookCommand(_context);
            //try
           // {
                command.BookId=id;
                command.Model=updatedBook;
                UpdateBookCommandValidator validator=new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
           // }
           //catch (Exception ex)
           //{
           //    return BadRequest(ex.Message);
           //}           
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command=new DeleteBookCommand(_context);
            //try
            //{
                command.BookId=id;
                DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            //}
           //catch (Exception ex)
           //{                
           //    return BadRequest(ex.Message);
           //}
            return Ok();
        }
    }
}