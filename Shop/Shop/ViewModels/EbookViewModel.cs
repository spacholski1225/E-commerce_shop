using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class EbookViewModel  : IEbookRepository
    {
        private readonly ShopDbContext context;

        public EbookViewModel(ShopDbContext context)
        {
            this.context = context;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<Ebook> GetAllEbooks { get; }
        //todo tu jest syf rozbic ten view model na osobna klase typu sqlEbookRepository i tam niech dziedzicy po IebookRepository
        //zaimplementowac pozostale metody
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
