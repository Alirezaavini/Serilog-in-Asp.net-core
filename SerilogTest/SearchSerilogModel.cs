using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogTest
{
    public class SearchSerilogModel
    {
        public IPagedList<Log> LinkPaging { get; set; }
        public string Name { get; set; } = "";
        public string Link { get; set; } = "";
    }
}
