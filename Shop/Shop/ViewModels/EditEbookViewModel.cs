using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class EditEbookViewModel : CreateEbookViewModel
    {
        public int  Id { get; set; }
        public string ExistingPath { get; set; }
    }
}
