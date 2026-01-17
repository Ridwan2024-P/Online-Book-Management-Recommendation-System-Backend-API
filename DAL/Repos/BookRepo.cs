using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class BookRepo
    {
        PMSContext db;
        public BookRepo(PMSContext db)
        {
            this.db = db;
        }

        public bool Create(Book book)
        {
            db.Books.Add(book);
            return db.SaveChanges() > 0;
        }

        public List<Book> Get()
        {
            return db.Books.ToList();
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }
        public bool update(Book book)
        {
            var ex = Get(book.Id);
            db.Entry(ex).CurrentValues.SetValues(book);
            return db.SaveChanges() > 0;

        }
        public bool delete(int id)
        {
            var ex = Get(id);
            db.Books.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public List<Book> GetLowStock(int low)
        {
            return db.Books.Where(b => b.Stock <= low).ToList();
        }

        public List<Book> AdvancedSearch(
    string ?title = null,
    string? author = null,
    string genre = null,
    decimal? minPrice = null,
    decimal? maxPrice = null)
        {
            var query = db.Books.AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(b => b.Title.Contains(title));

            if (!string.IsNullOrEmpty(author))
                query = query.Where(b => b.Author.Contains(author));

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(b => b.Genre == genre);

            if (minPrice.HasValue)
                query = query.Where(b => b.Price >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(b => b.Price <= maxPrice);

            return query.ToList();
        }


    }
}
