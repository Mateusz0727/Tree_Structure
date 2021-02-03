using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TreeController : Controller
    {
        // GET: TreeController
        public ActionResult Index()
        {
            Database database = new Database();
            return View(database.CreateList());
        }

        // GET: TreeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TreeController/Create
        public IActionResult Create()
        {
           
            return View();
        }
        

       

        // GET: TreeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TreeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TreeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TreeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
