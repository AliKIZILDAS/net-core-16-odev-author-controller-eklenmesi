using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;
//using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context=new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Authors.AddRange(
                    new Author{
                        Name="Yaşar",
                        Surname="Kemal",
                        BirthDay=new DateTime(1982,03,03)
                    },
                    new Author{
                        Name="Viktor",
                        Surname="Hugo",
                        BirthDay=new DateTime(1982,03,03)
                    },
                    new Author{
                        Name="Frans",
                        Surname="Kafka",
                        BirthDay=new DateTime(1982,03,03)
                    }
                );
                
                context.Genres.AddRange(
                    new Genre{
                        Name="Personel Growth"
                    },
                    new Genre{
                        Name="ScienceFiction"
                    },
                    new Genre{
                        Name="Romence"
                    }                    
                );

                context.Books.AddRange(

                    new Book{
                        //Id=1,
                        Title="lean Startup",
                        GenreId=1,//personel Grouth
                        PageCount=200,
                        PublishDate=new DateTime(2001,06,12)
                    },
                    new Book{
                        //Id=2,
                        Title="Herland",
                        GenreId=2,//Science Fiction
                        PageCount=250,
                        PublishDate=new DateTime(2010,05,23)
                    },
                    new Book{
                        //Id=3,
                        Title="Dune",
                        GenreId=2,///Science Fiction
                        PageCount=540,
                        PublishDate=new DateTime(2001,12,21)
                    }
                );

                context.SaveChanges();
            }
            
        }
        
    }
    
}