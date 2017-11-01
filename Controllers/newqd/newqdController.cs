using System;
using Microsoft.AspNetCore.Mvc;
using newqd.Models;
using System.Collections.Generic;
using System.Linq;

namespace newqd.Controllers
{
    public class newqdController : Controller
    {
        private newqdContext _context;
        public newqdController(newqdContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // howgetlist of authors? 
            ViewBag.qs = _context.quotes.ToList();           
            ViewBag.peeps = _context.authors.ToList();
            ViewBag.cats = _context.category.ToList();
            return View();
        }

        [HttpPost]
        [Route("author/create")]
        public IActionResult AddAuthor(AuthorViewmodel incoming)
        {
            System.Console.WriteLine(incoming.name);
            TryValidateModel(incoming);
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("All good in da hood!");
                Author noob = new Author();
                noob.name = incoming.name;
                _context.authors.Add(noob);
                _context.SaveChanges();
            } else {
                System.Console.WriteLine("All isnot good in da hood!");;
            }
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        [Route("quote/create")]
        public IActionResult AddQuote(QuoteViewModel incoming)
        {
            TryValidateModel(incoming);
            if(ModelState.IsValid)
            {
                // have to make all the things!
                // quote
                Quote newquote = new Quote();
                // newquote.authorId = incoming.authorId;
                Author auth = _context.authors.SingleOrDefault(auther => auther.authorId == incoming.authorId);
                newquote.message = incoming.quote;
                newquote.author = auth;
                // meta
                Meta newmeta = new Meta();
                newmeta.notes = incoming.meta;
                _context.metas.Add(newmeta);
                _context.SaveChanges();
                // reassign to db instance of meat
                newmeta = _context.metas.Last();
                newquote.meta = newmeta;
                _context.SaveChanges();
                newquote.metaId = newmeta.metaId;
                // quotecats
                QuoteCat qcat = new QuoteCat();
                // grab cat and quote
                Category catsy = _context.category.SingleOrDefault(cattergory => cattergory.categoryId == incoming.categoryId);
                _context.quotes.Add(newquote);
                _context.SaveChanges();
                newquote = _context.quotes.Last();
                qcat.quoteId = newquote.quoteId;
                qcat.categoryId = catsy.categoryId;
                _context.quotecategory.Add(qcat);
                _context.SaveChanges();
                System.Console.WriteLine("Good");
            } else {
                System.Console.WriteLine("Baaaad");
            };
            return RedirectToAction("Index");
        }
    }

}