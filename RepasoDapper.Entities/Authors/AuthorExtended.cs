using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Entities.Authors
{
    public class AuthorExtended : Author
    {
        public int NumberOfBooks { get; set; }
    }
}
