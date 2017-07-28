using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReedHampton.Models;
using System.IO;

namespace ReedHampton.Controllers
{
    public class ProfessionalDocumentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProfessionalDocuments
        public ActionResult DocumentPortfolio()
        {
            return View(db.ProfessionalDocuments.ToList());
        }

        // GET: ProfessionalDocuments/Create
        public ActionResult Create()
        {
            var model = new ProfessionalDocumentsViewModel();
            return View(model);
        }

        // POST: ProfessionalDocuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfessionalDocumentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var DocumentToAdd = new ProfessionalDocuments();

                DocumentToAdd.Title = model.Title;
                DocumentToAdd.Description = model.Description;
                DocumentToAdd.Icon = model.Icon;

                if (model.FileUpload != null && model.FileUpload.ContentLength > 0)
                {
                    var uploadDir = "~/DocumentUploads/";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), model.FileUpload.FileName);
                    var documentURL = Path.Combine(uploadDir, model.FileUpload.FileName);

                    documentURL = documentURL.Replace(@"\", "/");
                    imagePath = imagePath.Replace(@"\", "/");

                    model.FileUpload.SaveAs(imagePath);
                    DocumentToAdd.FileURL =  documentURL;
                }


                db.ProfessionalDocuments.Add(DocumentToAdd);
                db.SaveChanges();
                return RedirectToAction("DocumentPortfolio");
            }

            return View(model);
        }

        // GET: ProfessionalDocuments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProfessionalDocuments professionalDocuments = db.ProfessionalDocuments.Find(id);

            if (professionalDocuments == null)
            {
                return HttpNotFound();
            }
            return View(professionalDocuments);
        }

        // POST: ProfessionalDocuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,FileURL")] ProfessionalDocuments professionalDocuments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professionalDocuments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DocumentPortfolio");
            }
            return View(professionalDocuments);
        }

        // GET: ProfessionalDocuments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalDocuments professionalDocuments = db.ProfessionalDocuments.Find(id);
            if (professionalDocuments == null)
            {
                return HttpNotFound();
            }
            return View(professionalDocuments);
        }

        // POST: ProfessionalDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfessionalDocuments professionalDocuments = db.ProfessionalDocuments.Find(id);
            db.ProfessionalDocuments.Remove(professionalDocuments);
            db.SaveChanges();
            return RedirectToAction("DocumentPortfolio");
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
