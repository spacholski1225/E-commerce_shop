using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public interface IEbookRepository
    {
        IEnumerable<Ebook> GetAllEbooks { get; }
        Ebook GetEbookById(int ebookId);
        Ebook Add(Ebook ebook);
        Ebook Delete(Ebook ebook);
        Ebook Update(Ebook ebook);

    }
}
