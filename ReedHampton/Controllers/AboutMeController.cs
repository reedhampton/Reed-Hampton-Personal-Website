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
    public class AboutMeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AboutMe
        public ActionResult Index()
        {
            return View(db.AboutMes.ToList());
        }

        // GET: AboutMe/Create
        public ActionResult Create()
        {
            var model = new AboutMeViewModel();

            return View(model);
        }

        // POST: AboutMe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AboutMeViewModel model)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (model.FlipBoardThumbnailUpload == null || model.FlipBoardThumbnailUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ThumbnailUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(model.FlipBoardThumbnailUpload.ContentType))
            {
                ModelState.AddModelError("ThumbnailUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (ModelState.IsValid)
            {
                var aboutMeToAdd = new AboutMe();

                aboutMeToAdd.FlipBoardTitle = model.FlipBoardTitle;
                aboutMeToAdd.FlipBoardSubTitle = model.FlipBoardSubTitle;
                aboutMeToAdd.Description = model.Description;

                if (model.FlipBoardThumbnailUpload != null && model.FlipBoardThumbnailUpload.ContentLength > 0)
                {
                    var uploadDir = "~/ImageUploads/FlipboardThumbnailUploads";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), model.FlipBoardThumbnailUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, model.FlipBoardThumbnailUpload.FileName);

                    imageUrl = imageUrl.Replace(@"\", "/");
                    imagePath = imagePath.Replace(@"\", "/");

                    model.FlipBoardThumbnailUpload.SaveAs(imagePath);
                    aboutMeToAdd.FlipboardThumnbailUrl = imageUrl;
                }

                db.AboutMes.Add(aboutMeToAdd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: AboutMe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutMe aboutMe = db.AboutMes.Find(id);
            if (aboutMe == null)
            {
                return HttpNotFound();
            }
            return View(aboutMe);
        }

        // POST: AboutMe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FlipBoardTitle,FlipBoardSubTitle,FlipboardThumnbailUrl,Description")] AboutMe aboutMe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutMe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutMe);
        }

        // GET: AboutMe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutMe aboutMe = db.AboutMes.Find(id);
            if (aboutMe == null)
            {
                return HttpNotFound();
            }
            return View(aboutMe);
        }

        // POST: AboutMe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutMe aboutMe = db.AboutMes.Find(id);
            db.AboutMes.Remove(aboutMe);
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
