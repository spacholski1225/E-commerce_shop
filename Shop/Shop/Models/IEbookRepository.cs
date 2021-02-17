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
    }
}
