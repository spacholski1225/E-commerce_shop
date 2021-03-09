using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Ebook> GetAllEbooks => context.Ebooks.ToList();

        public Ebook Add(Ebook ebook)
        {
            context.Ebooks.Add(ebook);
            context.SaveChanges();
            return ebook;
        }

        public Ebook Delete(Ebook ebook)
        {
            context.Ebooks.Remove(ebook);
            context.SaveChanges();
            return ebook;
        }

        public Ebook GetEbookById(int ebookId)
        {
            return GetAllEbooks.FirstOrDefault(x => x.EbookId == ebookId);
        }

        public Ebook Update(Ebook ebook)
        {
            context.Ebooks.Update(ebook);
            context.SaveChanges();
            return ebook;
        }
    }
}
