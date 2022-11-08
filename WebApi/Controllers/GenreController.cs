
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleateGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Quries.GetGenreDetail;
using WebApi.Application.GenreOperations.Quries.GetGenres;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Controlers
{
    [ApiController]
    [Route("[controller]s")]

    public class GenreController:ControllerBase
    {        
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;
        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public ActionResult GetGenres()
        {
            GetGenreQuery query=new GetGenreQuery(_context,_mapper);            
            var obj=query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]

        public ActionResult GetGenreDetail(int id)
        {
            
            GetGenreDetailQuery query=new GetGenreDetailQuery(_context,_mapper);
            query.GenreId=id;
            GetGenreDetailQueryValidator validator=new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var obj=query.Handle();
            return Ok(obj);
        }

        [HttpPost]

        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command=new CreateGenreCommand(_context);
            command.Model=newGenre;

            CreateGenreCommandValidator validator=new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        [HttpPut]

        public IActionResult UpdateGenre(int Id, [FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand command=new UpdateGenreCommand(_context);
            command.GenreId=Id;
            command.Model=updateGenre;


            UpdateGenreCommandValidator validator=new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
            
        }

        [HttpDelete("id")]

        public IActionResult DeleteGenre(int Id)
        {
            DeleteGenreCommand command=new DeleteGenreCommand(_context);
            command.GenreId=Id;

            DeleteGenreCommandValidator validator=new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
