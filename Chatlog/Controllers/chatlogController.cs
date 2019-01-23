using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chatlog.Models;
using System.Data.Entity;

namespace Chatlog.Controllers
{
    public class chatlogController : Controller
    {
        asptrialsEntities _db = new asptrialsEntities();
        // GET: chatlog
        public ActionResult Index()
        {
            return View(_db.chatlogs.ToList());
        }
        public ActionResult Details(int id=0)
        {
            chatlog chat = _db.chatlogs.Find(id);
            return View(chat);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create (chatlog _chat)
        {
            if (ModelState.IsValid)
            {
                _db.chatlogs.Add(_chat);
                _db.SaveChanges();
                return RedirectToAction("Index");
             }
            return View(_chat);
        }
        public ActionResult Edit(int id=0)
        {
            chatlog _chat = _db.chatlogs.Find(id);
            if (_chat == null)
            { return HttpNotFound(); }
            else
            {
                return View(_chat);
            }
        }
        [HttpPost]
        public ActionResult Edit(chatlog _chat)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(_chat).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_chat);
        }
        public ActionResult Delete(int id = 0)
        {
            chatlog _chat = _db.chatlogs.Find(id);
            if (_chat == null)
            { return HttpNotFound(); }
            else
            {
                return View(_chat);
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            chatlog _chat = _db.chatlogs.Find(id);
            _db.chatlogs.Remove(_chat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}