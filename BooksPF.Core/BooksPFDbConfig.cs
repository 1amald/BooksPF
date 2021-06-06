using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksPF.Core
{
    public class BooksPFDbConfig
    {
        public string Database_Name { get; set; }
        public string Books_Collection_Name { get; set; }
        public string Users_Collection_Name { get; set; }
        public string Connection_String { get; set; }
    }
}
