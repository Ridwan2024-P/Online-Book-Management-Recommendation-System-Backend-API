using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookService
    {
        BookRepo repo;
        public BookService(BookRepo repo)
        {
            this.repo = repo;

        }

        public List<BookDTO> Get()
        {
            var data = repo.Get();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<BookDTO>>(data);
            return ret;


        }
        public BookDTO Get(int id)
        {
            var data = repo.Get(id);
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<BookDTO>(data);
            return ret;



        }

        public bool Create(BookDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Book>(c);
            return repo.Create(data);
        }
        public bool Delete(int id)
        {
            repo.delete(id);
            return true;
        }
        public bool Update(BookDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Book>(c);
            return repo.update(data);
        }


        public List<BookDTO>GetLowStock(int low =5)
        {
            var b = repo.GetLowStock(low);
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<BookDTO>>(b);
            if (ret.Count > 0)
            {
                Console.WriteLine("⚠️ Low stock alert:");
                foreach (var book in ret)
                {
                    Console.WriteLine($"{book.Title} - Stock: {book.Stock}");
                }
            }

            return ret;

        }


        public List<BookDTO> AdvancedSearch(
    string? title = null,
    string? author = null,
    string? genre = null,
    decimal? minPrice = null,
    decimal? maxPrice = null)
        {
            var data = repo.AdvancedSearch(title, author, genre, minPrice, maxPrice);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<BookDTO>>(data);
        }
    }
}
