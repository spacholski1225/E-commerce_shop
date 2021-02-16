using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpikClone.Models
{
    interface IProduct { 
    
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public string Type { get; set; }
    }
}
