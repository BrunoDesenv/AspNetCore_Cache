using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoMemoryCache.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DemoMemoryCache.Controllers
{
    public class HomeController : Controller
    {
        public IMemoryCache _memoryCache { get; set; }
        public HomeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            var chaveDoCache = "chave_do_cache";
            string dataAtual;

            if (!_memoryCache.TryGetValue(chaveDoCache, out dataAtual))
            {
                var opcoesDoCache = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(30)
                };
                dataAtual = DateTime.Now.ToString();
                _memoryCache.Set(chaveDoCache, dataAtual, opcoesDoCache);
            }

            ViewBag.Data = dataAtual;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
