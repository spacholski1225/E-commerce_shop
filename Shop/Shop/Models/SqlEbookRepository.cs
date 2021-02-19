using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class SqlEbookRepository : IEbookRepository
    {
        private readonly ShopDbContext context;

        public SqlEbookRepository(ShopDbContext context)
        {
            this.context = context;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<Ebook> GetAllEbooks { get; }

        public Ebook Add(Ebook ebook)
        {
            context.Ebooks.Add(ebook);
            context.SaveChanges();
            return ebook;
        }

        public Ebook Delete(Ebook ebook)
        {
            throw new NotImplementedException();
        }

        public Ebook GetEbookById(int ebookId)
        {
            throw new NotImplementedException();
        }

        public Ebook Update(Ebook ebook)
        {
            throw new NotImplementedException();
        }
    }
}
