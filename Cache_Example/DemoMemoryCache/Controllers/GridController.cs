using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using DemoMemoryCache.Models;
using System.Collections.Generic;

namespace DemoMemoryCache.Controllers
{
    public class GridController : Controller
    {
        public IMemoryCache _memoryCache { get; set; }

        public GridController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        
        public ActionResult Index()
        {
            var user = new User();
            var chaveDoCache = "grid";
            var users = new List<User>();

            if (!_memoryCache.TryGetValue(chaveDoCache, out users))
            {
                var opcoesDoCache = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(30)
                };

                users = user.CreateRandomList();
                _memoryCache.Set(chaveDoCache, users, opcoesDoCache);
            }

            return View(users);
        }
    }
}