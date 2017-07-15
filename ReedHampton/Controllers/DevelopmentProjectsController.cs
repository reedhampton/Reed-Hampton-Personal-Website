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
    [Authorize]
    public class DevelopmentProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DevelopmentProjects
        [AllowAnonymous]
        public ActionResult Portfolio()
        {
            return View(db.DevelopmentProjects.ToList());
        }

        // GET: DevelopmentProjects/Create
        public ActionResult Create()
        {
            var model = new DevelopmentProjectViewModel();
            return View(model);
        }

        // POST: DevelopmentProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DevelopmentProjectViewModel model)
        {
            var validImageTypes = new string[]
          {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
          };

            if (model.ProjectThumbnailUpload == null || model.ProjectThumbnailUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ThumbnailUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(model.ProjectThumbnailUpload.ContentType))
            {
                ModelState.AddModelError("ThumbnailUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (ModelState.IsValid)
            {
                var developmentProject = new DevelopmentProject();

                developmentProject.Category = model.Category;
                developmentProject.Date = model.Date;
                developmentProject.LongDescription = model.LongDescription;
                developmentProject.LongName = model.LongName;
                developmentProject.ShortDescription = model.ShortDescription;
                developmentProject.ShortName = model.ShortName;
                developmentProject.SkillsNeeded = model.SkillsNeeded;

                if (model.ProjectThumbnailUpload != null && model.ProjectThumbnailUpload.ContentLength > 0)
                {
                    var uploadDir = "~/ImageUploads/AlbumThumbnailUploads";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), model.ProjectThumbnailUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, model.ProjectThumbnailUpload.FileName);

                    imageUrl = imageUrl.Replace(@"\", "/");
                    imagePath = imagePath.Replace(@"\", "/");

                    model.ProjectThumbnailUpload.SaveAs(imagePath);
                    developmentProject.ProjectImageUrl = imageUrl;
                }

                db.DevelopmentProjects.Add(developmentProject);
                db.SaveChanges();
                return RedirectToAction("Portfolio");
            }

            return View(model);
        }

        // GET: DevelopmentProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevelopmentProject developmentProject = db.DevelopmentProjects.Find(id);
            if (developmentProject == null)
            {
                return HttpNotFound();
            }
            return View(developmentProject);
        }

        // POST: DevelopmentProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ProjectImageUrl,ShortName,ShortDescription,LongName,Category,Date,LongDescription,SkillsNeeded")] DevelopmentProject developmentProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(developmentProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Portfolio");
            }
            return View(developmentProject);
        }

        // GET: DevelopmentProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevelopmentProject developmentProject = db.DevelopmentProjects.Find(id);
            if (developmentProject == null)
            {
                return HttpNotFound();
            }
            return View(developmentProject);
        }

        // POST: DevelopmentProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DevelopmentProject developmentProject = db.DevelopmentProjects.Find(id);
            db.DevelopmentProjects.Remove(developmentProject);
            db.SaveChanges();
            return RedirectToAction("Portfolio");
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
