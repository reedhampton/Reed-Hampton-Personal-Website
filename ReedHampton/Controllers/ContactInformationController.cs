using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReedHampton.Models;

namespace ReedHampton.Controllers
{
    [Authorize]
    public class ContactInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactInformation
        public ActionResult Index()
        {
            return View(db.ContactInformations.ToList());
        }

        // GET: ContactInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ContactName,PrimaryEmail,SecondaryEmail,GitHubLink,LinkedInLink,FacebookLink")] ContactInformation contactInformation)
        {
            if (ModelState.IsValid)
            {
                db.ContactInformations.Add(contactInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactInformation);
        }

        // GET: ContactInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInformation contactInformation = db.ContactInformations.Find(id);
            if (contactInformation == null)
            {
                return HttpNotFound();
            }
            return View(contactInformation);
        }

        // POST: ContactInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ContactName,PrimaryEmail,SecondaryEmail,GitHubLink,LinkedInLink,FacebookLink")] ContactInformation contactInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactInformation);
        }

        // GET: ContactInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInformation contactInformation = db.ContactInformations.Find(id);
            if (contactInformation == null)
            {
                return HttpNotFound();
            }
            return View(contactInformation);
        }

        // POST: ContactInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactInformation contactInformation = db.ContactInformations.Find(id);
            db.ContactInformations.Remove(contactInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
