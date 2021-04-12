using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SerilogTest.Controllers
{
    public class SerilogController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppContext _ctx;


        public SerilogController(ILogger<HomeController> logger, AppContext context)
        {
            _logger = logger;
            _ctx = context;
        }

        public IActionResult Index(int page = 1, int pageSize = 10, string name = "")
        {
            IQueryable<Log> query = _ctx.Log.OrderByDescending(p => p.Id);
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Message.Contains(name));
            var logs = new PagedList<Log>(query, page, pageSize);
            var model = new SearchSerilogModel()
            {
                LinkPaging = logs,
                Name = name
            };
            return View(model);
        }
    }
}
